using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRates.Data
{
	public class BankRateInfo
	{
		public int BankId { get; set; }
		public int RateBankId { get; set; }
		public string BankName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public double USD_Buying { get; set; }
		public double USD_Selling { get; set; }
		public double EUR_Buying { get; set; }
		public double EUR_Selling { get; set; }
		public double RUB_Buying { get; set; }
		public double RUB_Selling { get; set; }
		public DateTime DateofRate { get; set; }

		public BankRateInfo(int bankid, int ratebankid, string bankname, string address, string phone,
								double usd_buying, double usd_selling, double eur_buying,
								double eur_selling, double rub_buying, double rub_selling,
																	DateTime dateofrate)
		{
			this.BankId = bankid;
			this.RateBankId = ratebankid;
			this.BankName = bankname;
			this.Address = address;
			this.Phone = phone;

			this.USD_Buying = usd_buying;
			this.USD_Selling = usd_selling;
			this.EUR_Buying = eur_buying;
			this.EUR_Selling = eur_selling;
			this.RUB_Buying = rub_buying;
			this.RUB_Selling = rub_selling;
			this.DateofRate = dateofrate;
		}
	}
}