Imports System.Data.SqlClient
Imports System.Windows

Public Class AdminLoginForm
    Dim connection As SqlConnection
    Dim command As SqlCommand
    Dim rdr As SqlDataReader


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtUsername.Text = "") Then
            MessageBox.Show("Enter username")
            txtUsername.Focus()
            Exit Sub

        End If
        If (txtPassword.Text = "") Then
            MessageBox.Show("Enter password")
            txtPassword.Focus()
            Exit Sub
        End If
        Try

            connection = New SqlConnection("Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True")
            connection.Open()
            command = New SqlCommand("select * from adminlogin where Username='" & txtUsername.Text & "' and password ='" & txtPassword.Text & "'")
            command.Connection = connection
            rdr = command.ExecuteReader
            If (rdr.Read()) Then
                AdminDashboard.Show()
                Me.Close()
                CheckAdmin.IsAdmin = True
            Else
                MessageBox.Show("Enter valid username and password")
                txtUsername.Text = ""
                txtPassword.Text = ""

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdminLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub ShowPasswordCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPasswordCheckBox.CheckedChanged
        If ShowPasswordCheckBox.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class