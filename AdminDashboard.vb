Public Class AdminDashboard
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AdminCourse.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AdminProfile.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AdminMarks.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AdminAttendance.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AdminPayment.Show()
    End Sub


End Class