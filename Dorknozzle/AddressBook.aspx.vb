Imports System.Data.SqlClient

Partial Class AddressBook
    Inherits System.Web.UI.Page

    Protected Sub employeeDetails_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) _
        Handles employeeDetails.ItemUpdated
        grid.DataBind()

    End Sub


    Protected Sub employeeDetails_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewDeletedEventArgs) Handles employeeDetails.ItemDeleted
        grid.DataBind()
    End Sub

    Protected Sub employeeDetails_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewInsertedEventArgs) Handles employeeDetails.ItemInserted
        grid.DataBind()
    End Sub

    Protected Sub addEmployeeButton_Click(sender As Object, e As System.EventArgs) Handles addEmployeeButton.Click
        employeeDetails.ChangeMode(DetailsViewMode.Insert)
    End Sub
End Class
