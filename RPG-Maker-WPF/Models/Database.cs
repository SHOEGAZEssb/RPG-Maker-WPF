using RPG_Maker_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace RPG_Maker_WPF.Models
{
	/// <summary>
	/// Represents a database with all the info about a game.
	/// </summary>
	public class Database
	{
		#region Properties

		[XmlArrayItem("ListOfActors")]
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

		public void LoadData()
		{
			Type[] knownTypes = new Type[] { typeof(Actor) };
			XmlSerializer serializer = new XmlSerializer(typeof(List<Actor>), knownTypes);
			FileStream fs = new FileStream(ProjectViewModel.CurrentProject.Path + "\\Data\\ActorData.rpgwpfd", FileMode.Open);
			XmlReader reader = XmlReader.Create(fs);

			Actors = (List<Actor>)serializer.Deserialize(fs);
		}

		public void SaveData()
		{
			Type[] knownTypes = new Type[] { typeof(Actor) };
			XmlSerializer serializer = new XmlSerializer(typeof(List<Actor>), knownTypes);
			string path = ProjectViewModel.CurrentProject.Path + "\\Data\\ActorData.rpgwpfd";
			FileStream file = File.Create(path);
			serializer.Serialize(file, Actors);
			file.Close();
		}
	}
}