<%@ Page Title="Dorknozzle Employee Directory" Language="VB" MasterPageFile="~/Dorknozzle.master"
    AutoEventWireup="false" CodeFile="EmployeeDirectory.aspx.vb" Inherits="EmployeeDirectory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Employee Directory</h1>
    <asp:Label ID="dbErrorLabel" runat="server" />
    <%--    <asp:Repeater ID="employeesRepeater" runat="server">
        <ItemTemplate>
            Employee ID:<strong><%# Eval("EmployeeID")%></strong><br />
            Name:<strong><%# Eval("Name")%></strong><br />
            Username:<strong><%# Eval("Username")%></strong><br />
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>--%>

    <asp:DataList ID="employessList" runat="server">        
        <EditItemTemplate>
            <span class="widelabel">Name:</span> 
            <asp:TextBox ID="nameTextBox" runat="server" Text=<%# Eval("Name")%> />
            <br />
            
            <span class="widelabel">Username:</span> <asp:TextBox ID="usernameTextBox" runat="server" Text=<%# Eval("Username")%> />            
            <br />
            
            <asp:LinkButton ID="updateButton" runat="server" 
                Text="Update Item"
                CommandName="UpdateItem"
                CommandArgument=<%# Eval("EmployeeID") %> />
             or 
            <asp:LinkButton ID="cancelButton" runat="server" 
                Text="Cancel Editing"
                CommandName="CancelEditing"
                CommandArgument=<%# Eval("EmployeeID") %>/>
        </EditItemTemplate>
        <ItemTemplate>
            <asp:Literal ID="extraDetailsLiteral" runat="server" EnableViewState="false" />
            
            Name:<strong><%# Eval("Name")%></strong><br />Username:<strong><%# Eval("Username")%><br /></strong><br /><asp:LinkButton ID="detailsButton" runat="server" 
                Text=<%#"View more details about " & Eval("Name") %>
                CommandName="MoreDetailsPlease"
                CommandArgument=<%# Eval("EmployeeID") %> />
            <br />
            <asp:LinkButton ID="editButton" runat="server" 
                Text=<%#"Edit employee " & Eval("Name") %> 
                CommandName="EditItem"
                CommandArgument=<%# Eval("EmployeeID") %>/>
          
        </ItemTemplate>      
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:DataList>

</asp:Content>
