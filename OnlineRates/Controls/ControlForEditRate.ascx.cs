using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Data;
using OnlineRates.Logic;

namespace OnlineRates.Controls
{
	public partial class ControlForEditRate : System.Web.UI.UserControl
	{
        public RateInBank RatesInfo{get; set;}
	
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                MinskRatesManager manager = new MinskRatesManager();
                if (RatesInfo != null)
                {
                    lblBankName.Text = manager.GetBankNameById(RatesInfo.BankId);
                    tbUSDBuying.Text = RatesInfo.USD_Buying.ToString();
                    tbUSDSelling.Text = RatesInfo.USD_Selling.ToString();
                    tbEURBuying.Text = RatesInfo.EUR_Buying.ToString();
                    tbEURSelling.Text = RatesInfo.EUR_Selling.ToString();
                    tbRUBBuying.Text = RatesInfo.RUB_Buying.ToString();
                    tbRUBSelling.Text = RatesInfo.RUB_Selling.ToString();
                    ibtnSaveRateChanges.CommandArgument = RatesInfo.RateId.ToString();
                }
            } 
		}

        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
             var ibtn = sender as ImageButton;
             if (ibtn != null)
             {
                 if (ibtn.CommandArgument != String.Empty)
                 {
                     var rateId = Convert.ToInt32(ibtn.CommandArgument);
                     if (rateId != null)
                     {
                         RateInBank rb = new RateInBank(rateId, 0, Convert.ToDouble(tbUSDBuying.Text),
                                                        Convert.ToDouble(tbUSDSelling.Text),
                                                        Convert.ToDouble(tbEURBuying.Text),
                                                        Convert.ToDouble(tbEURSelling.Text),
                                                        Convert.ToDouble(tbRUBBuying.Text),
                                                        Convert.ToDouble(tbRUBSelling.Text), DateTime.Now.Date);
                         MinskRatesManager manager = new MinskRatesManager();
                         manager.UpdateTodayRateForBank(rb);
                     }

                 }
             }
             Response.Redirect("RatesInBanks.aspx");
        }

        protected void ibtnCansel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RatesInBanks.aspx");
        }
	}
}