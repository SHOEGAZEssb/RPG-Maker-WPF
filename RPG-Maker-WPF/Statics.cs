using System.Windows;
using System.Windows.Media;

namespace RPG_Maker_WPF
{
	/// <summary>
	/// Contains different static objects.
	/// </summary>
	public static class Statics
	{
		/// <summary>
		/// The minimum map width.
		/// </summary>
		public const int MINMAPWIDTH = 15;

		/// <summary>
		/// The minimum map height.
		/// </summary>
		public const int MINMAPHEIGHT = 20;

		/// <summary>
		/// The file extension of project files.
		/// </summary>
		public const string PROJECTFILEEXTENSION = ".rpgwpf";

		/// <summary>
		/// Finds the ancestor with the given type of the given DependencyObject.
		/// </summary>
		/// <typeparam name="T">Type of the ancestor to find.</typeparam>
		/// <param name="from">Object to get ancestor of.</param>
		/// <returns></returns>
		public static T FindAncestor<T>(DependencyObject from) where T : class
		{
			if (from == null)
				return null;

			var candidate = from as T;
			return candidate ?? FindAncestor<T>(VisualTreeHelper.GetParent(from));
		}
	}
}