Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class AdminPayment
    Dim connectionString As String = "Data Source=DESKTOP-JI8QG4T\SQLSERVER2022;Initial Catalog=collegestudent;Integrated Security=True"
    Private Sub ViewPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsAdmin Then
            Dim query As String = "SELECT * FROM FEE_PAYMENT"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                connection.Open()
                dataAdapter.Fill(dataTable)
            End Using
            With FeeDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ReadOnly = False
            End With
        Else
            Dim query As String = "SELECT * FROM FEE_PAYMENT WHERE COURSE_YEAR = (SELECT Course_Year FROM studentreg WHERE StudentId = @stdID) AND DEPT = (SELECT Dept FROM studentreg WHERE StudentId = @stdID)"
            Dim dataTable As New DataTable()
            Using connection As New SqlConnection(connectionString)
                Dim dataAdapter As New SqlDataAdapter(query, connection)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@stdID", CurrentStudentID)
                connection.Open()
                dataAdapter.Fill(dataTable)
            End Using
            With FeeDataGrid
                .DataSource = dataTable
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .ReadOnly = True
            End With
        End If

    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If IsAdmin Then
            Try
                Dim changes As DataTable = CType(FeeDataGrid.DataSource, DataTable).GetChanges()

                ' Create a new DataAdapter to update the changes to the database
                Using connection As New SqlConnection(connectionString)
                    Dim adapter As New SqlDataAdapter("SELECT * FROM FEE_PAYMENT", connection)
                    Dim builder As New SqlCommandBuilder(adapter)

                    ' Update the database with the changes made to the DataTable
                    adapter.UpdateCommand = builder.GetUpdateCommand()
                    adapter.InsertCommand = builder.GetInsertCommand()
                    adapter.DeleteCommand = builder.GetDeleteCommand()
                    adapter.Update(changes)

                    ' Update the original DataTable with the changes from the database
                    CType(FeeDataGrid.DataSource, DataTable).AcceptChanges()
                End Using
                MessageBox.Show("Updated the Table")
            Catch ex As Exception
                MessageBox.Show("Invalid entry.")
            End Try
        End If
        Close()
    End Sub

    Private Sub PayButton_Click(sender As Object, e As EventArgs) Handles PayButton.Click
        Dim url As String = "https://pay.google.com/"
        Dim OpenURL As New ProcessStartInfo With {
        .UseShellExecute = True,
        .FileName = "explorer.exe",
        .Arguments = url
    }

        Process.Start(OpenURL)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CardPayButton_Click(sender As Object, e As EventArgs) Handles CardPayButton.Click
        Dim cardPayment As New CardPayment()
        cardPayment.Show()
    End Sub
End Class