<%@ Page Title="Dorknozzle Departments" Language="VB" MasterPageFile="~/Dorknozzle.master"
    AutoEventWireup="false" CodeFile="Departments.aspx.vb" Inherits="Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Dorknozzle Departments
    </h1>
    <p>
        Page rendered at
        <%= DateTime.Now.ToLongTimeString() %>.</p>
    <asp:UpdatePanel ID="DepartmentsUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="DepartmentsUpdateProgress" runat="server">
                <ProgressTemplate>
                <p class="UpdateProgress">Updating...</p>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:GridView ID="departmentsGrid" runat="server" AllowPaging="True" AllowSorting="True"
                PageSize="4">
            </asp:GridView>
            <p>
                Grid rendered at
                <%= DateTime.Now.ToLongTimeString() %></p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
