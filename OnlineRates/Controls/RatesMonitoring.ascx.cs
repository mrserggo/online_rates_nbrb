using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Data;

namespace OnlineRates.Controls
{
    public partial class RatesMonitoring : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string RateInfo { get; set; }
        public bool Is1stCurrencyMonitor { get; set; }

        public List<DataRow> DataSource
        {
            get { return (List<DataRow>)rptRatesMonitoring.DataSource; }
            set { rptRatesMonitoring.DataSource = value; }
        }

        public override void DataBind()
        {
            rptRatesMonitoring.DataBind();
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
            rptRatesMonitoring.Visible = isNormal;
        }

        protected void rptRatesMonitoring_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;

            if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
                return;

            var element = item.DataItem as DataRow;
            if (null == element)
                return;

            var litTitle = rptRatesMonitoring.Controls[0].Controls[0].FindControl("litTitle") as Literal;
            if (litTitle != null)
                litTitle.Text = RateInfo;

            var litCurrencyValue = item.FindControl("litCurrencyValue") as Literal;
            var litDate = item.FindControl("litDate") as Literal;

            if (Is1stCurrencyMonitor)
            {
                if (litCurrencyValue != null)
                    litCurrencyValue.Text = element["Cur_OfficialRate"].ToString();

                if (litDate != null)
                    litDate.Text = DateTime.Parse(element["Date"].ToString()).ToString("dd'.'MM'.'yyyy");

            }
            else
            {
                if (litCurrencyValue != null)
                    litCurrencyValue.Text = element["Price"].ToString();

                if (litDate != null)
                    litDate.Text = DateTime.Parse(element["Date"].ToString()).ToString("dd'.'MM'.'yyyy");
            }
        }
    }
}