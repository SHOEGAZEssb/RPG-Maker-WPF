using Caliburn.Micro;
using RPG_Maker_WPF.Views;

namespace RPG_Maker_WPF.ViewModels
{
	/// <summary>
	/// ViewModel of the <see cref="MainView"/>
	/// </summary>
	class MainViewModel : PropertyChangedBase
	{
		#region Properties

		/// <summary>
		/// The ProjectViewModel.
		/// </summary>
		public ProjectViewModel ProjectVM
		{
			get { return _projectVM; }
			private set
			{
				_projectVM = value;
				NotifyOfPropertyChange(() => ProjectVM);
			}
		}
		private ProjectViewModel _projectVM;

		public DatabaseViewModel DatabaseVM
		{
			get { return _databaseVM; }
			private set
			{
				_databaseVM = value;
				NotifyOfPropertyChange(() => DatabaseVM);
			}
		}
		private DatabaseViewModel _databaseVM;

		#endregion

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainViewModel()
		{
			ProjectVM = new ProjectViewModel();
			DatabaseVM = new DatabaseViewModel();
		}

		public void ExitProgram()
		{
			ProjectVM.CloseProject();
			App.Current.Shutdown();
		}
	}
}