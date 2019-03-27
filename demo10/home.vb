Imports System.Data
Imports MySql.Data.MySqlClient



Public Class home
    Dim con As MySqlConnection

    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim cs As String

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Form1.nm
        bindgrid()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cs = "server=localhost;userid=root;password=1234;database=bhavya"
        con = New MySqlConnection(cs)
        con.Open()
        cmd = New MySqlCommand("insert into register values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", con)
        Dim i As Integer = cmd.ExecuteNonQuery()
        If (i > 0) Then
            clear()
            MessageBox.Show("Record saved Successfully", "success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
            bindgrid()

        Else
            MsgBox("Not saved")
        End If
        con.Close()



    End Sub

    Private Sub bindgrid()
        Using con As New MySqlConnection("server=localhost;userid=root;password=1234;database=bhavya")
            con.Open()
            Using cmd As New MySqlCommand("select * from register", con)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DataGridView1.DataSource = dt

                    End Using
                End Using
            End Using
        End Using

    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        End

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con = New MySqlConnection("server=localhost;userid=root;password=1234;database=bhavya")
        con.Open()
        cmd = New MySqlCommand("delete from register where roll = '" & TextBox1.Text & "' ", con)
        cmd.ExecuteNonQuery()
        MsgBox("Record is Deleted")
        Me.bindgrid()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con = New MySqlConnection("server=localhost;userid=root;password=1234;database=bhavya")
        con.Open()
        Dim qr = "update register set  nm = '" & TextBox2.Text & "',class = '" & TextBox3.Text & "',address = '" & TextBox4.Text & "' where roll = '" + TextBox1.Text + "'"

        cmd = New MySqlCommand(qr, con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Updated")
        clear()
        Me.bindgrid()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Try
            TextBox1.Text = DataGridView1.Item(0, i).Value
            TextBox2.Text = DataGridView1.Item(1, i).Value
            TextBox3.Text = DataGridView1.Item(2, i).Value
            TextBox4.Text = DataGridView1.Item(3, i).Value
        Catch ex As Exception
            MsgBox("sorry")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con = New MySqlConnection("server=localhost;userid=root;password=1234;database=bhavya")
            con.Open()
        cmd = New MySqlCommand("select *from register where roll = @roll", con)
            cmd.Parameters.Add("@roll", MySqlDbType.Int16).Value = TextBox5.Text
            Dim adp As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adp.Fill(table)

        If (table.Rows.Count() > 0) Then
                DataGridView1.DataSource = table
                TextBox1.Text = table.Rows(0)(0).ToString
            TextBox2.Text = table.Rows(0)(1).ToString
            TextBox3.Text = table.Rows(0)(2).ToString
            TextBox4.Text = table.Rows(0)(3).ToString

        Else
            MessageBox.Show("no data found")

        End If
        Catch ex As Exception
        MsgBox("exception..Sorry no data found")
        End Try



    End Sub

    Private Sub TextBox5_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyUp
        If (TextBox5.Text = "") Then
            bindgrid()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        clear()

    End Sub
End Class



