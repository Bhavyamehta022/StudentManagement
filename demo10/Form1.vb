Imports MySql.Data.MySqlClient



Public Class Form1
    Dim mysqlconn As MySqlConnection

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim dt As DataTable


    Public nm As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MySqlConn = New MySqlConnection
        MySqlConn.connectionstring = "server=localhost;userid=root;password=1234;database=bhavya"


        Dim username As String = TextBox1.Text
		Dim password As String = TextBox2.Text
        cmd = New MySqlCommand("select usename,pswrd from login where usename='" + TextBox1.Text + "' and pswrd = '" + TextBox2.Text + "' ", mysqlconn)
        da = New MySqlDataAdapter(cmd)
        dt = New DataTable()
		da.Fill(dt)
		If (dt.Rows.Count > 0) Then
            nm = TextBox1.Text

            MessageBox.Show("login successful", "success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
			home.Show()
		Else
			MsgBox("Invalid login information", MessageBoxButtons.OK, MessageBoxIcon.Error)

		End If

	End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End

    End Sub
End Class
