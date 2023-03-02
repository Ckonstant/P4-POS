Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports Syncfusion.WinForms.DataGrid.Styles
Imports System.ComponentModel
Imports Syncfusion.WinForms.DataGrid.Events
Imports Syncfusion.WinForms.DataGrid.Interactivity
Imports Syncfusion.Data
Imports Syncfusion.WinForms.DataGrid

Public Class Form1
    Private mprcTabTip As Process
    Dim cmd As New SqlCommand
    Dim sqlcon As SqlConnection
    Dim con As New SqlConnection("Data Source=hostequal1.ddns.net\MSSQLSERVER,1433;Initial Catalog=C:\USERS\AKUAKU\DOWNLOADS\1_9_EQUAL\EQUALV1_24_7\EQUALV1_16_7\EQUALV1\EQUALV1\DATABASE1.MDF;Persist Security Info=True;User ID=SuperAdmin;Password=SuperAdmin")
    Private Const WM_SYSCOMMAND As Int32 = 274
    Private Const SC_CLOSE As UInt32 = 61536

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Integer
    End Function
    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure
    Dim TouchhWnd As IntPtr = New IntPtr(0)
    Public Sub disp_data()
        If con.State = ConnectionState.Open Then
            con.Close()

        End If
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from posSales"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        SfDataGrid1.DataSource = dt



    End Sub

    Private Sub SfDataGrid1_QueryImageCellStyle(ByVal sender As Object, ByVal e As QueryImageCellStyleEventArgs)
        '' Dim employee = CType(e.Record, equalPoint.pointOSRowChangeEvent)
        ''MsgBox(e.ColumnIndex)
        If e.DisplayText = "Καφές" Then
            e.Image = (Image.FromFile("C:\Users\Akuaku\Desktop\icoBLACK\wine_bottle_16px.png"))
            e.DisplayText = "Καφές"

            e.TextImageRelation = TextImageRelation.ImageBeforeText
        End If





    End Sub
    Private Sub SfDataGrid1_QueryCellStyle(ByVal sender As Object, ByVal e As QueryCellStyleEventArgs)
        If e.Column.MappingName = "kathgoria" Then
            If e.DisplayText = "Καφές" Then
                ' e.Style.BackColor = Color.FromArgb(200, 164, 164, 164)

            End If

        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'EqualPoint.posSale' table. You can move, or remove it, as needed.
        Me.PosSaleTableAdapter.Fill(Me.EqualPoint.posSale)
        'TODO: This line of code loads data into the 'EqualPoint.posSale' table. You can move, or remove it, as needed.
        Me.PosSaleTableAdapter.Fill(Me.EqualPoint.posSale)
        'TODO: This line of code loads data into the 'EqualPoint.Sales' table. You can move, or remove it, as needed.
        ' Me.SalesTableAdapter.Fill(Me.EqualPoint.Sales)
        ' Me.SfDataGrid1.Columns.Add(New GridImageColumn() With {.MappingName = "kathgoria", .HeaderText = "Product Name", .TextImageRelation = TextImageRelation.ImageBeforeText})
        'TODO: This line of code loads data into the 'EqualPoint.pointOS' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'EqualPoint.pointOS' table. You can move, or remove it, as needed.
        '' Me.PointOSTableAdapter.Fill(Me.EqualPoint.pointOS)
        'TODO: This line of code loads data into the 'EqualHostDB.pointOS' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'EqualHostDB.pointOS' table. You can move, or remove it, as needed.

        'AddHandler SfDataGrid1.DrawCell, AddressOf SfDataGrid1_DrawCell
        AddHandler SfDataGrid1.QueryImageCellStyle, AddressOf SfDataGrid1_QueryImageCellStyle
        AddHandler SfDataGrid1.QueryCellStyle, AddressOf SfDataGrid1_QueryCellStyle
        'TODO: This line of code loads data into the 'EqualDataset1.pointOS' table. You can move, or remove it, as needed.
        ' disp_data()
        Me.SfDataGrid1.Style.CellStyle.Font.Size = 15
        Me.SfDataGrid1.Style.CellStyle.TextColor = Color.FromArgb(125, 129, 130)
        Me.SfDataGrid1.ShowRowHeader = True
        Me.SfDataGrid1.RowHeaderWidth = 4
        Me.SfDataGrid1.Style.RowHeaderStyle.BackColor = Color.White
        Me.SfDataGrid1.Style.RowHeaderStyle.Borders.All = New GridBorder(GridBorderStyle.None, GridBorderWeight.ExtraThick)
        Me.SfDataGrid1.Style.CellStyle.Borders.Right = New GridBorder(GridBorderStyle.None)
        Me.SfDataGrid1.Style.CellStyle.Borders.Bottom = New GridBorder(Color.WhiteSmoke)
        Me.SfDataGrid1.RowHeight = 50
        Me.SfDataGrid1.Style.SelectionStyle.BackColor = Color.White
    End Sub
    Private Sub GunaGradient2Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles GunaGradient2Panel2.MouseClick
        GunaGradient2Panel1.Visible = True
        GunaGradient2Panel2.Visible = False
        'GunaLabel2.ForeColor = Color.FromArgb(46, 204, 113)
        Timer1.Start()
    End Sub
    Private Sub GunaGradient2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles GunaGradient2Panel2.Paint

    End Sub

    Private Sub GunaLabel2_Click(sender As Object, e As EventArgs) Handles GunaLabel2.Click
        GunaGradient2Panel1.Visible = True
        GunaGradient2Panel2.Visible = False
        'GunaLabel2.ForeColor = Color.FromArgb(46, 204, 113)
        Timer1.Start()
    End Sub
    Dim i As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        i += 1
        If i = 30 Then
            Timer1.Stop()
            GunaGradient2Panel1.Visible = False
            GunaGradient2Panel2.Visible = True
            '    GunaLabel2.ForeColor = Color.FromArgb(46, 204, 113)
            i = 0
            Try
                sqlcon = New SqlConnection("Data Source=" + GunaTextBox1.Text + "\MSSQLSERVER,1433;Initial Catalog=C:\USERS\AKUAKU\DOWNLOADS\1_9_EQUAL\EQUALV1_24_7\EQUALV1_16_7\EQUALV1\EQUALV1\DATABASE1.MDF;Persist Security Info=True;User ID=SuperAdmin;Password=SuperAdmin")
                sqlcon.Open()
                MsgBox("success")
            Catch ex As Exception
                MsgBox("failed")
            End Try
        End If

    End Sub
    Private Sub GunaLabel3_Click(sender As Object, e As EventArgs) Handles GunaLabel3.Click
        GunaGradient2Panel1.Visible = True
        GunaGradient2Panel2.Visible = False
        'GunaLabel2.ForeColor = Color.FromArgb(46, 204, 113)
        Timer1.Start()
    End Sub

    Private Sub GunaTileButton1_Click(sender As Object, e As EventArgs) Handles GunaTileButton1.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "0"
        Else
            TextBox1.Text = "0"
        End If
    End Sub

    Private Sub GunaTileButton2_Click(sender As Object, e As EventArgs) Handles GunaTileButton2.Click
        If Not TextBox1.Text.Contains(".") Then
            TextBox1.Text += "."
        End If
    End Sub

    Private Sub GunaTileButton3_Click(sender As Object, e As EventArgs) Handles GunaTileButton3.Click
        TextBox1.Text = "0"
    End Sub

    Private Sub GunaTileButton6_Click(sender As Object, e As EventArgs) Handles GunaTileButton6.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "1"
        Else
            TextBox1.Text = "1"
        End If
    End Sub

    Private Sub GunaTileButton5_Click(sender As Object, e As EventArgs) Handles GunaTileButton5.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "2"
        Else
            TextBox1.Text = "2"
        End If
    End Sub

    Private Sub GunaTileButton4_Click(sender As Object, e As EventArgs) Handles GunaTileButton4.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "3"
        Else
            TextBox1.Text = "3"
        End If
    End Sub

    Private Sub GunaTileButton9_Click(sender As Object, e As EventArgs) Handles GunaTileButton9.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "4"
        Else
            TextBox1.Text = "4"
        End If
    End Sub

    Private Sub GunaTileButton8_Click(sender As Object, e As EventArgs) Handles GunaTileButton8.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "5"
        Else
            TextBox1.Text = "5"
        End If
    End Sub

    Private Sub GunaTileButton7_Click(sender As Object, e As EventArgs) Handles GunaTileButton7.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "6"
        Else
            TextBox1.Text = "6"
        End If
    End Sub

    Private Sub GunaTileButton12_Click(sender As Object, e As EventArgs) Handles GunaTileButton12.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "7"
        Else
            TextBox1.Text = "7"
        End If
    End Sub

    Private Sub GunaTileButton11_Click(sender As Object, e As EventArgs) Handles GunaTileButton11.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "8"
        Else
            TextBox1.Text = "8"
        End If
    End Sub

    Private Sub GunaTileButton10_Click(sender As Object, e As EventArgs) Handles GunaTileButton10.Click
        If TextBox1.Text <> "0" Then
            TextBox1.Text += "9"
        Else
            TextBox1.Text = "9"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Dim hWndIPTip_Main_Window As IntPtr = FindWindow("IPTip_Main_Window", Nothing)
        If (hWndIPTip_Main_Window <> IntPtr.Zero) Then
            PostMessage(hWndIPTip_Main_Window, WM_SYSCOMMAND, CType(SC_CLOSE, IntPtr), IntPtr.Zero)
        End If
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        If mprcTabTip Is Nothing OrElse mprcTabTip.HasExited Then
            If mprcTabTip IsNot Nothing AndAlso mprcTabTip.HasExited Then
                mprcTabTip.Close()
                For Each pkiller As Process In Process.GetProcesses
                    If String.Compare(pkiller.ProcessName, "tabtip", True) = 0 Then
                        pkiller.Kill()
                    End If
                Next
            End If
            mprcTabTip = Process.Start("C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe")

            'TextBox1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox(SfDataGrid1.Columns(2).MappingName)
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    End Sub
End Class
