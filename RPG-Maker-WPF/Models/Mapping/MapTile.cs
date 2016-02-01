using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Maker_WPF.Models.Mapping
{
	class MapTile
	{
		#region Properties

		public LowerTile LowerTile
		{
			get { return _lowerTile; }
			set { _lowerTile = value; }
		}
		private LowerTile _lowerTile;

		public UpperTile UpperTile
		{
			get { return _upperTile; }
			set { _upperTile = value; }
		}
		private UpperTile _upperTile;

		public Event Event
		{
			get { return _event; }
			set { _event = value; }
		}
		private Event _event;

		#endregion Properties
	}
}