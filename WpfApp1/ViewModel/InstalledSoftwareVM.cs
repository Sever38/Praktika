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
	class InstalledSoftwareVM : BaseHelper
	{
		prktEntities db = new prktEntities();
		ObservableCollection<InstalledSoftware> isofts = null;

		public ObservableCollection<InstalledSoftware> ISOFTs
		{
			get { return isofts; }
			set
			{
				isofts = value;
				OnPropertyChanged(nameof(ISOFTs));
			}
		}

		public InstalledSoftwareVM()
		{
			db.InstalledSoftware.Load();
			isofts = new ObservableCollection<InstalledSoftware>(db.InstalledSoftware.Local.ToList());
			db.PC.Load();
			GetPc = new ObservableCollection<PC>(db.PC.Local.ToBindingList());
			db.Software.Load();
			GetS = new ObservableCollection<Software>(db.Software.Local.ToBindingList());

		}

		private InstalledSoftware SelectedItem;
		public InstalledSoftware Selecteditem { get { return SelectedItem; } set { SelectedItem = value; OnPropertyChanged(nameof(Selecteditem)); } }

		private RelayCommand DeleteInfo;
		public RelayCommand DeleteInfocommand
		{
			get
			{
				return DeleteInfo ?? (DeleteInfo = new RelayCommand(obj =>
				{
					if (Selecteditem != null)
					{
						var finditem = db.InstalledSoftware.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Deleted;
							db.InstalledSoftware.Remove(finditem);
							db.SaveChanges();
							db.InstalledSoftware.Load();
							ISOFTs = new ObservableCollection<InstalledSoftware>(db.InstalledSoftware.Local.ToBindingList());
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
						var finditem = db.InstalledSoftware.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Modified;
							finditem.Инвентарный_Номер_ПК = Selecteditem.Инвентарный_Номер_ПК;							
							finditem.Продукт = Selecteditem.Продукт;
							finditem.Дата_Установки = Selecteditem.Дата_Установки;							
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
					db.InstalledSoftware.Add(Selecteditem);
					db.SaveChanges();
				}

				));
			}
		}


		private ObservableCollection<PC> getpc;
		public ObservableCollection<PC> GetPc { get { return getpc; } set { getpc = value; OnPropertyChanged(nameof(GetPc)); } }

		private ObservableCollection<Software> gets;
		public ObservableCollection<Software> GetS { get { return gets; } set { gets = value; OnPropertyChanged(nameof(GetS)); } }
	}
}
