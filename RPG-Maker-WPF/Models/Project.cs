using System;

namespace RPG_Maker_WPF.Models
{
	/// <summary>
	/// Represents the current loaded project.
	/// </summary>
	class Project
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

		public Database Database
		{
			get { return _database; }
			private set { _database = value; }
		}
		private Database _database;

		#endregion Properties

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The name of the project to create.</param>
		public Project(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Constructor for a new project.
		/// </summary>
		public Project()
		{
			Database = new Database();
		}
	}
}