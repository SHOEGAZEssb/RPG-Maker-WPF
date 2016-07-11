using Caliburn.Micro;
using RPG_Maker_WPF.Views;
using System;
using System.Windows.Forms;

namespace RPG_Maker_WPF.ViewModels
{
  /// <summary>
  /// ViewModel for the <see cref="NewProjectView"/>.
  /// </summary>
  class NewProjectViewModel : PropertyChangedBase
  {
    #region Member

    /// <summary>
    /// Indicates if the <see cref="ProjectName"/> has been changed
    /// manually. If so, changing the <see cref="DirectoryName"/> will have
    /// no effect on the <see cref="ProjectName"/>.
    /// </summary>
    private bool _manuallyChangedProjectName;

    /// <summary>
    /// Indicates if the <see cref="DirectoryName"/> has been changed
    /// manually. If so, changing the <see cref="ProjectName"/> will have
    /// no effect on the <see cref="DirectoryName"/>.
    /// </summary>
    private bool _manuallyChangedDirectoryName;

    #endregion Member

    #region Properties

    /// <summary>
    /// The name of the new project.
    /// </summary>
    public string ProjectName
    {
      get { return _projectName; }
      set
      {
        _projectName = value;
        NotifyOfPropertyChange(() => ProjectName);
        NotifyOfPropertyChange(() => CanCreate);
      }
    }
    private string _projectName;

    /// <summary>
    /// The name of the directory the project will
    /// be saved in.
    /// </summary>
    public string DirectoryName
    {
      get { return _directoryName; }
      set
      {
        _directoryName = value;
        NotifyOfPropertyChange(() => DirectoryName);
        NotifyOfPropertyChange(() => CanCreate);
      }
    }
    private string _directoryName;

    /// <summary>
    /// The path of the directory the project directory
    /// will be saved in.
    /// </summary>
    public string SaveDirectory
    {
      get { return _saveDirectory; }
      set
      {
        _saveDirectory = value;
        NotifyOfPropertyChange(() => SaveDirectory);
      }
    }
    private string _saveDirectory;

    #region Read-Only Properties

    /// <summary>
    /// Checks if the given information is valid
    /// and a project can be created.
    /// </summary>
    public bool CanCreate
    {
      get { return ProjectName != "" && DirectoryName != ""; }
    }

    /// <summary>
    /// Returns the full path to the project.
    /// </summary>
    public string FullPath
    {
      get { return SaveDirectory + "\\" + DirectoryName; }
    }

    #endregion Read-Only Properties

    #endregion Properties

    /// <summary>
    /// Constructor.
    /// </summary>
    public NewProjectViewModel()
    {
      ProjectName = "SampleProject";
      DirectoryName = "SampleProject";
      SaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    /// <summary>
    /// Opens a <see cref="FolderBrowserDialog"/> where the user
    /// can choose where to save his new project.
    /// </summary>
    public void SelectSaveDirectory()
    {
      FolderBrowserDialog dlg = new FolderBrowserDialog();
      dlg.SelectedPath = SaveDirectory;
      if (dlg.ShowDialog() == DialogResult.OK)
        SaveDirectory = dlg.SelectedPath;
    }

    /// <summary>
    /// Creates the project with the given data.
    /// </summary>
    /// <param name="view">Reference to the calling <see cref="NewProjectView"/>,
    /// used to set its DialogResult to true.
    /// </param>
    public void CreateNewProject(NewProjectView view)
    {
      view.DialogResult = true;
      view.Close();
    }

    /// <summary>
    /// Cancels the dialog.
    /// </summary>
    /// <param name="view">Reference to the calling <see cref="NewProjectView"/>,
    /// used to set its DialogResult to false.
    /// </param>
    public void Cancel(NewProjectView view)
    {
      view.DialogResult = false;
      view.Close();
    }
  }
}