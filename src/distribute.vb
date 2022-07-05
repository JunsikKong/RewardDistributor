Public Class distribute
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim final_aucinfo_str As String = DateTime.Now.ToString("yyyyMMdd_HHmm") + ","


            For Each idx In ListView1.CheckedIndices
                final_aucinfo_str += (ListView1.Items(idx).Text + ",-" + ListView1.Items.Item(idx).SubItems(1).Text + ",")
            Next
            My.Computer.FileSystem.WriteAllText("auction.csv", final_aucinfo_str.Substring(0, final_aucinfo_str.Length - 1) + vbCrLf, True)
            Main.todo = Main.ReadAuctionFile()
            load_todo()

        Catch ex As Exception

        End Try


    End Sub


    Public Sub load_todo()
        ListView1.Items.Clear()
        Label3.Text = 0
        Label4.Text = 0
        Label5.Text = 0

        Dim todo_spl As String() = Main.todo.Split(",")
        Dim todo_price As Long = 0


        For k As Integer = 0 To CInt(todo_spl.Length / 2) - 1
            Dim newitem As ListViewItem = New ListViewItem()

            newitem.Text = todo_spl(2 * k)
            newitem.SubItems.Add(todo_spl(2 * k + 1).ToString())

            todo_price += CLng(todo_spl(2 * k + 1))

            ListView1.Items.Add(newitem)
        Next
        Label3.Text = todo_price.ToString("N0")
    End Sub

    Private Sub distribute_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_todo()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.ItemCheck, ListView1.ItemChecked
        Try
            Dim price_cumul As Long = 0

            For Each idx In ListView1.CheckedIndices
                price_cumul += CLng(ListView1.Items.Item(idx).SubItems(1).Text)
            Next

            Label4.Text = price_cumul.ToString("N0")
            Label5.Text = (CLng(Label3.Text) - price_cumul).ToString("N0")

            Label7.Text = ListView1.CheckedIndices.Count.ToString() + "명 선택"
        Catch ex As Exception

        End Try

    End Sub
End Class