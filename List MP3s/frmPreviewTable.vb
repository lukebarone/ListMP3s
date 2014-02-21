Public Class frmPreviewTable

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set ListView Properties
        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.HideSelection = False
        ListView1.MultiSelect = False

        ' Create Columns Headers
        ListView1.Columns.Add("Artist")
        ListView1.Columns.Add("Album")
        ListView1.Columns.Add("Title")
        ListView1.Columns.Add("Track")
        ListView1.Columns.Add("Year")
        ListView1.Columns.Add("Genre")
        ListView1.Columns.Add("Comment")
        ListView1.Columns.Add("Filename")

        Dim tempValue As Int64 = 0
        ProgressBar1.Maximum = frmMain.ListBox1.Items.Count
        For i As Integer = 0 To frmMain.ListBox1.Items.Count - 1
            ProgressBar1.Value = i

            Dim Current As New ID3(frmMain.ListBox1.Items(i))
            Current.ReadID3()
            ' Create List View Item (Row)
            Dim lvi As New ListViewItem

            ' First Column can be the listview item's Text
            lvi.Text = Current.Artist

            ' Second Column is the first sub item
            lvi.SubItems.Add(Current.Album)

            ' Third Column is the second sub item
            lvi.SubItems.Add(Current.Title)
            lvi.SubItems.Add(Current.TitleNumber)
            lvi.SubItems.Add(Current.Year)
            lvi.SubItems.Add(Current.Genre)
            lvi.SubItems.Add(Current.Comment)
            lvi.SubItems.Add(Current.ToString)

            ' Add the ListViewItem to the ListView
            ListView1.Items.Add(lvi)

        Next
        ProgressBar1.Visible = False
    End Sub
End Class