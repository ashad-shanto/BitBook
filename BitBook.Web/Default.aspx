<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BitBook.Web._Default" %>

<%--<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadContent">
    <link href="Content/app.css" rel="stylesheet" type="text/css" />
</asp:Content>--%>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="row">
        <div class="large-6 columns">
            <h3 class="welcome-message">Welcome to BitBook. Connect with friends, meet new people, stay in sync.</h3>
            <form>
                <fieldset>
                    <h6>Log in</h6>
                    <label>USERNAME</label>
                    <input type="text" placeholder="Insert email or username" />
                    <label>PASSWORD</label>
                    <input type="text" placeholder="Insert your password" />
                    <input type="submit" class="button right" value="Sign in" />
                </fieldset>
            </form>
        </div>

        <div class="large-6 columns">
            <form>
                <fieldset>
                    <h6>Don't have an account? Sign up</h6>
                    <label>NAME</label>
                    <input type="text" placeholder="Enter desired name" />
                    <label>EMAIL</label>
                    <input type="text" placeholder="Enter desired e-mail" />
                    <label>PASSWORD</label>
                    <input type="password" placeholder="Enter desired password" />
                    <label>CONFIRM PASSWORD</label>
                    <input type="password" placeholder="Repeat your password" />
                    <input type="submit" class="button" value="Sign up" />
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
