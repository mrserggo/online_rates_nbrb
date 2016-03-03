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
	public partial class RatesNBRB : System.Web.UI.Page
	{
        private NBRBManager nbrbManager = new NBRBManager();
        private ExRates exRates = new ExRates();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                //var tableCurrencies = exRates.ExRatesDaily(exRates.IngotsLastDate()).Tables[0];//exRates.CurrenciesRef(0).Tables[0];

                //tableCurrencies.Columns[0].ColumnName = "Id валюты";
                //gvCurrencies.DataSource = exRates.CurrenciesRef(0);//exRates.MetalsRef();//tableCurrencies;
                //gvCurrencies.DataBind();

                /****инициализация выпадающего списка валют****/
				DataRow[] currentRowsCur = exRates.CurrenciesRef(0).Tables[0].Select(null, null, DataViewRowState.CurrentRows);

				List<ListItem> lItemCurrencies = new List<ListItem>();
				foreach (DataRow row in currentRowsCur)
				{
                    object currencyId = row["Cur_Id"];
				    object currencyName = row["Cur_Name"];
					lItemCurrencies.Add(new ListItem(currencyName.ToString(), currencyId.ToString()));
				}
				ddlCurrencies.Items.AddRange(lItemCurrencies.OrderBy(s => s.Text).ToArray());

                /****инициализация выпадающего списка твердых валют****/
				DataRow[] currentMetals = exRates.CurrenciesRef(0).Tables[0].Select(null, null, DataViewRowState.CurrentRows);

				var funMetals = exRates.MetalsRef().Tables[0].Select(null, null, DataViewRowState.CurrentRows);
				List<ListItem> lItemMetals = new List<ListItem>();
				foreach (DataRow row in funMetals)
				{
					lItemMetals.Add(new ListItem(row["Name"].ToString(), row["Id"].ToString()));
				}
				ddlMetals.Items.AddRange(lItemMetals.OrderBy(s => s.Text).ToArray());
			}

            //****курсы валют****//
		    firstHalfRates.DataSource = nbrbManager.GetExRatesDaily(true);
            firstHalfRates.DataBind();
		    secondHalfRates.DataSource = nbrbManager.GetExRatesDaily(false);
            secondHalfRates.DataBind();
            //****цены на мерные слитки****/
            metalsRates.DataSource = exRates.IngotsPrices(exRates.IngotsLastDate()).Tables[0].Select(null, null, DataViewRowState.CurrentRows).ToList();
            metalsRates.DataBind();

		}

		protected void btnShowAvailableFunMetals_Click(object sender, EventArgs e)
		{
			ExRates exRates = new ExRates();
			var funMetalsTable = exRates.MetalsRef().Tables[0];
			DataTable newFunMetalsTable = new DataTable();

            //rptMetals.DataSource = funMetalsTable.Select(null, null, DataViewRowState.CurrentRows);
            //rptMetals.DataBind();
		}

        //protected void rptMetals_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    var item = e.Item;
        //    if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
        //        return;

        //    var element = item.DataItem as DataRow;
        //    if (null == element)
        //        return;

        //    var hlShowExPrices = item.FindControl("hlShowExPrices") as HyperLink;
        //    if (null != hlShowExPrices)
        //    {
        //        hlShowExPrices.Text = (string)element["Name"]; ;
        //        //hlShowExPrices.NavigateUrl = String.Concat("Default.aspx?", "ID=", element["ID"].ToString());
        //    }
        //}

		protected void ddlMetals_SelectedIndexChanged(object sender, EventArgs e)
		{
			var dMetals = (DropDownList)sender;
			int idMetal = -1;

			DateTime startAjaxDate;
			DateTime endAjaxDate;
			if ((DateTime.TryParse(tbStartDateCurrency.Text, out startAjaxDate)) &&
				(DateTime.TryParse(tbEndDateCurrency.Text, out endAjaxDate))
                && int.TryParse(dMetals.SelectedValue, out idMetal))
			{
                var data = exRates.MetalsPrices(idMetal, startAjaxDate, endAjaxDate);
                if (data != null)
                {
                    ratesMonitoring.RateInfo = String.Format("Объект мониторинга - <span class='redTitle'>{0}</span>", dMetals.SelectedItem.Text);
                    ratesMonitoring.Is1stCurrencyMonitor = false;
                    ratesMonitoring.DataSource = data.Tables[0].Select(null, null, DataViewRowState.CurrentRows).ToList();
                    ratesMonitoring.DataBind();

                    //gvListFunMetals.DataSource = exRates.MetalsPrices(idMetal, startAjaxDate, endAjaxDate).Tables[0];
                    //gvListFunMetals.DataBind();
                }
			}
		}

		protected void lbtnExit_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("Default.aspx");
			//FormsAuthentication.RedirectToLoginPage();
		}

        protected void ddlCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dCurrencies = (DropDownList)sender;
            int idMetal = -1;
            DateTime startAjaxDate;
            DateTime endAjaxDate;
            if ((DateTime.TryParse(tbStartDateCurrency.Text, out startAjaxDate)) && (DateTime.TryParse(tbEndDateCurrency.Text, out endAjaxDate)))
            {
                var data = exRates.ExRatesDyn(int.Parse(dCurrencies.SelectedValue), startAjaxDate, endAjaxDate);
                if (data != null)
                {
                    ratesMonitoring.RateInfo = String.Format("Объект мониторинга - <span class='redTitle'>{0}</span>", dCurrencies.SelectedItem.Text);
                    ratesMonitoring.Is1stCurrencyMonitor = true;
                    ratesMonitoring.DataSource = data.Tables[0].Select(null, null, DataViewRowState.CurrentRows).ToList();
                    ratesMonitoring.DataBind();

                    //gvDyn.DataSource = data.Tables[0];
                    //gvDyn.DataBind();
                }
            }
            else
            {
                //gvDyn.DataSource = "NOT DATA";
                //gvDyn.DataBind();
            }
        }
	}
}