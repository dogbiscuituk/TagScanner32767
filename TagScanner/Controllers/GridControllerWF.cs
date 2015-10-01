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

		public GridControllerWF(Model model, DataGridView view) : base(model, view) { }

		#endregion

		#region View

		private new DataGridView View { get { return (DataGridView)base.View; } }

		protected override void DisconnectView()
		{
			View.CellFormatting -= View_CellFormatting;
			View.ColumnHeaderMouseClick -= View_ColumnHeaderMouseClick;
			View.SelectionChanged -= View_SelectionChanged;
		}

		protected override void ReconnectView()
		{
			View.Columns.Clear();
			View.Columns.AddRange(GetColumns().ToArray());
			View.CellFormatting += View_CellFormatting;
			View.ColumnHeaderMouseClick += View_ColumnHeaderMouseClick;
			View.SelectionChanged += View_SelectionChanged;
		}

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

		#region Columns

		public IEnumerable<DataGridViewColumn> GetColumns()
		{
			return SimpleCondition.SortablePropertyInfos.Select(GetColumn);
		}

		private int _displayIndex;

		private DataGridViewColumn GetColumn(PropertyInfo propertyInfo)
		{
			var column = (DataGridViewColumn)GetColumn(propertyInfo.PropertyType.Name);
			if (column != null)
			{
				column.DataPropertyName = column.HeaderText = column.Name = column.ToolTipText = propertyInfo.Name;
				column.DisplayIndex = _displayIndex++;
				column.Width = 100;
			}
			return column;
		}

		protected override object GetCheckBoxColumn()
		{
			return new DataGridViewCheckBoxColumn();
		}

		protected override object GetTextBoxColumn(StringAlignment alignment)
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

		protected override void InitVisibleColumns()
		{
			var columns = View.Columns.Cast<DataGridViewColumn>();
            foreach (var column in columns)
				column.Visible = false;
			var displayIndex = 0;
			foreach (var columnName in VisibleColumnNames)
			{
				var column = columns.Single(c => c.Name == columnName);
				column.DisplayIndex = displayIndex++;
				column.Visible = true;
			}
		}

		#endregion

		#region Filter

		protected override void InitFilter()
		{
		}

		#endregion

		#region Groups

		protected override void InitGroups()
		{
		}

		#endregion

		#region Formatting

		private void View_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			e.Value = FormatCell(e);
		}

		private object FormatCell(DataGridViewCellFormattingEventArgs e)
		{
			var result = e.Value;
			var column = View.Columns[e.ColumnIndex];
			result = result.Format(column.DataPropertyName, column.ValueType, false);
			return result;
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

		private void SetSelection(Func<DataGridViewRow, bool> select)
		{
			BeginUpdateSelection();
		    foreach (DataGridViewRow row in View.Rows)
			    row.Selected = select(row);
			EndUpdateSelection();
		}

		private void View_SelectionChanged(object sender, EventArgs e)
		{
			OnSelectionChanged();
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
