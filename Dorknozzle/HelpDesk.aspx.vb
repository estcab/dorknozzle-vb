Imports System.Data.SqlClient
Imports System.Configuration

Partial Class HelpDesk
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Si es la primera vez que accesdemos a la pagin
        If Not IsPostBack Then
            'Declaramos las variables de acceso a  datos
            Dim conn As SqlConnection
            Dim categoryCmd As SqlCommand
            Dim subjectCmd As SqlCommand
            Dim reader As SqlDataReader

            'Obtenemos la cadena de conexion del archivo de configuracion
            Dim conectionString As String = _
                ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString

            'Creamos la conexion y los parametros
            conn = New SqlConnection(conectionString)

            Dim categoryQuery As String = _
                "SELECT CategoryID, Category FROM HelpDeskCategories"
            Dim subjectQuery As String = _
                "SELECT SubjectID, [Subject] FROM HelpDeskSubjects"

            categoryCmd = New SqlCommand(categoryQuery, conn)
            subjectCmd = New SqlCommand(subjectQuery, conn)

            Try
                conn.Open()

                'Completamos los datos del DropDown List Categorias
                reader = categoryCmd.ExecuteReader()
                categoryList.DataSource = reader
                categoryList.DataValueField = "CategoryID"
                categoryList.DataTextField = "Category"
                categoryList.DataBind()
                reader.Close()

                'Completamos los datos del DropDown List subject
                reader = subjectCmd.ExecuteReader()
                subjectList.DataSource = reader
                subjectList.DataValueField = "SubjectID"
                subjectList.DataTextField = "Subject"
                subjectList.DataBind()
                reader.Close()
            Catch ex As Exception

            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Protected Sub submitButton_Click(sender As Object, e As System.EventArgs) _
        Handles submitButton.Click

        If Page.IsValid Then
            ' Code that uses the data entered by the user
            Dim conn As SqlConnection
            Dim cmd As SqlCommand

            Dim connectionString As String = _
                ConfigurationManager.ConnectionStrings("dorknozzle").ConnectionString

            conn = New SqlConnection(connectionString)

            Dim insertQuery As String = _
                "INSERT INTO HelpDesk (EmployeeID, StationNumber, CategoryID, SubjectID, [Description], StatusID)" & _
                "VALUES (@EmployeeID, @StationNumber, @CategoryID, @SubjectID, @Description, @StatusID)"

            cmd = New SqlCommand(insertQuery, conn)

            cmd.Parameters.Add("@EmployeeID", Data.SqlDbType.Int)
            cmd.Parameters("@EmployeeID").Value = 5

            cmd.Parameters.Add("@StationNumber", Data.SqlDbType.Int)
            cmd.Parameters("@StationNumber").Value = stationTextBox.Text

            cmd.Parameters.Add("@CategoryID", Data.SqlDbType.Int)
            cmd.Parameters("@CategoryID").Value = categoryList.SelectedItem.Value

            cmd.Parameters.Add("@SubjectID", Data.SqlDbType.Int)
            cmd.Parameters("@SubjectID").Value = subjectList.SelectedItem.Value

            cmd.Parameters.Add("@Description", Data.SqlDbType.NVarChar, 50)
            cmd.Parameters("@Description").Value = descriptionTextBox.Text

            cmd.Parameters.Add("@StatusID", Data.SqlDbType.Int)
            cmd.Parameters("@StatusID").Value = 1

            Try
                conn.Open()
                cmd.ExecuteNonQuery()

                Response.Redirect("HelpDesk.aspx")

            Catch ex As Exception
                dbErrorMessage.Text = "Error submitting the help desk request! Please " & _
                                      "try again later, and/or change the entered data!"

            Finally
                conn.Close()

            End Try
        End If

    End Sub


End Class
