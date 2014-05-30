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
                if (string.IsNullOrWhiteSpace(aUser.Email) || string.IsNullOrWhiteSpace(aUser.Password) || string.IsNullOrWhiteSpace(aUser.UserName))
                {
                    return new ObjectId("0");
                }
                else if(!IsValidMailAddress(aUser.Email))
                {
                    return new ObjectId("0");
                }
                else
                {
                    aUser._id = new ObjectId();
                    aUser.JoinDate = DateTime.Now;
                    aUser.Friends = new List<UserBasic>();
                    
                    userId = repo.AddUser(aUser);
                    if (userId != new ObjectId("0"))
                    {
                        return userId;
                    }
                    else
                    {
                        return new ObjectId("0");
                    }
                }
                
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
        private bool IsValidMailAddress(string email)
        {
            Regex mailRegx = new Regex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
            bool valid = false;
            valid = mailRegx.IsMatch(email);
            return valid;
        }
    }
}
