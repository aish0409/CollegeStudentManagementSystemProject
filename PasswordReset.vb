Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class PasswordReset

    Private ReadOnly _studentID As String
    Public Sub New(StudentID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _studentID = StudentID

    End Sub
    Private Sub PasswordReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DOB_Validate(sender As Object, e As CancelEventArgs) Handles DOBPicker.Validating
        If DOBPicker.Value.Date >= Today Then
            MessageBox.Show("Enter a Valid Date.")
        ElseIf (Today.Year - DOBPicker.Value.Date.Year) <= 17 Or (Today.Year - DOBPicker.Value.Date.Year) >= 23 Then
            MessageBox.Show("Enter a Valid Date.")
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If Not String.IsNullOrEmpty(PasswordTextBox.Text) AndAlso Not String.IsNullOrEmpty(ConfirmPasswordTextBox.Text) Then
            Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "SELECT * FROM studentreg WHERE StudentId = @studentID AND DOB = @dob"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@studentID", _studentID)
                    command.Parameters.AddWithValue("@dob", DOBPicker.Value.Date)
                    connection.Open()
                    If command.ExecuteScalar = Nothing Then
                        MessageBox.Show("Wrong Date of Birth was entered.")
                        Close()
                    Else
                        query = "UPDATE studentreg SET Password = @pwd WHERE StudentId = @studentID"
                        Using updateCommand As New SqlCommand(query, connection)
                            updateCommand.Parameters.AddWithValue("@pwd", PasswordTextBox.Text)
                            updateCommand.Parameters.AddWithValue("@studentID", _studentID)
                            updateCommand.ExecuteNonQuery()
                            MessageBox.Show("Password has been reset successfully.")
                            Close()
                        End Using
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Please Enter the Password correctly.")
        End If
    End Sub

    Private Sub ConfirmPasswordTextBox_Validation(sender As Object, e As EventArgs) Handles ConfirmPasswordTextBox.Validated
        If ConfirmPasswordTextBox.Text <> PasswordTextBox.Text Then
            MessageBox.Show("Passwords do not match.")
            ConfirmPasswordTextBox.Text = ""
            Return
        End If
    End Sub

    Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged
        If ShowPasswordCheckBox.Checked Then
            PasswordTextBox.UseSystemPasswordChar = False
            ConfirmPasswordTextBox.UseSystemPasswordChar = False
        Else
            PasswordTextBox.UseSystemPasswordChar = True
            ConfirmPasswordTextBox.UseSystemPasswordChar = True
        End If
    End Sub
End Class