using ProjectStructureExample2019.Models;
using ProjectStructureExample2019.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectStructureExample2019.Controllers
{
    [Authorize(Roles = "Account Manager")]
    public class AccountManagerController : ApiController
    {
        AccountManagerRepository db = new AccountManagerRepository();

        public AccountUserViewModel getAccounts()
        {
            var currentuser = db.getUserByName(User.Identity.Name);
            if (currentuser != null) {
                var CurrnetUserPortfoliio = db.GetAccountsByUser(currentuser.Id);
                if(CurrnetUserPortfoliio.accounts.Count() < 1)
                {
                    var  msg = new HttpResponseMessage(HttpStatusCode.OK)
                                { ReasonPhrase = "There are no accounts to manage for this user " };
                    throw new HttpResponseException(msg);
                }
                return CurrnetUserPortfoliio;
            }
            var msg1 = new HttpResponseMessage(HttpStatusCode.BadRequest)
                            { ReasonPhrase = "User is not an account manager " };
            throw new HttpResponseException(msg1);



        }
        
    }
}
