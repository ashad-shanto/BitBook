<%@ Page Title="Home Page" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BitBook.Web._Default" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-2.1.0.min.js"></script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $("#SearchBarTextBox").hide();
        });
    </script>--%>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="row">
        <div class="large-6 columns">
            <h3 class="welcome-message">Welcome to BitBook. Connect with friends, meet new people, stay in sync.</h3>
                <fieldset>
                    <h6>Log in</h6>
                    <asp:Label ID="Alert" runat="server"></asp:Label>
                    <p><label>Email</label></p>
                    <asp:TextBox ID="SignInEmailTextBox" runat="server" placeholder="Insert email or username" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="SignInEmailRequiredValidator" CssClass="validation-message" runat="server" ControlToValidate="SignInEmailTextBox" ErrorMessage="Username is required" ValidationGroup="SignInValidationGroup"></asp:RequiredFieldValidator>

                    <label>PASSWORD</label>
                    <asp:TextBox ID="SignInPasswordTextox" runat="server" placeholder="Insert your password" TextMode="Password" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordFieldValidator" CssClass="validation-message" runat="server" ControlToValidate="SignInPasswordTextox" ErrorMessage="Password is Required" ValidationGroup="SignInValidationGroup"></asp:RequiredFieldValidator>

                    <asp:Button ID="LoginButton" runat="server" CssClass="button right" OnClick="LoginButton_Click" Text="Sign In" ValidationGroup="SignInValidationGroup" />
                </fieldset>
        </div>

        <div class="large-6 columns">
            <fieldset class="sign-up">
                <h6>Don't have an account? Sign up</h6>
                <%--name--%>
                <label>NAME</label>
                <asp:TextBox ID="SignUpUserNameTextBox" runat="server" placeholder="Enter desired name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validation-message" runat="server" ControlToValidate="SignUpUserNameTextBox" ErrorMessage="Name is Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>

                <%--email--%>
                <label>EMAIL</label>
                <asp:TextBox ID="SignUpEmailTextBox" runat="server" placeholder="Enter desired e-mail" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validation-message" runat="server" ControlToValidate="SignUpEmailTextBox" ErrorMessage="Email is Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                <%--password--%>
                <label>PASSWORD</label>
                <asp:TextBox ID="SignUpPasswordTextBox" placeholder="Enter password" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="SignUpPasswordRequiredValidator" CssClass="validation-message" runat="server" ControlToValidate="SignUpPasswordTextBox" ErrorMessage="Password is Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                <%--confirm password--%>
                <label>CONFIRM PASSWORD</label>
                <asp:TextBox ID="SignUpConfirmPasswordTextBox" placeholder="Repeat your password" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="SignUpConfirmPasswordRequired" CssClass="validation-message" runat="server" ControlToValidate="SignUpConfirmPasswordTextBox" ErrorMessage="Confirm password is required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="SubmitButton" runat="server" CssClass="button" Text="Sign Up" OnClick="SubmitButton_Click" ValidationGroup="SignUpValidationGroup" />
            </fieldset>
        </div>
    </div>
</asp:Content>
