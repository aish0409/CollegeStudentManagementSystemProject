Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class UpdateMarks

    Private ReadOnly _department As String
    Private ReadOnly _courseYear As String

    Public Sub New(Department As String, CourseYear As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _department = Department
        _courseYear = CourseYear
    End Sub

    Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"

    Private Sub UpdateMarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_StudentID()
        Load_CourseID()
    End Sub
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If ValidateAllTextBoxes(Me) Then
            Dim query As String = "INSERT INTO MARKS(STUDENT_ID, COURSE_ID, MARKS) VALUES (@stdID, @courseID, @marks)"
            Try
                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@stdID", StudentIDComboBox.SelectedValue)
                        command.Parameters.AddWithValue("@courseID", CourseIDComboBox.SelectedValue)
                        command.Parameters.AddWithValue("@marks", MarksTextBox.Text)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show($"Marks has been inserted.")
            Catch ex As Exception
                If ex.Message.Contains("UC_StudentCourse") Then
                    query = "UPDATE MARKS SET MARKS = @marks WHERE STUDENT_ID = @stdID AND COURSE_ID = @courseID"
                    Using connection As New SqlConnection(connectionString)
                        Using command As New SqlCommand(query, connection)
                            command.Parameters.AddWithValue("@stdID", StudentIDComboBox.SelectedValue)
                            command.Parameters.AddWithValue("@courseID", CourseIDComboBox.SelectedValue)
                            command.Parameters.AddWithValue("@marks", MarksTextBox.Text)
                            connection.Open()
                            command.ExecuteNonQuery()
                        End Using
                    End Using
                    MessageBox.Show($"Marks has been updated.")
                End If
            End Try
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim query As String = "DELETE FROM MARKS WHERE STUDENT_ID = @stdID AND COURSE_ID = @courseID"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@stdID", StudentIDComboBox.SelectedValue)
                command.Parameters.AddWithValue("@courseID", CourseIDComboBox.SelectedValue)
                connection.Open()
                If command.ExecuteNonQuery() = 0 Then
                    MessageBox.Show($"Entry with corresponding ID does not exist")
                    Return
                Else
                    MessageBox.Show($"Marks has been deleted.")
                End If
            End Using
        End Using
    End Sub

    Private Sub Marks_Validate(sender As Object, e As CancelEventArgs) Handles MarksTextBox.Validating
        If Not IsNumeric(MarksTextBox.Text) Then
            MessageBox.Show("Enter a Valid Mark.")
        ElseIf CInt(MarksTextBox.Text) > 100 Or CInt(MarksTextBox.Text) < 0 Then
            MessageBox.Show("Enter a Valid Mark.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Load_StudentID()
        Dim query As String = "SELECT StudentId FROM studentreg WHERE Dept = @department AND Course_Year = @courseYear"
        Dim datatable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Dim dataAdapter As New SqlDataAdapter(query, connection)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@department", _department)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@courseYear", _courseYear)
            connection.Open()
            dataAdapter.Fill(datatable)
        End Using
        With StudentIDComboBox
            .DataSource = datatable
            .DisplayMember = "StudentID"
            .ValueMember = "StudentID"
        End With
    End Sub

    Private Sub Load_CourseID()
        Dim query As String = "SELECT COURSE_ID, COURSE_NAME FROM COURSE_DETAILS WHERE DEPT = @department AND COURSE_YEAR = @courseYear"
        Dim datatable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Dim dataAdapter As New SqlDataAdapter(query, connection)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@department", _department)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@courseYear", _courseYear)
            connection.Open()
            dataAdapter.Fill(datatable)
        End Using
        With CourseIDComboBox
            .DataSource = datatable
            .DisplayMember = "COURSE_NAME"
            .ValueMember = "COURSE_ID"
        End With
    End Sub
End Class
