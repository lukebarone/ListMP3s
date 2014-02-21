Imports System.IO
Public Class frmMain
    Private WithEvents MyApiVideo As New ApiVideo

#Region " Subs for events "
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each sCommandString As String In My.Application.CommandLineArgs
            If sCommandString = vbNullString Then
                Exit For
            Else
                LoadListBox(sCommandString)
            End If
        Next
        CheckIfListHasStuff()
        tbrVolume.Value = MyApiVideo.Volume
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Me.ListBox1.SelectedItem = vbNullString Then Exit Sub
        Dim mp3File As New ID3(txtFilename.Text)
        'mp3File = txtFilename.Text
        mp3File.HasTag = chkHasTag.Checked
        If chkHasTag.Checked = True Then
            mp3File.Title = txtTitle.Text
            mp3File.Album = txtAlbum.Text
            mp3File.Year = txtYear.Text
            mp3File.Artist = txtArtist.Text
            If cmbGenre.SelectedIndex = -1 Then
                mp3File.Genre = 0
            Else
                mp3File.Genre = cmbGenre.SelectedIndex
            End If
            If txtTrack.Text = "" Then
                mp3File.TitleNumber = 0
            Else
                mp3File.TitleNumber = txtTrack.Text
            End If
            mp3File.Comment = txtComment.Text
        End If
        Try
            mp3File.WriteID3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BrowseForFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseForFolder.Click
        fbdBrowseForFolder.ShowDialog()
        If fbdBrowseForFolder.SelectedPath = vbNullString Then Exit Sub
        LoadListBox(fbdBrowseForFolder.SelectedPath)
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim CurrentItem As New ID3(ListBox1.SelectedItem)
        CurrentItem.ReadID3()
        txtFilename.Text = ListBox1.SelectedItem
        txtAlbum.Text = CurrentItem.Album
        txtArtist.Text = CurrentItem.Artist
        txtComment.Text = CurrentItem.Comment
        If CurrentItem.Genre() <= 147 Then
            cmbGenre.SelectedIndex = CurrentItem.Genre()
        Else
            cmbGenre.SelectedIndex = 0
        End If
        txtTitle.Text = CurrentItem.Title
        txtTrack.Text = CurrentItem.TitleNumber
        txtYear.Text = CurrentItem.Year
        chkHasTag.Checked = CurrentItem.HasTag
    End Sub
    Private Sub cmdGenHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenHTML.Click
        With SaveFileDialog1
            .Reset()
            .Filter = "HTML Files (*.htm; *.html)|*.htm;*.html|All Files (*.*)|*.*"
            .DefaultExt = "html"
            .ShowDialog()
        End With

        If SaveFileDialog1.FileName = vbNullString Then
            MsgBox("HTML file not generated; must specify valid filename. Or, user clicked Cancel", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "List MP3s")
            Exit Sub
        End If
        GenHTMLList(SaveFileDialog1.FileName)
    End Sub
    Private Sub SomethingEdited(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlbum.TextChanged, txtArtist.TextChanged, txtComment.TextChanged, txtTitle.TextChanged, txtTrack.TextChanged, txtYear.TextChanged
        chkHasTag.Checked = True
    End Sub
    Private Sub cmdPreviewTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreviewTable.Click
        frmPreviewTable.Show(Me)
    End Sub
    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        frmAbout.Show(Me)
    End Sub
    Private Sub cmdGenCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGenCSV.Click
        With SaveFileDialog1
            .Reset()
            .Filter = "Comma Seperated Values (*.csv)|*.csv|All Files (*.*)|*.*"
            .DefaultExt = "csv"
            .ShowDialog()
        End With

        If SaveFileDialog1.FileName = vbNullString Then
            MsgBox("CSV file not generated; must specify valid filename. Or, user clicked Cancel", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "List MP3s")
            Exit Sub
        End If
        GenCSVFile(SaveFileDialog1.FileName)
    End Sub
    Private Sub GenXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenXML.Click
        With SaveFileDialog1
            .Reset()
            .Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
            .DefaultExt = "xml"
            .ShowDialog()
        End With

        If SaveFileDialog1.FileName = vbNullString Then
            MsgBox("XML file not generated; must specify valid filename. Or, user clicked Cancel", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "List MP3s")
            Exit Sub
        End If

        GenXMLFile(SaveFileDialog1.FileName)
    End Sub
#End Region
#Region " My created subs and functions "
    Public Sub CheckIfListHasStuff()
        'PURPOSE: If there is nothing loaded in the listbox, the entries won't be available
        If ListBox1.Items.Count < 1 Then
            txtAlbum.Enabled = False
            txtArtist.Enabled = False
            txtComment.Enabled = False
            txtTitle.Enabled = False
            txtTrack.Enabled = False
            txtYear.Enabled = False
            cmbGenre.Enabled = False

            cmdGenHTML.Enabled = False
            cmdPreviewTable.Enabled = False
            cmdSave.Enabled = False
            cmdGenCSV.Enabled = False
            GenXML.Enabled = False

            cmdPrevious.Enabled = False
            cmdPlay.Enabled = False
            cmdPause.Enabled = False
            cmdStop.Enabled = False
            cmdNext.Enabled = False
            tbrSongLength.Enabled = False
        Else
            txtAlbum.Enabled = True
            txtArtist.Enabled = True
            txtComment.Enabled = True
            txtTitle.Enabled = True
            txtTrack.Enabled = True
            txtYear.Enabled = True
            cmbGenre.Enabled = True

            cmdGenHTML.Enabled = True
            cmdPreviewTable.Enabled = True
            cmdSave.Enabled = True
            cmdGenCSV.Enabled = True
            GenXML.Enabled = True

            cmdPrevious.Enabled = True
            cmdPlay.Enabled = True
            cmdPause.Enabled = True
            cmdStop.Enabled = True
            cmdNext.Enabled = True
            tbrSongLength.Enabled = True

        End If
    End Sub ' Ensure a folder is loaded, if not, disable controls
    Public Sub LoadListBox(ByVal sPathName As String)
        ListBox1.Items.Clear()
        Dim sFolderPath As String
        sFolderPath = sPathName
        If sFolderPath = vbNullString Then Exit Sub
        Dim arrDirs() As String
        Dim strDir As String
        Dim mp3list(10000) As String
        Dim i As Integer
        Try
            ProgressBar1.Visible = True
            arrDirs = Directory.GetFiles(sFolderPath, "*.mp3", SearchOption.AllDirectories)
            ProgressBar1.Maximum = arrDirs.Count
            ProgressBar1.Value = 0
            For Each strDir In arrDirs
                i += 1
                ProgressBar1.Value = i
                mp3list(i) = strDir
                ListBox1.Items.Add(mp3list(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
        ProgressBar1.Visible = False
        CheckIfListHasStuff()
    End Sub
#Region " Format Strings for Proper Output "
    Public Function StripNulls(ByVal sStringText As String) As String
        StripNulls = sStringText.Replace(Chr(0), "")
    End Function
    Public Function StripCommas(ByVal sStringText As String) As String
        StripCommas = sStringText.Replace(",", "")
    End Function
    Public Function StripQuotes(ByVal sStringText As String) As String
        StripQuotes = sStringText.Replace(Chr(34), "")
    End Function
    Public Function StripAppost(ByVal sStringText As String) As String
        StripAppost = sStringText.Replace(Chr(39), "")
    End Function
    Public Function StripAmp(ByVal sStringText As String) As String
        StripAmp = sStringText.Replace(Chr(38), "")
    End Function
    Public Function StripLT(ByVal sStringText As String) As String
        StripLT = sStringText.Replace(Chr(60), "")
    End Function
    Public Function StripGT(ByVal sStringText As String) As String
        StripGT = sStringText.Replace(Chr(62), "")
    End Function
    Public Function StripAstrix(ByVal sStringText As String) As String
        StripAstrix = sStringText.Replace(Chr(42), "")
    End Function
    Public Function StripQues(ByVal sStringText As String) As String
        StripQues = sStringText.Replace(Chr(63), "")
    End Function
    Public Function StripColon(ByVal sStringText As String) As String
        StripColon = sStringText.Replace(Chr(58), "")
    End Function
    Public Function StripSlashes(ByVal sStringText As String) As String
        StripSlashes = sStringText.Replace(Chr(47), "")
        StripSlashes = sStringText.Replace(Chr(92), "")
    End Function
    Public Function MakeXMLHappy(ByVal sStringText As String) As String
        sStringText = StripNulls(StripLT(StripAmp(StripAppost(StripQuotes(sStringText)))))
        MakeXMLHappy = sStringText
    End Function
    Public Function MakeFileSystemHappy(ByVal sStringText As String) As String
        sStringText = StripNulls(StripQuotes(StripAstrix(StripColon(StripGT(StripLT(StripQues(StripSlashes(sStringText))))))))
        MakeFileSystemHappy = sStringText
    End Function
#End Region  ' Functions for editing strings before making HTML/CSV/XML
#Region " Generate files of type "
    Public Sub GenCSVFile(ByVal sFilename As String)
        Dim iIndex As Integer
        Dim CurrentSelection As New ID3v1
        Dim sSomething As String
        Dim sCSV As String
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        sCSV = "Artist,Album,Track Name,Genre,Year,Track,Comment,Filename"
        For iIndex = 0 To ListBox1.Items.Count - 1
            ProgressBar1.Value += 1
            sSomething = ListBox1.Items(iIndex)
            With CurrentSelection
                .FileName = sSomething
                sCSV &= vbNewLine & StripCommas(.Artist) & "," & StripCommas(.Album) & "," & StripCommas(.SongTitle) & "," & StripCommas(.Genre) & "," & StripCommas(.Year) & "," & StripCommas(.Track) & "," & StripCommas(.Comment) & "," & StripCommas(.FileName)
            End With
        Next iIndex
        ProgressBar1.Visible = False
        Dim iFreeFile As Integer
        iFreeFile = FreeFile()
        FileOpen(iFreeFile, sFilename, OpenMode.Output, OpenAccess.Default, OpenShare.LockReadWrite)
        Print(iFreeFile, sCSV)
        FileClose(iFreeFile)
    End Sub
    Public Sub GenXMLFile(ByVal sFileName As String)
        Dim iIndex As Integer
        Dim CurrentSelection As New ID3v1
        Dim sSomething As String
        Dim sXML As String

        'Set up Progress Bar
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True


        'Define top of document
        sXML = "<?xml-stylesheet type=""text/xsl"" href=""stylesheet.xsl""?>"
        sXML &= "<ListMP3Library>" & vbNewLine
        sXML &= "<!-- NOTE: The following characters have been removed to meet XML standards: "", <, & and ' -->" & vbNewLine
        For iIndex = 0 To ListBox1.Items.Count - 1
            ProgressBar1.Value += 1
            sSomething = ListBox1.Items(iIndex)
            With CurrentSelection
                .FileName = sSomething
                sXML &= vbNewLine & "<songdata>" & vbNewLine & "<artist>" & IIf((MakeXMLHappy(.Artist) = vbNullString), "No Data", MakeXMLHappy(.Artist)) & "</artist>" & vbNewLine & "<album>" & MakeXMLHappy(.Album) & "</album>" & vbNewLine & "<title>" & MakeXMLHappy(.SongTitle) & "</title>" & vbNewLine & "<genre>" & MakeXMLHappy(.Genre) & "</genre>" & vbNewLine & "<year>" & MakeXMLHappy(.Year) & "</year>" & vbNewLine & "<tracknumber>" & MakeXMLHappy(.Track) & "</tracknumber>" & vbNewLine & "<comment>" & MakeXMLHappy(.Comment) & "</comment>" & vbNewLine & "<filename>" & MakeXMLHappy(.FileName) & "</filename>" & vbNewLine & "</songdata>"
            End With
        Next iIndex
        sXML &= "</ListMP3Library>"
        Dim iFreeFile As Integer
        iFreeFile = FreeFile()
        FileOpen(iFreeFile, sFileName, OpenMode.Output, OpenAccess.Default, OpenShare.LockReadWrite)
        Print(iFreeFile, sXML)
        FileClose(iFreeFile)
        ProgressBar1.Visible = False

        ' Check if XSL has been created already
        If Not (My.Computer.FileSystem.FileExists("stylesheet.xsl")) Then
            FileOpen(iFreeFile + 1, "stylesheet.xsl", OpenMode.Output, OpenAccess.Default, OpenShare.Default)
            Print(iFreeFile + 1, My.Resources.sXMLStylesheet)
            FileClose(iFreeFile + 1)
        End If
    End Sub
    Public Sub GenHTMLList(ByVal sHTMLFile As String)
        Dim iIndex As Integer
        Dim CurrentSelection As New ID3v1
        Dim sSomething As String
        Dim HTMLCode As String
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        HTMLCode = "<html><head><link rel=""stylesheet"" type=""text/css"" href=""stylesheet.css""><title>List MP3s</title></head><body>" & vbNewLine
        HTMLCode &= "<table border=1 width=100%><tr><th>Artist</th><th>Album</th><th>Title</th><th>Genre</th><th>Year</th><th>Track #</th><th>Comments</th>"
        For iIndex = 0 To ListBox1.Items.Count - 1
            sSomething = ListBox1.Items(iIndex)
            ProgressBar1.Value += 1
            With CurrentSelection
                .FileName = sSomething
                HTMLCode &= vbNewLine & "<tr><td>" & StripNulls(.Artist) & "</td><td>" & StripNulls(.Album) & "</td><td>" & StripNulls(.SongTitle) & "</td><td>" & StripNulls(.Genre) & "</td><td>" & StripNulls(.Year) & "</td><td>" & StripNulls(.Track) & "</td><td>" & StripNulls(.Comment) & "</td></tr>"

            End With
        Next iIndex
        HTMLCode &= vbNewLine & "</table></body></html>"
        ProgressBar1.Visible = False
        Dim iFreeFile As Integer
        iFreeFile = FreeFile()
        FileOpen(iFreeFile, sHTMLFile, OpenMode.Output, OpenAccess.Default, OpenShare.LockReadWrite)
        Print(iFreeFile, HTMLCode)
        FileClose(iFreeFile)

        'Check if Stylesheet exists
        If Not (My.Computer.FileSystem.FileExists("stylesheet.css")) Then
            FileOpen(iFreeFile + 1, "stylesheet.css", OpenMode.Output, OpenAccess.Default, OpenShare.Default)
            Print(iFreeFile + 1, My.Resources.sCSSStylesheet)
            FileClose(iFreeFile + 1)
        End If
    End Sub
    Public Sub RenameFiles()
        Dim iIndex As Integer
        Dim CurrentSelection As New ID3v1
        Dim sSomething As String
        Dim sNewName As String = vbNullString
        Dim sSongTitle, sArtist, sAlbum As String
        ProgressBar1.Maximum = ListBox1.Items.Count
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        If frmRenameSettings.RadioButton2.Checked = True Then
            For iIndex = 0 To ListBox1.Items.Count - 1
                sSomething = ListBox1.Items(iIndex)
                ProgressBar1.Value += 1
                With CurrentSelection
                    .FileName = sSomething
                    sSongTitle = MakeFileSystemHappy(.SongTitle)
                    sAlbum = MakeFileSystemHappy(.Album)
                    sArtist = MakeFileSystemHappy(.Artist)
                    If sSongTitle = vbNullString Or (sArtist = vbNullString AndAlso sSongTitle = vbNullString) Then
                        sNewName = .FileName
                    ElseIf sArtist = vbNullString AndAlso sSongTitle <> vbNullString Then
                        sNewName = My.Computer.FileSystem.GetParentPath(.FileName) & "\" & sSongTitle & ".mp3"
                        ' No artist
                    ElseIf sAlbum = vbNullString AndAlso (sArtist <> vbNullString AndAlso sSongTitle <> vbNullString) Then
                        sNewName = My.Computer.FileSystem.GetParentPath(.FileName) & "\" & sArtist & " - " & sSongTitle & ".mp3"
                        ' No album
                    ElseIf sArtist <> vbNullString AndAlso sAlbum <> vbNullString AndAlso sSongTitle <> vbNullString Then
                        sNewName = My.Computer.FileSystem.GetParentPath(.FileName) & "\" & sArtist & "\" & sAlbum & "\" & sArtist & " - " & sSongTitle & ".mp3"
                    Else
                        sNewName = .FileName
                    End If

                    If MsgBox(.FileName & " will be renamed to " & sNewName & ". Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    ' EDIT
                    ' My.Computer.FileSystem.RenameFile(.FileName, sNewName)
                    ' /EDIT
                End With
            Next iIndex
            ProgressBar1.Visible = False
        ElseIf frmRenameSettings.RadioButton1.Checked = True Then
            For iIndex = 0 To ListBox1.Items.Count - 1
                sSomething = ListBox1.Items(iIndex)
                ProgressBar1.Value += 1
                With CurrentSelection
                    .FileName = sSomething
                    sSongTitle = MakeFileSystemHappy(.SongTitle)
                    sArtist = MakeFileSystemHappy(.Artist)
                    If sSongTitle = vbNullString Then
                        sNewName = .FileName
                    ElseIf sArtist = vbNullString AndAlso sSongTitle <> vbNullString Then
                        sNewName = My.Computer.FileSystem.GetParentPath(.FileName) & "\" & sSongTitle & ".mp3"
                        ' No artist
                    ElseIf sArtist <> vbNullString AndAlso sSongTitle <> vbNullString Then
                        sNewName = My.Computer.FileSystem.GetParentPath(.FileName) & "\" & sArtist & " - " & sSongTitle & ".mp3"
                    End If
                    If MsgBox(.FileName & " will be renamed to " & sNewName & ". Continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    ' EDIT
                    ' My.Computer.FileSystem.RenameFile(.FileName, sNewName)
                    ' /EDIT

                End With
            Next iIndex
            ProgressBar1.Visible = False
        End If
    End Sub
#End Region    ' Subs for generating HTML, XML, and CSV

#End Region
#Region " Media handling "
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        MyApiVideo.Stop()
        tmrCurrentPosition.Enabled = False
        tbrSongLength.Value = 0
    End Sub
    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        MyApiVideo.Pause()
        tmrCurrentPosition.Enabled = False
    End Sub
    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click
        If MyApiVideo.FileName = vbNullString Then
            Try
                ChangeSong(ListBox1.SelectedItem)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        MyApiVideo.Play()
        tmrCurrentPosition.Enabled = True
    End Sub
    Public Sub ChangeSong(ByVal sNewFileName As String)
        MyApiVideo.Open(sNewFileName)
        With tbrSongLength
            .Maximum = CInt(MyApiVideo.TotalTime)
            .Minimum = 0
            .Value = 0
            .SmallChange = 1
            .LargeChange = 10
            tmrCurrentPosition.Enabled = True
        End With
    End Sub
    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        ListBox1.SelectedIndex += 1
        If MyApiVideo.FileName <> vbNullString Then
            ChangeSong(ListBox1.SelectedItem)
            MyApiVideo.Play()
        End If
    End Sub
    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        ListBox1.SelectedIndex -= 1
        If MyApiVideo.FileName <> vbNullString Then
            ChangeSong(ListBox1.SelectedItem)
            MyApiVideo.Play()
        End If
    End Sub
    Private Sub tmrCurrentPosition_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrentPosition.Tick
        If MyApiVideo.FileName = vbNullString Then Exit Sub
        If CInt(MyApiVideo.CurrentTime) = CInt(MyApiVideo.TotalTime) Then
            If chkMute.Checked = True Then
                ListBox1.SelectedIndex += 1
                ChangeSong(ListBox1.SelectedItem)
                MyApiVideo.Play()
            Else
                MyApiVideo.Stop()
                tbrSongLength.Value = 0
                tmrCurrentPosition.Enabled = False
            End If
        End If
        tbrSongLength.Value = MyApiVideo.CurrentTime
        tbrSongLength.Refresh()
    End Sub
    Private Sub tbrSongLength_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbrSongLength.Scroll
        'MyApiVideo.Pause()
        tmrCurrentPosition.Enabled = False
        MyApiVideo.MoveToTime(tbrSongLength.Value)
        tmrCurrentPosition.Enabled = True
        'MyApiVideo.Play()
    End Sub
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbrVolume.Scroll
        MyApiVideo.Volume = tbrVolume.Value
    End Sub
    Private Sub chkMute_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMute.CheckStateChanged
        If chkMute.Checked = True Then
            MyApiVideo.Mute() = ApiVideo.Channels.Both
        Else
            MyApiVideo.Mute() = ApiVideo.Channels.None
        End If
    End Sub
#End Region

    
    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRename.Click
        If frmRenameSettings.ShowDialog = Windows.Forms.DialogResult.OK Then RenameFiles()
    End Sub
End Class