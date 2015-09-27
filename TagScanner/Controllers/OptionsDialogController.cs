using System;
using System.Linq;
using System.Windows.Forms;
using TagScanner.Models;
using TagScanner.Views;

namespace TagScanner.Controllers
{
	public class OptionsDialogController
	{
		#region Lifetime Management

		public OptionsDialogController(GridController gridController)
		{
			GridController = gridController;
			OptionsDialog = new OptionsDialog();
			OptionsDialog.btnApply.Click += ApplyButton_Click;
			VisibleColumnsPageController = new ColumnChooserController(OptionsDialog.SelectColumnsPage, false);
			GroupByColumnsPageController = new ColumnChooserController(OptionsDialog.GroupByColumnsPage, true);
			OrderByColumnsPageController = new ColumnChooserController(OptionsDialog.OrderByColumnsPage, true);
			// Disable the option to quickly add all available fields to the Group By clause.
			// This is not realistic and has a severe performance penalty if done accidentally.
			GroupByColumnsPageController.CanAddAll = false;
		}

		#endregion

		#region Properties

		private GridController GridController { get; set; }

		private OptionsDialog OptionsDialog { get; set; }

		private ColumnChooserController GroupByColumnsPageController { get; set; }
		private ColumnChooserController OrderByColumnsPageController { get; set; }
		private ColumnChooserController VisibleColumnsPageController { get; set; }

		#endregion

		#region Methods

		private void Apply()
		{
			/*GridController.SetView(
				VisibleColumnsPageController.ChosenProperties,
				GroupByColumnsPageController.ChosenGroupings,
				OrderByColumnsPageController.ChosenOrderings);
			OptionsApply();*/
		}

		private void ApplyButton_Click(object sender, EventArgs e)
		{
			Apply();
		}

		public void Execute(IWin32Window owner, int page)
		{
			Setup();
			OptionsDialog.TabControl.SelectedIndex = page;
			if (OptionsDialog.ShowDialog(owner) == DialogResult.OK)
				Apply();
		}

		private void OptionsApply()
		{
			/*GridController.Exact = OptionsDialog.cbShowExact.Checked;
			GridController.AutoFitColumns = OptionsDialog.cbAutoFitColumns.Checked;
			GridController.MergeCells = OptionsDialog.cbMergeCells.Checked;
			GridController.HeaderSummaries = OptionsDialog.cbHeaderSummaries.Checked;
			GridController.ShowGroupFooters = OptionsDialog.cbGroupFooters.Checked;
			GridController.ShowGridLinesHorizontal = OptionsDialog.cbGridLinesHorizontal.Checked;
			GridController.ShowGridLinesVertical = OptionsDialog.cbGridLinesVertical.Checked;*/
		}

		private void OptionsSetup()
		{
			/*OptionsDialog.cbShowExact.Checked = GridController.Exact;
			OptionsDialog.cbAutoFitColumns.Checked = GridController.AutoFitColumns;
			OptionsDialog.cbMergeCells.Checked = GridController.MergeCells;
			OptionsDialog.cbHeaderSummaries.Checked = GridController.HeaderSummaries;
			OptionsDialog.cbGroupFooters.Checked = GridController.ShowGroupFooters;
			OptionsDialog.cbGridLinesHorizontal.Checked = GridController.ShowGridLinesHorizontal;
			OptionsDialog.cbGridLinesVertical.Checked = GridController.ShowGridLinesVertical;*/
		}

		private void Setup()
		{
			var columns = GridController.SortableColumnNames.ToList();
			VisibleColumnsPageController.Init(columns, GridController.VisibleColumnNames.Select(p => new Order(p)));
			GroupByColumnsPageController.Init(columns, GridController.Groups.Select(p => new Order(p)));
			OrderByColumnsPageController.Init(columns, new Order[0]);
			OptionsSetup();
		}

		#endregion
	}
}
