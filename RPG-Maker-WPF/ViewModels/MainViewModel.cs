using Caliburn.Micro;
using RPG_Maker_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Maker_WPF.ViewModels
{
	class MainViewModel : PropertyChangedBase
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
	}
}