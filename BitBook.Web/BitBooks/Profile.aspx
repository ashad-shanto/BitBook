<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="BitBook.Web.Profile" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/jquery-2.1.1.js"></script>
    <script src="../Scripts/jquery-ui-1.10.4.js"></script>
    <asp:PlaceHolder runat="server" ID="searchText">
        <script type="text/javascript">
            $(function () {
                $(document).ready(function () {
                    SearchText();

                    function SearchText() {
                        $("#<%=SearchBarTextBox.ClientID %>").autocomplete({
                            source: function (request, response) {
                                $.ajax({
                                    url: "UserInfoServices.asmx/GetAllUsers",
                                    type: "POST",
                                    dataType: "json",
                                    contentType: "application/json; charset=utf-8",
                                    data: "{ 'txt' : '" + $("#<%=SearchBarTextBox.ClientID %>").val() + "' }",
                                    dataFilter: function (data) { return data; },
                                    success: function (data) {
                                        response($.map(data.d, function (item) {
                                            return {
                                                label: item,
                                                value: item
                                            }
                                        }))
                                    },

                                    error: function (result) {
                                        alert("Error Occured!!");
                                    }
                                });
                            },
                            minLength: 1,
                            delay: 10
                        });
                    }
                });
            })
        </script>
    </asp:PlaceHolder>

    <script type="text/javascript">
        function NoUserFoundMsg()
        {
            alert("No User Found");
        }
    </script>

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
    
    <asp:TextBox ID="SearchBarTextBox" runat="server" placeholder="Look for friends and people baby" />
    <asp:Button ID="SearchButton" runat="server" Text="Search Friend" Visible="true" OnClick="SearchButton_Click" />
    <asp:Panel runat="server" ID="panel1">
        <div style="float:left; height:auto; width:30%;">
            <asp:Button ID="addFriend" runat="server" Text="Add as friend" OnClick="addFriend_Click" Visible="false" />
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
            <div style="width:80%; margin-left:50px;" runat="server" id="stausField">
                <textarea id="status" runat="server" placeholder="Insert your bits"></textarea>
                <ccPiczardUC:SimpleImageUpload ID="PostPic" runat="server" />
                <asp:Button ID="UserPost" runat="server" Text="Update Bit" OnClick="UserPost_Click" />
            </div>
            <ul style="list-style-type:none; margin-left:50px; width:80%">
            <asp:Repeater ID="UserPosts" runat="server" OnItemCommand="UserPosts_ItemCommand">
                <ItemTemplate>                    
                    <li>
                        <div style="width:10%; float:left">
                            <img src="../Images/ProPic/<%#Eval("PostedBy.ProfilePic") %>" style="width:50px; height:50px;" />
                        </div>
                        <div style="width:75%; float:left">                            
                            <a href='Profile.aspx?user=<%#Eval("PostedBy._id") %>'><%#Eval("PostedBy.Username") %></a> posted on <%#Eval("PostDate") %> 
                            <p><%#Eval("PostBody") %></p>
                            <img src="../Images/PostPic/<%#Eval("PhotoName") %>" alt="" style="width:80%" />
                        </div>
                        <div style="width:15%; float:left">
                            <asp:Button runat="server" ID="deleteBtn" Text="Unbit" CommandArgument='<%#Eval("_id") %>' CommandName="Delete" Width="80px" />
                            <asp:LinkButton ID="likeButton" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName="Like">Like</asp:LinkButton>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("LikeCount") %>'></asp:Label>
                            <asp:LinkButton ID="unlikeButton" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName="Unlike" Visible="false">Unlike</asp:LinkButton>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater> 
            </ul>           
        </div>
    </asp:Panel>
</asp:Content>