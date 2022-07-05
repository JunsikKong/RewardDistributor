Public Class Form1

    Dim digits_tmp As Bitmap() = {My.Resources._0, My.Resources._1, My.Resources._2, My.Resources._3,
        My.Resources._4, My.Resources._5, My.Resources._6, My.Resources._7, My.Resources._8, My.Resources._9}

    Dim digits_tmp_b As Bitmap() = {My.Resources._00, My.Resources._11, My.Resources._22, My.Resources._33,
        My.Resources._44, My.Resources._55, My.Resources._66, My.Resources._77, My.Resources._88, My.Resources._99}

    Dim digits_mat(10) As OpenCvSharp.Mat
    Dim digits_mat_b(10) As OpenCvSharp.Mat
    Dim title_mat As OpenCvSharp.Mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(My.Resources.title)
    Dim original_mat As OpenCvSharp.Mat = New OpenCvSharp.Mat()
    Dim sold_mat As OpenCvSharp.Mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(My.Resources.ItemStatus)

    Dim arcane_mat As OpenCvSharp.Mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(My.Resources.arcane)
    Dim absolabs_mat As OpenCvSharp.Mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(My.Resources.absolabs)

    Dim classes_bitmap As Bitmap() = {My.Resources.warrior, My.Resources.mage, My.Resources.archor, My.Resources.thief, My.Resources.pirate}
    Dim classes_mat(5) As OpenCvSharp.Mat

    Dim page_lst As List(Of Integer) = New List(Of Integer)

    Dim namefield_bmp As Bitmap() = {My.Resources.flame1, My.Resources.flame1_1, My.Resources.flame2, My.Resources.flame2_1,
        My.Resources.flame3, My.Resources.flame3_1, My.Resources.scroll1, My.Resources.scroll2, My.Resources.scroll3,
        My.Resources.scroll4, My.Resources.scroll5, My.Resources.consume1, My.Resources.consume2, My.Resources.consume3,
        My.Resources.eq1, My.Resources.eq2, My.Resources.eq3, My.Resources.eq4, My.Resources.eq5, My.Resources.eq6,
        My.Resources.eq7, My.Resources.eq8, My.Resources.eq9, My.Resources.eq10, My.Resources.eq11, My.Resources.eq12}

    Dim namefield As String() = {"강력한 환생의 불꽃", "꺼지지 않는 불꽃", "영원한 환생의 불꽃", "영원히 꺼지지 않는 불꽃",
        "검은 환생의 불꽃", "영원히 꺼지지 않는 검은 불꽃", "놀라운 긍정의 혼돈 주문서 60%", "프리미엄 펫 장비 스크롤",
        "프리미엄 악세서리 스크롤", "매지컬 주문서", "악세서리 스크롤", "대형 보스 명예의 훈장", "수상한 에디셔널 큐브", "추가 경험치 50% 쿠폰",
        "가디언 엔젤 링", "트와일라이트 마크", "에스텔라 이어링", "데이브레이크 펜던트",
        "거대한 공포", "고통의 근원", "루즈 컨트롤 머신 마크", "마력이 깃든 안대", "미트라의 분노",
        "몽환의 벨트", "저주받은 마도서", "커맨더 포스 이어링",
        "앱솔랩스 (무기)", "앱솔랩스 (방어구)", "아케인셰이드 (무기)", "아케인셰이드 (방어구)"}

    Dim namefield_mat(26) As OpenCvSharp.Mat
    Dim prices As List(Of Tuple(Of Long, Long, Integer)) = New List(Of Tuple(Of Long, Long, Integer))  '총 가격, 갯수, 보상타입

    Public Total_Price As Long = 0

    Private Sub Init()


        For i As Integer = 0 To 9
            digits_mat(i) = OpenCvSharp.Extensions.BitmapConverter.ToMat(digits_tmp(i))
            digits_mat_b(i) = OpenCvSharp.Extensions.BitmapConverter.ToMat(digits_tmp_b(i))
            OpenCvSharp.Cv2.CvtColor(digits_mat(i), digits_mat(i), OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
            OpenCvSharp.Cv2.CvtColor(digits_mat_b(i), digits_mat_b(i), OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        Next
        OpenCvSharp.Cv2.CvtColor(title_mat, title_mat, OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        OpenCvSharp.Cv2.CvtColor(sold_mat, sold_mat, OpenCvSharp.ColorConversionCodes.RGBA2GRAY)

        OpenCvSharp.Cv2.CvtColor(arcane_mat, arcane_mat, OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        OpenCvSharp.Cv2.CvtColor(absolabs_mat, absolabs_mat, OpenCvSharp.ColorConversionCodes.RGBA2GRAY)

        For i As Integer = 0 To 4
            classes_mat(i) = OpenCvSharp.Extensions.BitmapConverter.ToMat(classes_bitmap(i))
            OpenCvSharp.Cv2.CvtColor(classes_mat(i), classes_mat(i), OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        Next

        For i As Integer = 0 To namefield_bmp.Length - 1
            namefield_mat(i) = OpenCvSharp.Extensions.BitmapConverter.ToMat(namefield_bmp(i))
            OpenCvSharp.Cv2.CvtColor(namefield_mat(i), namefield_mat(i), OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        Next

        page_lst.Clear()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Private Function ROItoNumeric(ByVal roi As OpenCvSharp.Mat)
        Dim buf As OpenCvSharp.Mat = New OpenCvSharp.Mat()
        Dim buf_thresh As OpenCvSharp.Mat = New OpenCvSharp.Mat()

        Dim dig_lst As List(Of Tuple(Of Integer, Integer)) = New List(Of Tuple(Of Integer, Integer))

        ' 분석 파트
        For digits As Integer = 0 To 9
            OpenCvSharp.Cv2.MatchTemplate(roi, digits_mat(digits), buf, OpenCvSharp.TemplateMatchModes.CCoeffNormed)
            OpenCvSharp.Cv2.Threshold(buf, buf_thresh, 0.95, 1, OpenCvSharp.ThresholdTypes.Binary)

            Dim min_, max_ As Double
            Dim minloc, maxloc As OpenCvSharp.Point
            OpenCvSharp.Cv2.MinMaxLoc(buf_thresh, min_, max_, minloc, maxloc)

            While (Not min_ = max_)
                dig_lst.Add(Tuple.Create(maxloc.X, digits))
                OpenCvSharp.Cv2.FloodFill(buf_thresh, maxloc, New OpenCvSharp.Scalar(0))

                OpenCvSharp.Cv2.MinMaxLoc(buf_thresh, min_, max_, minloc, maxloc)
            End While
        Next
        If (dig_lst.Count > 0) Then
            dig_lst.Sort(Function(p As Tuple(Of Integer, Integer), q As Tuple(Of Integer, Integer)) p.Item1.CompareTo(q.Item1))

            Dim dig_str As String = ""
            For dig_idx As Integer = 0 To dig_lst.Count - 1
                dig_str += dig_lst(dig_idx).Item2.ToString()
            Next

            Return CLng(dig_str)
        Else
            Return -1
        End If

    End Function

    Private Function ROItoNumeric_B(ByVal roi As OpenCvSharp.Mat)
        Dim buf As OpenCvSharp.Mat = New OpenCvSharp.Mat()
        Dim buf_thresh As OpenCvSharp.Mat = New OpenCvSharp.Mat()

        Dim dig_lst As List(Of Tuple(Of Integer, Integer, Double)) = New List(Of Tuple(Of Integer, Integer, Double))

        ' 분석 파트
        For digits As Integer = 0 To 9
            OpenCvSharp.Cv2.MatchTemplate(roi, digits_mat_b(digits), buf, OpenCvSharp.TemplateMatchModes.CCorrNormed)
            OpenCvSharp.Cv2.Threshold(buf, buf_thresh, 0.9, 1.0, OpenCvSharp.ThresholdTypes.Binary)

            Dim min_, max_ As Double
            Dim minloc, maxloc As OpenCvSharp.Point
            OpenCvSharp.Cv2.MinMaxLoc(buf_thresh, min_, max_, minloc, maxloc)

            While (Not min_ = max_)
                dig_lst.Add(Tuple.Create(maxloc.X, digits, max_))
                OpenCvSharp.Cv2.FloodFill(buf_thresh, maxloc, New OpenCvSharp.Scalar(0))

                OpenCvSharp.Cv2.MinMaxLoc(buf_thresh, min_, max_, minloc, maxloc)
            End While
        Next
        If (dig_lst.Count > 0) Then
            dig_lst.Sort(Function(p As Tuple(Of Integer, Integer, Double), q As Tuple(Of Integer, Integer, Double)) p.Item1.CompareTo(q.Item1))

            Dim dig_str As String = ""
            For dig_idx As Integer = 0 To dig_lst.Count - 1
                If (dig_idx > 0) Then
                    If (dig_lst(dig_idx - 1).Item1 = dig_lst(dig_idx).Item1) Then
                        If (dig_lst(dig_idx - 1).Item3 >= dig_lst(dig_idx).Item3) Then

                            Continue For
                        Else
                            dig_str = dig_str.Substring(0, dig_str.Length - 1) + dig_lst(dig_idx).Item2.ToString()
                        End If
                    Else
                        dig_str += dig_lst(dig_idx).Item2.ToString()
                    End If
                Else
                    dig_str += dig_lst(dig_idx).Item2.ToString()
                End If



            Next

            Return CLng(dig_str)
        Else
            Return -1
        End If

    End Function


    Private Function Capture_screen()
        'Total Screen Capture
        Dim btMain As Bitmap = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

        Using g As Graphics = Graphics.FromImage(btMain)
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             btMain.Size,
                            CopyPixelOperation.SourceCopy)
            'Picture Box Display
        End Using

        Return btMain
    End Function


    Private Function Contains_rect(ByVal template As OpenCvSharp.Mat, ByVal screen As OpenCvSharp.Mat)
        Dim a_, b_ As Double
        Dim c_, d_ As OpenCvSharp.Point

        Dim out_mat_ As OpenCvSharp.Mat = New OpenCvSharp.Mat()

        OpenCvSharp.Cv2.MatchTemplate(screen, template, out_mat_, OpenCvSharp.TemplateMatchModes.CCoeffNormed)
        OpenCvSharp.Cv2.Threshold(out_mat_, out_mat_, 0.85, 1, OpenCvSharp.ThresholdTypes.Binary)
        OpenCvSharp.Cv2.MinMaxLoc(out_mat_, a_, b_, c_, d_)


        If (d_.Y = 0 Or d_.X = 0) Then
            Return False
        End If

        Return True

    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bitmap_buf As Bitmap = Capture_screen()
        Dim in_mat As OpenCvSharp.Mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap_buf)
        OpenCvSharp.Cv2.CvtColor(in_mat, in_mat, OpenCvSharp.ColorConversionCodes.RGBA2GRAY)
        ' Pattern matching process

        Dim out_mat As OpenCvSharp.Mat = New OpenCvSharp.Mat()

        Dim a, b As Double
        Dim c, d As OpenCvSharp.Point


        ' 분석 파트

        OpenCvSharp.Cv2.MatchTemplate(in_mat, title_mat, out_mat, OpenCvSharp.TemplateMatchModes.CCoeffNormed)
        OpenCvSharp.Cv2.Threshold(out_mat, out_mat, 0.8, 1, OpenCvSharp.ThresholdTypes.Binary)
        OpenCvSharp.Cv2.MinMaxLoc(out_mat, a, b, c, d)




        If (d.Y = 0 Or d.X = 0) Then
            Main.Label6.Text = ("경매장 UI가 인식되지 않습니다.")
        Else
            ' ROI submatrix
            Dim sub_roi As OpenCvSharp.Mat = in_mat(d.Y, d.Y + 567, d.X, d.X + 981)

            If (original_mat.Size.Height = 0) Then
                original_mat = sub_roi
            Else
                OpenCvSharp.Cv2.VConcat(sub_roi, original_mat, original_mat)
            End If


            For sub_idx As Integer = 0 To 8
                Dim item_name_rect As OpenCvSharp.Mat = sub_roi(51 + 55 * sub_idx, 65 + 55 * sub_idx, 247, 448)
                Dim item_status As OpenCvSharp.Mat = sub_roi(51 + 55 * sub_idx, 64 + 55 * sub_idx, 571, 623)
                Dim price_rect As OpenCvSharp.Mat = sub_roi(46 + 55 * sub_idx, 56 + 55 * sub_idx, 719, 802)

                Dim item_cnt As OpenCvSharp.Mat = sub_roi(60 + 55 * sub_idx, 72 + 55 * sub_idx, 158, 191)



                ' 분석 파트
                If (Not Contains_rect(sold_mat, item_status)) Then
                    Continue For
                End If

                Dim price As Long = ROItoNumeric(price_rect)
                Dim items_cnt As Long = ROItoNumeric_B(item_cnt)

                If (price < 0) Then
                    Exit For
                End If

                Dim item_category As String = "소비/기타"
                Dim item_name As String = ""

                Dim itemcode As Integer

                ' 아이템분류
                If (Contains_rect(absolabs_mat, item_name_rect)) Then
                    item_category = "장비"
                    item_name += "앱솔랩스 "
                    itemcode = 26

                    Dim sw As Integer = 0

                    For idx As Integer = 0 To 4
                        sw = sw Or Contains_rect(classes_mat(idx), item_name_rect)
                    Next
                    If (sw) Then
                        item_name += "(방어구)"
                        itemcode += 1
                    Else
                        item_name += "(무기)"
                    End If

                ElseIf (Contains_rect(arcane_mat, item_name_rect)) Then
                    item_category = "장비"
                    item_name += "아케인셰이드 "
                    itemcode = 28

                    Dim sw As Integer = 0

                    For idx As Integer = 0 To 4
                        sw = sw Or Contains_rect(classes_mat(idx), item_name_rect)
                    Next

                    If (sw) Then
                        item_name += "(방어구)"
                        itemcode += 1
                    Else
                        item_name += "(무기)"
                    End If
                Else
                    itemcode = -1
                    For k As Integer = 0 To 25
                        If Contains_rect(namefield_mat(25 - k), item_name_rect) Then
                            itemcode = 25 - k
                            Exit For
                        End If
                    Next

                End If

                If (itemcode >= 14) Then
                    item_category = "장비"
                Else
                    item_category = "소비/기타"
                End If

                If items_cnt = -1 Then
                    items_cnt = 1
                End If



                Dim newitem As ListViewItem = New ListViewItem()

                If itemcode < 0 Then
                    newitem.Text = "(기타 아이템)"
                Else
                    newitem.Text = namefield(itemcode)
                End If

                newitem.SubItems.Add(item_category)
                newitem.SubItems.Add((price / items_cnt).ToString())
                newitem.SubItems.Add(items_cnt.ToString())

                ListView1.Items.Add(newitem)
                Dim newitem_tup As Tuple(Of Long, Long, Integer) = New Tuple(Of Long, Long, Integer)(price, items_cnt, itemcode)
                prices.Add(newitem_tup)



            Next

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        prices.Clear()
        ListView1.Items.Clear()
        Label2.Text = "총 0개의 아이템 선택됨" + vbCrLf + vbCrLf + "(0메소)"
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.ItemChecked, ListView1.ItemCheck
        If (ListView1.Items.Count = 0) Then
            Return
        Else
            Dim price As Long = 0
            Dim cnts As Integer = 0




            For k As Integer = 0 To ListView1.CheckedItems.Count() - 1
                cnts += 1
                price += prices(ListView1.CheckedIndices(k)).Item1
            Next

            Label2.Text = "총 " + cnts.ToString() + "개의 아이템 선택됨" + vbCrLf + vbCrLf + "(" + price.ToString("N0") + "메소)"

            Total_Price = price
            Form2.Label1.Text = Total_Price.ToString("N0")
            If (Form2.CheckBox1.Checked) Then
                Form2.Label5.Text = CLng(Total_Price * 0.97R).ToString("N0")
            Else
                Form2.Label5.Text = CLng(Total_Price * 0.95R).ToString("N0")
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Form2.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

        Form2.TextBox19.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
        Form2.Label1.Text = Total_Price.ToString("N0")
        Form2.Label5.Text = CLng(Total_Price * 0.97R).ToString("N0")

    End Sub

    Private Sub move_exportwindow(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Form2.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)
    End Sub

End Class
