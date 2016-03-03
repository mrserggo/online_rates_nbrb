using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRates.Data
{
	public class RateInBank
	{
		public int RateId { get; set; }
		public int BankId { get; set; }

		public double USD_Buying { get; set; }
		public double USD_Selling { get; set; }
		public double EUR_Buying { get; set; }
		public double EUR_Selling { get; set; }
		public double RUB_Buying { get; set; }
		public double RUB_Selling { get; set; }
		public DateTime DateofRate { get; set; }

		public RateInBank(int rateId, int bankid, double usd_buying, double usd_selling, 
									double eur_buying, double eur_selling, double rub_buying,
									double rub_selling, DateTime dateofrate)
		{
			this.RateId = rateId;
			this.BankId = bankid;
			this.USD_Buying = usd_buying;
			this.USD_Selling = usd_selling;
			this.EUR_Buying = eur_buying;
			this.EUR_Selling = eur_selling;
			this.RUB_Buying = rub_buying;
			this.RUB_Selling = rub_selling;
			this.DateofRate = dateofrate;
		}
	}

	public class BestRatesBuyingSelling
	{
		public double Best_USD_Buying { get; set; }
		public double Best_USD_Selling { get; set; }
		public double Best_EUR_Buying { get; set; }
		public double Best_EUR_Selling { get; set; }
		public double Best_RUB_Buying { get; set; }
		public double Best_RUB_Selling { get; set; }
	}
}