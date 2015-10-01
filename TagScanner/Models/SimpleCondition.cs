using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TagScanner.Models
{
	public class SimpleCondition
	{
		#region Public Interface

		#region Lifetime Management

		public SimpleCondition(string text)
		{
			PropertyName = StringUtilities.TakeWord(ref text);
			foreach (var op in AllOperators)
				if (text.StartsWith(op))
				{
					Operation = op;
					ValueString = text.Substring(op.Length).TrimStart();
					return;
				}
		}

		#endregion

		#region Properties

		public static IEnumerable<string> GetOperatorsForType(string propertyTypeName)
		{
			var result = new List<string>();
			if (StringTypes.Contains(propertyTypeName))
				result.AddRange(StringOperators);
			result.AddRange(EqualityOperators);
			if (ComparableTypes.Contains(propertyTypeName))
				result.AddRange(ComparisonOperators);
			return result;
		}

		public string Operation { get; private set; }

		public string PropertyName { get; private set; }

		public Type PropertyType
		{
			get
			{
				return GetPropertyInfo(PropertyName).PropertyType;
            }
		}

		public string PropertyTypeName
		{
			get
			{
				return PropertyType.Name;
			}
		}

		public string ValueString { get; private set; }

		public object Value
		{
			get
			{
				switch (PropertyTypeName)
				{
					case "String":
						return ValueString;
					case "Int32":
						return Convert.ToInt32(ValueString);
					case "Int64":
						return Convert.ToInt64(ValueString);
					case "TimeSpan":
						return TimeSpan.Parse(ValueString);
					case "Logical":
						return ValueString == "true" ? Logical.Yes : Logical.No;
				}
				return null;
			}
		}

		#endregion

		#region Methods

		private static ExpressionType OperatorToExpressionType(string op)
		{
			switch (op)
			{
				case Operator.Equal:
					return ExpressionType.Equal;
				case Operator.GreaterThan:
					return ExpressionType.GreaterThan;
				case Operator.LessThan:
					return ExpressionType.LessThan;
				case Operator.LessThanOrEqual:
					return ExpressionType.LessThanOrEqual;
				case Operator.NotEqual:
					return ExpressionType.NotEqual;
			}
			return ExpressionType.Equal;
		}

		public BinaryExpression ToExpression()
		{
			var expression = Expression.Parameter(typeof(ITrack), "propertyName");
			var conversion = Expression.Convert(Expression.Property(expression, PropertyName), PropertyType);
			var expressionType = OperatorToExpressionType(Operation);
            var value = Expression.Constant(Value);
			return Expression.MakeBinary(expressionType, conversion, value);
			/*
			var result = Expression.Lambda<Func<ITrack, bool>>(test, expression);
			return result.Compile();
			*/
		}

		public Func<ITrack, bool> ToFunc()
		{
			var expression = Expression.Parameter(typeof(ITrack), "propertyName");
			var conversion = Expression.Convert(Expression.Property(expression, PropertyName), PropertyType);
			var rhs = Expression.Constant(Value);
			var test = Expression.MakeBinary(OperatorToExpressionType(Operation), conversion, rhs);
			var result = Expression.Lambda<Func<ITrack, bool>>(test, expression);
			return result.Compile();
		}

		private bool Test(object track)
		{
			return ToFunc()((ITrack)track);
		}

		public Predicate<object> ToPredicate()
		{
			return Test;
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", PropertyName, Operation, ValueString);
		}

		#endregion

		private static readonly PropertyInfo[] PropertyInfos = typeof(ITrack).GetProperties();

		public static readonly IEnumerable<PropertyInfo> SortablePropertyInfos =
			PropertyInfos.Where(p => !p.PropertyType.IsArray && p.PropertyType.Name != "TagTypes");

		public static readonly string[] SortableColumnNames = SortablePropertyInfos.Select(p => p.Name).ToArray();

		public static PropertyInfo GetPropertyInfo(string propertyName)
		{
			return PropertyInfos.FirstOrDefault(p => p.Name == propertyName);
		}

		public static Type GetPropertyType(string propertyName)
		{
			return GetPropertyInfo(propertyName).PropertyType;
        }

		public static string GetPropertyTypeName(string propertyName)
		{
			return GetPropertyType(propertyName).Name;
        }

		#endregion

		#region Private Implementation

		private static string[] ComparableTypes = new[]
		{
			"String",
			"Int32",
			"Int64",
			"TimeSpan"
		};

		private static string[] ComparisonOperators = new[]
		{
			Operator.LessThan,
			Operator.LessThanOrEqual,
			Operator.GreaterThanOrEqual,
			Operator.GreaterThan
		};

		private static string[] EqualityOperators = new[]
		{
			Operator.Equal,
			Operator.NotEqual
		};

		private static string[] StringTypes = new[]
		{
			"String"
		};

		private static string[] StringOperators = new[]
		{
			"contains",
			"starts with",
			"ends with",
			"does not contain",
			"does not start with",
			"does not end with"
		};

		private static IEnumerable<string> AllOperators =
			StringOperators
			.Union(EqualityOperators)
			.Union(ComparisonOperators);

		#endregion
	}
}
