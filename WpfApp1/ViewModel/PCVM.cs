using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace WpfApp1.ViewModel
{
	class PCVM : BaseHelper
	{
		prktEntities db = new prktEntities();
		ObservableCollection<PC> pCs = null;
		
		public ObservableCollection<PC> PCs
		{
			get { return pCs; }
			set
			{
				pCs = value;
				OnPropertyChanged(nameof(PCs));
			}
		}
		public PCVM()
		{
			db.PC.Load();
			pCs = new ObservableCollection<PC>(db.PC.Local.ToBindingList());
			db.ТИП_УСТРОЙСТВА.Load();
			GetUst = new ObservableCollection<ТИП_УСТРОЙСТВА>(db.ТИП_УСТРОЙСТВА.Local.ToBindingList());

		}
		private PC SelectedItem;
		public PC Selecteditem { get { return SelectedItem; } set { SelectedItem = value; OnPropertyChanged(nameof(Selecteditem)); } }

		private RelayCommand DeleteInfo;
		public RelayCommand DeleteInfocommand
		{
			get
			{
				return DeleteInfo ?? (DeleteInfo = new RelayCommand(obj =>
				{
					if (Selecteditem != null)
					{
						var finditem = db.PC.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Deleted;
							db.PC.Remove(finditem);
							db.SaveChanges();
							db.PC.Load();
							PCs = new ObservableCollection<PC>(db.PC.Local.ToBindingList());
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
						var finditem = db.PC.Find(Selecteditem.id);
						if (finditem != null)
						{
							db.Entry(finditem).State = EntityState.Modified;
							finditem.Название = Selecteditem.Название;
							finditem.Тип_Устройства = Selecteditem.Тип_Устройства;
							finditem.ТИП_УСТРОЙСТВА1 = Selecteditem.ТИП_УСТРОЙСТВА1;
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
					db.PC.Add(Selecteditem);
					db.SaveChanges();
				}

				));
			}
		}
		private ObservableCollection<ТИП_УСТРОЙСТВА> getust;
		public ObservableCollection<ТИП_УСТРОЙСТВА> GetUst { get { return getust; } set { getust = value; OnPropertyChanged(nameof(GetUst)); } }



	}
}
