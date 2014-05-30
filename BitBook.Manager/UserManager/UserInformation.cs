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

        //Return True if user exist
        public bool UserExists(ObjectId userId)
        {
            return repo.CheckUserExist(userId);
        }
        //Return True if email is already in use
        public bool CheckEmailValidity(string email)
        {
            if(!string.IsNullOrWhiteSpace(email))
            {
                return repo.CheckEmailValidity(email);
            }
            else
            {
                return false;
            }
        }
        public List<User> SearchUserByMatchingName(string nameChunk)
        {
            List<User> allMatchedUser = new List<User>();
            try
            {
                allMatchedUser = repo.SearchUserByMatchingName(nameChunk);
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding users" + ex);
            }
            return allMatchedUser;
        }
        public bool CheckFriendShip(ObjectId userId, ObjectId anotherId)
        {
            try
            {
                return repo.CheckFriendship(userId, anotherId);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error friendship checking process");
            }
        }
        public bool AddFriend(ObjectId userId, UserBasic friend)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId.ToString()) || string.IsNullOrWhiteSpace(friend._id.ToString()))
                {
                    return false;
                }
                else
                {
                    return repo.AddFriend(userId, friend);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding friend");
            } 
        }
        public bool RemoveFriend(ObjectId id, UserBasic friend)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(friend._id.ToString()))
                {
                    return false;
                }
                else
                {
                    return repo.RemoveFriend(id, friend);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding friend");
            } 
        }
        public User GetByUserName(string userName)
        {
            User aUser = new User();
            try
            {
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    aUser = repo.GetByUserName(userName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error"+ex);
            }
            return aUser;
            
        }
    }
}
