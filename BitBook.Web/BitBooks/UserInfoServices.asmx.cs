using BitBook.Manager.UserManager;
using BitBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BitBook.Web.BitBooks
{
    /// <summary>
    /// Summary description for UserInfoServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserInfoServices : System.Web.Services.WebService
    {

        private UserInformation users;
        private List<User> filteredUser;

        [WebMethod]
        public List<string> GetAllUsers(string txt)
        {
            users = new UserInformation();
            List<string> userName = new List<string>();

            foreach (User user in users.SearchUserByMatchingName(txt))
            {
                userName.Add(user.UserName);
            }

            return userName;
        }
 
    }
}
