using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineRates.Logic;

namespace OnlineRates
{
	public partial class Default : System.Web.UI.Page
	{
		private CustomersManager customerManager = new CustomersManager();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				MV_RegAuth.ActiveViewIndex = 0;

			if (Request.QueryString["Registration"] == "true")
				MV_RegAuth.ActiveViewIndex = 1;
		}

		protected void ibtnAuthorization_Click(object sender, ImageClickEventArgs e)
		{
			Page.Validate();
			if (!Page.IsValid) return;
			if (customerManager.IsAccess(tbLogin.Text, tbPassword.Text))
			{
				HttpCookie AuthCookie;
				AuthCookie = FormsAuthentication.GetAuthCookie(tbLogin.Text, true);
				AuthCookie.Expires = DateTime.Now.AddDays(1);
				Response.Cookies.Add(AuthCookie);
				Response.Redirect(FormsAuthentication.GetRedirectUrl(tbLogin.Text, true));
			}
			else
			{
				LegendStatus.Text = "Неверное имя пользователя или пароль!";
			}
		}

		protected void ibtnRegister_Click(object sender, ImageClickEventArgs e)
		{
			Page.Validate();
			if (!Page.IsValid) return;

			// проверка на уникальность логина
			if (customerManager.IsLoginUnique(tbLogin_.Text))
			{
				// создаем объект пользователя
				Customer customernew = new Customer();
				customernew.Login = tbLogin_.Text;
				customernew.Password = tbPassword_.Text;
				customernew.FullName = tbFullName.Text;
				customernew.Phone = tbPhone.Text;
				// сохранение информации о новом пользователе в БД с последующей  
				// авторизацией и перенаправлением на страницу личного кабинета
				customerManager.InsertCustomer(customernew);

				//// Создать cookie-набор аутентификации
				HttpCookie AuthCookie;
				AuthCookie = FormsAuthentication.GetAuthCookie(tbLogin.Text, true);

				// устанавливаем время действия аутентификации
				AuthCookie.Expires = DateTime.Now.AddDays(1);

				// Добавить cookie-набор в ответ
				Response.Cookies.Add(AuthCookie);
				FormsAuthentication.RedirectFromLoginPage(tbLogin_.Text, true);
			}
			else lblError.Text = "Пожалуйста, выберите другой логин";
		}
	}
}