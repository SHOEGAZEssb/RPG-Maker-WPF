using Caliburn.Micro;
using RPG_Maker_WPF.ViewModels;

namespace RPG_Maker_WPF
{
	/// <summary>
	/// Bootstrapper used to connect View and ViewModel on startup.
	/// </summary>
	internal class AppBootstrapper : BootstrapperBase
	{
		/// <summary>
		/// Ctor.
		/// </summary>
		public AppBootstrapper()
		{
			Initialize();
		}

		/// <summary>
		/// Displays the root View.
		/// </summary>
		/// <param name="sender">Ignored.</param>
		/// <param name="e">Ignored.</param>
		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
		{
			DisplayRootViewFor<MainViewModel>();
		}
	}
}