<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.Master" Inherits="BitBook.Web.Home" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div style="width: 70%; float:left">
        <textarea runat="server" id="Post"></textarea>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Post on BitBook" />
        </p>
        <p>
            <asp:Repeater ID="FriendUpdate" runat="server"></asp:Repeater>
        </p>
    </div>
    <div style="width: 30%; float:left">
        <asp:Repeater ID="SuggestionList" runat="server"></asp:Repeater>
    </div>
</asp:Content>