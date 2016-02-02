using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Maker_WPF.Models;
using Caliburn.Micro;
using RPG_Maker_WPF.Views;

namespace RPG_Maker_WPF.ViewModels
{
	/// <summary>
	/// ViewModel for all <see cref="Project"/> stuff.
	/// </summary>
	class ProjectViewModel : PropertyChangedBase
	{
		#region Properties

		/// <summary>
		/// The currently loaded <see cref="Project"/>.
		/// </summary>
		public Project CurrentProject
		{
			get { return _currentProject; }
			private set
			{
				_currentProject = value;
				NotifyOfPropertyChange(() => CurrentProject);
			}
		}
		private Project _currentProject;

		#endregion Properties

		public void ShowNewProjectDialog()
		{
			NewProjectView npv = new NewProjectView();
			if (npv.ShowDialog() == true)
			{
				// todo: check if current loaded project needs saving and close it.
				NewProjectViewModel vm = npv.DataContext as NewProjectViewModel;
				CurrentProject = new Project(vm.ProjectName, vm.FullPath);
			}
		}
	}
}
