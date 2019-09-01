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
			"D_COMPANY TEXT, D_ADDRESS TEXT, D_PHONE TEXT, D_DATE TEXT)";
		public static void InitializeConnection(string _path, bool _firstTime)
		{
			if(_firstTime)
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
				Console.WriteLine("created table");
			}
		}
		public static void CreateItemTable(ItemViewModel _ivm)
		{
			CreateTable(itemTableTemplate, _ivm.Category);
			InsertItemToTable(_ivm);
			Console.WriteLine("created item table");
		}
		public static void InsertCategoryToTable(CategoryViewModel _cvm)
		{
			connection.Open();
			using (var command = new SQLiteCommand(CategoryInsertString(_cvm.ToString()), connection))
			{
				command.ExecuteNonQuery();
				connection.Close();
				Console.WriteLine("created item table");
			}
		}

		public static void InsertItemToTable(ItemViewModel _ivm)
		{
			connection.Open();
			using (var command = new SQLiteCommand(ItemInsertString(_ivm.Category, _ivm.ToString()), connection))
			{
				Console.WriteLine("item inserted " + ItemInsertString(_ivm.Category, _ivm.ToString()));

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
			"D_COMPANY, D_ADDRESS, D_PHONE, D_DATE) " +
			"VALUES ({1})", _table, _values);
		}

		public static CategoryViewModel ReadCategoryTable()
		{
			CategoryViewModel c = new CategoryViewModel();
			connection.Open();
			using (var command = new SQLiteCommand("SELECT * FROM " + categoryName, connection))
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					c = new CategoryViewModel(
						reader["ID"].ToString(), reader["NAME"].ToString(), reader["DESC"].ToString());
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
						reader["D_COMPANY"].ToString(), reader["D_ADDRESS"].ToString(), reader["D_PHONE"].ToString(), DateTime.Parse(reader["D_DATE"].ToString()))));
				}
			}
			return col;
		}
	}
}
