using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Web;
using OnlineRates.Data;

namespace OnlineRates.Logic
{
	public class NBRBManager
	{
		private ExRates exRates;

		public NBRBManager()
		{
			exRates = new ExRates();
		}

		public List<ExRatesNow> GetCurrenciesChangesToday(DateTime someDate, DateTime dateBefore)
		{
            var rowsRatesToday = exRates.ExRatesDaily(someDate).Tables[0].Select(null, null, DataViewRowState.CurrentRows);
            var rowsRatesYesterday = exRates.ExRatesDaily(dateBefore).Tables[0].Select(null, null, DataViewRowState.CurrentRows);
			List<ExRatesNow> listCurrenciesToday = new List<ExRatesNow>();

			List<CurrenciesPrice> listCurPricesToday = new List<CurrenciesPrice>();
			List<CurrenciesPrice> listCurPricesYestreday = new List<CurrenciesPrice>();
			
			foreach (DataRow row in rowsRatesToday)
			{
				int curCode = -1;
				curCode = Convert.ToInt32(row["Cur_Code"]);
				if ((curCode == 840)||(curCode == 978)||(curCode == 643)||(curCode == 826)||(curCode == 392)) // 5 основных валют
				{
					listCurPricesToday.Add(new CurrenciesPrice(Convert.ToInt32(row["Cur_Code"]), row["Cur_QuotName"].ToString(), Convert.ToDouble(row["Cur_OfficialRate"])));
				}
				
			}
			foreach (DataRow row in rowsRatesYesterday)
			{
				int curCode = -1;
				curCode = Convert.ToInt32(row["Cur_Code"]);
				if ((curCode == 840) || (curCode == 978) || (curCode == 643) || (curCode == 826) || (curCode == 392)) // 5 основных валют
				{
					listCurPricesYestreday.Add(new CurrenciesPrice(Convert.ToInt32(row["Cur_Code"]), row["Cur_QuotName"].ToString(), Convert.ToDouble(row["Cur_OfficialRate"])));
				}
			}

			foreach (var valueToday in listCurPricesToday)
			{
				double priceToday = valueToday.Price;
				double priceYesterday = listCurPricesYestreday.Where(valueYesterday => valueYesterday.CurCode == valueToday.CurCode).Single().Price;

				ChangeCurrencyState ccState = (priceToday.Equals(priceYesterday))
				                              	? ChangeCurrencyState.NotChanged
				                              	: ((priceToday - priceYesterday) > 0)
				                              	  	? ChangeCurrencyState.Increased
				                              	  	: ChangeCurrencyState.Decreased;

				double priceDifference = Math.Abs(priceToday - priceYesterday);
				double parcentChange = (ccState == ChangeCurrencyState.NotChanged) ? 0 : (priceDifference / priceYesterday) * 100;

				listCurrenciesToday.Add(new ExRatesNow(valueToday.CurCode, valueToday.CurrencyName, Math.Round(priceToday, 3), Math.Round(parcentChange, 3), Math.Round(priceDifference, 3), ccState));
			
			}
			
			return listCurrenciesToday;
		}

        public List<DataRow> GetExRatesDaily(bool isFirstHalf)
        {
            var table = exRates.ExRatesDaily(DateTime.Now.Date).Tables[0];
            List<DataRow> results;
            var listRates = table.Select(null, null, DataViewRowState.CurrentRows).ToList();
            int countRates = listRates.Count;
            bool evenCount = (countRates%2 == 0) ? true : false;
            int skip1 = 0;
            int take1 = evenCount ? countRates/2 : countRates/2 + 1;
            int skip2 = evenCount ? countRates / 2 : countRates / 2 + 1;
            int take2 = countRates/2;


            if (isFirstHalf)
            {
                results = listRates.Skip(skip1).Take(take1).ToList();
            }
            else
            {
                results = listRates.Skip(skip2).Take(take2).ToList();
                if (!evenCount)
                {
                    DataRow row = table.NewRow();
                    row["Cur_Abbreviation"] = "UNI";
                    row["Cur_QuotName"] = "1 всемирный универсал";
                    row["Cur_OfficialRate"] = 0;
                    results.Add(row);
                }
            }
            return results;
        }

        public bool ConvertCurrency(int cur_id1, int cur_id2, double count_money, ref double result_money)
        {
            double rate1 = 0;
            double rate2 = 0;

            if ((cur_id1 != -1) && (cur_id2 != -1))
            {
                var data1 = exRates.ExRatesDyn(cur_id1, DateTime.Now.Date, DateTime.Now.Date);
                var data2 = exRates.ExRatesDyn(cur_id2, DateTime.Now.Date, DateTime.Now.Date);
                if ((data1 != null) && (data2 != null))
                {
                    rate1 = Convert.ToDouble(data1.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]);
                    rate2 = Convert.ToDouble(data2.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]);
                    result_money = Math.Round(count_money * rate1 / rate2, 4);
                    return true;
                }
                return false;
            }
            if ((cur_id1 == -1) && (cur_id2 == -1))
            {
                result_money = 1;
                return true;
            }
            if ((cur_id1 == -1) && (cur_id2 != -1))
            {
                var data2 = exRates.ExRatesDyn(cur_id2, DateTime.Now.Date, DateTime.Now.Date);
                if (data2 != null)
                {
                    rate2 = Convert.ToDouble(data2.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]);
                    result_money = Math.Round(count_money / rate2, 4);
                    return true;
                }
                return false;
            }
            if ((cur_id1 != -1) && (cur_id2 == -1))
            {
                var data1 = exRates.ExRatesDyn(cur_id1, DateTime.Now.Date, DateTime.Now.Date);
                if (data1 != null)
                {
                    rate1 = Convert.ToDouble(data1.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]);
                    result_money = Math.Round(count_money * rate1, 4);
                    return true;
                }
                return false;
            }
            return false;
        }
	}
}