using System;
using System.Linq;
using System.Windows.Forms;
using TagScanner.Model;

namespace TagScanner.Controllers
{
	public class GridViewController
	{
		private TagFileModel _model;
		public TagFileModel Model
		{
			get
			{
				return _model;
			}
			set
			{
				if (Model != null)
				{
					Model.FilesChanged -= Model_FilesChanged;
				}
				_model = value;
				if (Model != null)
				{
					Model.FilesChanged += Model_FilesChanged;
				}
			}
		}

		public GridViewController(TagFileModel model, DataGridView gridView)
		{
			Model = model;
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

		void Model_FilesChanged(object sender, EventArgs e)
		{
			RefreshDataSource();
		}

		private void RefreshDataSource()
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

		private TagFileSelection _selection;
		public TagFileSelection Selection
		{
			get { return _selection ?? (_selection = GetSelection()); }
		}

		public void SelectAll()
		{
			SetSelection(p => p.Visible);
		}

		public void InvertSelection()
		{
			SetSelection(p => p.Visible && !p.Selected);
		}

		public event EventHandler SelectionChanged;

		private int UpdatingSelectionCount { get; set; }

		private TagFileSelection GetSelection()
		{
			return new TagFileSelection(
				GridView
					.SelectedRows
					.Cast<DataGridViewRow>()
					.Select(p => Model.Files[p.Index])
					.ToList());
		}

		private void BeginUpdateSelection()
		{
			UpdatingSelectionCount++;
		}

		private void EndUpdateSelection()
		{
			UpdatingSelectionCount--;
			OnSelectionChanged();
		}

		private void GridView_SelectionChanged(object sender, EventArgs e)
		{
			OnSelectionChanged();
		}

		private void InvalidateSelection()
		{
			_selection = null;
		}

		private void OnSelectionChanged()
		{
			if (UpdatingSelectionCount == 0)
			{
				InvalidateSelection();
				var selectionChanged = SelectionChanged;
				if (selectionChanged != null)
					selectionChanged(this, EventArgs.Empty);
			}
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
			Model.Orders = new[] {GetNewOrder(GridView.Columns[e.ColumnIndex].DataPropertyName)};
		}

		private Order GetNewOrder(string propertyName)
		{
			var newOrder = new Order(propertyName);
			var orders = Model.Orders;
			if (orders.Length == 1)
			{
				var oldOrder = orders[0];
				if (oldOrder.PropertyName == propertyName)
					newOrder.Descending = !oldOrder.Descending;
			}
			return newOrder;
		}

		#endregion
	}
}
