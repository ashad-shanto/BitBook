<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BitBook.Web.Account.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="userNameLabel" runat="server" Text="User Name"></asp:Label>
    <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="User Name Required"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="EmailAddressValidator" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Email Format Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
    <asp:TextBox ID="ConfirmPasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="Confirm Your Password"></asp:RequiredFieldValidator>
    <br />

    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />

</asp:Content>
