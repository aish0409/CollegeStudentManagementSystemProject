Imports System.Text.RegularExpressions

Public Class CardPayment
    Private Sub CardNumber_Validation(sender As Object, e As EventArgs) Handles CardNumberTextBox.Validating
        If (String.IsNullOrEmpty(CardNumberTextBox.Text) = False) Then
            If (IsNumeric(CardNumberTextBox.Text) = False) OrElse (CardNumberTextBox.Text.Length <> 16) Then
                MessageBox.Show("Invalid Card Number.")
                CardNumberTextBox.Text = ""
                Return
            End If
        End If
    End Sub

    Private Sub CVV_Validation(sender As Object, e As EventArgs) Handles CVVTextBox.Validating
        If (String.IsNullOrEmpty(CVVTextBox.Text) = False) Then
            If (IsNumeric(CVVTextBox.Text) = False) OrElse CVVTextBox.Text.Length <> 3 Then
                MessageBox.Show("Invalid CVV.")
                CVVTextBox.Text = ""
                Return
            End If
        End If
    End Sub

    Private Sub Month_Validation(sender As Object, e As EventArgs) Handles MonthTextBox.Validating
        If Not String.IsNullOrEmpty(MonthTextBox.Text) Then
            If (IsNumeric(MonthTextBox.Text) = False) OrElse CInt(MonthTextBox.Text) > 12 Then
                MessageBox.Show("Enter Correct Month.")
                MonthTextBox.Text = ""
                Return
            End If
        End If
    End Sub

    Private Sub Date_Validation(sender As Object, e As EventArgs) Handles DateTextBox.Validating
        If Not String.IsNullOrEmpty(DateTextBox.Text) Then
            If (IsNumeric(DateTextBox.Text) = False) OrElse CInt(DateTextBox.Text) > 31 Then
                MessageBox.Show("Enter Correct Date.")
                DateTextBox.Text = ""
                Return
            End If
        End If
    End Sub

    Private Sub FullName_Validation(sender As Object, e As EventArgs) Handles FullNameTextBox.Validating
        If FullNameTextBox.Text.Trim() = "" OrElse Not Regex.IsMatch(FullNameTextBox.Text, "^[a-zA-Z ]+$") Then
            MessageBox.Show("Please enter a valid name.")
            FullNameTextBox.Text = ""
            Return
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If ValidateAllTextBoxes(Me, Array.Empty(Of TextBox)()) Then
            DelayTimer.Interval = 2000
            DelayTimer.Start()
        End If
    End Sub

    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles DelayTimer.Tick
        DelayTimer.Stop()
        MessageBox.Show("Payment was Successful.")
        Close()
    End Sub

    Private Sub FullNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles FullNameTextBox.TextChanged

    End Sub
End Class