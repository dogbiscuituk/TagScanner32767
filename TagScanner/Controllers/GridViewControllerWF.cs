using System;
using System.Linq;
using System.Windows.Forms;
using TagScanner.Model;

namespace TagScanner.Controllers
{
	public class GridViewControllerWF : GridViewController
	{
		public GridViewControllerWF(TagFileModel model, DataGridView gridView) : base(model)
		{
			GridView = gridView;
		}

		private DataGridView _gridView;
		public DataGridView GridView
		{
			get { return _gridView; }
			set
			{
				if (GridView != null)
				{
					GridView.CellFormatting -= GridView_CellFormatting;
					GridView.ColumnHeaderMouseClick -= GridView_ColumnHeaderMouseClick;
					GridView.SelectionChanged -= GridView_SelectionChanged;
				}
				_gridView = value;
				if (GridView != null)
				{
					GridView.CellFormatting += GridView_CellFormatting;
					GridView.ColumnHeaderMouseClick += GridView_ColumnHeaderMouseClick;
					GridView.SelectionChanged += GridView_SelectionChanged;
				}
			}
		}

		#region File processing

		protected override void RefreshDataSource()
		{
			if (GridView.InvokeRequired)
				GridView.Invoke(new MethodInvoker(RefreshDataSource));
			else
			{
				var files = Model.Files;
				GridView.DataSource = files.Any() ? files : null;
			}
		}

		#endregion

		#region Formatting

		private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			e.Value = FormatCell(e);
		}

		private string FormatCell(DataGridViewCellFormattingEventArgs e)
		{
			var column = GridView.Columns[e.ColumnIndex];
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

		protected override TagFileSelection GetSelection()
		{
			return new TagFileSelection(
				GridView
					.SelectedRows
					.Cast<DataGridViewRow>()
					.Select(p => Model.Files[p.Index])
					.ToList());
		}

		private void GridView_SelectionChanged(object sender, EventArgs e)
		{
			OnSelectionChanged();
		}

		private void SetSelection(Func<DataGridViewRow, bool> select)
		{
			BeginUpdateSelection();
		    foreach (DataGridViewRow row in GridView.Rows)
			    row.Selected = select(row);
			EndUpdateSelection();
		}

		#endregion

		#region Sorting

		private void GridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Model.ToggleOrder(GridView.Columns[e.ColumnIndex].DataPropertyName);
		}

		#endregion
	}
}
