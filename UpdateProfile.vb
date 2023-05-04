Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.Text.RegularExpressions

Public Class UpdateProfile
    Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"

    Private ReadOnly _studentID As String
    Public Sub New(studentID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _studentID = studentID

    End Sub

    Private Sub UpdateProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query = "SELECT * FROM studentreg where StudentId = @stdid"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@stdid", _studentID)
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Do While reader.Read()
                    FirstNameTextBox.Text = reader.Item("FirstName").ToString()
                    LastNameTextBox.Text = reader.Item("LastName").ToString()
                    StudentIDTextBox.Text = reader.Item("StudentId").ToString()
                    DepartmentTextBox.Text = reader.Item("Dept").ToString()
                    CourseYearTextBox.Text = reader.Item("Course_Year").ToString()
                    PasswordTextBox.Text = reader.Item("Password").ToString()
                    DOBPicker.Value = reader.Item("DOB").ToString()
                    EmailTextBox.Text = reader.Item("Email").ToString()
                    CourseYearTextBox.ReadOnly = True
                    DepartmentTextBox.ReadOnly = True
                    PasswordTextBox.ReadOnly = True
                    StudentIDTextBox.ReadOnly = True
                    If IsAdmin Then
                        DepartmentTextBox.ReadOnly = False
                        CourseYearTextBox.ReadOnly = False
                        PasswordTextBox.ReadOnly = False
                        StudentIDTextBox.ReadOnly = False
                    End If
                Loop
                reader.Close()
            End Using
        End Using
        If Not CheckAdmin.IsAdmin Then
            Me.Controls.Remove(DeleteButton)
        End If
    End Sub
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Try
            Dim query As String = "INSERT INTO studentreg(FirstName, LastName, StudentId, Dept, Password, Course_Year, DOB, Email) VALUES (@firstname, @lastname, @stdid, @dept, @pwd, @year, @dob, @email)"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@firstname", FirstNameTextBox.Text)
                    command.Parameters.AddWithValue("@lastname", LastNameTextBox.Text)
                    command.Parameters.AddWithValue("@dept", DepartmentTextBox.Text)
                    command.Parameters.AddWithValue("@year", CourseYearTextBox.Text)
                    command.Parameters.AddWithValue("@dob", DOBPicker.Value.Date)
                    command.Parameters.AddWithValue("@email", EmailTextBox.Text)
                    command.Parameters.AddWithValue("@stdid", StudentIDTextBox.Text)
                    command.Parameters.AddWithValue("@pwd", PasswordTextBox.Text)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show($"Student with Student ID {StudentIDTextBox.Text} has been inserted.")
        Catch ex As Exception
            If ex.Message.Contains("PRIMARY KEY") Then
                Dim query = "UPDATE studentreg SET FirstName = @firstname, LastName = @lastname, Password = @pwd, Dept = @dept, Course_Year = @year, DOB = @dob, Email = @email WHERE StudentId = @stdid"
                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@firstname", FirstNameTextBox.Text)
                        command.Parameters.AddWithValue("@lastname", LastNameTextBox.Text)
                        command.Parameters.AddWithValue("@dept", DepartmentTextBox.Text)
                        command.Parameters.AddWithValue("@year", CourseYearTextBox.Text)
                        command.Parameters.AddWithValue("@dob", DOBPicker.Value.Date)
                        command.Parameters.AddWithValue("@email", EmailTextBox.Text)
                        command.Parameters.AddWithValue("@stdid", StudentIDTextBox.Text)
                        command.Parameters.AddWithValue("@pwd", PasswordTextBox.Text)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show($"Student with Student ID {StudentIDTextBox.Text} has been updated.")
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        Dim query As String = "DELETE FROM studentreg WHERE StudentId = @stdID"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@stdID", StudentIDTextBox.Text)
                connection.Open()
                If command.ExecuteNonQuery() = 0 Then
                    MessageBox.Show($"Student with Student ID {StudentIDTextBox.Text} does not exist")
                    Return
                Else
                    MessageBox.Show($"Student ID {StudentIDTextBox.Text} has been deleted.")
                End If
            End Using
        End Using
    End Sub
    Private Sub FirstName_Validate(sender As Object, e As CancelEventArgs) Handles FirstNameTextBox.Validating
        If FirstNameTextBox.Text.Trim() = "" OrElse Not Regex.IsMatch(FirstNameTextBox.Text.Trim(), "^[a-zA-Z]+$") Then
            MessageBox.Show("Enter a Valid First Name.")
            e.Cancel = True
        End If
    End Sub

    Private Sub LastName_Validate(sender As Object, e As CancelEventArgs) Handles LastNameTextBox.Validating
        If LastNameTextBox.Text.Trim() = "" OrElse Not Regex.IsMatch(LastNameTextBox.Text.Trim(), "^[a-zA-Z]+$") Then
            MessageBox.Show("Enter a Valid First Name.")
            e.Cancel = True
        End If
    End Sub

    Private Sub StudentID_Validate(sender As Object, e As CancelEventArgs) Handles StudentIDTextBox.Validating
        ValidateStudentID(StudentIDTextBox.Text)
        e.Cancel = True
    End Sub

    Private Sub DepartmentTextBox_Validation(sender As Object, e As CancelEventArgs) Handles DepartmentTextBox.Validating
        Dim validDepartments As String() = {"BBA", "BCA", "BA"}
        If Not validDepartments.Contains(DepartmentTextBox.Text.ToUpper()) Then
            MessageBox.Show("Please enter a valid Department (BBA, BCA, or BA).")
            e.Cancel = True
        End If
    End Sub

    Private Sub CourseYear_Validation(sender As Object, e As CancelEventArgs) Handles CourseYearTextBox.Validating
        Dim validYears As String() = {"1", "2", "3"}
        If Not validYears.Contains(CourseYearTextBox.Text) Then
            MessageBox.Show("Please enter a valid Course Year (1, 2, or 3).")
            e.Cancel = True
        End If
    End Sub

    Private Sub DOB_Validate(sender As Object, e As CancelEventArgs) Handles DOBPicker.Validating
        If DOBPicker.Value.Date >= Today Then
            MessageBox.Show("Enter a Valid Date.")
            e.Cancel = True
        End If
    End Sub

    Private Sub Email_Validate(sender As Object, e As CancelEventArgs) Handles EmailTextBox.Validating
        If Not EmailTextBox.Text.Contains("@gmail.com") Then
            MessageBox.Show("Enter a Valid Email.")
            e.Cancel = True
        End If
    End Sub
End Class