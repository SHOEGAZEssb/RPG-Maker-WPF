using RPG_Maker_WPF.Models;
using Caliburn.Micro;
using RPG_Maker_WPF.Views;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;

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
		public static Project CurrentProject
		{
			get { return _currentProject; }
			private set
			{
				_currentProject = value;
			}
		}
		private static Project _currentProject;

		#region Read-Only Properties

		/// <summary>
		/// Gets wether the user can currently close a project.
		/// </summary>
		public bool CanCloseProject
		{
			get { return CurrentProject != null; }
		}

		#endregion

		#endregion Properties

		/// <summary>
		/// Constructor.
		/// Loads the last opened project.
		/// </summary>
		public ProjectViewModel()
		{
			if (Properties.Settings.Default.LastOpenedProject != "" && File.Exists(Properties.Settings.Default.LastOpenedProject))
				LoadProject(Properties.Settings.Default.LastOpenedProject);
		}

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

		/// <summary>
		/// Loads the project from the given <paramref name="path"/>.
		/// </summary>
		/// <param name="path">The project file to load.</param>
		private void LoadProject(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Project));
			FileStream fs = new FileStream(path, FileMode.Open);
			XmlReader reader = XmlReader.Create(fs);

			CurrentProject = (Project)serializer.Deserialize(reader);
			CurrentProject.Path = Path.GetDirectoryName(path);
		}

		/// <summary>
		/// Shows a dialog where the user can
		/// select a project file to load.
		/// </summary>
		public void LoadProject()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "RPG Maker WPF Project Files (*" + Statics.PROJECTFILEEXTENSION + "|*" + Statics.PROJECTFILEEXTENSION;
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				CloseProject();
				LoadProject(dlg.FileName);
			}
		}

		/// <summary>
		/// Closes the currently opened project.
		/// </summary>
		public void CloseProject()
		{
			if (CurrentProject != null)
			{
				// todo: check if dirty and save
				CurrentProject = null;
			}
		}
	}
}