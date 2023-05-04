Imports System.Data.SqlClient
Public Class ViewMarks
    Private ReadOnly _studentId As String
    Private ReadOnly _department As String
    Private ReadOnly _courseYear As String
    Public Sub New(studentID As String, Optional Department As String = Nothing, Optional CourseYear As String = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _studentId = studentID
        _department = Department
        _courseYear = CourseYear
    End Sub

    Private Sub ViewMarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _studentId <> Nothing Then
            Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
            Dim query As String = "SELECT * FROM STUDENT_MARKS WHERE studentid = @stdid"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@stdID", _studentId)
                connection.Open()
                dataAdapter.Fill(dataTable)
            End Using
            With MarksDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        Else
            Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
            Dim query As String = "SELECT STUDENT_MARKS.* FROM STUDENT_MARKS JOIN COURSE_DETAILS ON STUDENT_MARKS.course_id = COURSE_DETAILS.COURSE_ID WHERE COURSE_DETAILS.DEPT = @department AND COURSE_DETAILS.COURSE_YEAR = @courseYear"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@department", _department)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@courseYear", _courseYear)
                connection.Open()
                dataAdapter.Fill(dataTable)
            End Using
            With MarksDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End With
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
    End Sub
End Class