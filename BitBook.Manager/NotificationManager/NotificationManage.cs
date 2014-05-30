using BitBook.Model;
using BitBook.Repository.DataAccess;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Manager.NotificationManager
{
    public class NotificationManage
    {
        private readonly NotificationRepository repo;
        public NotificationManage()
        {
            repo = new NotificationRepository();
        }
        public bool AddNotification(Notification aNotification)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(aNotification.NotificationFor.ToString()) || string.IsNullOrWhiteSpace(aNotification.Friend._id.ToString()))
                {
                    return false;
                }
                else
                {
                    return repo.Add(aNotification);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public int CountUnreadNotifications(ObjectId userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId.ToString()))
                {
                    return 0;
                }
                else
                {
                    return repo.CountUnreadNotifications(userId);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error counting notification" + ex);
            } 
        }
        public List<Notification> GetAllNotifications(ObjectId userId)
        {
            List<Notification> allNotification = new List<Notification>();
            try
            {
                allNotification = repo.GetAllNotification(userId);
            }
            catch (Exception ex)
            {                
                throw new Exception("Error fetching notifications" + ex);
            }
            return allNotification;
        }
    }
}
