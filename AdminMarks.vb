Imports System.ComponentModel

Public Class AdminMarks
    Private Sub AdminMarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsAdmin Then
            Dim viewForm As New ViewMarks(CurrentStudentID)
            viewForm.Show()
            Me.Close()
        End If

    End Sub

    Private Sub ViewMarksButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If DepartmentListBox.SelectedItem <> Nothing And CourseYearListBox.SelectedItem <> Nothing Then
            Dim Department As String = DepartmentListBox.SelectedItem.ToString()
            Dim CourseYear As String = CourseYearListBox.SelectedItem.ToString()
            Dim adminView As New ViewMarks(Nothing, Department, CourseYear)
            adminView.Show()
        Else
            MessageBox.Show("Select Department and Course Year")
            Return
        End If
    End Sub

    Private Sub UpdateMarksButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If DepartmentListBox.SelectedItem <> Nothing And CourseYearListBox.SelectedItem <> Nothing Then
            Dim Department As String = DepartmentListBox.SelectedItem.ToString()
            Dim CourseYear As String = CourseYearListBox.SelectedItem.ToString()
            Dim adminUpdate As New UpdateMarks(Department, CourseYear)
            adminUpdate.Show()
        Else
            MessageBox.Show("Select Department and Course Year")
            Return
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class