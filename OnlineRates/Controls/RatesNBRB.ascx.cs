using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRates.Controls
{
    public partial class RatesNBRB : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var litDate = rptRates.Controls[0].Controls[0].FindControl("litDate") as Literal;
            if (litDate != null)
                litDate.Text = String.Format("Курс НБРБ на {0}", DateTime.Now.Date.ToString("dd'.'MM'.'yyyy"));
        }

        protected void rptRates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;

            if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
                return;

            var element = item.DataItem as DataRow;
            if (null == element)
                return;

            var litCode = item.FindControl("litCode") as Literal;
            if (litCode != null)
                litCode.Text = element["Cur_Abbreviation"].ToString();

            var litCurrency = item.FindControl("litCurrency") as Literal;
            if (litCurrency != null)
                litCurrency.Text = element["Cur_QuotName"].ToString();


            var litRate = item.FindControl("litRate") as Literal;
            if (litRate != null)
                litRate.Text = Convert.ToDouble(element["Cur_OfficialRate"].ToString()).Equals(0) ? "&infin;" : element["Cur_OfficialRate"].ToString();
        }

        public string DateInfo { get; set; }

        public List<DataRow> DataSource
        {
            get { return (List<DataRow>)rptRates.DataSource; }
            set { rptRates.DataSource = value; }
        }

        public override void DataBind()
        {
            rptRates.DataBind();
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
            rptRates.Visible = isNormal;
        }
    }
}