using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Logic;

namespace OnlineRates
{
	public partial class Finance : System.Web.UI.Page
	{
		private string dateFormat = "dd'.'MM'.'yyyy";

		public void Page_Load(object sender, EventArgs e)
		{
			ExRates exRates = new ExRates();
			if (!IsPostBack)
			{
				var lastDateActualRatesInfo = exRates.LastDailyExRatesDate();
				lblIngotsLastDate.Text = exRates.IngotsLastDate().ToString(dateFormat);
				lblLastDailyExRatesDate.Text = lastDateActualRatesInfo.ToString(dateFormat);
				lblMetalsLastDate.Text = exRates.MetalsLastDate().ToString(dateFormat);
				lblStockAddRatesLastDate.Text = exRates.StockAddRatesLastDate().ToString(dateFormat);

				if (lastDateActualRatesInfo.Date >= DateTime.Now.AddDays(1).Date)
				{
					mainRatesTableToday.DateInfo = String.Format("Курсы валют на {0}", DateTime.Now.ToString(dateFormat));
					mainRatesTableToday.DataSource = new NBRBManager().GetCurrenciesChangesToday(DateTime.Now, DateTime.Now.AddDays(-1));
					mainRatesTableToday.DataBind();

					mainRatesTableTomorrow.DateInfo = String.Format("Курсы валют на {0}", DateTime.Now.AddDays(1).ToString(dateFormat));
					mainRatesTableTomorrow.DataSource = new NBRBManager().GetCurrenciesChangesToday(DateTime.Now.AddDays(1), DateTime.Now);
					mainRatesTableTomorrow.DataBind();
				}
				else
				{
					mainRatesTableToday.DateInfo = String.Format("Курсы валют на {0}", DateTime.Now.ToString(dateFormat));
					mainRatesTableToday.DataSource = new NBRBManager().GetCurrenciesChangesToday(DateTime.Now, DateTime.Now.AddDays(-1));
					mainRatesTableToday.DataBind();

					mainRatesTableTomorrow.DataSource = null;
				}

				//mainRatesTableTomorrow.DataSource = null;
				////mainRatesTableTomorrow.DataSource = new NBRBManager().GetCurrenciesChangesToday(DateTime.Now.AddDays(1), DateTime.Now);
				//mainRatesTableTomorrow.DataBind();
			}

		}

		//*****************************************************************//
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
            //FormsAuthentication.RedirectToLoginPage();
        }
	}
}