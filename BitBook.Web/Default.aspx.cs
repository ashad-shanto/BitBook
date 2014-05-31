using BitBook.Manager.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitBook.Model;
using MongoDB.Bson;

namespace BitBook.Web
{
    public partial class _Default : Page
    {
        private UserAccount account;
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
            }
        }

        private string message;
        public string ValidateLoginForm(string email, string password) 
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email)) 
            {
                message += "Email Is Required \n";
            }

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                message += "Password Is Required";
            }

            return message;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            message = "";
            message = ValidateLoginForm(SignInEmailTextBox.Text, SignInPasswordTextox.Text);

            if (message != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ValidateForm();", true);
            }


            account = new UserAccount();
            try
            {
                user = account.UserLogin(SignInEmailTextBox.Text.ToString(), SignInPasswordTextox.Text.ToString());
                if(user.UserName == null)
                {
                    //Alert.Text = "Invalid username or password!";
                }
                else
                {
                    Session["UserId"] = user._id;
                    Session["LoggedInUser"] = user.UserName;
                }                
            }
            catch (Exception ex)
            {
                //need to build this page
                Response.Redirect("Error.aspx");
            }
            finally
            {
                if(Session["UserId"] != null)
                {
                    Response.Redirect("~/BitBooks/Profile.aspx?user=" + user._id, false);
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectId userId = new ObjectId();
                user = new User();
                user.UserName = SignUpUserNameTextBox.Text;
                user.Email = SignUpEmailTextBox.Text;
                user.Password = SignUpPasswordTextBox.Text;

                account = new UserAccount();
                userId = account.UserRegistration(user);
                Session["UserId"] = userId;
                Response.Redirect("~/BitBooks/Profile.aspx?user=" + userId);
               
                
                //redirect to login page
            }
            catch (Exception ex)
            {
                //add error page
                Response.Redirect("");
            }
        }


        private void Clear()
        {
            SignInEmailTextBox.Text = "";
            SignInPasswordTextox.Text = "";

            SignUpUserNameTextBox.Text = "";
            SignUpEmailTextBox.Text = "";
            SignUpPasswordTextBox.Text = "";
            SignUpConfirmPasswordTextBox.Text = "";
        }
    }
}