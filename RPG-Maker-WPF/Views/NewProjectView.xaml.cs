using RPG_Maker_WPF.ViewModels;
using System.Windows;

namespace RPG_Maker_WPF.Views
{
	/// <summary>
	/// Interaction logic for the <see cref="NewProjectView"/>.
	/// </summary>
	public partial class NewProjectView : Window
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public NewProjectView()
		{
			InitializeComponent();
			DataContext = new NewProjectViewModel();
		}
	}
}