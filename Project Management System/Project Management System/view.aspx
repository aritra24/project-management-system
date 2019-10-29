<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Project_Management_System.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="title1" Text="" Width="50%"></asp:Label><br />
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="Description" Text="" Width="50%"></asp:Label><br />
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="Duration" Text="" Width="50%"></asp:Label><br />
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="Client" Text="" Width="50%"></asp:Label><br />
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="PostedOn" Text="" Width="50%"></asp:Label><br />
        <asp:Label runat="server" Text="Title :"></asp:Label>
        <asp:Label runat="server" ID="ReviseCount" Text="" Width="50%"></asp:Label><br />
        
        <asp:TextBox ID="Comment" runat="server" ></asp:TextBox>
        <asp:Button runat="server" OnClick="Unnamed_Click" Text="submit" />
        <asp:GridView ID="commentsTable" runat="server"></asp:GridView>

    </div>
</asp:Content>
