﻿<%@ Page Title="Dorknozzle Address Book" Language="VB" MasterPageFile="~/Dorknozzle.master"
    AutoEventWireup="false" CodeFile="AddressBook.aspx.vb" Inherits="AddressBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Address Book</h1>
    <p>
        <asp:LinkButton ID="addEmployeeButton" runat="server">Add New Employee</asp:LinkButton>
    </p>
    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        AllowSorting="True" DataKeyNames="EmployeeID" DataSourceID="employeesDataSource"
        PageSize="3">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="MobilePhone" HeaderText="MobilePhone" SortExpression="MobilePhone" />
            <asp:ButtonField CommandName="Select" Text="Select" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="employeesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Dorknozzle %>"
        SelectCommand="SELECT [EmployeeID], [Name], [City], [MobilePhone] FROM [Employees] ORDER BY [Name]">
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="dbErrorLabel" runat="server" />
    <asp:SqlDataSource ID="employeeDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Dorknozzle %>"
        DeleteCommand="DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID" InsertCommand="INSERT INTO [Employees] ([DepartmentID], [Name], [Username], [Password], [Address], [City], [State], [Zip], [MobilePhone], [Extension], [HomePhone]) VALUES (@DepartmentID, @Name, @Username, @Password, @Address, @City, @State, @Zip, @MobilePhone, @Extension, @HomePhone)"
        SelectCommand="SELECT [EmployeeID], [DepartmentID], [Name], [Username], [Password], [Address], [City], [State], [Zip], [MobilePhone], [Extension], [HomePhone] FROM [Employees] WHERE ([EmployeeID] = @EmployeeID)"
        UpdateCommand="UPDATE [Employees] SET [DepartmentID] = @DepartmentID, [Name] = @Name, [Username] = @Username, [Password] = @Password, [Address] = @Address, [City] = @City, [State] = @State, [Zip] = @Zip, [MobilePhone] = @MobilePhone, [Extension] = @Extension, [HomePhone] = @HomePhone WHERE [EmployeeID] = @EmployeeID">
        <DeleteParameters>
            <asp:Parameter Name="EmployeeID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="DepartmentID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Username" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="Zip" Type="String" />
            <asp:Parameter Name="MobilePhone" Type="String" />
            <asp:Parameter Name="Extension" Type="String" />
            <asp:Parameter Name="HomePhone" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="grid" Name="EmployeeID" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="DepartmentID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Username" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="State" Type="String" />
            <asp:Parameter Name="Zip" Type="String" />
            <asp:Parameter Name="MobilePhone" Type="String" />
            <asp:Parameter Name="Extension" Type="String" />
            <asp:Parameter Name="HomePhone" Type="String" />
            <asp:Parameter Name="EmployeeID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dorknozzle %>"
        SelectCommand="SELECT [DepartmentID], [Department] FROM [Departments] ORDER BY [Department]">
    </asp:SqlDataSource>
    <asp:DetailsView ID="employeeDetails" runat="server" AutoGenerateRows="False" AllowPaging="True"
        AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True"
        DataKeyNames="EmployeeID" DataSourceID="employeeDataSource">
        <Fields>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" InsertVisible="False"
                ReadOnly="True" SortExpression="EmployeeID" />
            <asp:TemplateField HeaderText="DepartmentID" SortExpression="DepartmentID">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Department" DataValueField="DepartmentID" SelectedValue='<%# Bind("DepartmentID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Department" DataValueField="DepartmentID" SelectedValue='<%# Bind("DepartmentID") %>'>
                    </asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                        DataTextField="Department" DataValueField="DepartmentID" SelectedValue='<%# Bind("DepartmentID") %>'
                        Enabled="false">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            <asp:BoundField DataField="Zip" HeaderText="Zip" SortExpression="Zip" />
            <asp:BoundField DataField="MobilePhone" HeaderText="MobilePhone" SortExpression="MobilePhone" />
            <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
            <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
        </Fields>
        <HeaderTemplate>
            <%# IIf (Eval("Name") = Nothing, "Adding New Emplooy", Eval("Name"))%>
        </HeaderTemplate>
    </asp:DetailsView>
</asp:Content>
