using System.Collections.Generic;
using System.Linq;
using TagScanner.Model;

namespace TagScanner.Model
{
	public class Order
	{
		public Order(string propertyName, bool descending = false)
		{
			PropertyName = propertyName;
			Descending = descending;
		}

		public string PropertyName { get; set; }
		public bool Descending { get; set; }

		public IOrderedEnumerable<TagFile> ApplyFirst(IEnumerable<TagFile> files)
		{
			return Descending ? files.OrderByDescending(PropertyName) : files.OrderBy(PropertyName);
		}

		public IOrderedEnumerable<TagFile> ApplyNext(IOrderedEnumerable<TagFile> files)
		{
			return Descending ? files.ThenByDescending(PropertyName) : files.ThenBy(PropertyName);
		}
	}
}
