<%@ Page Title="Dorknozzle Help Desk" Language="VB" MasterPageFile="~/Dorknozzle.master"
    AutoEventWireup="false" CodeFile="HelpDesk.aspx.vb" Inherits="HelpDesk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Employee Help Desk Request</h1>
    <asp:Label ID="dbErrorMessage" runat="server"
        CssClass="errorMsg" ></asp:Label>
    <p>
        Station Number:<br />
        <asp:TextBox ID="stationTextBox" runat="server" CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="stationTextBox" ErrorMessage="<br />The station number cannot be empty!"
            SetFocusOnError="true" Display="Dynamic" ID="stationNumReq" 
            CssClass="errorMsg" />
        <asp:CompareValidator ID="stationNumCheck" runat="server" ControlToValidate="stationTextBox"
            Operator="DataTypeCheck" Type="Integer" ErrorMessage="<br />The value must be a number!"
            Display="Dynamic" CssClass="errorMsg" />
        <asp:RangeValidator ID="stationNumRangeCheck" runat="server" ControlToValidate="stationTextBox"
            Type="Integer" MinimumValue="1" MaximumValue="50" ErrorMessage="<br />Number must be between 1 and 50."
            Display="Dynamic" CssClass="errorMsg" />
    </p>
    <p>
        Problem Category:<br />
        <asp:DropDownList ID="categoryList" runat="server" CssClass="dropdownmenu">
        </asp:DropDownList>
    </p>
    <p>
        Problem Subject:
        <br />
        <asp:DropDownList ID="subjectList" runat="server" CssClass="dropdownmenu">
        </asp:DropDownList>
    </p>
    <p>
        Problem Description:
        <br />
        <asp:TextBox ID="descriptionTextBox" runat="server" Columns="40" CssClass="textbox"
            Rows="4" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="descriptionReq" runat="server" ControlToValidate="descriptionTextBox"
            ErrorMessage="<br />You must enter a description!" SetFocusOnError="true" 
            Display="Dynamic" CssClass="errorMsg" />
    </p>
    <p>
        <asp:Button ID="submitButton" runat="server" CssClass="button" Text="Submit Request" />
    </p>
</asp:Content>
