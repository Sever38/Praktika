using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
	class SoftwareVM:BaseHelper
	{
		prktEntities db = new prktEntities();
		ObservableCollection<Software> softwares = null;
		public ObservableCollection<Software> Softwares
		{
			get { return softwares; }
			set
			{
				Softwares = value;
				OnPropertyChanged("Выбранный софт");
			}
		}
		public SoftwareVM()
		{
			db.Software.Load();
			softwares = new ObservableCollection<Software>(db.Software.Local.ToBindingList());
		}
	}
}
