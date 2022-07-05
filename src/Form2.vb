Public Class Form2




    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Label1.Text = Form1.Total_Price.ToString("N0")
        If (CheckBox1.Checked) Then
            Label5.Text = CLng(Form1.Total_Price * 0.97F).ToString("N0")
        Else
            Label5.Text = CLng(Form1.Total_Price * 0.95F).ToString("N0")
        End If

        update_result_prices()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim weight_tboxes As TextBox() = {TextBox2, TextBox5, TextBox8, TextBox11, TextBox14, TextBox17}
        Dim name_tboxes As TextBox() = {TextBox1, TextBox4, TextBox7, TextBox10, TextBox13, TextBox16}


        If (CheckBox2.Checked) Then
            For k As Integer = 0 To 5
                weight_tboxes(k).ReadOnly = True
                weight_tboxes(k).TabStop = False
                If (name_tboxes(k).Text.Length >= 1) Then
                    weight_tboxes(k).Text = 1
                Else
                    weight_tboxes(k).Text = 0
                End If
            Next

        Else
            For k As Integer = 0 To 5
                weight_tboxes(k).ReadOnly = False
                weight_tboxes(k).TabStop = True
            Next
        End If




    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Leave, TextBox4.Leave, TextBox7.Leave, TextBox10.Leave, TextBox13.Leave, TextBox16.Leave,
            TextBox1.TextChanged, TextBox4.TextChanged, TextBox7.TextChanged, TextBox10.TextChanged, TextBox13.TextChanged, TextBox16.TextChanged

        Dim name_tboxes As TextBox() = {TextBox1, TextBox4, TextBox7, TextBox10, TextBox13, TextBox16}
        For k As Integer = 0 To 5
            name_tboxes(k).Text = name_tboxes(k).Text.Replace(",", "")
        Next


        If (CheckBox2.Checked) Then
            If (TextBox1.TextLength > 0) Then
                TextBox2.Text = 1
            End If
            If (TextBox4.TextLength > 0) Then
                TextBox5.Text = 1
            End If
            If (TextBox7.TextLength > 0) Then
                TextBox8.Text = 1
            End If
            If (TextBox10.TextLength > 0) Then
                TextBox11.Text = 1
            End If
            If (TextBox13.TextLength > 0) Then
                TextBox14.Text = 1
            End If
            If (TextBox16.TextLength > 0) Then
                TextBox17.Text = 1
            End If


            If (TextBox1.TextLength = 0) Then
                TextBox2.Text = 0
            End If
            If (TextBox4.TextLength = 0) Then
                TextBox5.Text = 0
            End If
            If (TextBox7.TextLength = 0) Then
                TextBox8.Text = 0
            End If
            If (TextBox10.TextLength = 0) Then
                TextBox11.Text = 0
            End If
            If (TextBox13.TextLength = 0) Then
                TextBox14.Text = 0
            End If
            If (TextBox16.TextLength = 0) Then
                TextBox17.Text = 0
            End If
        End If


    End Sub
    Private Sub weightbox_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged, TextBox5.TextChanged, TextBox8.TextChanged, TextBox11.TextChanged, TextBox14.TextChanged, TextBox17.TextChanged
        update_result_prices()
    End Sub

    Private Sub update_result_prices()
        Dim result_tboxes As TextBox() = {TextBox3, TextBox6, TextBox9, TextBox12, TextBox15, TextBox18}
        Dim w As Double() = get_weights()

        For k As Integer = 0 To 5
            If (CheckBox1.Checked) Then
                result_tboxes(k).Text = (w(k) * Form1.Total_Price * 0.97R).ToString("N0")
            Else
                result_tboxes(k).Text = (w(k) * Form1.Total_Price * 0.95R).ToString("N0")
            End If
        Next
    End Sub

    Private Function get_weights()
        Dim weight_tboxes As TextBox() = {TextBox2, TextBox5, TextBox8, TextBox11, TextBox14, TextBox17}

        Dim w_sum As Double = 0.0R
        Dim weights(6) As Double

        For k As Integer = 0 To 5
            If (weight_tboxes(k).TextLength = 0) Then
                Continue For
            End If
            w_sum += CDbl(weight_tboxes(k).Text)
        Next

        If (w_sum = 0.0) Then
            Return {0.0R, 0.0R, 0.0R, 0.0R, 0.0R, 0.0R}
        Else
            For k As Integer = 0 To 5
                If (weight_tboxes(k).TextLength = 0) Then
                    weights(k) = 0.0R
                Else
                    weights(k) = CDbl(weight_tboxes(k).Text) / w_sum
                End If
            Next
        End If
        Return weights
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For k As Integer = 0 To Main.partyinfo.Count - 1
            ComboBox1.Items.Add(Main.partyinfo(k).Split(",")(0))
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim party_string = Main.partyinfo(ComboBox1.SelectedIndex)
        Dim party_member_autofill As String() = party_string.Split(",")

        Dim party_mem_cnt = party_member_autofill.Length - 2

        Dim target_tboxes As TextBox() = {TextBox1, TextBox4, TextBox7, TextBox10, TextBox13, TextBox16}

        For k As Integer = 0 To party_mem_cnt - 1
            target_tboxes(k).Text = party_member_autofill(k + 2)
        Next

        For k As Integer = party_mem_cnt To 5
            target_tboxes(k).Text = ""
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name_tboxes As TextBox() = {TextBox1, TextBox4, TextBox7, TextBox10, TextBox13, TextBox16}
        Dim result_tboxes As TextBox() = {TextBox3, TextBox6, TextBox9, TextBox12, TextBox15, TextBox18}

        Dim base_str As String = (TextBox19.Text.Replace(":", "").Replace("-", "").Replace(" ", "_")) + ","

        Try
            If (Not My.Computer.FileSystem.FileExists("auction.csv")) Then
                My.Computer.FileSystem.WriteAllText("auction.csv", "", False)
                My.Computer.FileSystem.WriteAllText("logs.txt", vbCrLf + Date.Now.ToString("MM-dd HH:mm") + " " + "분배금 내역 파일 생성", True)
            End If

            For k As Integer = 0 To 5
                If (name_tboxes(k).Text.Length > 1) Then
                    base_str += (name_tboxes(k).Text + "," + result_tboxes(k).Text.Replace(",", "") + ",")
                End If
            Next

            My.Computer.FileSystem.WriteAllText("auction.csv", base_str.Substring(0, base_str.Length - 1) + vbCrLf, True)
            My.Computer.FileSystem.WriteAllText("logs.txt", vbCrLf + Date.Now.ToString("MM-dd HH:mm") + " " + "분배금 내역 저장", True)
            Main.refresh_log()
            Main.todo = Main.ReadAuctionFile()

            Button1.Enabled = False
            Button1.Text = "완료"
        Catch ex As Exception

        End Try

    End Sub
End Class