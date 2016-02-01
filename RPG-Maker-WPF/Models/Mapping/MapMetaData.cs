using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Maker_WPF.Models.Mapping
{
	/// <summary>
	/// Represents certain meta informations about a <see cref="Map"/>.
	/// </summary>
	class MapMetaData
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

		#endregion
	}
}
