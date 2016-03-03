using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using OnlineRates.Data;

namespace OnlineRates.Logic
{
	public class MinskRatesManager
	{
		private OnlineRatesDataContext ratesContext;
        // создание объекта контекста в конструкторе
		public MinskRatesManager()
        {
			ratesContext = new OnlineRatesDataContext();
        }

		public List<BankRateInfo>GetAllRatesInBanks(DateTime date)
		{
			List<BankRateInfo> listBankRateInfo = new List<BankRateInfo>();
			var rates = from ratesinbanks in ratesContext.RatesinBanks
			            where ratesinbanks.DateofRate.Equals(date)
                        orderby ratesinbanks.Bank.BankName
			            select ratesinbanks;

			foreach (var ratesinBank in rates)
			{
				BankRateInfo bankRateInfo = 
					new BankRateInfo(
					ratesinBank.Bank.BankId,
					ratesinBank.RateBankId,
					ratesinBank.Bank.BankName,
					ratesinBank.Bank.Address,
					ratesinBank.Bank.Phone, 
					ratesinBank.USD_Buying,
					ratesinBank.USD_Selling, 
					ratesinBank.EUR_Buying, 
					ratesinBank.EUR_Selling, 
					ratesinBank.RUB_Buying,
					ratesinBank.RUB_Selling, 
					ratesinBank.DateofRate
					);
				listBankRateInfo.Add(bankRateInfo);

			}
			return listBankRateInfo;
		}

        public RateInBank GetRateInBankByRateId(int rateId)
        {
            RateInBank rateInBank;
            var rate = (from ratesinbanks in ratesContext.RatesinBanks
                        where ratesinbanks.RateBankId.Equals(rateId)
                        select ratesinbanks).SingleOrDefault();

            if (rate != null)
            {
                rateInBank = new RateInBank(rate.RateBankId, rate.IdBank, rate.USD_Buying, rate.USD_Selling, rate.EUR_Buying, rate.EUR_Selling, rate.RUB_Buying, rate.RUB_Selling, rate.DateofRate);
                return rateInBank;
            }
            return null;
        }

		public BestRatesBuyingSelling GetBestRates(List<BankRateInfo> listRates)
		{
		    if (listRates.Count != 0)
            {
                BestRatesBuyingSelling bestRatesBS = new BestRatesBuyingSelling();

                bestRatesBS.Best_USD_Buying = Double.Parse(listRates.Select(rate => rate.USD_Buying).Max().ToString());
                bestRatesBS.Best_USD_Selling = Double.Parse(listRates.Select(rate => rate.USD_Selling).Min().ToString());

                bestRatesBS.Best_EUR_Buying = Double.Parse(listRates.Select(rate => rate.EUR_Buying).Max().ToString());
                bestRatesBS.Best_EUR_Selling = Double.Parse(listRates.Select(rate => rate.EUR_Selling).Min().ToString());

                bestRatesBS.Best_RUB_Buying = Double.Parse(listRates.Select(rate => rate.RUB_Buying).Max().ToString());
                bestRatesBS.Best_RUB_Selling = Double.Parse(listRates.Select(rate => rate.RUB_Selling).Min().ToString());

                return bestRatesBS;
            }
		    return null;
		}

	    public bool UpdateTodayRateForBank(RateInBank rateInBankNewValue)
		{
			var updatedRate = ratesContext.RatesinBanks.Where(rate => rate.RateBankId == rateInBankNewValue.RateId).SingleOrDefault();
			if (updatedRate != null)
			{
				updatedRate.USD_Buying = rateInBankNewValue.USD_Buying;
				updatedRate.USD_Selling = rateInBankNewValue.USD_Selling;
				updatedRate.EUR_Buying = rateInBankNewValue.EUR_Buying;
				updatedRate.EUR_Selling = rateInBankNewValue.EUR_Selling;
				updatedRate.RUB_Buying = rateInBankNewValue.RUB_Buying;
				updatedRate.RUB_Selling = rateInBankNewValue.RUB_Selling;
				updatedRate.DateofRate = DateTime.Now.Date;

				ratesContext.SubmitChanges();

				return true;
			}
			return false;
		}

		public string GetBankNameById(int bankId)
		{
			var bankName = ratesContext.Banks.Where(bank => bank.BankId == bankId).Select(bank => bank.BankName).SingleOrDefault();
			if (bankName != null)
			{
				return bankName;
			}
			return null;
		}

        public bool AddRatesInBank(RateInBank rateInBankNew)
        {
            if (rateInBankNew != null)
            {

                var listRatesInBanks = ratesContext.GetTable<RatesinBank>();

                RatesinBank newRateInBank = new RatesinBank();

                newRateInBank.IdBank = rateInBankNew.BankId;
                newRateInBank.USD_Buying = rateInBankNew.USD_Buying;
                newRateInBank.USD_Selling = rateInBankNew.USD_Selling;
                newRateInBank.EUR_Buying = rateInBankNew.EUR_Buying;
                newRateInBank.EUR_Selling = rateInBankNew.EUR_Selling;
                newRateInBank.RUB_Buying = rateInBankNew.RUB_Buying;
                newRateInBank.RUB_Selling = rateInBankNew.RUB_Selling;
                newRateInBank.DateofRate = rateInBankNew.DateofRate;

                listRatesInBanks.InsertOnSubmit(newRateInBank);
                ratesContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public List<int>GetListBankIdNonRatesToday()
        {
            var listAllBankId = ratesContext.Banks.Select(bank => bank.BankId);
            var listBankIdWithRatesToday = ratesContext.RatesinBanks.Where(rates => rates.DateofRate == DateTime.Now.Date).Select(
                    rate => rate.IdBank);
            
            // нахождение разности
            var listBankIdNonRatesToday = listAllBankId.Except(listBankIdWithRatesToday);

            return listBankIdNonRatesToday.ToList();
        }

        public bool DeleteRateByRateBankId(int ratebankid)
        {
            var listRatesInBanks = ratesContext.RatesinBanks;
            var removedRate = listRatesInBanks.SingleOrDefault(rate => rate.RateBankId.Equals(ratebankid));

            if (removedRate != null)
            {
                try
                {
                    listRatesInBanks.DeleteOnSubmit(removedRate);
                    ratesContext.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                } 
            }
            return false;
        }
	}
}