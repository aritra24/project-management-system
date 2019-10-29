<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="new.aspx.cs" Inherits="Project_Management_System._new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="data1" runat="server" SelectCommand="SELECT id, name FROM Clients" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True"></asp:SqlDataSource>
    <asp:TextBox ID="title" runat="server"></asp:TextBox>
    <asp:TextBox ID="description" runat="server"></asp:TextBox>
    <asp:TextBox ID="duration" runat="server"></asp:TextBox>
    <asp:DropDownList ID="client" DataSourceID="data1" DataValueField="id" DataTextField="name" runat="server"></asp:DropDownList>
    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
</asp:Content>
