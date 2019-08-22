using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvMgmt
{
    public class FormViewModel : ViewModelBase
    {
        private CategoryViewModel category;
        public FormViewModel()
        {
            category = new CategoryViewModel();
        }

        public int SetId
        {
            get { return category.Id; }
            set
            {
                if (category.Id == value)
                    return;
                category.Id = value;
                NotifyPropertyChanged("SetId");
                Console.WriteLine(category.Id);
            }
        }

        public string SetName
        {
            get { return category.Name; }
            set
            {
                if (string.Equals(category.Name, value))
                    return;
                category.Name = value;
                NotifyPropertyChanged("SetName");
                Console.WriteLine(category.Name);
            }
        }

        public string SetDescription
        {
            get { return category.Description; }
            set
            {
                if (string.Equals(category.Description, value))
                    return;
                category.Description = value;
                NotifyPropertyChanged("SetDescription");
                Console.WriteLine(category.Description);
            }
        }
    }
}
