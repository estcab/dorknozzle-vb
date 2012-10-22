
Partial Class ErrorTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim a(10) As Integer
        Dim i As Integer
        Try
            For i = 1 To 11
                a(i) = i
            Next

        Catch ex As Exception
            'ErrorLabel.Text = "Se ha producido un error.<br />" _
            '                    & ex.Message

            Response.Redirect("~/ErrorPage.aspx")
        End Try
        
    End Sub
End Class
