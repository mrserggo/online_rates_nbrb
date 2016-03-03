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
    public partial class ControlForAddRate : System.Web.UI.UserControl
    {
        public int BankIdAdd { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MinskRatesManager manager = new MinskRatesManager();
                // заполнение выпадающего списка банками, для которых
                // возможно добавить информацию о курсах валют на сегодня

                List<ListItem> lItemBanks = new List<ListItem>();
                var listFreeBankId = manager.GetListBankIdNonRatesToday();

                foreach (var bankId in listFreeBankId)
                {
                    lItemBanks.Add(new ListItem(manager.GetBankNameById(bankId), bankId.ToString()));
                }
                ddlFreeBanksToAddRateToday.Items.AddRange(lItemBanks.OrderBy(bank => bank.Text).ToArray());
            }
        }

        protected void ibtnSaveAddedRate_Click(object sender, ImageClickEventArgs e)
        {
       
            if (ddlFreeBanksToAddRateToday.SelectedValue != String.Empty)
            {
                var bankId = int.Parse(ddlFreeBanksToAddRateToday.SelectedValue);

                    RateInBank rb = new RateInBank(-1, bankId, Convert.ToDouble(tbUSDBuying.Text),
                                                   Convert.ToDouble(tbUSDSelling.Text),
                                                   Convert.ToDouble(tbEURBuying.Text),
                                                   Convert.ToDouble(tbEURSelling.Text),
                                                   Convert.ToDouble(tbRUBBuying.Text),
                                                   Convert.ToDouble(tbRUBSelling.Text), DateTime.Now.Date);
                   
                    MinskRatesManager manager = new MinskRatesManager();
                    manager.AddRatesInBank(rb);
                    Response.Redirect("RatesInBanks.aspx");
            }

        }

        protected void ibtnCansel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RatesInBanks.aspx");
        }
    }
}