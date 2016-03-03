using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace OnlineRates.Logic
{
	public class CustomersManager
	{
		 private OnlineRatesDataContext dContext = new OnlineRatesDataContext();
        // создание объекта контекста в конструкторе
		 public CustomersManager()
        {
			dContext = new OnlineRatesDataContext();
        }

//*******работа с таблицей клиентов Begin********//

        // метод добавления нового пользователя
        public void InsertCustomer(Customer newCustomer)
        {
            Table<Customer> customerlist = dContext.GetTable<Customer>();
            customerlist.InsertOnSubmit(newCustomer);
            dContext.SubmitChanges();
        }

        // метод проверки уникальности логина
        public Boolean IsLoginUnique(string login)
        {
            int countLogin = (from customer in dContext.Customers
                     where customer.Login == login 
                     select customer).Count();
            switch (countLogin)
            {
                case 0: return true;
                case 1: return false;
                default: return false;
            }
        }

        // метод проверки корректности атрибутов доступа пользователя
        public Boolean IsAccess(string login, string password)
        {
            int countCustomer = (from customer in dContext.Customers
                              where (customer.Login == login)&&(customer.Password == password)
                              select customer).Count();
            switch (countCustomer)
            {
                case 1: return true;
                default: return false;
            }
        }

        // метод получения ФИО пользователя по логину
        public string GetFullNameByLogin(string login)
        {
            Table<Customer> customerList = dContext.GetTable<Customer>();
            string fullName = customerList.Single(
                customer => customer.Login == login).FullName;

            return fullName;
        }
//*******работа с таблицей клиентов End********//
	}
}