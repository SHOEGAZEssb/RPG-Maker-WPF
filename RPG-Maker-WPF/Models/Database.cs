using System.Collections.Generic;

namespace RPG_Maker_WPF.Models
{
	/// <summary>
	/// Represents a database with all the info about a game.
	/// </summary>
	public class Database
	{
		#region Properties

		public List<Actor> Actors
		{
			get { return _actors; }
			private set { _actors = value; }
		}
		private List<Actor> _actors;

		#endregion properties

		public Database()
		{
			Actors = new List<Actor>();
		}
	}
}