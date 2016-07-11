using RPG_Maker_WPF.Models;
using Caliburn.Micro;
using RPG_Maker_WPF.Views;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System;
using Polenter.Serialization;

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
      try
      {
        if (Properties.Settings.Default.LastOpenedProject != "" && File.Exists(Properties.Settings.Default.LastOpenedProject))
          LoadProject(Properties.Settings.Default.LastOpenedProject);
      }
      catch { }
    }

    /// <summary>
    /// Shows a <see cref="NewProjectView"/> to
    /// create a new <see cref="Project"/>.
    /// </summary>
    public void ShowNewProjectDialog()
    {
      NewProjectView npv = new NewProjectView();
      if (npv.ShowDialog().Value)
      {
        CloseProject();
        NewProjectViewModel vm = npv.DataContext as NewProjectViewModel;
        CurrentProject = new Project(vm.ProjectName, vm.FullPath);
        CreateFolderStructure();
        CreateProjectFile();
      }
    }

    /// <summary>
    /// Creates the folder structure for a newly
    /// created <see cref="Project"/>.
    /// </summary>
    private void CreateFolderStructure()
    {
      // create main project folder
      Directory.CreateDirectory(CurrentProject.Path);

      // todo: create all needed data folders (maps, sounds etc...)
      Directory.CreateDirectory(CurrentProject.Path + "\\Maps");
      Directory.CreateDirectory(CurrentProject.Path + "\\Data");
    }

    /// <summary>
    /// Creates the project file.
    /// </summary>
    private void CreateProjectFile()
    {
      SharpSerializer serializer = new SharpSerializer();
      string path = CurrentProject.Path + "\\" + CurrentProject.Name + Statics.PROJECTFILEEXTENSION;
      serializer.Serialize(CurrentProject, path);
    }

    /// <summary>
    /// Loads the project from the given <paramref name="path"/>.
    /// </summary>
    /// <param name="path">The project file to load.</param>
    private void LoadProject(string path)
    {
      SharpSerializer serializer = new SharpSerializer();
      CurrentProject = (Project)serializer.Deserialize(path);
      CurrentProject.Path = Path.GetDirectoryName(path);
      CurrentProject.Database.LoadData();
      Properties.Settings.Default.LastOpenedProject = path;
      Properties.Settings.Default.Save();
      NotifyOfPropertyChange(() => CanCloseProject);
    }

    /// <summary>
    /// Shows a dialog where the user can
    /// select a project file to load.
    /// </summary>
    public void LoadProject()
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Filter = "RPG Maker WPF Project Files (*" + Statics.PROJECTFILEEXTENSION + "|*" + Statics.PROJECTFILEEXTENSION;
      if (dlg.ShowDialog() == DialogResult.OK)
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

      NotifyOfPropertyChange(() => CanCloseProject);
    }
  }
}