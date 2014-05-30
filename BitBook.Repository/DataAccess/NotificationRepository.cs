using BitBook.Model;
using BitBook.Repository.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.DataAccess
{
    public class NotificationRepository : DataRepository<Notification>, INotificationRepository
    {
        public int CountUnreadNotifications(ObjectId userId)
        {
            int count = 0;
            try
            {
                var query = Query.And(
                      Query<Notification>.EQ(e => e._id, userId),
                      Query<Notification>.EQ(e => e.Status, 0)
                  );
                count = (int)Collection.FindAs<Notification>(query).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(""+ex);
            }
            return count;
        }
        public List<Notification> GetAllNotification(ObjectId userId)
        {
            List<Notification> allNotification = new List<Notification>();
            try
            {
                allNotification = Collection.FindAs<Notification>(Query<Notification>.EQ(n => n._id, userId)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetching notifications" + ex);
            }
            return allNotification;
        }
    }
}
