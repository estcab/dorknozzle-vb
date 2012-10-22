Imports System.Data.SqlClient
Imports System.Configuration


Partial Class EmployeeDirectory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            BindList()
        End If


    End Sub

    Private Sub BindList()

        'Variables necesarias para el acceso a datos
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        'Cadena de conexion almacenada en web.config
        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        'Creamos la query que selecciona todos los empleados
        Dim selectQuery As String = "SELECT EmployeeID, Name, Username FROM Employees"


        'Creamos la conexion y el comando
        conn = New SqlConnection(connectionString)
        cmd = New SqlCommand(selectQuery, conn)

        'Operamos con la base  de datos
        Try
            'Abrir conexion
            conn.Open()
            'Ejecutar comando
            dr = cmd.ExecuteReader()

            'Establecer origen de datosdel Repeater
            employessList.DataSource = dr
            'Ejecutar el Enlace de  Datos
            employessList.DataBind()

            'Cerramos el Data Reader para aliviar recursos
            dr.Close()

        Catch ex As Exception
        Finally
            'Pase lo que pase, cerramos al conexion
            conn.Close()

        End Try
    End Sub

    Protected Sub employessList_ItemCommand( _
            source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) _
                Handles employessList.ItemCommand

        If e.CommandName = "MoreDetailsPlease" Then
            Dim li As Literal
            li = e.Item.FindControl("extraDetailsLiteral")
            li.Text = "Employee ID: <strong>" & e.CommandArgument & "</strong><br />"

        ElseIf e.CommandName = "EditItem" Then
            employessList.EditItemIndex = e.Item.ItemIndex
            BindList()
        ElseIf e.CommandName = "CancelEditing" Then
            employessList.EditItemIndex = -1
            BindList()

        ElseIf e.CommandName = "UpdateItem" Then
            Dim employeeID As Integer = e.CommandArgument
            Dim nameTexBox As TextBox = e.Item.FindControl("nameTextBox")
            Dim usernameTextBox As TextBox = e.Item.FindControl("usernameTextBox")

            Dim newName As String = nameTexBox.Text
            Dim newUsername As String = usernameTextBox.Text
            UpdateItem(employeeID, newName, newUsername)
            employessList.EditItemIndex = -1
            BindList()


        End If



    End Sub

    Private Sub UpdateItem(employeeID As Integer, newName As String, newUsername As String)
        Dim conn As SqlConnection
        Dim cmd As SqlCommand

        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        conn = New SqlConnection(connectionString)

        cmd = New SqlCommand("UpdateEmployee", conn)
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.Add("@EmployeeID", Data.SqlDbType.Int)
        cmd.Parameters.Item("@EmployeeID").Value = employeeID

        cmd.Parameters.Add("@newName", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@newName").Value = newName

        cmd.Parameters.Add("@newUsername", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@newUsername").Value = newUsername


        Try
            conn.Open()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            dbErrorLabel.Text = ex.Message
        Finally
            conn.Close()

        End Try

    End Sub


End Class
