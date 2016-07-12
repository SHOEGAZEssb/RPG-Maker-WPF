using Caliburn.Micro;
using RPG_Maker_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Maker_WPF.ViewModels
{
  class ActorViewViewModel : PropertyChangedBase
  {
    #region Properties

    public Database Database
    {
      get { return _parentVM.TempDatabase; }
    }

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
      get { return Database.Actors.IndexOf(SelectedActor).ToString("000") + ": "; }
    }

    /// <summary>
    /// Gets whether an <see cref="Actor"/> can be removed.
    /// </summary>
    public bool CanRemoveActor
    {
      get { return SelectedActor != null && Database.Actors.Count > 1; }
    }

    #endregion Properties

    #region Private Member

    private DatabaseViewModel _parentVM;

    #endregion

    public ActorViewViewModel(DatabaseViewModel parentVM)
    {
      _parentVM = parentVM;
    }

    /// <summary>
    /// Adds an <see cref="Actor"/> to the database.
    /// </summary>
    public void AddActor()
    {
      Database.Actors.Add(new Actor());
      UpdateActorBindings();
    }

    /// <summary>
    /// Removes the <see cref="SelectedActor"/> from the database.
    /// </summary>
    public void RemoveActor()
    {
      Database.Actors.Remove(SelectedActor);
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
  }
}