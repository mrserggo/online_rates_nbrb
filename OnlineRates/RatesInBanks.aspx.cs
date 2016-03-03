using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Data;
using OnlineRates.Logic;

namespace OnlineRates
{
    public partial class RatesInBanks : System.Web.UI.Page
    {
    	private MinskRatesManager minskRatesManager;
        protected void Page_Load(object sender, EventArgs e)
        {
			
        	minskRatesManager = new MinskRatesManager();

        	var updateRateId = Request.QueryString["updateRateId"];
            var addRate = Request.QueryString["addrate"];

            if (addRate != null)
            {
                AddRateControl.Visible = true;
            }
			if (updateRateId != null)
			{
			    int rateId = Convert.ToInt32(updateRateId);
			    UpdateRateControl.Visible = true;
                UpdateRateControl.RatesInfo = minskRatesManager.GetRateInBankByRateId(rateId);
			}
			if (!Page.IsPostBack)
			{
				if (User.Identity.Name == "Djoser")
				{
					RatesInBanksControl.Role = "Admin";
				}
				else RatesInBanksControl.Role = "NoAdmin";

				RatesInBanksControl.Title = String.Format("Курсы валют в Минске на {0}", DateTime.Now.Date.ToString("dd'.'MM'.'yyyy"));
				// нахождение выгодных курсов валют
				var allRatesInBanks = minskRatesManager.GetAllRatesInBanks(DateTime.Now.Date);
				RatesInBanksControl.BestRates = minskRatesManager.GetBestRates(allRatesInBanks);
				RatesInBanksControl.DataSource = allRatesInBanks;
				RatesInBanksControl.DataBind();
			}
			
        }

		//protected void TestUpdate_Click(object sender, EventArgs e)
		//{
		//    RateInBank rb = new RateInBank(3453, 1, 100, 1000, 2000, 234,233,3789,DateTime.Now);
		//    minskRatesManager.UpdateTodayRateForBank(rb);
		//    Response.Redirect("RatesInBanks.aspx");
		//}

		protected void lbtnExit_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("Default.aspx");
			//FormsAuthentication.RedirectToLoginPage();
		}

        //protected void TestAdd_Click(object sender, EventArgs e)
        //{
        //    RateInBank rb = new RateInBank(-1, 6, 8099, 8100, 20000, 20500, 300, 310, DateTime.Now.Date);
        //    minskRatesManager.AddRatesInBank(rb);
        //    Response.Redirect("RatesInBanks.aspx");
        //}
    }
}