Imports System.ComponentModel

Public Class AdminAttendance
    Private Sub AdminAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckAdmin.IsAdmin Then
            Dim viewForm As New ViewAttendance(CheckAdmin.CurrentStudentID)
            viewForm.Show()
            Me.Close()
        End If

    End Sub

    Private Sub ViewAttendanceButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If DepartmentListBox.SelectedItem <> Nothing And CourseYearListBox.SelectedItem <> Nothing Then
            Dim Department As String = DepartmentListBox.SelectedItem.ToString()
            Dim CourseYear As String = CourseYearListBox.SelectedItem.ToString()
            Dim PresentDate As Date = PresentDatePicker.Value.Date
            Dim adminView As New ViewAttendance(Nothing, Department, CourseYear, PresentDate)
            adminView.Show()
        Else
            MessageBox.Show("Select Department and Course Year")
            Return
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class