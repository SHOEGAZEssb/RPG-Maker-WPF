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

		#endregion

		/// <summary>
		/// Constructor.
		/// </summary>
		public MainViewModel()
		{
			ProjectVM = new ProjectViewModel();
		}

		public void ExitProgram()
		{
			ProjectVM.CloseProject();
			App.Current.Shutdown();
		}
	}
}