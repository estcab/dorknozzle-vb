
Partial Class Cokkies
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim userCookie As HttpCookie
        userCookie = Request.Cookies.Get("UserID")

        If userCookie Is Nothing Then
            OutputLabel.Text = "Cookie doesn't exist! Creating a cookie now."
            userCookie = New HttpCookie("UserID", "Joe Black")
            userCookie.Expires = DateTime.Now.AddMonths(1)
            Response.Cookies.Add(userCookie)
        Else
            OutputLabel.Text = "Welcome back, " & userCookie.Value
        End If



    End Sub
End Class
