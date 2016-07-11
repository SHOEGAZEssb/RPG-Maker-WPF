namespace RPG_Maker_WPF.Models.Mapping
{
  public class MapTile
  {
    #region Properties

    /// <summary>
    /// The <see cref="LowerTile"/> of this MapTile.
    /// </summary>
    public LowerTile LowerTile
    {
      get { return _lowerTile; }
      set { _lowerTile = value; }
    }
    private LowerTile _lowerTile;

    /// <summary>
    /// The <see cref="UpperTile"/> of this MapTile.
    /// </summary>
    public UpperTile UpperTile
    {
      get { return _upperTile; }
      set { _upperTile = value; }
    }
    private UpperTile _upperTile;

    /// <summary>
    /// The <see cref="Event"/> of this MapTile.
    /// </summary>
    public Event Event
    {
      get { return _event; }
      set { _event = value; }
    }
    private Event _event;

    #endregion Properties
  }
}