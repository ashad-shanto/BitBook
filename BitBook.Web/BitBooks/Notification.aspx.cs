using BitBook.Manager.NotificationManager;
using BitBook.Manager.UserManager;
using BitBook.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitBook.Web.BitBooks
{
    public partial class Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                RptrBind();
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        public void RptrBind()
        {
            List<BitBook.Model.Notification> notifications = new List<BitBook.Model.Notification>();
            NotificationManage notMng = new NotificationManage();
            notifications = notMng.GetAllNotifications(new ObjectId(Session["UserId"].ToString()));

            NotifyRpt.DataSource = notifications;
            NotifyRpt.DataBind();
        }

        protected void NotifyRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            NotificationManage manage = new NotificationManage();
            LinkButton mark = (LinkButton)e.Item.FindControl("markButton");
            if (e.CommandName == "checkNotification")
            {
                
                manage.UpdateNotificationStatus(new ObjectId(e.CommandArgument.ToString()));
                RptrBind();
            }
            if (e.CommandName == "addFriend")
            {
                BitBook.Model.Notification notify = new BitBook.Model.Notification();
                UserInformation info = new UserInformation();
                notify = manage.GetNotificationById(new ObjectId(e.CommandArgument.ToString()));
                if(notify.Status == 0 || notify.Status == 1)
                {
                    UserBasic aUser = new UserBasic();
                    aUser._id = notify.Friend._id;
                    aUser.ProfilePic = notify.Friend.ProfilePic;
                    aUser.Username = notify.Friend.Username;
                    if(info.AddFriend(new ObjectId(Session["UserId"].ToString()), aUser))
                    {
                        manage.UpdateNotificationStatus(new ObjectId(e.CommandArgument.ToString()));   
                    }
                    RptrBind();
                }
                else
                {
                    Response.Redirect("~/BitBooks/Notification.aspx", false);
                }
            }
        }
    }
}