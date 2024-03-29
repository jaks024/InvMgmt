﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt.Information.ViewModels
{
    public class FormViewModel : ViewModelBase
    {
        private CategoryViewModel category;
        public FormViewModel()
        {
            category = new CategoryViewModel();
        }

        public string Id
        {
            get { return category.Id; }
            set
            {
                if (category.Id == value)
                    return;
                category.Id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return category.Name; }
            set
            {
                if (string.Equals(category.Name, value))
                    return;
                category.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return category.Description; }
            set
            {
                if (string.Equals(category.Description, value))
                    return;
                category.Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        
        public CategoryViewModel GetCategory
        {
            get { return category; }
        }

        public void Reset()
        {
            category = new CategoryViewModel();
            NotifyPropertyChanged("");
        }

        public bool IsAllFieldFull()
        {
            return !string.IsNullOrWhiteSpace(Id) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Description) ? true : false;
        }

        public bool IsOneFieldFilled()
        {
            return !string.IsNullOrWhiteSpace(Id) || !string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(Description) ? true : false;
        }

		public bool IsIdValid(CategoryManagerViewModel _man)
		{
			for (int i = 0; i < _man.CategoryCount; i++)
			{
				if (_man.Categories[i].Id.Equals(Id))
					return false;
			}
			return true;
		}

		public override string ToString()
        {
            return string.Format("Id: {0},  Name: {1},  Desc: {2}", Id, Name, Description);
        }
    }
}
