<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Project_Management_System.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="login.css" />
</head>
<body>
    <div class="login">
  <div class="heading">
    <h2>Register</h2>
    <form runat="server" action="#">
        <asp:Label ID="Label1" runat="server"></asp:Label>
      <div class="input-group input-group-lg">
        <span class="input-group-addon"><i class="fa fa-user"></i></span>
        <asp:TextBox ID="Login_username" runat="server" textmode="SingleLine" CSSclass="form-control" placeholder="Username or email" />
          </div>
        <div class="input-group input-group-lg">
          <span class="input-group-addon"><i class="fa fa-lock"></i></span>
          <asp:TextBox ID="Login_password" runat="server" textmode="password" CSSclass="form-control" placeholder="Password" />
        </div>

        <asp:Button ID="Login_button" runat="server" CSSclass="float" Text="Login" OnClick="Login_Click"></asp:Button>
       </form>
 		</div>
 </div>
</body>
</html>
