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
    /// Currently selected <see cref="Actor"/> in the
    /// ListBox of the <see cref="ActorView"/>
    /// </summary>
    public Actor SelectedActor
    {
      get { return _selectedActor; }
      set
      {
        _selectedActor = value;
        NotifyOfPropertyChange(() => SelectedActor);
      }
    }
    private Actor _selectedActor;

    public string SelectedActorIndex
    {
      get { return ProjectDatabase.Actors.IndexOf(SelectedActor).ToString("000") + ": "; }
    }

    #region Read-Only Properties

    /// <summary>
    /// Reference to the current projects <see cref="Database"/>.
    /// </summary>
    public Database ProjectDatabase
    {
      get { return ProjectViewModel.CurrentProject?.Database; }
    }

    /// <summary>
    /// Gets wether an <see cref="Actor"/> can be removed.
    /// </summary>
    public bool CanRemoveActor
    {
      get { return SelectedActor != null && ProjectDatabase.Actors.Count > 1; }
    }

    #endregion

    #endregion

    public DatabaseViewModel()
    {
      //SelectedActor = ProjectDatabase.Actors[0];
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
      ProjectDatabase.SaveData();
      view.Close();
    }

    /// <summary>
    /// Closes the <see cref="DatabaseView"/> without saving.
    /// </summary>
    /// <param name="view">The view to close.</param>
    public void Close(DatabaseView view)
    {
      view.Close();
    }

    /// <summary>
    /// Saves the database data.
    /// </summary>
    public void Apply()
    {
      ProjectDatabase.SaveData();
    }

    #region Actor

    /// <summary>
    /// Adds an <see cref="Actor"/> to the database.
    /// </summary>
    public void AddActor()
    {
      ProjectDatabase.Actors.Add(new Actor());
      UpdateActorBindings();
    }

    /// <summary>
    /// Removes the <see cref="SelectedActor"/> from the database.
    /// </summary>
    public void RemoveActor()
    {
      ProjectDatabase.Actors.Remove(SelectedActor);
      UpdateActorBindings();
    }

    /// <summary>
    /// Updates all <see cref="Actor"/> bindings.
    /// </summary>
    private void UpdateActorBindings()
    {
      NotifyOfPropertyChange(() => SelectedActor);
      NotifyOfPropertyChange(() => SelectedActorIndex);
      NotifyOfPropertyChange(() => CanRemoveActor);
    }

    #endregion Actor
  }
}