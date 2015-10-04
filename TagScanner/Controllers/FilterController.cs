using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using TagScanner.Models;
using TagScanner.Views;

namespace TagScanner.Controllers
{
	public class FilterController
	{
		#region Lifetime Management

		public FilterController(Control host)
		{
			View = new FilterEditor();
			host.Controls.Add(View);
			_simpleFilterEditController = new SimpleFilterEditController(View);
			_simpleFilterEditController.ValueChanged += FilterController_ValueChanged;
			_compoundFilterEditController = new CompoundFilterEditController(View);
			_compoundFilterEditController.ValueChanged += FilterController_ValueChanged;
		}

		private void FilterController_ValueChanged(object sender, EventArgs e)
		{
			SelectedNodeText = ((FilterEditController)sender).Text;
			InvalidateFilter();
		}

		private SimpleFilterEditController _simpleFilterEditController;
		private CompoundFilterEditController _compoundFilterEditController;

		#endregion

		#region View

		private FilterEditor _view;
		private FilterEditor View
		{
			get
			{
				return _view;
			}
			set
			{
				if (View != null)
				{
					View.btnAddFilter.Click -= BtnAddFilter_Click;
					View.btnAddGroup.Click -= BtnAddGroup_Click;
					View.btnDelete.Click -= BtnDelete_Click;
					View.btnClear.Click -= BtnClear_Click;
					View.btnMoveUp.Click -= BtnMoveUp_Click;
					View.btnMoveDown.Click -= BtnMoveDown_Click;
					View.btnOpen.Click -= BtnOpen_Click;
					View.btnSave.Click -= BtnSave_Click;
					View.btnSaveAs.Click -= BtnSaveAs_Click;
					View.TreeView.AfterSelect -= TreeView_AfterSelect;
				}
				_view = value;
				if (View != null)
				{
					View.btnAddFilter.Click += BtnAddFilter_Click;
					View.btnAddGroup.Click += BtnAddGroup_Click;
					View.btnDelete.Click += BtnDelete_Click;
					View.btnClear.Click += BtnClear_Click;
					View.btnMoveUp.Click += BtnMoveUp_Click;
					View.btnMoveDown.Click += BtnMoveDown_Click;
					View.btnOpen.Click += BtnOpen_Click;
					View.btnSave.Click += BtnSave_Click;
					View.btnSaveAs.Click += BtnSaveAs_Click;
					View.TreeView.AfterSelect += TreeView_AfterSelect;
				}
			}
		}

		private void BtnSaveAs_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnOpen_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnMoveDown_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnMoveUp_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BtnClear_Click(object sender, EventArgs e)
		{
			TreeView.Nodes.Clear();
			UpdateControls();
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			TreeView.Nodes.Remove(SelectedNode);
			UpdateControls();
		}

		private void BtnAddGroup_Click(object sender, EventArgs e)
		{
			TreeView.Nodes.Add(CompoundCondition.Quantifiers[0]);
			UpdateControls();
		}

		private void BtnAddFilter_Click(object sender, EventArgs e)
		{
			TreeView.Nodes.Add(SimpleCondition.SortableColumnNames[0] + " contains");
			UpdateControls();
		}

		private TreeNode SelectedNode { get { return TreeView.SelectedNode; } }

		private string SelectedNodeText
		{
			get
			{
				var selectedNode = SelectedNode;
				return selectedNode != null ? selectedNode.Text : string.Empty;
			}
			set
			{
				SelectedNode.Text = value;
			}
		}

		private TreeView TreeView { get { return View.TreeView; } }

		#endregion

		#region Control Events

		private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateControls();
		}

		private void UpdateControls()
		{
			UpdateEditControllers();
			InvalidateFilter();
			var canMoveUp = true;
			var canMoveDown = true;
			View.btnDelete.Enabled = SelectedNode != null;
			View.btnClear.Enabled = TreeView.Nodes.Count > 0;
		}

		private void UpdateEditControllers()
		{
			var text = SelectedNodeText;
			var compound = CompoundCondition.Quantifiers.Contains(text);
			var simple = !string.IsNullOrWhiteSpace(text) && !compound;
			_simpleFilterEditController.Visible = simple;
			_compoundFilterEditController.Visible = compound;
			if (simple)
				_simpleFilterEditController.Text = text;
			else if (compound)
				_compoundFilterEditController.Text = text;
		}

		#endregion

		#region Predicate

		private Expression GetExpression(TreeNode node)
		{
			var text = node.Text;
			return CompoundCondition.Quantifiers.Contains(text)
				? GetCompoundExpression(text, node.Nodes)
				: new SimpleCondition(text).ToExpression(_parameter);
		}

		private Expression GetCompoundExpression(string quantifier, TreeNodeCollection nodes)
		{
			if (nodes == null || nodes.Count < 1)
				return Expression.Constant(true);
			Expression result = null;
			var first = true;
			foreach (var subCondition in nodes.Cast<TreeNode>().Select(GetExpression))
			{
				result = first ? subCondition : Expression.MakeBinary(ExpressionType.AndAlso, result, subCondition);
				first = false;
			}
			return result;
		}

		public Predicate<object> Predicate
		{
			get
			{
				return Test;
			}
		}

		private bool Test(object track)
		{
			return Function((ITrack)track);
		}

		private Func<ITrack, bool> _function;
		private Func<ITrack, bool> Function
		{
			get
			{
				return _function ?? (_function = GetFunction());
			}
		}

		private Func<ITrack, bool> GetFunction()
		{
			var expression = GetCompoundExpression("All of these are true:", TreeView.Nodes);
			var lambda = Expression.Lambda<Func<ITrack, bool>>(expression, _parameter);
			var function = lambda.Compile();
			return function;
		}

		private static ParameterExpression _parameter = Expression.Parameter(typeof(ITrack), "track");

		private void InvalidateFilter()
		{
			_function = null;
		}

		#endregion
	}
}
