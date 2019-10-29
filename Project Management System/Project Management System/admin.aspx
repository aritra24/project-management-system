<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Project_Management_System.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Font-Size="Large" Font-Bold="true" Text="All Projects"></asp:Label>
    <div id="center" class="center">
    <asp:Button runat="server" ID="new" Text="New" OnClick="Unnamed_Click" /><br />
    <asp:GridView ID="AllProjects" DataKeyNames="id" Font-Size="Medium" HorizontalAlign="Center" OnRowCommand="AllProjects_RowCommand" AutoGenerateColumns="false" runat="server" PageSize="10" BorderStyle="None" AllowPaging="true" AllowSorting="true" EnablePersistedSelection="true">
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" DataField="id" HeaderText="S.no" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="name" HeaderText="Title" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="duration" HeaderText="duration" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="client" HeaderText="client" />
            <asp:ButtonField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" Text="View/Edit" HeaderText="View/Edit" CommandName="view" />
            <asp:ButtonField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" Text="Delete" HeaderText="Delete" CommandName="remove" />
        </Columns>
    </asp:GridView>
        <div id="notifs">
            <br />
            <br />
        <asp:Label runat="server" Text="Notifications" Font-Size="Large" Font-Bold="true"></asp:Label>
    <asp:GridView HorizontalAlign="Center" runat="server" ID="Notifications" OnRowCommand="Notifications_RowCommand">
        <Columns>
            <asp:ButtonField CommandName="Approve" Text="✓"/>
            <asp:ButtonField CommandName="Reject" Text="✗" />
        </Columns>
    </asp:GridView>
            </div>
    </div>
</asp:Content>
