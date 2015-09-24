using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TagScanner.Models;

namespace TagScanner.Controllers
{
	public class GridControllerWF : GridController
	{
		#region Lifetime Management

		public GridControllerWF(Model model, DataGridView view) : base(model)
		{
			View = view;
		}

		#endregion

		#region Model

		protected override void RefreshDataSource()
		{
			if (View.InvokeRequired)
				View.Invoke(new MethodInvoker(RefreshDataSource));
			else
			{
				var tracks = Model.Tracks;
				View.DataSource = tracks.Any() ? tracks : null;
			}
		}

		#endregion

		#region View

		private DataGridView _view;
		private DataGridView View
		{
			get
			{
				return _view;
			}
			set
			{
				if (View != null)
				{
					View.CellFormatting -= View_CellFormatting;
					View.ColumnHeaderMouseClick -= View_ColumnHeaderMouseClick;
					View.SelectionChanged -= View_SelectionChanged;
				}
				_view = value;
				if (View != null)
				{
					View.Columns.Clear();
					View.Columns.AddRange(GetColumns().ToArray());
					View.CellFormatting += View_CellFormatting;
					View.ColumnHeaderMouseClick += View_ColumnHeaderMouseClick;
					View.SelectionChanged += View_SelectionChanged;
				}
			}
		}

		#endregion

		#region Columns

		public IEnumerable<DataGridViewColumn> GetColumns()
		{
			return PropertyInfos.Select(GetColumn).Where(c => c != null);
		}

		private int _displayIndex;

		private DataGridViewColumn GetColumn(PropertyInfo propertyInfo)
		{
			var column = GetColumn(propertyInfo.PropertyType.Name);
			if (column != null)
			{
				column.DataPropertyName = column.Name = column.HeaderText = column.ToolTipText = propertyInfo.Name;
				column.DisplayIndex = _displayIndex++;
				column.Width = 100;

				column.Visible = true;
			}
			return column;
		}

		private DataGridViewColumn GetColumn(string propertyTypeName)
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

		private DataGridViewColumn GetCheckBoxColumn()
		{
			return new DataGridViewCheckBoxColumn();
		}

		private DataGridViewColumn GetTextBoxColumn(StringAlignment alignment)
		{
			var column = new DataGridViewTextBoxColumn();
			column.DefaultCellStyle.Alignment = GetContentAlignment(alignment);
			return column;
		}

		private static DataGridViewContentAlignment GetContentAlignment(StringAlignment stringAlignment)
		{
			switch (stringAlignment)
			{
				case StringAlignment.Near:
					return DataGridViewContentAlignment.MiddleLeft;
				case StringAlignment.Center:
					return DataGridViewContentAlignment.MiddleCenter;
				case StringAlignment.Far:
					return DataGridViewContentAlignment.MiddleRight;
			}
			return DataGridViewContentAlignment.NotSet;
		}

		#endregion

		#region Formatting

		private void View_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			e.Value = FormatCell(e);
		}

		private string FormatCell(DataGridViewCellFormattingEventArgs e)
		{
			var column = View.Columns[e.ColumnIndex];
			return e.Value.Format(column.DataPropertyName, column.ValueType, false);
		}

		#endregion

		#region Selection

		public override void SelectAll()
		{
			SetSelection(p => p.Visible);
		}

		public override void InvertSelection()
		{
			SetSelection(p => p.Visible && !p.Selected);
		}

		protected override Selection GetSelection()
		{
			return new Selection(
				View
				.SelectedRows
					.Cast<DataGridViewRow>()
					.Select(p => Model.Tracks[p.Index])
					.ToList());
		}

		private void View_SelectionChanged(object sender, EventArgs e)
		{
			OnSelectionChanged();
		}

		private void SetSelection(Func<DataGridViewRow, bool> select)
		{
			BeginUpdateSelection();
		    foreach (DataGridViewRow row in View.Rows)
			    row.Selected = select(row);
			EndUpdateSelection();
		}

		#endregion

		#region Sorting

		private void View_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Model.ToggleOrder(View.Columns[e.ColumnIndex].DataPropertyName);
		}

		#endregion
	}
}
