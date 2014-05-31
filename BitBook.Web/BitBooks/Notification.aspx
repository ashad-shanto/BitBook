<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" MasterPageFile="~/Site.Master" Inherits="BitBook.Web.BitBooks.Notification" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:Repeater ID="NotifyRpt" runat="server" OnItemCommand="NotifyRpt_ItemCommand">
        <ItemTemplate>
            <div style="width:10%; float:left">
                <img src="../Images/ProPic/<%#Eval("Friend.ProfilePic") %>" style="width:50px; height:50px;" />
            </div>
            <div style="width:75%; float:left">                            
                <a href='Profile.aspx?user=<%#Eval("Friend._id") %>'><%#Eval("Friend.Username") %></a> wanted to be your friend!
            </div>
            <div style="width:15%; float:left">
                <asp:LinkButton ID="addFriend" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName="addFriend">Add as friend</asp:LinkButton>
                <asp:LinkButton ID="markButton" runat="server" CommandArgument='<%#Eval("_id") %>' CommandName="checkNotification">Reject friendship</asp:LinkButton>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>