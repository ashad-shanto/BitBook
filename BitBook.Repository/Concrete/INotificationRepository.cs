using BitBook.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBook.Repository.Concrete
{
    public interface INotificationRepository
    {
        int CountUnreadNotifications(ObjectId userId);
        List<Notification> GetAllNotification(ObjectId userId);
    }
}
