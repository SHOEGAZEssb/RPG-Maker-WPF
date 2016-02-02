using System;
using System.Xml.Serialization;

namespace RPG_Maker_WPF.Models
{
	/// <summary>
	/// Represents the current loaded project.
	/// </summary>
	public class Project
	{
		#region Properties

		/// <summary>
		/// The name of this project.
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
		/// Reference to this projects <see cref="Database"/>.
		/// </summary>
		[XmlIgnore]
		public Database Database
		{
			get { return _database; }
			private set { _database = value; }
		}
		private Database _database;

		/// <summary>
		/// Path used for file creation.
		/// </summary>
		/// <remarks>
		/// Only use relative paths for file creation.
		/// _path will only be set once on creation or load
		/// of the project to determine the relative paths.
		/// </remarks>
		[XmlIgnore]
		public string Path
		{
			get { return _path; }
			set
			{
				if (value.Length == 0)
					throw new Exception("Path can not be empty.");
				else
					_path = value;
			}
		}
		private string _path;

		#endregion Properties

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The name of the project to create.</param>
		/// <param name="path">Path where the project will be created.</param>
		public Project(string name, string path)
		{
			Name = name;
			Database = new Database();
			_path = path;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public Project()
		{
			Database = new Database();
		}
	}
}