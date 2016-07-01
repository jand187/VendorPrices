using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PriceChecker
{
	public class StandardParser
	{
		private readonly Dictionary<string, int> priceList;

		public StandardParser()
		{
			priceList = new Dictionary<string, int>
			{
				{@"\+\d+ to maximum Life", 3},
				{@"\+\d+% to Fire Resistance", 1}
			};
		}

		public PriceCalculation Parse(string item)
		{
			var price = new PriceCalculation();

			foreach (var priceTag in priceList)
			{
				var match = Regex.Match(item, priceTag.Key);
				if (match.Success)
					price.AddLine(priceTag.Value, Currencies.AlterationShard);
			}

			return price;
		}
	}

	public class PriceCalculation
	{
		private readonly List<KeyValuePair<Currencies, int>> lines;

		public PriceCalculation()
		{
			lines = new List<KeyValuePair<Currencies, int>>();
		}

		public void AddLine(int amount, Currencies currency)
		{
			lines.Add(new KeyValuePair<Currencies, int>(currency, amount));
		}

		public int CalculateTotal()
		{
			return lines.Where(l => l.Key == Currencies.AlterationShard).Sum(l => l.Value);
		}
	}


	public enum Currencies
	{
		AlterationShard
	}
}