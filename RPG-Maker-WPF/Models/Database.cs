using RPG_Maker_WPF.ViewModels;
using System.Collections.Generic;
using System.Xml.Serialization;
using Polenter.Serialization;

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

		/// <summary>
		/// Constructor.
		/// </summary>
		public Database()
		{
			Actors = new List<Actor>();
		}

		/// <summary>
		/// Loads database data from xmls.
		/// </summary>
		public void LoadData()
		{
			SharpSerializer serializer = new SharpSerializer();
			string path = ProjectViewModel.CurrentProject.Path + "\\Data\\ActorData.rpgwpfd";
			Actors = (List<Actor>)serializer.Deserialize(path);
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
	}
}