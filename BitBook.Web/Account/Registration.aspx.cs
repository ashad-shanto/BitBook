using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitBook.Model;
using BitBook.Manager.UserManager;

namespace BitBook.Web.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Clear();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try {
                User newUser = new User();
                newUser.UserName = UserNameTextBox.Text;
                newUser.Email = EmailTextBox.Text;
                newUser.Password = PasswordTextBox.Text;

                UserAccount account = new UserAccount();
                account.UserRegistration(newUser);

                //redirect to login page

            } catch(Exception ex){
                //add error page
                Response.Redirect("");
            }
        }

        private void Clear() 
        {
            UserNameTextBox.Text = "";
            EmailTextBox.Text = "";
            PasswordTextBox.Text = "";
        }



    }
}