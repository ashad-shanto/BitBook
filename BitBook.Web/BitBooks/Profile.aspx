<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="BitBook.Web.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        //<![CDATA[
        function fvPicture1_Validate(sender, args) {
            // Validate the Picture1 (must contain a value)
            args.IsValid = CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_hasImage("<%= CodeCarvings.Piczard.Web.Helpers.JSHelper.EncodeString(this.Upload.ClientID) %>");;
        }
        function btnSave_clientClick() {
            if (CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_uploadInProgress()) {
                alert("Upload in progress, please wait...");
                return false;
            }

            return true;
        }
     </script>
</asp:Content>

<asp:Content ID="body" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="panel1">
        <div class="row">
            <div class="large-4 columns profile-banner">
                <ul class="inline-list">
                    <li><%--username--%>
                        <h4>
                            <a href="Profile.aspx">
                                <asp:Label ID="Name" runat="server"></asp:Label>
                            </a>
                            <asp:TextBox ID="txtName" runat="server" Visible="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="namevalid" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="One"></asp:RequiredFieldValidator>
                        </h4>
                    </li>
                    <li>
                        <%--update profile button--%>
                        <%--update info button 1--%>
                        <%--button 2 @ line 63--%>
                        <asp:Button ID="Update" CssClass="image-button-edit relative-for-container-effect" runat="server" OnClick="HideControl" />
                    </li>
                </ul>

                <div class="bordered-background content-centered">
                    <%--profile image--%>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ProPic/default.png" Height="280" Width="280" />
                    <ccPiczardUC:SimpleImageUpload ID="Upload" runat="server" Visible="false" />
                    <asp:Button ID="ImageButton" CssClass="image-button-edit-image" runat="server" OnClick="ImageButton_Click" />
                    <asp:Button ID="UpdateImage" runat="server" OnClick="UpdateImage_Click" Visible="false" />
                </div>

                <%--email--%>
                <p>
                    <label>Email</label>
                    <asp:Label ID="Email" runat="server"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="emailvalid" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="One"></asp:RequiredFieldValidator>
                </p>
                <%--location--%>
                <p>
                    <label>Location</label>
                    <asp:Label ID="Location" runat="server" Text="Dhaka, Bangladesh"></asp:Label>
                    <asp:TextBox ID="txtCity" runat="server" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="cityvalid" runat="server" ErrorMessage="*" ControlToValidate="txtCity" ValidationGroup="One"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtCountry" runat="server" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="countryvalid" runat="server" ErrorMessage="*" ControlToValidate="txtCountry" ValidationGroup="One"></asp:RequiredFieldValidator>
                </p>
                <%--update info button 2--%>
                <asp:Button ID="Update2" runat="server" Visible="false" Text="Update" OnClick="Update2_Click" ValidationGroup="One" />

                <%--friend list--%>
                <h4><%= Name.Text %>'s Friend's</h4>
                <ul>
                    <asp:Repeater ID="FriendList" runat="server">
                        <ItemTemplate>
                            <li><a href="#">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="large-8 columns">
                <div class="self-stream">
                    <h3><%= Name.Text %>'s Stream</h3>
                    <textarea id="status" runat="server" placeholder="Insert your bits"></textarea>
                    <asp:Button ID="UserPost" runat="server" CssClass="button" Text="Update bits" OnClick="UserPost_Click" />
                </div>
                <ul>
                    <asp:Repeater ID="UserPosts" runat="server">
                        <ItemTemplate>
                            <li><a href="#">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
