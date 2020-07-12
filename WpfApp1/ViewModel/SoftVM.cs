using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
	class SoftVM : BaseHelper
	{
		prktEntities db = new prktEntities();
		ObservableCollection<Software> softs = null;

		public ObservableCollection<Software> SOFTs
		{
			get { return softs; }
			set
			{
				softs = value;
				OnPropertyChanged(nameof(SOFTs));
			}
		}

		public SoftVM()
		{
			db.Software.Load();
			softs = new ObservableCollection<Software>(db.Software.Local.ToList());			
			db.ТИП_ПО.Load();
			GetPo = new ObservableCollection<ТИП_ПО>(db.ТИП_ПО.Local.ToBindingList());
			db.ТИП_РАСПРОСТРАНЕНИЯ.Load();
			GetTy = new ObservableCollection<ТИП_РАСПРОСТРАНЕНИЯ>(db.ТИП_РАСПРОСТРАНЕНИЯ.Local.ToBindingList());
		}

		private Software SelectedItem;
		public Software Selecteditem { get { return SelectedItem; } set { SelectedItem = value; OnPropertyChanged(nameof(Selecteditem)); } }

		private RelayCommand DeleteInfo;
		public RelayCommand DeleteInfocommand
		{
			get
			{
				return DeleteInfo ?? (DeleteInfo = new RelayCommand(obj =>
				{
					if (Selecteditem != null)
					{
						var finditem = db.Software.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Deleted;
							db.Software.Remove(finditem);
							db.SaveChanges();
							db.Software.Load();
							SOFTs = new ObservableCollection<Software>(db.Software.Local.ToBindingList());
						}

					}
				}
				));
			}
		}
		private RelayCommand UpdateInfo;
		public RelayCommand UpdateInfocommand
		{
			get
			{
				return UpdateInfo ?? (UpdateInfo = new RelayCommand(obj =>
				{
					if (Selecteditem != null)
					{
						var finditem = db.Software.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Modified;
							finditem.Наименование_Продукта = Selecteditem.Наименование_Продукта;
							finditem.Тип_ПО = Selecteditem.Тип_ПО;
							finditem.ТИП_ПО1 = Selecteditem.ТИП_ПО1;
							finditem.Тип_распространения = Selecteditem.Тип_распространения;
							finditem.ТИП_РАСПРОСТРАНЕНИЯ1 = Selecteditem.ТИП_РАСПРОСТРАНЕНИЯ1;
							finditem.Количество_Лицензий = Selecteditem.Количество_Лицензий;
							finditem.Остаток_Лицензий = Selecteditem.Остаток_Лицензий;
							db.SaveChanges();
						}
					}
				}
				));
			}
		}
		private RelayCommand CreateInfo;
		public RelayCommand CreateInfocommand
		{
			get
			{
				return CreateInfo ?? (CreateInfo = new RelayCommand(obj =>
				{
					db.Software.Add(Selecteditem);
					db.SaveChanges();
				}

				));
			}
		}
		

		private ObservableCollection<ТИП_ПО> getpo;
		public ObservableCollection<ТИП_ПО> GetPo { get { return getpo; } set { getpo = value; OnPropertyChanged(nameof(GetPo)); } }

		private ObservableCollection<ТИП_РАСПРОСТРАНЕНИЯ> getty;
		public ObservableCollection<ТИП_РАСПРОСТРАНЕНИЯ> GetTy { get { return getty; } set { getty = value; OnPropertyChanged(nameof(GetTy)); } }


	}
}
