<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Project_Management_System.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="title" runat="server"></asp:Label>
    <asp:GridView ID="view_project" runat="server" AutoGenerateColumns="false" AutoGenerateEditButton="true" OnRowEditing="view_project_RowEditing" OnRowUpdating="view_project_RowUpdating">
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px" DataField="id" ReadOnly="true" HeaderText="S.no" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="name" HeaderText="Title" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="description" HeaderText="Description" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="duration" HeaderText="Duration" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="client" ReadOnly="true" HeaderText="Client" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" DataField="createdby" ReadOnly="true" HeaderText="Created By" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" DataField="postedOn" ReadOnly="true" HeaderText="posted On" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" DataField="reviseCount" ReadOnly="true" HeaderText="Revise Count" />
            
        </Columns>
    </asp:GridView>
</asp:Content>
