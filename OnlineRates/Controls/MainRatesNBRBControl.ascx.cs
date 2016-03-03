using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Data;

namespace OnlineRates.Controls
{
    public partial class MainRatesNBRBControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		public string DateInfo { get; set; }

        public List<ExRatesNow> DataSource
        {
            get { return (List<ExRatesNow>)RepeaterRatesMainCurrencies.DataSource; }
            set { RepeaterRatesMainCurrencies.DataSource = value; }
        }

        public override void DataBind()
        {
            RepeaterRatesMainCurrencies.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (Page.IsPostBack && (null == DataSource || DataSource.Count == 0))
            {
                SetNormalVisibility(false);
            }
            else
            {
                SetNormalVisibility(true);
            }
        }

		protected void SetNormalVisibility(bool isNormal)
		{
			RepeaterRatesMainCurrencies.Visible = isNormal;
		}

        protected void RepeaterRatesMainCurrencies_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;

            if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
                return;

            var element = item.DataItem as ExRatesNow;
            if (null == element)
                return;

            var litDate = RepeaterRatesMainCurrencies.Controls[0].Controls[0].FindControl("litDate") as Literal;
            if (litDate != null)
                litDate.Text = DateInfo;

            var litCurrencyName = item.FindControl("litCurrencyName") as Literal;
			if (litCurrencyName != null)
				litCurrencyName.Text = element.CurrencyName;

            var imgCurrency = item.FindControl("imgCurrency") as Image;
			if (imgCurrency != null)
			{
			    switch (element.CurCode)
			    {
			        case 840:
                        imgCurrency.ImageUrl = "~/Images/MainRates/currency_dollarblue_24x24.png";
			            break;
                    case 978:
			            imgCurrency.ImageUrl = "~/Images/MainRates/currency_euroblue_24x24.png";
			            break;
                    case 643:
			            imgCurrency.ImageUrl = "~/Images/MainRates/currency_roublebluenew_24x24.png";
			            break;
                    case 826:
			            imgCurrency.ImageUrl = "~/Images/MainRates/currency_poundblue_24x24.png";
			            break;
                    case 392:
			            imgCurrency.ImageUrl = "~/Images/MainRates/currency_yuanblue_24x24.png";
			            break;
			    }

			}

            var litRate = item.FindControl("litRate") as Literal;
            if (litRate != null)
                litRate.Text = Math.Round(element.Price, 2).ToString();

             var imgState = item.FindControl("imgState") as Image;
             if (imgState != null)
             {
                 switch (element.ChangeState)
                 {
                     case ChangeCurrencyState.Increased:
                         imgState.ImageUrl = "~/Images/MainRates/Up.png";
                         break;
                     case ChangeCurrencyState.Decreased:
                         imgState.ImageUrl = "~/Images/MainRates/Down.png";
                         break;
                     case ChangeCurrencyState.NotChanged:
                         imgState.ImageUrl = "~/Images/MainRates/Drow.png";
                         break;
                 }
             }
			
			 if (element.ChangeState != ChangeCurrencyState.NotChanged)
			 {
				 var litChange = item.FindControl("litChange") as Literal;
				 if (litChange != null)
					 litChange.Text = String.Format("( {0} руб. <=> {1} % )", Math.Round(element.PriceDifference, 2), Math.Round(element.ParcentChange, 2));
			 }
        }
    }
}