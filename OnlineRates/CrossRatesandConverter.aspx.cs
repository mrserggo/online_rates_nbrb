using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Data;
using OnlineRates.Logic;

namespace OnlineRates
{
    public partial class CrossRatesandConverter : System.Web.UI.Page
    {
        NBRBManager nbrbManager = new NBRBManager();
        ExRates exRates = new ExRates();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dataEURO = exRates.ExRatesDyn(19, DateTime.Now.Date, DateTime.Now.Date);
                var dataUSD = exRates.ExRatesDyn(145, DateTime.Now.Date, DateTime.Now.Date);
                var dataRUB = exRates.ExRatesDyn(190, DateTime.Now.Date, DateTime.Now.Date);
                
                if ((dataEURO != null)&&(dataUSD != null)&&(dataRUB != null))
                {
                    double EUR =
                        Convert.ToDouble(
                            dataEURO.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]); 
                    double USD =
                        Convert.ToDouble(
                            dataUSD.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]); 
                    double RUB =
                        Convert.ToDouble(
                            dataRUB.Tables[0].Select(null, null, DataViewRowState.CurrentRows)[0]["Cur_OfficialRate"]); 
                    lblEUR_RUB.Text = Math.Round(EUR / RUB, 3).ToString();
                    lblEUR_USD.Text = Math.Round(EUR / USD, 3).ToString();
                    lblRUB_EUR.Text = Math.Round(RUB / EUR, 3).ToString();
                    lblRUB_USD.Text = Math.Round(RUB / USD, 3).ToString();
                    lblUSD_EUR.Text = Math.Round(USD / EUR, 3).ToString();
                    lblUSD_RUB.Text = Math.Round(USD / RUB, 3).ToString();

					lblcrossTitle.Text = String.Format("Кросс-курсы валют на {0}", DateTime.Now.Date.ToString("dd'.'MM'.'yyyy"));
                }

            }

			Literal ltr1 = new Literal();
			Literal ltr2 = new Literal();
			List<DDLImage> lstDDLImage = DDLConverter.GetDDLImage();
			for (int i = 0; i < lstDDLImage.Count; i++)
			{
				ltr1.Text = ltr1.Text + "<span class='ddlText' id='" + lstDDLImage[i].ddlId + "' onclick='GetSelectedValue1(this);'>" + lstDDLImage[i].ddlImgPath + lstDDLImage[i].ddlText + "</span>" + "<br/>";
				ltr2.Text = ltr2.Text + "<span class='ddlText' id='" + lstDDLImage[i].ddlId + "' onclick='GetSelectedValue2(this);'>" + lstDDLImage[i].ddlImgPath + lstDDLImage[i].ddlText + "</span>" + "<br/>";
			}
			effect1.Controls.Add(ltr1);
			effect2.Controls.Add(ltr2);

            //gvData.DataSource = exRates.CurrenciesRef(0).Tables[0];
            //gvData.DataBind();
        }

        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
            //FormsAuthentication.RedirectToLoginPage();
        }

        protected void imgConvert_Click(object sender, ImageClickEventArgs e)
        {
            double result = 0;
            if ((hidValue1.Value != String.Empty) && (hidValue2.Value != String.Empty))
            {
                Convert.ToDouble(tbConvertValue1.Text);
                if (nbrbManager.ConvertCurrency(Convert.ToInt32(hidValue1.Value), Convert.ToInt32(hidValue2.Value), Convert.ToDouble(tbConvertValue1.Text), ref result))
                    tbConvertValue2.Text = result.ToString();
            }
            else
                tbConvertValue2.Text = "Error";
        }
    }
}