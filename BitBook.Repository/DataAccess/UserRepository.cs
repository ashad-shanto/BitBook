using BitBook.Model;
using BitBook.Repository.Concrete;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.DataAccess
{
    public class UserRepository : DataRepository<User>, IUserRepository
    {
        public User UserLogin(string email, string userPass)
        {
            User aUser = new User();
            try
            {
                var query = Query.And(
                      Query<User>.EQ(e => e.Email, email),
                      Query<User>.EQ(e => e.Password, userPass)
                  );
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Exclude(u => u.Password)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Login error" + ex);
            }
            return aUser;
        }
        public User GetById(ObjectId id)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e._id, id);
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Exclude(u => u.Password)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }

        public List<User> SearchUserByMatchingName(string nameChunk)
        {
            List<User> allMatchingUsers = new List<User>();
            try
            {
                if (!string.IsNullOrWhiteSpace(nameChunk))
                {
                    nameChunk = string.Format("^{0}", nameChunk);
                    allMatchingUsers = Collection.FindAs<User>(Query.Matches("UserName", new BsonRegularExpression(nameChunk, "i"))).SetFields(Fields<User>.Include(u => u.UserName, u => u.ProfilePic)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error getting users");
            }
            return allMatchingUsers;
        }


        public bool UpdateUserInformation(User aUser)
        {
            bool modifySuccess = false;
            try
            {
                var aUserData = Collection.FindAndModify(Query<User>.EQ(u => u._id, aUser._id), SortBy<User>.Ascending(u => u.UserName), Update<User>.Set(u => u.UserName, aUser.UserName)
                .Set(u => u.Email, aUser.Email).Set(u => u.UserCity, aUser.UserCity).Set(u => u.UserCountry, aUser.UserCountry), true);
                if (aUserData != null)
                    modifySuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error modifying data" + ex);
            }
            return modifySuccess;

        }

        public bool UpdateProfilePic(string id, string photoName)
        {
            bool modifySuccess = false;
            ObjectId userId = new ObjectId(id);
            try
            {
                var aUserData = Collection.FindAndModify(Query<User>.EQ(u => u._id, userId), SortBy<User>.Ascending(u => u.UserName), Update<User>.Set(u => u.ProfilePic, photoName), true);
                if (aUserData != null)
                    modifySuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error modifying data" + ex);
            }
            return modifySuccess;
        }


        public ObjectId AddUser(User aUser)
        {
            try
            {
                Collection.Insert(aUser);
                return aUser._id;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool CheckUserExist(ObjectId id)
        {
            bool exist = false;
            try
            {
                int result = (int)Collection.FindAs<User>(Query<User>.EQ(u => u._id, id)).Count();
                if (result > 0)
                    exist = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking data" + ex);
            }
            return exist;
        }
        public bool AddFriend(ObjectId userId, UserBasic friend)
        {
            bool addSuccess = false;
            try
            {
                var query = Collection.Update(Query<User>.EQ(u => u._id, userId), Update<User>.AddToSet(u => u.Friends, friend));
                addSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding data" + ex);
            }
            return addSuccess;
        }
        public bool RemoveFriend(ObjectId id, UserBasic friend)
        {
            bool removeSuccess = false;
            try
            {
               
                var quer = Collection.Update(Query<User>.EQ(u => u._id, id), Update<User>.Pull(u => u.Friends, friend));
                removeSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error removing data" + ex);
            }
            return removeSuccess;
        }
        //Return true if email is already in use
        public bool CheckEmailValidity(string email)
        {
            bool exist = false;
            try
            {
                int result = (int)Collection.FindAs<User>(Query<User>.EQ(u => u.Email, email)).Count();
                if (result > 0)
                    exist = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking data" + ex);
            }
            return exist;
        }


        //Return true if both are friends
        public bool CheckFriendship(ObjectId userId, ObjectId anotherUserId)
        {
            int result = 0;
            try
            {
                var query = Query.And(
                      Query.EQ("_id", userId),
                      Query.EQ("Friends._id", anotherUserId)
                  );

                result = (int)Collection.Find(query).Count();
                if (result > 0)
                    return true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking friendship");
            }
            return false;
        }
        public User GetByUserName(string userName)
        {
            User aUser = new User();
            try
            {
                var query = Query<User>.EQ(e => e.UserName, userName);
                aUser = Collection.FindAs<User>(query).SetFields(Fields<User>.Include(u => u._id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user data" + ex);
            }
            return aUser;
        }
    }
}

