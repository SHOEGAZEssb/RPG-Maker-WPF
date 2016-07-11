using System;

namespace RPG_Maker_WPF.Models.Mapping
{
  /// <summary>
  /// Represents certain meta informations about a <see cref="Map"/>.
  /// </summary>
  public class MapMetaData
  {
    #region Properties

    /// <summary>
    /// The name of this map.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set
      {
        if (value.Length == 0)
          throw new Exception("Name can not be empty.");
        else
          _name = value;

      }
    }
    private string _name;

    /// <summary>
    /// The string that should be displayed
    /// upon entering the map.
    /// </summary>
    public string DisplayName
    {
      get { return _displayName; }
      private set { _displayName = value; }
    }
    private string _displayName;

    /// <summary>
    /// The width of the map.
    /// </summary>
    public int MapWidth
    {
      get { return _mapWidth; }
      set
      {
        if (value < Statics.MINMAPWIDTH)
          throw new Exception(String.Format("Map width must be bigger than {0}.", Statics.MINMAPWIDTH));
        else
          _mapWidth = value;
      }
    }
    private int _mapWidth;

    /// <summary>
    /// The height of the map.
    /// </summary>
    public int MapHeight
    {
      get { return _mapHeight; }
      set
      {
        if (value < Statics.MINMAPHEIGHT)
          throw new Exception(String.Format("Map width must be bigger than {0}.", Statics.MINMAPHEIGHT));
        else
          _mapHeight = value;
      }
    }
    private int _mapHeight;

    #endregion
  }
}