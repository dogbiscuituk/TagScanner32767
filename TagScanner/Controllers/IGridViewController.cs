using System;

namespace TagScanner.Controllers
{
	public interface IGridViewController
	{
		void SelectAll();
		void InvertSelection();

		TagFileSelection Selection { get; }

		event EventHandler SelectionChanged;
	}
}
