Imports System.Data.SqlClient
Public Class ViewAttendance
    Private ReadOnly _studentId As String
    Private ReadOnly _department As String
    Private ReadOnly _courseYear As String
    Private ReadOnly _presentdate As Date
    Public Sub New(studentID As String, Optional Department As String = Nothing, Optional CourseYear As String = Nothing, Optional PresentDate As Date = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _studentId = studentID
        _department = Department
        _courseYear = CourseYear
        _presentdate = PresentDate

    End Sub
    Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
    Private Sub ViewAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "DROP TABLE STUDENT_ATTENDANCE"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Try
                    command.ExecuteNonQuery()
                Catch ex As System.Data.SqlClient.SqlException
                    query = ""
                End Try
            End Using
        End Using
        If _studentId <> Nothing Then
            query = "SELECT * FROM ATTENDANCE WHERE STUDENT_ID = @stdID"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@stdID", _studentId)
                connection.Open()
                dataAdapter.Fill(dataTable)
            End Using
            With AttendanceDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                If IsAdmin Then
                    .ReadOnly = False
                End If
            End With
        Else
            query = "SELECT s.studentid, s.dept, s.course_year, ISNULL(a.PRESENT_DATE, @presentdate) as presentdate, ISNULL(a.is_present, 0) as is_present INTO Student_Attendance FROM studentreg s LEFT JOIN (SELECT * FROM Attendance WHERE present_date = @presentdate) a ON s.studentid = a.STUDENT_ID WHERE s.dept = @department AND s.course_year = @courseYear"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    connection.Open()
                    command.Parameters.AddWithValue("@department", _department)
                    command.Parameters.AddWithValue("@courseYear", _courseYear)
                    command.Parameters.AddWithValue("@presentdate", _presentdate)
                    command.ExecuteNonQuery()
                End Using
                query = "SELECT * FROM Student_Attendance"
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.Fill(dataTable)
            End Using
            With AttendanceDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                If IsAdmin Then
                    .ReadOnly = False
                End If
                If IsAdmin Then
                    For Each column As DataGridViewColumn In AttendanceDataGrid.Columns
                        If column.Name = "is_present" Then
                            AttendanceDataGrid.Columns(column.Name).ReadOnly = False
                        Else
                            AttendanceDataGrid.Columns(column.Name).ReadOnly = True
                        End If
                    Next
                End If
            End With

        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If IsAdmin Then
            Try
                Dim changes As DataTable = CType(AttendanceDataGrid.DataSource, DataTable).GetChanges()

                ' Create a new DataAdapter to update the changes to the database
                Using connection As New SqlConnection(connectionString)
                    Dim query As String = "SELECT * FROM Student_Attendance"
                    Dim adapter As New SqlDataAdapter(query, connection)
                    Dim builder As New SqlCommandBuilder(adapter)

                    ' Update the database with the changes made to the DataTable
                    adapter.SelectCommand = New SqlCommand(query, connection)

                    adapter.InsertCommand = New SqlCommand("INSERT INTO ATTENDANCE (STUDENT_ID, PRESENT_DATE, IS_PRESENT) VALUES (@studentid, @presentdate, @is_present)", connection)
                    adapter.InsertCommand.Parameters.Add("@studentid", SqlDbType.Int, 0, "studentid")
                    adapter.InsertCommand.Parameters.Add("@presentdate", SqlDbType.Date, 0, "presentdate")
                    adapter.InsertCommand.Parameters.Add("@is_present", SqlDbType.Bit, 0, "is_present")

                    ' Set up the UpdateCommand
                    adapter.UpdateCommand = New SqlCommand("UPDATE ATTENDANCE SET IS_PRESENT = @is_present WHERE STUDENT_ID = @studentid AND PRESENT_DATE = @presentdate", connection)
                    adapter.UpdateCommand.Parameters.Add("@is_present", SqlDbType.Bit, 0, "is_present")
                    adapter.UpdateCommand.Parameters.Add("@studentid", SqlDbType.Int, 0, "studentid").SourceVersion = DataRowVersion.Original
                    adapter.UpdateCommand.Parameters.Add("@presentdate", SqlDbType.Date, 0, "presentdate").SourceVersion = DataRowVersion.Original

                    ' Set up the DeleteCommand
                    adapter.DeleteCommand = New SqlCommand("DELETE FROM Attendance WHERE studentid = @studentid AND presentdate = @presentdate", connection)
                    adapter.DeleteCommand.Parameters.Add("@studentid", SqlDbType.Int, 0, "studentid").SourceVersion = DataRowVersion.Original
                    adapter.DeleteCommand.Parameters.Add("@presentdate", SqlDbType.Date, 0, "presentdate").SourceVersion = DataRowVersion.Original
                    Try
                        adapter.Update(changes)
                    Catch ex As Exception
                        If ex.Message.Contains("Concurrency violation: the UpdateCommand") Then
                            adapter.UpdateCommand = New SqlCommand("INSERT INTO ATTENDANCE (STUDENT_ID, PRESENT_DATE, IS_PRESENT) VALUES (@studentid, @presentdate, @is_present)", connection)
                            adapter.UpdateCommand.Parameters.Add("@studentid", SqlDbType.Int, 0, "studentid")
                            adapter.UpdateCommand.Parameters.Add("@presentdate", SqlDbType.Date, 0, "presentdate")
                            adapter.UpdateCommand.Parameters.Add("@is_present", SqlDbType.Bit, 0, "is_present")
                            adapter.Update(changes)
                        End If
                    End Try

                    ' Update the original DataTable with the changes from the database
                    CType(AttendanceDataGrid.DataSource, DataTable).AcceptChanges()
                End Using
                MessageBox.Show("Updated the Table")
            Catch ex As Exception
                If ex.Message.Contains("null") Then
                    Return
                Else
                    MessageBox.Show(ex.Message)
                End If
            End Try
        End If
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class