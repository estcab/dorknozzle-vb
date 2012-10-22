<%@ Page Title="Dorknozzle Admin Tools" Language="VB" MasterPageFile="~/Dorknozzle.master"
    AutoEventWireup="false" CodeFile="AdminTools.aspx.vb" Inherits="AdminTools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Admin Tools</h1>
    <p>
        <asp:Label ID="dbErrorLabel" runat="server" CssClass="errorMsg"></asp:Label>
        Select an employee to update:<br />
        <asp:DropDownList ID="employeesList" runat="server">
        </asp:DropDownList>
        <asp:Button ID="selectButton" runat="server" Text="select" />
    </p>
    <p>
        <span class="widelabel">Name:</span>
        <asp:TextBox ID="nameTextBox" runat="server" />
        <br />
        <span class="widelabel">User Name:</span>
        <asp:TextBox ID="userNameTextBox" runat="server" />
        <br />
        <span class="widelabel">Address:</span>
        <asp:TextBox ID="addressTextBox" runat="server" />
        <br />
        <span class="widelabel">City:</span>
        <asp:TextBox ID="cityTextBox" runat="server" />
        <br />
        <span class="widelabel">State:</span>
        <asp:TextBox ID="stateTextBox" runat="server" />
        <br />
        <span class="widelabel">Zip:</span>
        <asp:TextBox ID="zipTextBox" runat="server" />
        <br />
        <span class="widelabel">Home Phone:</span>
        <asp:TextBox ID="homePhoneTextBox" runat="server" />
        <br />
        <span class="widelabel">Extension:</span>
        <asp:TextBox ID="extensionTextBox" runat="server" />
        <br />
        <span class="widelabel">Mobile Phone:</span>
        <asp:TextBox ID="mobilePhoneTextBox" runat="server" />
        <br />
    </p>
    <p>
        <asp:Button ID="updateButton" Text="Update Employee" Width="200" Enabled="False"
            runat="server" />
        <asp:Button ID="deleteButton" runat="server" Enabled="False" 
            Text="Delete Employee" />
    </p>
</asp:Content>
