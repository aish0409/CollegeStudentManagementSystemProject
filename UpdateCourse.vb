Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class UpdateCourse
    Private ReadOnly _studentId As String
    Private ReadOnly _department As String
    Private ReadOnly _courseYear As String
    Public Sub New(Department As String, CourseYear As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _department = Department
        _courseYear = CourseYear
    End Sub

    Private Sub UpdateCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DepartmentTextBox.Text = _department
        CourseYearTextBox.Text = _courseYear
        Load_CourseName()
        Load_CourseID()
    End Sub

    Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If ValidateAllTextBoxes(Me, Array.Empty(Of TextBox)()) Then
            Dim query As String = "INSERT INTO COURSE_DETAILS(COURSE_ID, COURSE_NAME, DEPT, COURSE_YEAR) VALUES (@courseID, @courseName, @dept, @courseYear)"
            Try
                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@courseID", CourseIDComboBox.Text)
                        command.Parameters.AddWithValue("@courseName", CourseNameComboBox.Text)
                        command.Parameters.AddWithValue("@dept", DepartmentTextBox.Text)
                        command.Parameters.AddWithValue("@courseYear", CourseYearTextBox.Text)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show($"New Course has been inserted for Course ID {CourseIDComboBox.Text} with Course Name {CourseNameComboBox.Text} under Department {DepartmentTextBox.Text} for Year {CourseYearTextBox.Text}.")
            Catch ex As Exception
                If ex.Message.Contains("PRIMARY KEY") Then
                    query = "UPDATE COURSE_DETAILS SET COURSE_NAME = @courseName, DEPT = @dept, COURSE_YEAR = @courseYear WHERE COURSE_ID = @courseID"
                    Using connection As New SqlConnection(connectionString)
                        Using command As New SqlCommand(query, connection)
                            command.Parameters.AddWithValue("@courseID", CourseIDComboBox.Text)
                            command.Parameters.AddWithValue("@courseName", CourseNameComboBox.Text)
                            command.Parameters.AddWithValue("@dept", DepartmentTextBox.Text)
                            command.Parameters.AddWithValue("@courseYear", CourseYearTextBox.Text)
                            connection.Open()
                            command.ExecuteNonQuery()
                        End Using
                    End Using
                    MessageBox.Show($"Course has been updated for Course ID {CourseIDComboBox.Text} with Course Name {CourseNameComboBox.Text} under Department {DepartmentTextBox.Text} for Year {CourseYearTextBox.Text}.")
                End If
            End Try
        End If
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim query As String = "DELETE FROM COURSE_DETAILS WHERE COURSE_ID = @courseID"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@courseID", CourseIDComboBox.Text)
                connection.Open()
                If command.ExecuteNonQuery() = 0 Then
                    MessageBox.Show($"Course with Course ID {CourseIDComboBox.Text} does not exist")
                    Return
                Else
                    MessageBox.Show($"Course ID {CourseIDComboBox.Text} has been deleted.")
                End If
            End Using
        End Using
    End Sub

    Private Sub DepartmentTextBox_Validation(sender As Object, e As CancelEventArgs) Handles DepartmentTextBox.Validating
        Dim validDepartments As String() = {"BBA", "BCA", "BA"}
        If Not validDepartments.Contains(DepartmentTextBox.Text.ToUpper()) Then
            MessageBox.Show("Please enter a valid Department (BBA, BCA, or BA).")
        End If
    End Sub

    Private Sub CourseYear_Validation(sender As Object, e As CancelEventArgs) Handles CourseYearTextBox.Validating
        Dim validYears As String() = {"1", "2", "3"}
        If Not validYears.Contains(CourseYearTextBox.Text) Then
            MessageBox.Show("Please enter a valid Course Year (1, 2, or 3).")
        End If
    End Sub

    Private Sub Load_CourseName()
        Dim query As String = "SELECT COURSE_ID, COURSE_NAME FROM COURSE_DETAILS WHERE DEPT = @department AND COURSE_YEAR = @courseYear"
        Dim datatable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            Dim dataAdapter As New SqlDataAdapter(query, connection)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@department", _department)
            dataAdapter.SelectCommand.Parameters.AddWithValue("@courseYear", _courseYear)
            connection.Open()
            dataAdapter.Fill(datatable)
        End Using
        With CourseNameComboBox
            .DataSource = datatable
            .DisplayMember = "COURSE_NAME"
            .ValueMember = "COURSE_ID"
        End With
    End Sub

    Private Sub Load_CourseID()
        Dim query As String = "SELECT COURSE_ID FROM COURSE_DETAILS WHERE DEPT = @department AND COURSE_YEAR = @courseYear"
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
            .DisplayMember = "COURSE_ID"
            .ValueMember = "COURSE_ID"
        End With
    End Sub

    Private Sub CourseName_Validation(sender As Object, e As EventArgs) Handles CourseNameComboBox.Validating
        If CourseNameComboBox.Text.Trim() = "" OrElse Not Regex.IsMatch(CourseNameComboBox.Text, "^[a-zA-Z ]+$") Then
            MessageBox.Show("Please enter a valid name.")
            Return
        End If
    End Sub

    Private Sub CourseID_Validation(sender As Object, e As EventArgs) Handles CourseIDComboBox.Validating
        If Not IsNumeric(CourseIDComboBox.Text) Then
            If CourseIDComboBox.Text <> 3 Then
                MessageBox.Show("Invalid Course ID")
                Return
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CourseNameComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CourseNameComboBox.SelectedIndexChanged
        CourseIDComboBox.Text = CourseNameComboBox.SelectedValue.ToString()
    End Sub
End Class
