using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace RPG_Maker_WPF.Converters
{
  class CollectionItemToIndexConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var item = value as ListBoxItem;
      if (item != null)
      {
        var lb = Statics.FindAncestor<ListBox>(item);
        if (lb != null)
        {
          var index = lb.Items.IndexOf(item.Content);
          return index.ToString("000") + ": ";
        }
      }
      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
