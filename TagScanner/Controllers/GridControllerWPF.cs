using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms.Integration;
using TagScanner.Models;
using TagScanner.Views;

namespace TagScanner.Controllers
{
	public class GridControllerWPF : GridController
	{
		#region Lifetime Management
		public GridControllerWPF(Model model, ElementHost view) : base(model)
		{
			View = view;
		}

		#endregion

		#region Model

		protected override void RefreshDataSource()
		{
			if (View.InvokeRequired)
				View.Invoke(new System.Windows.Forms.MethodInvoker(RefreshDataSource));
			else
				Grid.ItemsSource = new ObservableCollection<ITrack>(Model.Tracks);
		}

		#endregion

		#region View

		private DataGrid Grid
		{
			get
			{
				return GridContainer.DataGrid;
			}
		}

		private GridContainer GridContainer
		{
			get
			{
				return (GridContainer)View.Child;
			}
		}

		private ElementHost _view;
		private ElementHost View
		{
			get
			{
				return _view;
			}
			set
			{
				if (View != null)
				{
					Grid.SelectionChanged -= Grid_SelectionChanged;
				}
				_view = value;
				if (View != null)
				{
					View.Child = new GridContainer();
					Grid.Columns.Clear();
					foreach (var column in GetColumns())
						Grid.Columns.Add(column);
					Grid.SelectionChanged += Grid_SelectionChanged;
				}
			}
		}

		#endregion

		#region Columns
		public IEnumerable<DataGridBoundColumn> GetColumns()
		{
			return PropertyInfos.Select(GetColumn).Where(c => c != null);
		}

		private DataGridBoundColumn GetColumn(PropertyInfo propertyInfo)
		{
			var column = GetColumn(propertyInfo.PropertyType.Name);
			if (column != null)
			{
				var binding = new Binding(propertyInfo.Name);
				binding.Mode = propertyInfo.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay;
				column.Binding = binding;
				column.Header = propertyInfo.Name;
				column.Width = 100;

				column.Visibility = System.Windows.Visibility.Visible;
			}
			return column;
		}

		private DataGridBoundColumn GetColumn(string propertyTypeName)
		{
			switch (propertyTypeName)
			{
				case "String":
				case "TagTypes":
					return GetTextBoxColumn(StringAlignment.Near);
				case "Int32":
				case "Int64":
				case "TimeSpan":
					return GetTextBoxColumn(StringAlignment.Far);
				case "Logical":
					return GetCheckBoxColumn();
				case "Picture[]":
				case "String[]":
					return null;
				default:
					return null;
			}
		}

		private DataGridBoundColumn GetCheckBoxColumn()
		{
			var column = new DataGridCheckBoxColumn();
			return null;
		}

		private DataGridBoundColumn GetTextBoxColumn(StringAlignment alignment)
		{
			var column = new DataGridTextColumn();
			// TODO: set alignment in style
			return column;
		}

		#endregion

		#region Selection

		public override void SelectAll()
		{
			Grid.SelectAll();
		}

		public override void InvertSelection()
		{
        }

		private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			OnSelectionChanged();
		}

		protected override Selection GetSelection()
		{
            return new Selection(Grid.SelectedItems.Cast<ITrack>());
		}

		#endregion
	}
}
