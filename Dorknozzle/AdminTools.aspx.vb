Imports System.Data.SqlClient
Imports System.Configuration

Partial Class AdminTools
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Si es la  primera vez que accedemos a la pagina rellenamos la lista de empleados
        If Not IsPostBack Then
            LoadEmployeesList()
        End If

    End Sub

    Private Sub LoadEmployeesList()
        'Declaramos las variables de acceso a datos
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim reader As SqlDataReader

        'Utilizamos la cadena deconexion definida en el archivo de configuracion
        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        'Creamos la conexion
        conn = New SqlConnection(connectionString)

        'Definimos la query que obtendra la lista de empleados
        Dim employeesQuery As String = _
            "SELECT EmployeeID, Name FROM Employees"

        'Creamos el comando
        cmd = New SqlCommand(employeesQuery, conn)

        'Ejecutamos el comando
        Try
            'Abrimos la conexio
            conn.Open()
            'Ejecutamos el comando
            reader = cmd.ExecuteReader()
            'Enlazamos el resultado con el DropDownList
            employeesList.DataSource = reader
            employeesList.DataValueField = "EmployeeID"
            employeesList.DataTextField = "Name"
            employeesList.DataBind()
            'Cerramos el Data Reader
            reader.Close()

        Catch ex As Exception
            dbErrorLabel.Text = "Error loading the list of employees.<br />"
        Finally
            conn.Close()
        End Try

        updateButton.Enabled = False
        deleteButton.Enabled = False

        nameTextBox.Text = ""
        userNameTextBox.Text = ""
        addressTextBox.Text = ""
        cityTextBox.Text = ""
        stateTextBox.Text = ""
        zipTextBox.Text = ""
        homePhoneTextBox.Text = ""
        extensionTextBox.Text = ""
        mobilePhoneTextBox.Text = ""

    End Sub

    Protected Sub selectButton_Click(sender As Object, e As System.EventArgs) Handles selectButton.Click
        'Declaramos las variables de acceso a datos
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim reader As SqlDataReader

        'Utilizamos la cadena deconexion definida en el archivo de configuracion
        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        'Creamos la conexion
        conn = New SqlConnection(connectionString)

        'Definimos la query que obtendra los datos del empleado seleccionado
        Dim employeeDataQuery As String = _
            "SELECT Name, Username, [Address],City, [State] ,Zip, HomePhone, Extension, MobilePhone " & _
            "FROM Employees WHERE EmployeeID=@EmployeeID"

        'Creamos el comando
        cmd = New SqlCommand(employeeDataQuery, conn)

        'Introducimos el parametro
        cmd.Parameters.Add("@EmployeeID", Data.SqlDbType.Int)
        cmd.Parameters.Item("@EmployeeID").Value = employeesList.SelectedItem.Value

        Try
            'Abrimos la conexio
            conn.Open()

            'Ejecutamos el comando
            reader = cmd.ExecuteReader()

            'Enlazamos el resultado con el TextBox
            If reader.Read Then
                nameTextBox.Text = reader.Item("Name").ToString()
                userNameTextBox.Text = reader.Item("Username").ToString()
                addressTextBox.Text = reader.Item("Address").ToString()
                cityTextBox.Text = reader.Item("City").ToString()
                stateTextBox.Text = reader.Item("State").ToString()
                zipTextBox.Text = reader.Item("Zip").ToString()
                homePhoneTextBox.Text = reader.Item("HomePhone").ToString()
                extensionTextBox.Text = reader.Item("Extension").ToString()
                mobilePhoneTextBox.Text = _
                reader.Item("MobilePhone").ToString()
            End If

            'Cerramos el Data Reader
            reader.Close()
            'Habilitamos el boton de actualizar y eliminar
            updateButton.Enabled = True
            deleteButton.Enabled = True

        Catch ex As Exception
            dbErrorLabel.Text = ex.Message

            '"Error loading the employee details.<br />"
        Finally
            conn.Close()

        End Try
    End Sub

    Protected Sub updateButton_Click(sender As Object, e As System.EventArgs) Handles updateButton.Click
        'Declaramos las variables de acceso a datos
        Dim conn As SqlConnection
        Dim cmd As SqlCommand

        'Utilizamos la cadena deconexion definida en el archivo de configuracion
        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        'Creamos la conexion
        conn = New SqlConnection(connectionString)

        'Definimos la query que actualizara los datos del empleado seleccionado
        Dim employeeUpdateQuery As String = _
            "UPDATE Employees " & _
            "SET Name = @Name, Username = @Username ,[Address] = @Address, City = @City ," & _
                "[State] = @State ,Zip = @Zip, HomePhone = @HomePhone ," & _
                "Extension = @Extension, MobilePhone = @MobilePhone " & _
            "WHERE(EmployeeID = @EmployeeID)"

        'Creamos el comando
        cmd = New SqlCommand(employeeUpdateQuery, conn)

        'Introducimos los parametros
        cmd.Parameters.Add("@Name", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@Name").Value = nameTextBox.Text

        cmd.Parameters.Add("@Username", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@Username").Value = userNameTextBox.Text

        cmd.Parameters.Add("@Address", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@Address").Value = addressTextBox.Text()

        cmd.Parameters.Add("@City", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@City").Value = cityTextBox.Text

        cmd.Parameters.Add("@State", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@State").Value = stateTextBox.Text

        cmd.Parameters.Add("@Zip", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@Zip").Value = zipTextBox.Text

        cmd.Parameters.Add("@HomePhone", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@HomePhone").Value = homePhoneTextBox.Text

        cmd.Parameters.Add("@Extension", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@Extension").Value = extensionTextBox.Text

        cmd.Parameters.Add("@MobilePhone", Data.SqlDbType.NVarChar, 50)
        cmd.Parameters.Item("@MobilePhone").Value = mobilePhoneTextBox.Text

        cmd.Parameters.Add("@EmployeeID", Data.SqlDbType.Int)
        cmd.Parameters.Item("@EmployeeID").Value = employeesList.SelectedItem.Value

        Try
            'Abrimos la conexio
            conn.Open()

            'Ejecutamos el comando
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            dbErrorLabel.Text = "Error updating the employee details.<br />"
        Finally
            conn.Close()

        End Try

        LoadEmployeesList()
    End Sub

    Protected Sub deleteButton_Click(sender As Object, e As System.EventArgs) Handles deleteButton.Click
        'Declaramos las variables de acceso a datos
        Dim conn As SqlConnection
        Dim cmd As SqlCommand

        'Utilizamos la cadena deconexion definida en el archivo de configuracion
        Dim connectionString As String = _
            ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

        'Creamos la conexion
        conn = New SqlConnection(connectionString)

        'Definimos la query que actualizara los datos del empleado seleccionado
        Dim employeeDeleteQuery As String = _
                "DELETE FROM Employees " & _
                "WHERE EmployeeID = @EmployeeID"

        'Creamos el comando
        cmd = New SqlCommand(employeeDeleteQuery, conn)

        'Introducimos los parametros
        cmd.Parameters.Add("@EmployeeID", Data.SqlDbType.Int)
        cmd.Parameters.Item("@EmployeeID").Value = employeesList.SelectedItem.Value

        Try
            'Abrimos la conexio
            conn.Open()

            'Ejecutamos el comando
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            dbErrorLabel.Text = "Error deleting the employee.<br />"
        Finally
            conn.Close()

        End Try

        LoadEmployeesList()

    End Sub
End Class
