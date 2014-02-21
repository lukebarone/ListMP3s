<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.txtTrack = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.txtAlbum = New System.Windows.Forms.TextBox
        Me.txtArtist = New System.Windows.Forms.TextBox
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.chkHasTag = New System.Windows.Forms.CheckBox
        Me.cmbGenre = New System.Windows.Forms.ComboBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdGenHTML = New System.Windows.Forms.Button
        Me.BrowseForFolder = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.fbdBrowseForFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.cmdPreviewTable = New System.Windows.Forms.Button
        Me.cmdAbout = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.cmdGenCSV = New System.Windows.Forms.Button
        Me.GenXML = New System.Windows.Forms.Button
        Me.cmdPlay = New System.Windows.Forms.Button
        Me.cmdPause = New System.Windows.Forms.Button
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.tbrSongLength = New System.Windows.Forms.TrackBar
        Me.tmrCurrentPosition = New System.Windows.Forms.Timer(Me.components)
        Me.chkMute = New System.Windows.Forms.CheckBox
        Me.tbrVolume = New System.Windows.Forms.TrackBar
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdRename = New System.Windows.Forms.Button
        CType(Me.tbrSongLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbrVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Comment"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Track #"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Year"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Genre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Album"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Artist"
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(74, 184)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(209, 71)
        Me.txtComment.TabIndex = 12
        '
        'txtTrack
        '
        Me.txtTrack.Location = New System.Drawing.Point(74, 158)
        Me.txtTrack.Name = "txtTrack"
        Me.txtTrack.Size = New System.Drawing.Size(209, 20)
        Me.txtTrack.TabIndex = 11
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(74, 132)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(209, 20)
        Me.txtYear.TabIndex = 10
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(74, 84)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(209, 20)
        Me.txtTitle.TabIndex = 8
        '
        'txtAlbum
        '
        Me.txtAlbum.Location = New System.Drawing.Point(74, 58)
        Me.txtAlbum.Name = "txtAlbum"
        Me.txtAlbum.Size = New System.Drawing.Size(209, 20)
        Me.txtAlbum.TabIndex = 7
        '
        'txtArtist
        '
        Me.txtArtist.Location = New System.Drawing.Point(74, 32)
        Me.txtArtist.Name = "txtArtist"
        Me.txtArtist.Size = New System.Drawing.Size(209, 20)
        Me.txtArtist.TabIndex = 6
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(74, 6)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.txtFilename.Size = New System.Drawing.Size(209, 20)
        Me.txtFilename.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Filename"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'chkHasTag
        '
        Me.chkHasTag.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkHasTag.Enabled = False
        Me.chkHasTag.Location = New System.Drawing.Point(12, 206)
        Me.chkHasTag.Name = "chkHasTag"
        Me.chkHasTag.Size = New System.Drawing.Size(56, 51)
        Me.chkHasTag.TabIndex = 48
        Me.chkHasTag.Text = "Has Tag Already?"
        Me.chkHasTag.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkHasTag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chkHasTag.UseVisualStyleBackColor = True
        '
        'cmbGenre
        '
        Me.cmbGenre.FormattingEnabled = True
        Me.cmbGenre.Items.AddRange(New Object() {"", "Classic rock", "Country", "Dance", "Disco", "Funk", "Grunge", "Hip-Hop", "Jazz", "Metal", "New Age", "Oldies", "Other", "Pop", "R&B", "Rap", "Reggae", "Rock", "Techno", "Industrial", "Alternativ", "Ska", "Death Metal", "Pranks", "Soundtrack", "Euro-Techno", "Ambient", "Trip-Hop", "Vocal", "Jazz+Funk", "Fusion", "Trance", "Classical", "Instrumental", "Acid", "House", "Game", "Sound Clip", "Gospel", "Noise", "Alt. Rock", "Bass", "Soul", "Punk", "Space", "Meditative", "Instrumental Pop", "Instrumental Rock", "Ethnic", "Gothic", "Darkwave", "Techno-Industrial", "Electronic", "Pop-Folk", "Eurodance", "Dream", "Southern Rock", "Comedy", "Cult", "Gansta Rap", "Top 40", "Christian Rap", "Pop/Funk", "Jungle", "Native American", "Cabaret", "New Wave", "Psychedelic", "Rave", "Showtunes", "Trailer", "Lo-Fi", "Tribal", "Acid Punk", "Acid Jazz", "Polka", "Retro", "Musical", "Rock & Roll", "Hard Rock", "Folk", "Folk/Rock", "National Folk", "Swing", "Fast-Fusion", "Bebob", "Latin", "Revival", "Celtic", "Bluegrass", "Avantgarde", "Gothic Rock", "Progressive Rock", "Psychedelic Rock", "Symphonic Rock", "Slow Rock", "Big Band", "Chorus", "Easy Listening", "Acoustic", "Humor", "Speech", "Chansen", "Opera", "Chamber Music", "Sonata", "Symphony", "Booty Bass", "Primus", "Porn Groove", "Satire", "Slow Jam", "Club", "Tango", "Samba", "Folkrole", "Balld", "Power Ballad", "Rhythmic Soul", "Freestyle", "Duet", "Punk Rock", "Drum Solo", "A Cappella", "Euro-House", "Dance Hall", "Goa", "Drum & Bass", "Club-house", "Hardcore", "Terror", "Indie", "BritPop", "Negerpunk", "Polska Punk", "Beat", "Christian Gangsta", "Heavy Metal", "Black Metal", "Cross Over", "Contemporary Christian", "Christian Rock", "Merengue", "Salsa", "Trash Metal", "Anime", "Jpop", "Synthpop"})
        Me.cmbGenre.Location = New System.Drawing.Point(74, 107)
        Me.cmbGenre.Name = "cmbGenre"
        Me.cmbGenre.Size = New System.Drawing.Size(209, 21)
        Me.cmbGenre.TabIndex = 9
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(208, 264)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdGenHTML
        '
        Me.cmdGenHTML.Location = New System.Drawing.Point(289, 264)
        Me.cmdGenHTML.Name = "cmdGenHTML"
        Me.cmdGenHTML.Size = New System.Drawing.Size(139, 23)
        Me.cmdGenHTML.TabIndex = 15
        Me.cmdGenHTML.Text = "Generate HTML List"
        Me.cmdGenHTML.UseVisualStyleBackColor = True
        '
        'BrowseForFolder
        '
        Me.BrowseForFolder.Location = New System.Drawing.Point(435, 264)
        Me.BrowseForFolder.Name = "BrowseForFolder"
        Me.BrowseForFolder.Size = New System.Drawing.Size(139, 23)
        Me.BrowseForFolder.TabIndex = 4
        Me.BrowseForFolder.Text = "Browse for Folder"
        Me.BrowseForFolder.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.Location = New System.Drawing.Point(289, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(285, 251)
        Me.ListBox1.TabIndex = 5
        '
        'fbdBrowseForFolder
        '
        Me.fbdBrowseForFolder.SelectedPath = "C:\Documents and Settings\Administrator\My Documents\My Music"
        Me.fbdBrowseForFolder.ShowNewFolderButton = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "html"
        Me.SaveFileDialog1.Filter = "HTML Files (*.html; *.htm)|*.html;*.htm|All Files (*.*)|*.*"
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
        '
        'cmdPreviewTable
        '
        Me.cmdPreviewTable.Location = New System.Drawing.Point(74, 264)
        Me.cmdPreviewTable.Name = "cmdPreviewTable"
        Me.cmdPreviewTable.Size = New System.Drawing.Size(128, 23)
        Me.cmdPreviewTable.TabIndex = 14
        Me.cmdPreviewTable.Text = "Preview Table"
        Me.cmdPreviewTable.UseVisualStyleBackColor = True
        '
        'cmdAbout
        '
        Me.cmdAbout.Location = New System.Drawing.Point(208, 293)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(75, 23)
        Me.cmdAbout.TabIndex = 49
        Me.cmdAbout.Text = "About..."
        Me.cmdAbout.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 6)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(562, 252)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 50
        Me.ProgressBar1.Visible = False
        '
        'cmdGenCSV
        '
        Me.cmdGenCSV.Location = New System.Drawing.Point(289, 293)
        Me.cmdGenCSV.Name = "cmdGenCSV"
        Me.cmdGenCSV.Size = New System.Drawing.Size(139, 23)
        Me.cmdGenCSV.TabIndex = 51
        Me.cmdGenCSV.Text = "Generate CSV File"
        Me.cmdGenCSV.UseVisualStyleBackColor = True
        '
        'GenXML
        '
        Me.GenXML.Location = New System.Drawing.Point(435, 293)
        Me.GenXML.Name = "GenXML"
        Me.GenXML.Size = New System.Drawing.Size(139, 23)
        Me.GenXML.TabIndex = 52
        Me.GenXML.Text = "Generate XML File..."
        Me.GenXML.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Image = Global.List_MP3s.My.Resources.Resources.PlayHS
        Me.cmdPlay.Location = New System.Drawing.Point(44, 322)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(23, 24)
        Me.cmdPlay.TabIndex = 53
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdPause
        '
        Me.cmdPause.Image = Global.List_MP3s.My.Resources.Resources.PauseHS
        Me.cmdPause.Location = New System.Drawing.Point(73, 322)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(23, 24)
        Me.cmdPause.TabIndex = 54
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Image = Global.List_MP3s.My.Resources.Resources.StopHS
        Me.cmdStop.Location = New System.Drawing.Point(102, 322)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(23, 24)
        Me.cmdStop.TabIndex = 55
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Image = Global.List_MP3s.My.Resources.Resources.NavForward
        Me.cmdNext.Location = New System.Drawing.Point(131, 322)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(23, 24)
        Me.cmdNext.TabIndex = 57
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Image = Global.List_MP3s.My.Resources.Resources.NavBack
        Me.cmdPrevious.Location = New System.Drawing.Point(15, 322)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(23, 24)
        Me.cmdPrevious.TabIndex = 56
        Me.cmdPrevious.UseVisualStyleBackColor = True
        '
        'tbrSongLength
        '
        Me.tbrSongLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbrSongLength.AutoSize = False
        Me.tbrSongLength.Location = New System.Drawing.Point(15, 349)
        Me.tbrSongLength.Name = "tbrSongLength"
        Me.tbrSongLength.Size = New System.Drawing.Size(559, 24)
        Me.tbrSongLength.TabIndex = 58
        Me.tbrSongLength.TickFrequency = 0
        Me.tbrSongLength.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'tmrCurrentPosition
        '
        '
        'chkMute
        '
        Me.chkMute.AutoSize = True
        Me.chkMute.Location = New System.Drawing.Point(159, 326)
        Me.chkMute.Name = "chkMute"
        Me.chkMute.Size = New System.Drawing.Size(50, 17)
        Me.chkMute.TabIndex = 59
        Me.chkMute.Text = "Mute"
        Me.chkMute.UseVisualStyleBackColor = True
        '
        'tbrVolume
        '
        Me.tbrVolume.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbrVolume.AutoSize = False
        Me.tbrVolume.LargeChange = 10
        Me.tbrVolume.Location = New System.Drawing.Point(305, 322)
        Me.tbrVolume.Maximum = 1000
        Me.tbrVolume.Name = "tbrVolume"
        Me.tbrVolume.Size = New System.Drawing.Size(269, 24)
        Me.tbrVolume.TabIndex = 60
        Me.tbrVolume.TickFrequency = 10
        Me.tbrVolume.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbrVolume.Value = 500
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(215, 326)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Volume Control: "
        '
        'cmdRename
        '
        Me.cmdRename.Location = New System.Drawing.Point(74, 293)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.Size = New System.Drawing.Size(128, 23)
        Me.cmdRename.TabIndex = 62
        Me.cmdRename.Text = "Rename All Files..."
        Me.cmdRename.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 376)
        Me.Controls.Add(Me.cmdRename)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.tbrVolume)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkMute)
        Me.Controls.Add(Me.tbrSongLength)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.GenXML)
        Me.Controls.Add(Me.cmdGenCSV)
        Me.Controls.Add(Me.cmdAbout)
        Me.Controls.Add(Me.cmdPreviewTable)
        Me.Controls.Add(Me.BrowseForFolder)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.cmdGenHTML)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmbGenre)
        Me.Controls.Add(Me.chkHasTag)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTrack)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtAlbum)
        Me.Controls.Add(Me.txtArtist)
        Me.MinimumSize = New System.Drawing.Size(589, 410)
        Me.Name = "frmMain"
        Me.Text = "List MP3s"
        CType(Me.tbrSongLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbrVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtTrack As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtAlbum As System.Windows.Forms.TextBox
    Friend WithEvents txtArtist As System.Windows.Forms.TextBox
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkHasTag As System.Windows.Forms.CheckBox
    Friend WithEvents cmbGenre As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdGenHTML As System.Windows.Forms.Button
    Friend WithEvents BrowseForFolder As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents fbdBrowseForFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmdPreviewTable As System.Windows.Forms.Button
    Friend WithEvents cmdAbout As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdGenCSV As System.Windows.Forms.Button
    Friend WithEvents GenXML As System.Windows.Forms.Button
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents tbrSongLength As System.Windows.Forms.TrackBar
    Friend WithEvents tmrCurrentPosition As System.Windows.Forms.Timer
    Friend WithEvents chkMute As System.Windows.Forms.CheckBox
    Friend WithEvents tbrVolume As System.Windows.Forms.TrackBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdRename As System.Windows.Forms.Button
End Class
