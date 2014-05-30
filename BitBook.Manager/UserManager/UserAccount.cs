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

        public string UserRegistration(User aUser)
        {
            string message = "";
            bool regSuccess = false;
            try
            {
                if (string.IsNullOrWhiteSpace(aUser.Email) || string.IsNullOrWhiteSpace(aUser.Password) || string.IsNullOrWhiteSpace(aUser.UserName))
                {
                    return message = "incorrectdata";
                }
                else if(!IsValidMailAddress(aUser.Email))
                {
                    return message = "invalidemail";
                }
                else
                {
                    aUser._id = new ObjectId();
                    aUser.JoinDate = DateTime.Now;
                    aUser.Friends = new List<UserBasic>();
                    
                    regSuccess = repo.Add(aUser);
                    if (regSuccess)
                    {
                        message = "success";
                    }
                    else
                    {
                        message = "regfailed";
                    }
                }
                return message;
            }
            catch (Exception ex)
            {

                throw new Exception("Error In Registration Process" + ex);
            }
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
