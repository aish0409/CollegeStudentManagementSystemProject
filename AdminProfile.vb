Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Windows.Input

Public Class AdminProfile
    Private Sub AdminProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckAdmin.IsAdmin Then
            Dim viewForm As New ViewProfile(CheckAdmin.CurrentStudentID)
            viewForm.Show()
            Close()
        End If

    End Sub

    Private Sub ViewProfileButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim studentID As String = StudentIDComboBox.SelectedValue
        Dim adminView As New ViewProfile(studentID)
        adminView.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
        If DepartmentListBox.SelectedItem <> Nothing And CourseYearListBox.SelectedItem <> Nothing Then
            Dim department As String = DepartmentListBox.SelectedItem.ToString()
            Dim courseYear As String = CourseYearListBox.SelectedItem.ToString()
            Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
            Dim query As String = "SELECT StudentId FROM studentreg WHERE Dept = @department AND Course_Year = @courseYear"
            Dim datatable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@department", department)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@courseYear", courseYear)
                connection.Open()
                dataAdapter.Fill(datatable)
            End Using
            With StudentIDComboBox
                .DataSource = datatable
                .DisplayMember = "StudentID"
                .ValueMember = "StudentID"
            End With
        Else
            MessageBox.Show("Select Department and Course Year.")
            Return
        End If
    End Sub
End Class