<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.파티원관리ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.파티원관리ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.분배금ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.경매장캡쳐도구ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.분배금장부ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.새링스카니아ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.파티원ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.파티원관리ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.분배금ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.경매장캡쳐도구ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.내역수정ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.새링스카니아ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        '파티원관리ToolStripMenuItem
        '
        Me.파티원관리ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.파티원관리ToolStripMenuItem1})
        Me.파티원관리ToolStripMenuItem.Name = "파티원관리ToolStripMenuItem"
        Me.파티원관리ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.파티원관리ToolStripMenuItem.Text = "파티원"
        '
        '파티원관리ToolStripMenuItem1
        '
        Me.파티원관리ToolStripMenuItem1.Name = "파티원관리ToolStripMenuItem1"
        Me.파티원관리ToolStripMenuItem1.Size = New System.Drawing.Size(138, 22)
        Me.파티원관리ToolStripMenuItem1.Text = "파티원 관리"
        '
        '분배금ToolStripMenuItem
        '
        Me.분배금ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.경매장캡쳐도구ToolStripMenuItem, Me.분배금장부ToolStripMenuItem})
        Me.분배금ToolStripMenuItem.Name = "분배금ToolStripMenuItem"
        Me.분배금ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.분배금ToolStripMenuItem.Text = "분배금"
        '
        '경매장캡쳐도구ToolStripMenuItem
        '
        Me.경매장캡쳐도구ToolStripMenuItem.Name = "경매장캡쳐도구ToolStripMenuItem"
        Me.경매장캡쳐도구ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.경매장캡쳐도구ToolStripMenuItem.Text = "경매장 캡쳐 도구"
        '
        '분배금장부ToolStripMenuItem
        '
        Me.분배금장부ToolStripMenuItem.Name = "분배금장부ToolStripMenuItem"
        Me.분배금장부ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.분배금장부ToolStripMenuItem.Text = "내역 수정"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(67, 20)
        Me.ToolStripMenuItem1.Text = "제작문의"
        '
        '새링스카니아ToolStripMenuItem
        '
        Me.새링스카니아ToolStripMenuItem.Enabled = False
        Me.새링스카니아ToolStripMenuItem.Name = "새링스카니아ToolStripMenuItem"
        Me.새링스카니아ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.새링스카니아ToolStripMenuItem.Text = "새링@스카니아"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-2, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "파티 운영 중"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 129)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(168, 78)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.TabStop = False
        Me.TextBox1.WordWrap = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "최근 작업"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(91, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 33)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "미정산 내역"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 57)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 38)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "0"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(91, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 38)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "0"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Info
        Me.Label6.Location = New System.Drawing.Point(0, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '파티원ToolStripMenuItem
        '
        Me.파티원ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.파티원관리ToolStripMenuItem2})
        Me.파티원ToolStripMenuItem.Name = "파티원ToolStripMenuItem"
        Me.파티원ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.파티원ToolStripMenuItem.Text = "파티원"
        '
        '파티원관리ToolStripMenuItem2
        '
        Me.파티원관리ToolStripMenuItem2.Name = "파티원관리ToolStripMenuItem2"
        Me.파티원관리ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.파티원관리ToolStripMenuItem2.Text = "파티원 관리"
        '
        '분배금ToolStripMenuItem1
        '
        Me.분배금ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.경매장캡쳐도구ToolStripMenuItem1, Me.내역수정ToolStripMenuItem})
        Me.분배금ToolStripMenuItem1.Name = "분배금ToolStripMenuItem1"
        Me.분배금ToolStripMenuItem1.Size = New System.Drawing.Size(55, 20)
        Me.분배금ToolStripMenuItem1.Text = "분배금"
        '
        '경매장캡쳐도구ToolStripMenuItem1
        '
        Me.경매장캡쳐도구ToolStripMenuItem1.Name = "경매장캡쳐도구ToolStripMenuItem1"
        Me.경매장캡쳐도구ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.경매장캡쳐도구ToolStripMenuItem1.Text = "경매장 캡쳐 도구"
        '
        '내역수정ToolStripMenuItem
        '
        Me.내역수정ToolStripMenuItem.Name = "내역수정ToolStripMenuItem"
        Me.내역수정ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.내역수정ToolStripMenuItem.Text = "내역 수정"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.새링스카니아ToolStripMenuItem1})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(71, 20)
        Me.ToolStripMenuItem2.Text = "제작 문의"
        '
        '새링스카니아ToolStripMenuItem1
        '
        Me.새링스카니아ToolStripMenuItem1.Enabled = False
        Me.새링스카니아ToolStripMenuItem1.Name = "새링스카니아ToolStripMenuItem1"
        Me.새링스카니아ToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.새링스카니아ToolStripMenuItem1.Text = "새링@스카니아"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.파티원ToolStripMenuItem, Me.분배금ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(189, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(189, 238)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = "분배금 정산기"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 파티원관리ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 파티원관리ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 분배금ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 경매장캡쳐도구ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 분배금장부ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 새링스카니아ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 파티원ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 파티원관리ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents 분배금ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 경매장캡쳐도구ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 내역수정ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents 새링스카니아ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
End Class
