using Caliburn.Micro;
using RPG_Maker_WPF.Models;
using RPG_Maker_WPF.Views.DatabaseViews;
using System.Collections.Generic;

namespace RPG_Maker_WPF.ViewModels
{
  class DatabaseViewModel : PropertyChangedBase
  {
    #region Properties

    /// <summary>
    /// Temp database used to revert changes.
    /// </summary>
    public Database TempDatabase
    {
      get { return _tempDatabase; }
      private set
      {
        _tempDatabase = value;
        NotifyOfPropertyChange(() => TempDatabase);
      }
    }
    private Database _tempDatabase;

    public ActorViewViewModel ActorVM
    {
      get { return _actorVM; }
      private set
      {
        _actorVM = value;
        NotifyOfPropertyChange(() => ActorVM);
      }
    }
    private ActorViewViewModel _actorVM;

    #region Read-Only Properties

    /// <summary>
    /// Reference to the current projects <see cref="Database"/>.
    /// </summary>
    public Database ProjectDatabase
    {
      get { return ProjectViewModel.CurrentProject?.Database; }
    }

    #endregion

    #endregion

    public DatabaseViewModel()
    {
      //SelectedActor = ProjectDatabase.Actors[0];
      TempDatabase = new Database();
      TempDatabase.LoadData();
      ActorVM = new ActorViewViewModel(this);
    }

    public void ShowDatabaseDialog()
    {
      DatabaseView dbv = new DatabaseView();
      dbv.DataContext = this;
      dbv.ShowDialog();
    }

    /// <summary>
    /// Saves the database data and closes the <see cref="DatabaseView"/>.
    /// </summary>
    /// <param name="view">The view to close.</param>
    public void SaveAndClose(DatabaseView view)
    {
      ProjectDatabase.CopyData(TempDatabase);
      view.Close();
    }

    /// <summary>
    /// Closes the <see cref="DatabaseView"/> without saving.
    /// </summary>
    /// <param name="view">The view to close.</param>
    public void Cancel(DatabaseView view)
    {
      TempDatabase.CopyData(ProjectDatabase);
      view.Close();
    }

    /// <summary>
    /// Saves the database data.
    /// </summary>
    public void Apply()
    {
      ProjectDatabase.CopyData(TempDatabase);
    }
  }
}