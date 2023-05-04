Public Module CheckAdmin
    Public IsAdmin As Boolean
    Public CurrentStudentID As String
    Public Sub ValidateStudentID(ByVal studentID As String)
        If studentID.Length <> 9 Then
            MessageBox.Show("Student ID should be 6 characters long.")
            Return
        Else
            Dim dept As String = studentID.Substring(3, 3)
            If dept <> "BBA" AndAlso dept <> "BCA" AndAlso dept <> "BA0" Then
                MessageBox.Show("Invalid Student ID.")
                Return
            Else
                Dim courseYear As String = studentID.Substring(6, 3)
                If courseYear <> "001" AndAlso courseYear <> "002" AndAlso courseYear <> "003" Then
                    MessageBox.Show("Invalid Student ID.")
                    Return
                End If
            End If
        End If
    End Sub

    Public Function ValidateAllTextBoxes(form As Form, ParamArray excludeTextBoxes() As TextBox) As Boolean
        For Each textBox As TextBox In form.Controls.OfType(Of TextBox)()
            If Not excludeTextBoxes.Contains(textBox) AndAlso String.IsNullOrEmpty(textBox.Text) Then
                MessageBox.Show("Please fill in all the required fields.")
                Return False
            End If
        Next
        Return True
    End Function

End Module
