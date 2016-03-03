using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRates.Data
{
	public class ExRatesNow
	{
		public int CurCode { get; set; }
		public string CurrencyName { get; set; }
		public double Price { get; set; }
		public double ParcentChange { get; set; }
		public double PriceDifference { get; set; }
		public ChangeCurrencyState ChangeState { get; set; }

		public ExRatesNow(int curCode, string currencyName, double price, double parsentChange, double priceDifference, ChangeCurrencyState State)
		{
			this.CurCode = curCode;
			this.CurrencyName = currencyName;
			this.Price = price;
			this.ParcentChange = parsentChange;
			this.PriceDifference = priceDifference;
            this.ChangeState = State;
		}
	}

	public class CurrenciesPrice
	{
		public int CurCode { get; set; }
		public string CurrencyName { get; set; }
		public double Price { get; set; }
		
		public CurrenciesPrice(int curCode, string currencyName, double price)
		{
			this.CurCode = curCode;
			this.CurrencyName = currencyName;
			this.Price = price;
		}
	}

	public enum ChangeCurrencyState
	{
		NotChanged = 1,
		Increased = 2,
		Decreased = 3
	}

}