<%@ Page Title="Home Page" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BitBook.Web._Default" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#SearchBarTextBox").hide();
        });
    </script>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="row">
        <div class="large-6 columns">
            <h3 class="welcome-message">Welcome to BitBook. Connect with friends, meet new people, stay in sync.</h3>
            <form>
                <fieldset>
                    <h6>Log in</h6>
                    <%--<label>USERNAME</label>
                    <input type="text" placeholder="Insert email or username" />
                    <label>PASSWORD</label>
                    <input type="text" placeholder="Insert your password" />
                    <input type="submit" class="button right" value="Sign in" />--%>

                    <asp:Label ID="SignInEmailLabel" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="SignInEmailTextBox" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="SignInEmailRequiredValidator" runat="server" ControlToValidate="SignInEmailTextBox" ErrorMessage="Email Is Required" ValidationGroup="SignInValidationGroup"></asp:RequiredFieldValidator>
                    
                    <asp:Label ID="SignInPasswordLabel" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="SignInPasswordTextox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordFieldValidator" runat="server" ControlToValidate="SignInPasswordTextox" ErrorMessage="Password Is Required" ValidationGroup="SignInValidationGroup"></asp:RequiredFieldValidator>

                    <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Log In" />
                </fieldset>
            </form>
        </div>

        <div class="large-6 columns">
                <fieldset>
                    <h6>Don't have an account? Sign up</h6>
                    <%--<label>NAME</label>
                    <input type="text" placeholder="Enter desired name" />
                    <label>EMAIL</label>
                    <input type="text" placeholder="Enter desired e-mail" />
                    <label>PASSWORD</label>
                    <input type="password" placeholder="Enter desired password" />
                    <label>CONFIRM PASSWORD</label>
                    <input type="password" placeholder="Repeat your password" />
                    <input type="submit" class="button" value="Sign up" />--%>


                    <asp:Label ID="userNameLabel" runat="server" Text="User Name"></asp:Label>
                    <asp:TextBox ID="SignUpUserNameTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SignUpUserNameTextBox" ErrorMessage="User Name Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="SignUpEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="SignUpEmailTextBox" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SignUpEmailTextBox" ErrorMessage="Email Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="SignUpPasswordLabel" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="SignUpPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="SignUpPasswordRequiredValidator" runat="server" ControlToValidate="SignUpPasswordTextBox" ErrorMessage="Password Required" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="confirmPasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="SignUpConfirmPasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="SignUpConfirmPasswordRequired" runat="server" ControlToValidate="SignUpConfirmPasswordTextBox" ErrorMessage="Confirm Your Password" ValidationGroup="SignUpValidationGroup"></asp:RequiredFieldValidator>
                    <br />

                    <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />

                    
                </fieldset>
        </div>
    </div>
</asp:Content>
