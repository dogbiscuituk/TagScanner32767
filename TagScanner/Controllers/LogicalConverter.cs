﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace TagScanner.Controllers
{
	public class LogicalConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (value.ToString())
			{
				case "Yes":
					return true;
				case "No":
					return false;
			};
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}