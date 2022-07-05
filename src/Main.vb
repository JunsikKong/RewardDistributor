Public Class Main
    Public partyinfo As List(Of String) = New List(Of String)
    Public auctionInfo As List(Of String) = New List(Of String)

    Public party_members As List(Of String) = New List(Of String)
    Public party_price As List(Of Long) = New List(Of Long)

    Public todo As String = ""

    Private Sub 파티원관리ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 파티원관리ToolStripMenuItem2.Click
        partyedit.Show()
        partyedit.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
    End Sub

    Private Sub 경매장캡쳐도구ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 경매장캡쳐도구ToolStripMenuItem1.Click
        Form1.Show()
        Form1.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

    End Sub


    Private Sub OnFormSizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Dim clientsize As Size = MyBase.ClientSize()
        Dim delta_h As Integer = MyBase.Height - clientsize.Height
        Dim H_mb As Integer = MenuStrip1.Height

        Label1.Width = CInt(clientsize.Width / 2)
        Label1.Location = New Point(0, H_mb)

        Label3.Width = CInt(clientsize.Width / 2)
        Label3.Location = New Point(Label1.Width + 1, H_mb)

        Label4.Width = Label1.Width
        Label4.Location = New Point(0, 57)

        Label5.Width = Label1.Width
        Label5.Location = New Point(Label4.Width + 1, 57)

        Label6.Width = clientsize.Width - 24
        Label6.Location = New Point(12, 110)

        TextBox1.Location = New Point(12, 129)
        TextBox1.Width = Label6.Width
        If (clientsize.Height <= 159) Then
            TextBox1.Height = 1
        Else
            TextBox1.Height = clientsize.Height - 159
        End If

        Label6.Width = clientsize.Width
        Label6.Location = New Point(0, clientsize.Height - Label6.Height)

        distribute.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
        AuctionLog.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
        partyedit.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

        If MyBase.ClientSize.Height < (H_mb + Label1.Height + Label4.Height + Label6.Height) Then
            MyBase.Height = (H_mb + Label1.Height + Label4.Height + Label6.Height + delta_h)
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim startsize As String = GetSetting("BossDistributor", "OnStart", "StartAppWidth", "220,277")
            MyBase.Width = CInt(startsize.Split(",")(0))
            MyBase.Height = CInt(startsize.Split(",")(1))


            If (My.Computer.FileSystem.FileExists("logs.txt")) Then
                Dim logs As String() = My.Computer.FileSystem.ReadAllText("logs.txt").Split(vbCrLf)
            Else
                My.Computer.FileSystem.WriteAllText("logs.txt", Date.Now.ToString("MM-dd HH:mm") + " " + "로그 파일 생성", True)
            End If
            refresh_log()

            If (My.Computer.FileSystem.FileExists("parties.csv")) Then
                Dim parties_string As String() = My.Computer.FileSystem.ReadAllText("parties.csv").Split(vbCrLf)
                For k As Integer = 0 To parties_string.Length - 1
                    If (parties_string(k).Replace(vbCrLf, "").Length > 1) Then
                        partyinfo.Add(parties_string(k).Replace(vbCrLf, ""))
                    End If
                    Label4.Text = partyinfo.Count.ToString()

                Next
            Else
                My.Computer.FileSystem.WriteAllText("parties.csv", "", False)
                My.Computer.FileSystem.WriteAllText("logs.txt", vbCrLf + Date.Now.ToString("MM-dd HH:mm") + " " + "파티 파일 생성", True)
            End If

            If (My.Computer.FileSystem.FileExists("auction.csv")) Then
                todo = ReadAuctionFile()
            Else
                My.Computer.FileSystem.WriteAllText("auction.csv", "", False)
                My.Computer.FileSystem.WriteAllText("logs.txt", vbCrLf + Date.Now.ToString("MM-dd HH:mm") + " " + "분배금 내역 파일 생성", True)
            End If



            refresh_log()
        Catch ex As Exception

            Label6.Text = "로드 중 오류 발생. 재시작 필요."
        End Try
    End Sub


    Private Sub Main_Finish(sender As Object, e As EventArgs) Handles MyBase.Closed
        SaveSetting("BossDistributor", "OnStart", "StartAppWidth", MyBase.Width.ToString() + "," + MyBase.Height.ToString())
    End Sub

    Public Sub refresh_log()
        Dim logs As String() = My.Computer.FileSystem.ReadAllText("logs.txt").Split(vbCrLf)
        TextBox1.Text = ""
        For k As Integer = 0 To logs.Length - 1
            TextBox1.Text = logs(k) + vbCrLf + TextBox1.Text
        Next
    End Sub


    Public Function ReadAuctionFile()
        auctionInfo.Clear()
        party_members.Clear()
        party_price.Clear()

        Dim auc_txt As String() = My.Computer.FileSystem.ReadAllText("auction.csv").Split(vbCrLf)
        For k As Integer = 0 To auc_txt.Length - 1
            If (auc_txt(k).Length <= 1) Then
                Continue For
            End If

            auctionInfo.Add(auc_txt(k))

            Dim line_parse As String() = auc_txt(k).Split(",")

            Dim nickname As String
            Dim price As Long = 0

            For ptcp_idx As Integer = 0 To CInt((line_parse.Length - 1) / 2) - 1

                nickname = line_parse(2 * ptcp_idx + 1)
                price = CLng(line_parse(2 * ptcp_idx + 2))

                If (Not party_members.Contains(nickname)) Then
                    party_members.Add(nickname)
                    party_price.Add(price)
                Else
                    party_price(party_members.IndexOf(nickname)) += price
                End If

            Next

        Next

        Dim remaining_list As String = ""
        Dim remaining_cnt As Integer = 0

        For k As Integer = 0 To party_members.Count - 1
            If (Not party_price(k) = 0) Then
                remaining_list += (party_members(k) + "," + party_price(k).ToString() + ",")
                remaining_cnt += 1
            End If
        Next

        Label5.Text = remaining_cnt.ToString()

        If (remaining_cnt > 0) Then
            Label5.ForeColor = Color.Red
            Label3.BackColor = Color.FromArgb(255, 224, 192)
            Label5.BackColor = Color.FromArgb(255, 224, 192)
            Label3.Cursor = Cursors.Hand
            Label5.Cursor = Cursors.Hand

            Return remaining_list.Substring(0, (remaining_list.Length - 1))
        Else
            Label5.ForeColor = Color.DarkGreen
            Label3.BackColor = Color.FromArgb(192, 255, 192)
            Label5.BackColor = Color.FromArgb(192, 255, 192)
            Label3.Cursor = Cursors.Default
            Label5.Cursor = Cursors.Default

            Return ""
        End If


    End Function

    Private Sub 분배금장부ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 내역수정ToolStripMenuItem.Click
        AuctionLog.Show()
        AuctionLog.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click, Label3.Click
        If (CInt(Label5.Text) > 0) Then
            distribute.Show()
            distribute.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
        End If
    End Sub


    Private Sub move_exportwindow(sender As Object, e As EventArgs) Handles Me.LocationChanged
        distribute.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
        AuctionLog.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
        partyedit.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
    End Sub


End Class