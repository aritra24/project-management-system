<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Project_Management_System.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="All Projects"></asp:Label>
        <asp:GridView ID="AllProjects" DataKeyNames="id" Font-Size="Medium" HorizontalAlign="Center" OnRowCommand="AllProjects_RowCommand" AutoGenerateColumns="false" runat="server" PageSize="10" BorderStyle="None" AllowPaging="true" AllowSorting="true" EnablePersistedSelection="true">
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" DataField="id" HeaderText="S.no" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="name" HeaderText="Title" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="duration" HeaderText="duration" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="client" HeaderText="client" />
            <asp:ButtonField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" Text="View" HeaderText="View" CommandName="view" />
        </Columns>
    </asp:GridView>
</asp:Content>
