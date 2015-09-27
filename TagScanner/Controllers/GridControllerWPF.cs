using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows;
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
		public GridControllerWPF(Model model, ElementHost view) : base(model, view) { }

		#endregion

		#region View

		private new ElementHost View { get { return (ElementHost)base.View; } }

		private DataGrid Grid { get { return ((GridElement)View.Child).DataGrid; } }

		protected override void DisconnectView()
		{
			Grid.SelectionChanged -= Grid_SelectionChanged;
		}

		protected override void ReconnectView()
		{
			if (View.Child == null)
			{
				View.Child = new GridElement();
				Grid.Columns.Clear();
				foreach (var column in GetColumns())
					Grid.Columns.Add(column);
			}
			Grid.SelectionChanged += Grid_SelectionChanged;
		}

		protected override void RefreshDataSource()
		{
			if (View.InvokeRequired)
				View.Invoke(new System.Windows.Forms.MethodInvoker(RefreshDataSource));
			else
			{
				var tracks = new ListCollectionView(Model.Tracks);
				//tracks.SortDescriptions.Add(new SortDescription("JoinedPerformers", ListSortDirection.Ascending));
				//tracks.SortDescriptions.Add(new SortDescription("Year", ListSortDirection.Ascending));
				//tracks.SortDescriptions.Add(new SortDescription("Album", ListSortDirection.Ascending));
				Grid.ItemsSource = tracks;
				InitGroups();
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
			var propertyTypeName = propertyInfo.PropertyType.Name;
			var column = (DataGridBoundColumn)GetColumn(propertyTypeName);
			if (column != null)
			{
				var propertyName = propertyInfo.Name;
                var binding = new Binding(propertyName);
				binding.Mode = propertyInfo.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay;
				if (propertyTypeName == "Logical")
					binding.Converter = new LogicalConverter();
				column.Binding = binding;
				column.Header = propertyName;
			}
			return column;
		}

		protected override object GetCheckBoxColumn()
		{
			var column = new DataGridCheckBoxColumn();
			column.Width = 80;
			return column;
		}

		protected override object GetTextBoxColumn(StringAlignment alignment)
		{
			var column = new DataGridTextColumn();
			// TODO: set alignment in style
			column.Width = alignment == StringAlignment.Near ? 160 : 80;
			return column;
		}

		protected override void InitVisibleColumns()
		{
			foreach (var column in Grid.Columns)
				column.Visibility = Visibility.Collapsed;
			var displayIndex = 0;
			foreach (var columnName in VisibleColumnNames)
			{
				var column = Grid.Columns.Single(c => (string)c.Header == columnName);
				column.DisplayIndex = displayIndex++;
				column.Visibility = Visibility.Visible;
            }
		}

		#endregion

		#region Groups

		protected override void InitGroups()
		{
			var groupDescriptions = ((ListCollectionView)Grid.ItemsSource).GroupDescriptions;
			groupDescriptions.Clear();
			foreach (var group in Groups)
                groupDescriptions.Add(new PropertyGroupDescription(group));
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
