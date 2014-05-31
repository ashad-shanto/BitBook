using BitBook.Model;
using BitBook.Repository.DataAccess;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BitBook.Manager.UserManager
{
    public class UserAccount
    {
        private readonly UserRepository repo;

        public UserAccount()
        {
            repo = new UserRepository();
        }

        public ObjectId UserRegistration(User aUser)
        {

            ObjectId userId = new ObjectId();
            try
            {
                aUser._id = new ObjectId();
                aUser.JoinDate = DateTime.Now;
                aUser.Friends = new List<UserBasic>();
                userId = repo.AddUser(aUser);            
            }
            catch (Exception ex)
            {
                throw new Exception("Error In Registration Process" + ex);
            }
            return userId;
        }
        public User UserLogin(string email, string passWord)
        {
            User aUser = new User();
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(passWord))
                {
                    aUser.UserName = null;
                }
                else
                {
                    aUser = repo.UserLogin(email, passWord);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in login process");
            }
            return aUser;
        }
        //Return true if mail id is already in use
        public bool CheckEmailValidity(string email)
        {
            bool used = false;
            try
            {
                used = repo.CheckEmailValidity(email);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error"+ex);
            }
            return used;
        }
        //Return true is mail id is valid
        private bool IsValidMailAddress(string email)
        {
            Regex mailRegx = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            bool valid = false;
            try
            {
                valid = mailRegx.IsMatch(email);
            }
            catch (Exception)
            {
                throw new Exception("Error checking email structure");
            }
            
            return valid;
        }
    }
}
