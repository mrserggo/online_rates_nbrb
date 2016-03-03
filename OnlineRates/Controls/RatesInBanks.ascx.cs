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
	public partial class RatesInBanks : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public int UpdateRateId { get; set; }
		public string Title { get; set; }
		public string Role { get; set; }
		public BestRatesBuyingSelling BestRates { get; set; }

		public List<BankRateInfo> DataSource
		{
			get { return (List<BankRateInfo>)rptRatesInBanks.DataSource; }
			set { rptRatesInBanks.DataSource = value; }
		}

		public override void DataBind()
		{
			rptRatesInBanks.DataBind();
		}

		protected override void OnPreRender(EventArgs e)
		{
			//base.OnPreRender(e);
			//if (Page.IsPostBack && (null == DataSource || DataSource.Count == 0))
			//{
			//    SetNormalVisibility(false);
			//}
			//else
			//{
			//    SetNormalVisibility(true);
			//}
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			//rptRatesInBanks.ItemDataBound += rptRatesInBanks_ItemDataBound;
			//rptRatesInBanks.ItemCommand += rptRatesInBanks_ItemCommand;
		}

		protected void SetNormalVisibility(bool isNormal)
		{
			rptRatesInBanks.Visible = isNormal;
		}

		protected void rptRatesInBanks_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var item = e.Item;

			if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
				return;

			var element = item.DataItem as BankRateInfo;
			if (null == element)
				return;

			var litDate = rptRatesInBanks.Controls[0].Controls[0].FindControl("litTitle") as Literal;
			if (litDate != null)
				litDate.Text = Title;

			var hlBankInfo = item.FindControl("hlBankInfo") as HyperLink;
			if (hlBankInfo != null)
			{
				hlBankInfo.Text = element.BankName;
				hlBankInfo.ToolTip = String.Concat("Адрес: ", element.Address, "\n", "Тел. ", element.Phone);
				hlBankInfo.NavigateUrl = "#";
			}

			var litUSD_Buying = item.FindControl("litUSD_Buying") as Literal;
			if (litUSD_Buying != null)
			{
				litUSD_Buying.Text = (BestRates.Best_USD_Buying.Equals(element.USD_Buying)) ? String.Format("<span style='color:red;'>{0}</span>", element.USD_Buying) : element.USD_Buying.ToString();
			}

			var litUSD_Selling = item.FindControl("litUSD_Selling") as Literal;
			if (litUSD_Selling != null)
				litUSD_Selling.Text = (BestRates.Best_USD_Selling.Equals(element.USD_Selling)) ? String.Format("<span style='color:red;'>{0}</span>", element.USD_Selling) : element.USD_Selling.ToString();

			var litEUR_Buying = item.FindControl("litEUR_Buying") as Literal;
			if (litEUR_Buying != null)
				litEUR_Buying.Text = (BestRates.Best_EUR_Buying.Equals(element.EUR_Buying)) ? String.Format("<span style='color:red;'>{0}</span>", element.EUR_Buying) : element.EUR_Buying.ToString();

			var litEUR_Selling = item.FindControl("litEUR_Selling") as Literal;
			if (litEUR_Selling != null)
				litEUR_Selling.Text = (BestRates.Best_EUR_Selling.Equals(element.EUR_Selling)) ? String.Format("<span style='color:red;'>{0}</span>", element.EUR_Selling) : element.EUR_Selling.ToString();

			var litRUB_Buying = item.FindControl("litRUB_Buying") as Literal;
			if (litRUB_Buying != null)
				litRUB_Buying.Text = (BestRates.Best_RUB_Buying.Equals(element.RUB_Buying)) ? String.Format("<span style='color:red;'>{0}</span>", element.RUB_Buying) : element.RUB_Buying.ToString();

			var litRUB_Selling = item.FindControl("litRUB_Selling") as Literal;
			if (litRUB_Selling != null)
				litRUB_Selling.Text = (BestRates.Best_RUB_Selling.Equals(element.RUB_Selling)) ? String.Format("<span style='color:red;'>{0}</span>", element.RUB_Selling) : element.RUB_Selling.ToString();

			var ibtnUpdateRate = item.FindControl("ibtnUpdateRate") as ImageButton;
			if (ibtnUpdateRate != null)
			{
				ibtnUpdateRate.CommandArgument = element.RateBankId.ToString();
			}

            var ibtnDeleteRate = item.FindControl("ibtnDeleteRate") as ImageButton;
            if (ibtnDeleteRate != null)
			{
                ibtnDeleteRate.CommandArgument = element.RateBankId.ToString();
			}

            if (!Role.Equals("Admin"))
            {
                var pAdmin = item.FindControl("pAdmin") as Panel;
                if (pAdmin != null)
                    pAdmin.Visible = false;

                var pAdminHeader = rptRatesInBanks.Controls[0].Controls[0].FindControl("pAdminHeader") as Panel;
                if (pAdminHeader != null)
                    pAdminHeader.Visible = false;
            }

		}

		protected void rptRatesInBanks_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.Header || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				if (e.CommandName == "UpdateRate")
				{
					var ibtnUpdateRate = e.Item.FindControl("ibtnUpdateRate") as ImageButton;
					UpdateRateId = Int32.Parse(ibtnUpdateRate.CommandArgument);
					Response.Redirect(String.Format("RatesInBanks.aspx?updateRateId={0}", ibtnUpdateRate.CommandArgument));
				}

                if (e.CommandName == "DeleteRate")
                {
                    var ibtnDeleteRate = e.Item.FindControl("ibtnDeleteRate") as ImageButton;
                    if (ibtnDeleteRate != null)
                    {
                        var deleteRateId = int.Parse(ibtnDeleteRate.CommandArgument);
                        MinskRatesManager manager = new MinskRatesManager();
                        manager.DeleteRateByRateBankId(deleteRateId);
                        Response.Redirect("RatesInBanks.aspx");
                    }
                    
                }

                if (e.CommandName == "AddNewRate")
                {
                    var ibtnAddRate = rptRatesInBanks.Controls[0].Controls[0].FindControl("ibtnAddRate") as ImageButton;
                    Response.Redirect(String.Format("RatesInBanks.aspx?addrate={0}", ibtnAddRate.CommandArgument));
                } 
			}
		}
	}
}