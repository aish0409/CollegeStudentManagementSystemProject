<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardPayment
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
        Me.components = New System.ComponentModel.Container()
        Me.CardNumberTextBox = New System.Windows.Forms.TextBox()
        Me.CVVTextBox = New System.Windows.Forms.TextBox()
        Me.FullNameTextBox = New System.Windows.Forms.TextBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MonthTextBox = New System.Windows.Forms.TextBox()
        Me.DateTextBox = New System.Windows.Forms.TextBox()
        Me.DelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'CardNumberTextBox
        '
        Me.CardNumberTextBox.Location = New System.Drawing.Point(179, 70)
        Me.CardNumberTextBox.Name = "CardNumberTextBox"
        Me.CardNumberTextBox.PlaceholderText = "Card Number"
        Me.CardNumberTextBox.Size = New System.Drawing.Size(187, 27)
        Me.CardNumberTextBox.TabIndex = 0
        '
        'CVVTextBox
        '
        Me.CVVTextBox.Location = New System.Drawing.Point(179, 158)
        Me.CVVTextBox.Name = "CVVTextBox"
        Me.CVVTextBox.PlaceholderText = "CVV"
        Me.CVVTextBox.Size = New System.Drawing.Size(187, 27)
        Me.CVVTextBox.TabIndex = 1
        Me.CVVTextBox.UseSystemPasswordChar = True
        '
        'FullNameTextBox
        '
        Me.FullNameTextBox.Location = New System.Drawing.Point(179, 339)
        Me.FullNameTextBox.Name = "FullNameTextBox"
        Me.FullNameTextBox.PlaceholderText = "Full Name(as per Card)"
        Me.FullNameTextBox.Size = New System.Drawing.Size(187, 27)
        Me.FullNameTextBox.TabIndex = 3
        '
        'OkButton
        '
        Me.OkButton.Location = New System.Drawing.Point(543, 369)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(94, 29)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 261)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "/"
        '
        'MonthTextBox
        '
        Me.MonthTextBox.Location = New System.Drawing.Point(180, 258)
        Me.MonthTextBox.Name = "MonthTextBox"
        Me.MonthTextBox.PlaceholderText = "MM"
        Me.MonthTextBox.Size = New System.Drawing.Size(62, 27)
        Me.MonthTextBox.TabIndex = 6
        '
        'DateTextBox
        '
        Me.DateTextBox.Location = New System.Drawing.Point(269, 258)
        Me.DateTextBox.Name = "DateTextBox"
        Me.DateTextBox.PlaceholderText = "DD"
        Me.DateTextBox.Size = New System.Drawing.Size(63, 27)
        Me.DateTextBox.TabIndex = 7
        '
        'DelayTimer
        '
        '
        'CardPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DateTextBox)
        Me.Controls.Add(Me.MonthTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.FullNameTextBox)
        Me.Controls.Add(Me.CVVTextBox)
        Me.Controls.Add(Me.CardNumberTextBox)
        Me.Name = "CardPayment"
        Me.Text = "CardPayment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CardNumberTextBox As TextBox
    Friend WithEvents CVVTextBox As TextBox
    Friend WithEvents FullNameTextBox As TextBox
    Friend WithEvents OkButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents MonthTextBox As TextBox
    Friend WithEvents DateTextBox As TextBox
    Friend WithEvents DelayTimer As Timer
End Class
