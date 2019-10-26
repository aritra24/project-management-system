<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Project_Management_System.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="AllProjects" DataKeyNames="id" AutoGenerateColumns="false" runat="server" PageSize="10" BorderStyle="None" AllowPaging="true" AllowSorting="true" EnablePersistedSelection="true">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="S.no" />
            <asp:BoundField DataField="name" HeaderText="Title" />
            <asp:BoundField DataField="duration" HeaderText="duration" />
            <asp:BoundField DataField="client" HeaderText="client" />
            <asp:BoundField DataField="reviseCount" HeaderText="Revise Count" />
            <asp:BoundField DataField="postedOn" HeaderText="Posted on" />
        </Columns>
    </asp:GridView>
</asp:Content>
