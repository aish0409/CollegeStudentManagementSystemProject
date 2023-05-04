<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAttendance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AttendanceDataGrid = New System.Windows.Forms.DataGridView()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.AttendanceDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AttendanceDataGrid
        '
        Me.AttendanceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AttendanceDataGrid.Location = New System.Drawing.Point(202, 105)
        Me.AttendanceDataGrid.Name = "AttendanceDataGrid"
        Me.AttendanceDataGrid.ReadOnly = True
        Me.AttendanceDataGrid.RowHeadersWidth = 51
        Me.AttendanceDataGrid.RowTemplate.Height = 29
        Me.AttendanceDataGrid.Size = New System.Drawing.Size(300, 188)
        Me.AttendanceDataGrid.TabIndex = 0
        '
        'OkButton
        '
        Me.OkButton.Location = New System.Drawing.Point(214, 348)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(94, 29)
        Me.OkButton.TabIndex = 1
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(390, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ViewAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.AttendanceDataGrid)
        Me.Name = "ViewAttendance"
        Me.Text = "ViewAttendance"
        CType(Me.AttendanceDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AttendanceDataGrid As DataGridView
    Friend WithEvents OkButton As Button
    Friend WithEvents Button1 As Button
End Class
