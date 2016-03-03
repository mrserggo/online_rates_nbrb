using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRates.Controls
{
    public partial class MetalsRates : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string DateInfo { get; set; }

        public List<DataRow> DataSource
        {
            get { return (List<DataRow>)rptMetalsRates.DataSource; }
            set { rptMetalsRates.DataSource = value; }
        }

        public override void DataBind()
        {
            rptMetalsRates.DataBind();
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
            rptMetalsRates.Visible = isNormal;
        }

        protected void rptMetalsRates_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if (null == item || (item.ItemType != ListItemType.Item && item.ItemType != ListItemType.AlternatingItem))
                return;

            var element = item.DataItem as DataRow;
            if (null == element)
                return;

            var litMetalName = item.FindControl("litMetalName") as Literal;
            if (null != litMetalName)
            {
                int metalId = Convert.ToInt32(element["MetalId"].ToString());
                switch (metalId)
                {
                    case 0:
                        litMetalName.Text = "Золото";
                        break;
                    case 1:
                        litMetalName.Text = "Серебро";
                        break;
                    case 2:
                        litMetalName.Text = "Платина";
                        break;
                    case 3:
                        litMetalName.Text = "Палладий";
                        break;
                    default:
                        litMetalName.Text = "Неизвестный металл";
                        break;
                }
            }

            var litWeight = item.FindControl("litWeight") as Literal;
            if (null != litWeight)
                litWeight.Text = String.Concat(element["Nominal"].ToString(), " г");

            var litBuy = item.FindControl("litBuy") as Literal;
            if (null != litBuy)
                litBuy.Text = String.Concat(element["CertificateRubles"].ToString(), " руб.");

            var Sale = item.FindControl("Sale") as Literal;
            if (null != litBuy)
                Sale.Text = String.Concat(element["EntitiesRubles"].ToString(), " руб.");
        }
    }

}