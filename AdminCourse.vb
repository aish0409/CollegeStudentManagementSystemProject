Imports System.ComponentModel

Public Class AdminCourse
    Private Sub AdminCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckAdmin.IsAdmin Then
            Dim viewForm As New ViewCourse(CheckAdmin.CurrentStudentID)
            viewForm.Show()
            Me.Close()
        End If

    End Sub

    Private Sub ViewCourseButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim Department As String = DepartmentListBox.SelectedItem.ToString()
        Dim CourseYear As String = CourseYearListBox.SelectedItem.ToString()
        Dim adminView As New ViewCourse(Nothing, Department, CourseYear)
        adminView.Show()
    End Sub

    Private Sub UpdateCourseButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If DepartmentListBox.SelectedItem = Nothing And CourseYearListBox.SelectedItem = Nothing Then
            MessageBox.Show("Select Department and Course Year")
            Return
        End If
        Dim Department As String = DepartmentListBox.SelectedItem.ToString()
        Dim CourseYear As String = CourseYearListBox.SelectedItem.ToString()
        Dim updateCourse As New UpdateCourse(Department, CourseYear)
        updateCourse.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class