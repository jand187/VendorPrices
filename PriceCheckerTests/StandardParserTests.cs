using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using PriceChecker;
using Xunit;

namespace PriceCheckerTests
{
	public class StandardParserTests
	{
		[Fact]
		public void ParseMods()
		{
			var item = GetResource("PriceCheckerTests.TestData.Kraken Tether.txt");
			
			var parser = new StandardParser();
			var price = parser.Parse(item); 
			
			Assert.Equal(4, price.CalculateTotal());
		}

		private static string GetResource(string name)
		{
			var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}


}