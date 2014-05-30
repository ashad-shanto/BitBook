﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="BitBook.Web.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
            //<![CDATA[
        function fvPicture1_Validate(sender, args) {
            // Validate the Picture1 (must contain a value)
            args.IsValid = CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_hasImage("<%= CodeCarvings.Piczard.Web.Helpers.JSHelper.EncodeString(this.Upload.ClientID) %>"); ;
        }
        function btnSave_clientClick() {
            if (CodeCarvings.Wcs.Piczard.Upload.SimpleImageUpload.get_uploadInProgress()) {
                alert("Upload in progress, please wait...");
                return false;
            }

            return true;
        }
            //]]>
     </script>
</asp:Content>

<asp:Content ID="body" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="panel1">
        <div style="float:left; height:auto; width:30%;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/ProPic/default.png" Height="200px" Width="200px" />
            <ccPiczardUC:SimpleImageUpload ID="Upload" runat="server" Visible="false" />
            <asp:Button ID="ImageButton" runat="server" Text="Update Profile Picture" OnClick="ImageButton_Click" />
            <asp:Button ID="UpdateImage" runat="server" Text="Upload" OnClick="UpdateImage_Click" Visible="false" />
        <h2 style="text-align:left;">
            <asp:Label ID="Name" runat="server" Text="Moinul Hasan"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="namevalid" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="One"></asp:RequiredFieldValidator>
        </h2>
        <p>
            Email: <asp:Label ID="Email" runat="server" Text="shu@gmail.com"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailvalid" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="One"></asp:RequiredFieldValidator>
        </p>
        <p>
            Location: <asp:Label ID="Location" runat="server" Text="Dhaka, Bangladesh"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="cityvalid" runat="server" ErrorMessage="*" ControlToValidate="txtCity" ValidationGroup="One"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCountry" runat="server" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="countryvalid" runat="server" ErrorMessage="*" ControlToValidate="txtCountry" ValidationGroup="One"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="Update" runat="server" Text="Update Profile" OnClick="HideControl" />
            <asp:Button ID="Update2" runat="server" Visible="false" Text="Update" OnClick="Update2_Click" ValidationGroup="One" />
        </p>
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
        <div style="float:left; height:auto; width:70%;">
            <div style="width:80%; margin: 0 auto">
                <textarea id="status" runat="server" placeholder="Insert your bits"></textarea>
                <ccPiczardUC:SimpleImageUpload ID="PostPic" runat="server" />
                <asp:Button ID="UserPost" runat="server" Text="Update Bit" OnClick="UserPost_Click" />
            </div>
            <ul>
            <asp:Repeater ID="UserPosts" runat="server">
                <ItemTemplate>                    
                    <li>
                        
                    </li>
                </ItemTemplate>
            </asp:Repeater> 
            </ul>           
        </div>
    </asp:Panel>
</asp:Content>