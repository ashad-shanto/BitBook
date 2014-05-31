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
                      Query<Notification>.EQ(e => e.NotificationFor, userId),
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
                var query = Query.And(
                      Query<Notification>.EQ(e => e.NotificationFor, userId),
                      Query<Notification>.EQ(e => e.Status, 0)
                  );
                allNotification = Collection.FindAs<Notification>(query).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching notifications" + ex);
            }
            return allNotification;
        }


        public bool UpdateNotificationStatus(ObjectId nId)
        {
            bool done = false;
            try
            {
                var query = Collection.Update(Query<Notification>.EQ(u => u._id, nId), Update<Notification>.Set(u => u.Status, 1));
                done = true;
            }
            catch (Exception ex)
            {
                throw new Exception(""+ex);
            }
            return done;
        }
        public Notification GetNotificationById(ObjectId nId)
        {
            Notification aNotification = new Notification();
            try
            {
                aNotification = Collection.FindAs<Notification>(Query<Notification>.EQ(n => n._id, nId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error"+ex);
            }
            return aNotification;
        }
    }
}
