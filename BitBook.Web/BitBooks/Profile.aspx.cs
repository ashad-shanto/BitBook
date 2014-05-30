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

namespace BitBook.Web
{
    public partial class Profile : System.Web.UI.Page
    {
        public string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserId"] != null)
            {
                id = Session["UserId"].ToString();
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
                aUser = info.GetUserById(id);
                Name.Text = aUser.UserName;
                Email.Text = aUser.Email;
                Location.Text = aUser.UserCity + ", " + aUser.UserCountry;
                if(aUser.ProfilePic != null)
                {
                    Image1.ImageUrl = "~/Images/Propic/" + aUser.ProfilePic;
                }
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
                aUser._id = new ObjectId(Session["UserId"].ToString());
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
    }
}