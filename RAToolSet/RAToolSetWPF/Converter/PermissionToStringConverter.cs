using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RAToolSetWPF
{
  /// <summary>
  /// Converter that converts an integer to a permission string.
  /// </summary>
  class PermissionToStringConverter : IValueConverter
  {
    /// <summary>
    /// Converts the given permission id to a string.
    /// </summary>
    /// <param name="value">Permission id.</param>
    /// <returns>Permission string.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      int permission = (int)value;

      switch(permission)
      {
        case -1:
          return "Banned";
        case 0:
          return "Unregistered";
        case 1:
          return "Registered";
        case 2:
          return "Super User";
        case 3:
          return "Developer";
        case 4:
          return "Admin";
        case 5:
          return "Super Admin";
        default:
          return "Unknown";
      }
    }

    /// <summary>
    /// Converts the given string back to a permission id.
    /// </summary>
    /// <param name="value">Permission string.</param>
    /// <returns>Permission id.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string permission = (string)value;

      switch (permission)
      {
        case "Banned":
          return -1;
        case "Unregistered":
          return 0;
        case "Registered":
          return 1;
        case "Super User":
          return 2;
        case "Developer":
          return 3;
        case "Admin":
          return 4;
        case "Super Admin":
          return 5;
        default:
          return "Unknown";
      }
    }
  }
}