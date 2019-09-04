using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using InvMgmt.Information.Objects;
using InvMgmt.Information.ViewModels;
using System.Collections.ObjectModel;

namespace InvMgmt
{
	public class SaveDataHandler
	{
		private static SQLiteConnection connection;

		public static readonly string categoryName = "CATEGORY";
		private const string categoryTableTemplate = "CREATE TABLE IF NOT EXISTS {0} (ID TEXT, NAME TEXT, DESC TEXT)";
		private const string itemTableTemplate = "CREATE TABLE IF NOT EXISTS {0} (ID TEXT, NAME TEXT, DESC TEXT, CAT TEXT, " +
			"Q_TAVALIABLE INT, Q_TODAY INT, Q_WEEK INT, Q_MONTH INT, Q_ANNUAL INT, Q_TOTAL INT, " +
			"P_CURRENT DOUBLE, P_REGULAR DOUBLE, P_SALE DOUBLE, P_ONSALE INT, " +
			"D_COMPANY TEXT, D_ADDRESS TEXT, D_PHONE TEXT, D_EMAIL TEXT, D_DATE TEXT)";
		public static void InitializeConnection(string _path, bool _firstTime)
		{
			if (_firstTime)
				SQLiteConnection.CreateFile("data.sqlite");
			connection = new SQLiteConnection("Data Source=" + _path + ";Version=3");
			CreateTable(categoryTableTemplate, categoryName);
		}

		private static void CreateTable(string _template, string _name)
		{
			connection.Open();
			using (var command = new SQLiteCommand(string.Format(_template, _name), connection))
			{
				Console.WriteLine(command.CommandText);
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		//inserts parameter item into table as well
		public static void CreateItemTable(string _name)
		{
			CreateTable(itemTableTemplate, _name);
		}
		public static void InsertCategoryToTable(CategoryViewModel _cvm)
		{
			connection.Open();
			using (var command = new SQLiteCommand(CategoryInsertString(_cvm.ToString()), connection))
			{
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public static void InsertItemToTable(ItemViewModel _ivm)
		{
			connection.Open();
			using (var command = new SQLiteCommand(ItemInsertString(_ivm.Category, _ivm.ToString()), connection))
			{
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		private static string CategoryInsertString(string _values)
		{
			return string.Format("INSERT INTO CATEGORY (ID, NAME, DESC) VALUES ({0})", _values);
		}
		private static string ItemInsertString(string _table, string _values)
		{
			return string.Format("INSERT INTO {0} (ID, NAME, DESC, CAT, " +
			"Q_TAVALIABLE, Q_TODAY, Q_WEEK, Q_MONTH, Q_ANNUAL, Q_TOTAL, " +
			"P_CURRENT, P_REGULAR, P_SALE, P_ONSALE, " +
			"D_COMPANY, D_ADDRESS, D_PHONE, D_EMAIL, D_DATE) " +
			"VALUES ({1})", _table, _values);
		}

		public static ObservableCollection<CategoryViewModel> ReadCategoryTable()
		{
			ObservableCollection<CategoryViewModel> c = new ObservableCollection<CategoryViewModel>();
			connection.Open();
			using (var command = new SQLiteCommand("SELECT * FROM " + categoryName, connection))
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					c.Add(new CategoryViewModel(
						reader["ID"].ToString(), reader["NAME"].ToString(), reader["DESC"].ToString()));
				}
				connection.Close();
			}
			return c;
		}

		public static ObservableCollection<ItemViewModel> ReadItemTable(string _catName)
		{
			ObservableCollection<ItemViewModel> col = new ObservableCollection<ItemViewModel>();
			connection.Open();
			using (var command = new SQLiteCommand("SELECT * FROM " + _catName, connection))
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					col.Add(new ItemViewModel(
					reader["ID"].ToString(), reader["NAME"].ToString(), reader["DESC"].ToString(), reader["CAT"].ToString(),
					new QuantityViewModel(
						(int)reader["Q_TAVALIABLE"], (int)reader["Q_TODAY"], (int)reader["Q_WEEK"], (int)reader["Q_MONTH"], (int)reader["Q_ANNUAL"], (int)reader["Q_TOTAL"]),
					new PriceViewModel(
						(double)reader["P_CURRENT"], (double)reader["P_REGULAR"], (double)reader["P_SALE"], (int)reader["P_ONSALE"] == 1 ? true : false),
					new ItemDetailViewModel(
						reader["D_COMPANY"].ToString(), reader["D_ADDRESS"].ToString(), reader["D_PHONE"].ToString(), reader["D_EMAIL"].ToString(), DateTime.Parse(reader["D_DATE"].ToString()))));
				}
				connection.Close();
			}
			return col;
		}

		public static void UpdateCategoryInTable(CategoryViewModel _obj)
		{
			connection.Open();
			using (var command = new SQLiteCommand(connection))
			{
				command.CommandText = "UPDATE " + categoryName + " SET NAME = :name, DESC = :desc WHERE ID=:id";
				command.Parameters.Add("name", System.Data.DbType.String).Value = _obj.Name;
				command.Parameters.Add("desc", System.Data.DbType.String).Value = _obj.Description;
				command.Parameters.Add("id", System.Data.DbType.String).Value = _obj.Id;
				command.ExecuteNonQuery();
			}
			connection.Close();
		}
		public static void UpdateItemInTable(ItemViewModel _obj)
		{
			connection.Open();
			using (var command = new SQLiteCommand(connection))
			{
				command.CommandText = "UPDATE " + _obj.Category + " SET " +
					"NAME = :NAME, DESC = :DESC, CAT = :CAT, " +
					"Q_TAVALIABLE = :Q_TAVALIABLE, Q_TODAY = :Q_TODAY, Q_WEEK = :Q_WEEK, Q_MONTH = :Q_MONTH, Q_ANNUAL = :Q_ANNUAL, Q_TOTAL = :Q_TOTAL, " +
					"P_CURRENT = :P_CURRENT, P_REGULAR = :P_REGULAR, P_SALE = :P_SALE, P_ONSALE = :P_ONSALE, " +
					"D_COMPANY = :D_COMPANY, D_ADDRESS = :D_ADDRESS, D_PHONE = :D_PHONE, D_EMAIL = :D_EMAIL, D_DATE = :D_DATE " +
					"WHERE ID=:ID";
				command.Parameters.Add("NAME", System.Data.DbType.String).Value = _obj.Name;
				command.Parameters.Add("DESC", System.Data.DbType.String).Value = _obj.Description;
				command.Parameters.Add("CAT", System.Data.DbType.String).Value = _obj.Category;

				command.Parameters.Add("Q_TAVALIABLE", System.Data.DbType.Int32).Value = _obj.Quantity.Total;
				command.Parameters.Add("Q_TODAY", System.Data.DbType.Int32).Value = _obj.Quantity.Today;
				command.Parameters.Add("Q_WEEK", System.Data.DbType.Int32).Value = _obj.Quantity.Weekly;
				command.Parameters.Add("Q_MONTH", System.Data.DbType.Int32).Value = _obj.Quantity.Monthly;
				command.Parameters.Add("Q_ANNUAL", System.Data.DbType.Int32).Value = _obj.Quantity.Annually;
				command.Parameters.Add("Q_TOTAL", System.Data.DbType.Int32).Value = _obj.Quantity.UsedTotal;

				command.Parameters.Add("P_CURRENT", System.Data.DbType.Double).Value = _obj.Price.CurrentPrice;
				command.Parameters.Add("P_REGULAR", System.Data.DbType.Double).Value = _obj.Price.RegularPrice;
				command.Parameters.Add("P_SALE", System.Data.DbType.Double).Value = _obj.Price.SalePrice;
				command.Parameters.Add("P_ONSALE", System.Data.DbType.Int32).Value = _obj.Price.IsOnSale;

				command.Parameters.Add("D_COMPANY", System.Data.DbType.String).Value = _obj.Detail.Company;
				command.Parameters.Add("D_ADDRESS", System.Data.DbType.String).Value = _obj.Detail.Address;
				command.Parameters.Add("D_PHONE", System.Data.DbType.String).Value = _obj.Detail.Phone;
				command.Parameters.Add("D_EMAIL", System.Data.DbType.String).Value = _obj.Detail.Email;
				command.Parameters.Add("D_DATE", System.Data.DbType.String).Value = _obj.Detail.DateTimeSQLite(_obj.Detail.Date);
				command.Parameters.Add("ID", System.Data.DbType.String).Value = _obj.Id;
				command.ExecuteNonQuery();
			}
			connection.Close();
		}

		public static void RemoveItemInTable(ItemViewModel _obj)
		{
			connection.Open();
			using (var command = new SQLiteCommand(connection))
			{
				command.CommandText = "DELETE FROM " + _obj.Category + " WHERE ID=:ID";
				command.Parameters.Add("ID", System.Data.DbType.String).Value = _obj.Id;
				command.ExecuteNonQuery();
			}
			connection.Close();
		}

		public static void SwapItemTable(ItemViewModel _obj, string _to)
		{
			RemoveItemInTable(_obj);
			_obj.Category = _to;
			InsertItemToTable(_obj);
		}
	}
}
