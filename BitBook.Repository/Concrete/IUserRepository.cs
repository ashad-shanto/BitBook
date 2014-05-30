using BitBook.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.Concrete
{
    public interface IUserRepository
    {
        User UserLogin(string userName, string userPass);
        User GetById(ObjectId id);
        List<User> SearchUserByMatchingName(string nameChunk);
        bool UpdateUserInformation(User aUser);
        bool UpdateProfilePic(string id, string photoName);
        ObjectId AddUser(User aUser);
        bool CheckUserExist(ObjectId id);
        bool AddFriend(ObjectId userId, UserBasic friend);
        bool RemoveFriend(ObjectId id, UserBasic friend);
        bool CheckEmailValidity(string email);
        bool CheckFriendship(ObjectId userId, ObjectId anotherUserId);
    }
}
