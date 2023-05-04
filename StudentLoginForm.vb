Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class StudentLoginForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StudentRegistrationForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(txtStudentID.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter your Student ID and password.")
            Return
        End If

        ' Get the values entered by the user
        Dim studentID As String = txtStudentID.Text
        Dim password As String = txtPassword.Text

        ' Connect to the SQL Server database
        Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        ' Execute a SQL query to check if the student ID and password match
        Dim commandText As String = "SELECT * FROM studentreg WHERE StudentID = @StudentID AND Password = @Password"
        Dim command As New SqlCommand(commandText, connection)
        command.Parameters.AddWithValue("@StudentID", studentID)
        command.Parameters.AddWithValue("@Password", password)
        Dim reader As SqlDataReader = command.ExecuteReader()

        ' Check if the query returned any rows
        If reader.HasRows Then

            ' Login successful, navigate to the main form
            Dim StudentDashboard As New AdminDashboard
            Me.Hide()
            StudentDashboard.Show()
            CheckAdmin.IsAdmin = False
            CheckAdmin.CurrentStudentID = studentID
        Else
            ' Login failed, display an error message
            lblError.Text = "Invalid student ID or password , 
                             Please register yourself first. "


        End If

        ' Close the database connection and clean up resources
        reader.Close()
        connection.Close()
        command.Dispose()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If


    End Sub

    Private Sub StudentLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PasswordResetLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles PasswordResetLabel.LinkClicked
        If Not String.IsNullOrEmpty(txtStudentID.Text) Then
            Dim passwordReset As New PasswordReset(txtStudentID.Text)
            passwordReset.Show()
        Else
            MessageBox.Show("Enter Student ID")
            Return
        End If
    End Sub
End Class