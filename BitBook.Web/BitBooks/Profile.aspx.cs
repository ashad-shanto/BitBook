using BitBook.Manager.UserManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitBook.Model;
using CodeCarvings.Piczard;
using MongoDB.Bson;
using BitBook.Manager.PostManager;

namespace BitBook.Web
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserId"] != null && Request["user"] != null)
            {
                if (Session["UserId"].ToString() != Request["user"].ToString())
                {
                    ImageButton.Visible = false; Update.Visible = false; stausField.Visible = false;
                }
                if (!this.IsPostBack)
                {
                    this.Upload.AutoOpenImageEditPopupAfterUpload = true;
                    this.Upload.CropConstraint = new FixedCropConstraint(300, 300);
                    this.Upload.CropConstraint.DefaultImageSelectionStrategy = CropConstraintImageSelectionStrategy.WholeImage;
                    this.Upload.PreviewFilter = new FixedResizeConstraint(150, 150);
                    ShowData();                    
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        private void ShowData()
        {
            try
            {
                UserInformation info = new UserInformation();
                User aUser = new User();
                aUser = info.GetUserById(Request["user"].ToString());
                Name.Text = aUser.UserName;
                Email.Text = aUser.Email;
                Location.Text = aUser.UserCity + ", " + aUser.UserCountry;
                if(aUser.ProfilePic != null)
                {
                    Image1.ImageUrl = "~/Images/Propic/" + aUser.ProfilePic;
                }
                
                List<Post> posts = new List<Post>();
                PostManage postMng = new PostManage();
                posts = postMng.GetAllByUserId(new ObjectId(Request["user"].ToString()));

                UserPosts.DataSource = posts;
                UserPosts.DataBind();
            }
            catch(Exception ex)
            {
                throw new Exception("Error retrieving data!");
            }
            finally
            {
                txtName.Text = Name.Text; txtName.Visible = false;
                txtEmail.Text = Email.Text; txtEmail.Visible = false;
                txtCity.Text = "Dhaka"; txtCity.Visible = false;
                txtCountry.Text = "Bangladesh"; txtCountry.Visible = false;
            }
        }

        protected void HideControl(object sender, EventArgs e)
        {
            txtName.Visible = true; txtEmail.Visible = true; txtCity.Visible = true; txtCountry.Visible = true;
            Update.Visible = false; Update2.Visible = true;
        }

        protected void Update2_Click(object sender, EventArgs e)
        {
            try
            {
                UserInformation info = new UserInformation();
                User aUser = new User();
                aUser._id = new ObjectId(Request["user"].ToString());
                aUser.UserName = txtName.Text;
                aUser.Email = txtEmail.Text;
                aUser.UserCity = txtCity.Text;
                aUser.UserCountry = txtCountry.Text;
                info.UpdateUserData(aUser);
            }
            catch
            {
                throw new Exception("Error in updating data!");
            }
            finally
            {
                ShowData(); Update.Visible = true; Update2.Visible = false;
            }
        }

        protected void ImageButton_Click(object sender, EventArgs e)
        {
            Upload.Visible = true;
            UpdateImage.Visible = true;
            ImageButton.Visible = false;
        }

        protected void UpdateImage_Click(object sender, EventArgs e)
        {
            if (Upload.HasImage)
            {
                string imgsource = Upload.SourceImageClientFileName;
                string imgoutname = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFileName("~/Images/ProPic/", imgsource);
                string imgoutpath = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFilePath("~/Images/ProPic/", imgsource);
                Upload.SaveProcessedImageToFileSystem(imgoutpath);
                this.Upload.SaveProcessedImageToFileSystem(imgoutpath, new JpegFormatEncoderParams(92));
                UserInformation info = new UserInformation();
                info.UpdateProfilePic(Session["UserId"].ToString(), imgoutname);
                ShowData();
            }
            Upload.Visible = false;
            UpdateImage.Visible = false;
            ImageButton.Visible = true;
        }

        protected void UserPost_Click(object sender, EventArgs e)
        {
            string imgoutname;
            if(PostPic.HasImage == true)
            {
                string imgsource = PostPic.SourceImageClientFileName;
                imgoutname = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFileName("~/Images/PostPic/", imgsource);
                string imgoutpath = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFilePath("~/Images/PostPic/", imgsource);
                PostPic.SaveProcessedImageToFileSystem(imgoutpath);
                this.PostPic.SaveProcessedImageToFileSystem(imgoutpath, new JpegFormatEncoderParams(92));
            }
            else
            {
                imgoutname = null;
            }
            UserInformation info = new UserInformation();
            User aUser = new User();
            aUser = info.GetUserById(Session["UserId"].ToString());
            Post aPost = new Post();
            aPost.PostBody = status.InnerText;
            aPost.PhotoName = imgoutname;
            aPost.PostedBy._id = aUser._id;
            aPost.PostedBy.Username = aUser.UserName;
            aPost.PostedBy.ProfilePic = aUser.ProfilePic;
            aPost.PostDate = DateTime.Now;

            PostManage manage = new PostManage();
            manage.CreateTextPost(aPost);
            status.InnerText = "";
            ShowData();
        }

        protected void UserPosts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Button delete = (Button)e.Item.FindControl("deleteBtn");
            if (e.CommandName == "Delete")
            {
                PostManage manage = new PostManage();
                manage.RemovePost(new ObjectId(e.CommandArgument.ToString()));
                ShowData();
            }
        }
    }
}