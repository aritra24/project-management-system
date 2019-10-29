<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="comments.aspx.cs" Inherits="Project_Management_System.comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="searchterm" AutoPostBack="true" OnTextChanged="searchterm_TextChanged" runat="server"></asp:TextBox>
    <asp:DropDownList ID="userlist" AutoPostBack="true" OnSelectedIndexChanged="userlist_SelectedIndexChanged" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:GridView runat="server" ID="commentsFound"></asp:GridView>
</asp:Content>
