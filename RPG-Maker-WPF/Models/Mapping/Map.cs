using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Maker_WPF.Models.Mapping
{
	/// <summary>
	/// Represents a single map in a game.
	/// </summary>
	class Map
	{
		#region Properties

		/// <summary>
		/// The tile data of this map.
		/// </summary>
		public MapTile[,] MapData
		{
			get { return _mapData; }
			private set { _mapData = value; }
		}
		private MapTile[,] _mapData;

		/// <summary>
		/// The <see cref="MapMetaData"/> of this map.
		/// </summary>
		public MapMetaData MetaData
		{
			get { return _metaData; }
			private set { _metaData = value; }
		}
		private MapMetaData _metaData;

		#endregion Properties

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="metaData"><see cref="MapMetaData"/> of this map.</param>
		public Map(MapMetaData metaData)
		{
			MetaData = metaData;
			MapData = new MapTile[MetaData.MapWidth, MetaData.MapHeight];
		}
	}
}
