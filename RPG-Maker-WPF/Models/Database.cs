using RPG_Maker_WPF.ViewModels;
using Polenter.Serialization;
using System.Collections.ObjectModel;

namespace RPG_Maker_WPF.Models
{
  /// <summary>
  /// Represents a database with all the info about a game.
  /// </summary>
  public class Database
  {
    #region Properties

    public ObservableCollection<Actor> Actors
    {
      get { return _actors; }
      private set { _actors = value; }
    }
    private ObservableCollection<Actor> _actors;

    #endregion properties

    /// <summary>
    /// Constructor.
    /// </summary>
    public Database()
    {
      Actors = new ObservableCollection<Actor>();
    }

    /// <summary>
    /// Loads database data from xmls.
    /// </summary>
    public void LoadData()
    {
      SharpSerializer serializer = new SharpSerializer();
      string path = ProjectViewModel.CurrentProject.Path + "\\Data\\ActorData.rpgwpfd";
      Actors = (ObservableCollection<Actor>)serializer.Deserialize(path);
    }

    /// <summary>
    /// Saves the current database data to xmls.
    /// </summary>
    public void SaveData()
    {
      SharpSerializer serializer = new SharpSerializer();
      string path = ProjectViewModel.CurrentProject.Path + "\\Data\\ActorData.rpgwpfd";
      serializer.Serialize(Actors, path);
    }

    /// <summary>
    /// Copies the data from the given <paramref name="tempDatabase"/>
    /// to this database.
    /// </summary>
    /// <param name="tempDatabase"></param>
    public void CopyData(Database tempDatabase)
    {
      Actors = tempDatabase.Actors;
      // todo: copy other data
    }
  }
}