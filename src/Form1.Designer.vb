<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 15)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(450, 227)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "아이템명"
        Me.ColumnHeader1.Width = 181
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "분류"
        Me.ColumnHeader2.Width = 97
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "개당 가격"
        Me.ColumnHeader3.Width = 79
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "수량"
        Me.ColumnHeader4.Width = 49
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 248)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 38)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "캡쳐"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(93, 248)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 38)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "초기화"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(174, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 41)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "총 0개의 아이템 선택됨" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(0메소)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button3.Location = New System.Drawing.Point(368, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 44)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "내보내기"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 298)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = " 경매장 캡쳐 도구"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As ListView
    Public WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
End Class
