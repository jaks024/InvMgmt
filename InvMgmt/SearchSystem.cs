using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
namespace InvMgmt
{
	public class SearchSystem
	{

		public ObservableCollection<ItemViewModel> GetSearchedItem(string query, ObservableCollection<ItemViewModel> _list)
		{
			//Console.WriteLine("query " + query);
			string[] term = query.Split('/');
			ObservableCollection<ItemViewModel> items = _list;
			for(int i = 0; i < term.Length; i++)
			{
				//Console.WriteLine("term " + term[i]);
				if (string.IsNullOrWhiteSpace(term[i]))
					continue;
				items = Find(term[i], items);
				if (items.Count == 0)
					break;
			}
			//Console.WriteLine("found items count " + items.Count);
			//foreach (var x in items)
			//	Console.WriteLine("items " + x.SearchQuery());
			return items;
		}

		private ObservableCollection<ItemViewModel> Find(string _term, ObservableCollection<ItemViewModel> _list)
		{
			Console.WriteLine("list count " + _list.Count);
			ObservableCollection<ItemViewModel> found = new ObservableCollection<ItemViewModel>();
			for (int x = 0; x < _list.Count; x++)
			{
				Console.WriteLine("searching for query " + _list[x].SearchQuery());
				if (_list[x].SearchQuery().Contains(_term))
					found.Add(_list[x]);
				else
					found.Remove(_list[x]);
			}
			return found;
		}
	}
}
