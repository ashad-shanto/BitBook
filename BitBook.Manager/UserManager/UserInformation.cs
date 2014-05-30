using BitBook.Model;
using BitBook.Repository.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BitBook.Manager.UserManager
{
    public class UserInformation
    {
        private readonly UserRepository repo;
        public UserInformation()
        {
            repo = new UserRepository();
        }
        public User GetUserById(string userId)
        {
            User aUser = new User();
            try
            {
                if(!string.IsNullOrWhiteSpace(userId))
                {
                    ObjectId id = new ObjectId(userId);
                    aUser = repo.GetById(id);
                }
                else
                {
                    aUser.UserName = null;
                    return aUser;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user");
            }
            return aUser;
        }
        public bool UpdateUserData(User aUser)
        {
            bool updateDone = false;
            try
            {
                if(string.IsNullOrWhiteSpace(aUser.UserName) || string.IsNullOrWhiteSpace(aUser.Email))
                {
                    return false;
                }
                else
                {
                    updateDone = repo.UpdateUserInformation(aUser);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("error updating user data" + ex);
            }
            return updateDone;
        }
        public bool UpdateProfilePic(string id, string photoName)
        {
            if(string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(photoName))
            {
                return false;
            }
            else
            {
                return repo.UpdateProfilePic(id, photoName);
            }
        }
    }
}
