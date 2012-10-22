Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class Departments
    Inherits System.Web.UI.Page

    Private Property gridSortDirection() As SortDirection
        Get
            If (ViewState("GridSortDirection") Is Nothing) Then
                ViewState("GridSortDirection") = SortDirection.Ascending
            End If
            Return ViewState("GridSortDirection")
        End Get
        Set(ByVal value As SortDirection)
            ViewState("GridSortDirection") = value
        End Set
    End Property

    Private Property gridSortExpression() As String
        Get
            If (ViewState("GridSortExpression") Is Nothing) Then
                ViewState("GridSortExpression") = "DepartmentID"
            End If
            Return ViewState("GridSortExpression")
        End Get
        Set(ByVal value As String)
            ViewState("GridSortExpression") = value
        End Set
    End Property


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'La primera vez que cargamos la pagina rellenamos el grid
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim conn As SqlConnection
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        If ViewState("DepartmentsDS") Is Nothing Then

            Dim connectionString As String = _
                ConfigurationManager.ConnectionStrings("Dorknozzle").ConnectionString
            conn = New SqlConnection(connectionString)

            da = New SqlDataAdapter( _
                "SELECT DepartmentID, Department FROM Departments", conn)

            'da.SelectCommand = New SqlCommand( _
            '    "SELECT EmployeeID, Name, MobilePhone FROM Employees", conn)
            'da.Fill(ds, "Employees")

            da.Fill(ds, "Departments")

            ViewState("DepartmentsDS") = ds

        Else
            ds = ViewState("DepartmentsDS")

        End If
        
        Dim sortExpression As String
        If gridSortDirection = SortDirection.Ascending Then
            sortExpression = gridSortExpression & " ASC"
        Else
            sortExpression = gridSortExpression & " DESC"
        End If

        ds.Tables("Departments").DefaultView.Sort = sortExpression

        departmentsGrid.DataSource = ds.Tables("Departments").DefaultView
        'departmentsGrid.DataMember = "Employees"

        'Time delay to test the UpdateProgress control
        System.Threading.Thread.Sleep(5000)

        departmentsGrid.DataBind()

    End Sub

    Protected Sub departmentsGrid_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles departmentsGrid.PageIndexChanging
        departmentsGrid.PageIndex = e.NewPageIndex
        BindGrid()

    End Sub

    Protected Sub departmentsGrid_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles departmentsGrid.Sorting
        Dim sortExpression As String = e.SortExpression

        If (sortExpression = gridSortExpression) Then
            If gridSortDirection = SortDirection.Ascending Then
                gridSortDirection = SortDirection.Descending
            Else
                gridSortDirection = SortDirection.Ascending
            End If
        Else
            gridSortDirection = WebControls.SortDirection.Ascending
        End If
        gridSortExpression = sortExpression
        BindGrid()

    End Sub
End Class
