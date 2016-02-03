using Caliburn.Micro;
using RPG_Maker_WPF.Models;
using RPG_Maker_WPF.Views.DatabaseViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RPG_Maker_WPF.ViewModels
{
	class DatabaseViewModel : PropertyChangedBase
	{
		#region Properties

		/// <summary>
		/// Currently selected <see cref="Actor"/> in the
		/// ListBox of the <see cref="ActorView"/>
		/// </summary>
		public Actor SelectedActor
		{
			get { return _selectedActor; }
			set
			{
				_selectedActor = value;
				NotifyOfPropertyChange(() => SelectedActor);
			}
		}
		private Actor _selectedActor;

		public string ActorName
		{
			get { return SelectedActor.Name; }
			set
			{
				SelectedActor.Name = value;
				NotifyOfPropertyChange(() => SelectedActor);
			}
		}

		public string ActorSecondName
		{
			get { return SelectedActor.SecondName; }
			set
			{
				SelectedActor.SecondName = value;
				NotifyOfPropertyChange(() => SelectedActor);
			}
		}

		public string ActorDescription
		{
			get { return SelectedActor.Description; }
			set
			{
				SelectedActor.Description = value;
				NotifyOfPropertyChange(() => SelectedActor);
			}
		}

		#region Read-Only Properties

		/// <summary>
		/// Reference to the current projects <see cref="Database"/>.
		/// </summary>
		public Database ProjectDatabase
		{
			get { return ProjectViewModel.CurrentProject.Database; }
		}

		public void ShowDatabaseDialog()
		{
			DatabaseView dbv = new DatabaseView();
			dbv.DataContext = this;
			dbv.ShowDialog();
		}

		#endregion

		#endregion

		public DatabaseViewModel()
		{
			ProjectDatabase.Actors.Add(new Actor() { Name = "Test", SecondName = "Testi", InitialLevel = 1, MaxLevel = 44, Description = "Bla" });
			ProjectDatabase.SaveData();
		}
	}
}