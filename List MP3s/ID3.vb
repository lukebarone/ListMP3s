Imports System.IO
Imports System.Text

Public Class ID3

    Private FilePath As String

    Private _Title As String = ""
    Private _Artist As String = ""
    Private _Album As String = ""
    Private _Year As String = ""
    Private _Comment As String = ""
    Private _TitleNumber As Integer
    Private _Genre As Short

    Private _HasTag As Boolean
    Private _HadTag As Boolean

    Public buffer(128) As Byte

    Public Overrides Function ToString() As String
        Return FilePath
    End Function

    Public Sub New(ByVal FilePath As String)
        If Not File.Exists(FilePath) Then
            Throw New FileNotFoundException("File not found", FilePath)
        End If
        Me.FilePath = FilePath
    End Sub

    Public Sub CollectData()
        buffer.Clear(buffer, 0, 128)
        Encoding.Default.GetBytes("TAG".ToUpper.ToCharArray()).CopyTo(buffer, 0)
        Encoding.Default.GetBytes(_Title.ToCharArray()).CopyTo(buffer, 3)
        Encoding.Default.GetBytes(_Artist.ToCharArray()).CopyTo(buffer, 33)
        Encoding.Default.GetBytes(_Album.ToCharArray()).CopyTo(buffer, 63)
        Encoding.Default.GetBytes(_Year.ToCharArray()).CopyTo(buffer, 93)
        Encoding.Default.GetBytes(_Comment.ToCharArray()).CopyTo(buffer, 97)
        buffer(126) = _TitleNumber
        buffer(127) = Convert.ToInt32(_Genre)
    End Sub

    Public Sub WriteID3()
        Dim mp3File As New FileInfo(FilePath)
        If mp3File.Extension.ToLower <> ".mp3" Then
            Throw New Exception("File extension must be MP3")
        End If

        CollectData()

        Dim mp3Writer As FileStream = mp3File.OpenWrite()
        If _HasTag And _HadTag Then
            mp3Writer.Seek(-128, SeekOrigin.End)
            mp3Writer.Write(buffer, 0, 128)
        ElseIf (Not _HadTag) And _HasTag Then
            mp3Writer.Seek(0, SeekOrigin.End)
            mp3Writer.Write(buffer, 0, 128)
            _HadTag = True
        ElseIf _HadTag And (Not _HasTag) Then
            _HadTag = False
            mp3Writer.SetLength(mp3Writer.Length - 128)
        End If

        mp3Writer.Close()
    End Sub

    Public Sub ReadID3()
        Dim mp3File As New FileInfo(FilePath)
        If mp3File.Extension.ToLower <> ".mp3" Then
            Throw New Exception("File extension must be MP3")
        End If

        If mp3File.Length > 128 Then
            Dim mp3Reader As Stream = mp3File.OpenRead()
            mp3Reader.Seek(-128, SeekOrigin.End)
            Dim i As Integer
            For i = 0 To 127
                buffer(i) = mp3Reader.ReadByte
            Next
            mp3Reader.Close()
        End If

        If Encoding.Default.GetString(buffer, 0, 3).Equals("TAG") Then
            _Title = Encoding.Default.GetString(buffer, 3, 30)
            _Artist = Encoding.Default.GetString(buffer, 33, 30)
            _Album = Encoding.Default.GetString(buffer, 63, 30)
            _Year = Encoding.Default.GetString(buffer, 93, 4)
            _Comment = Encoding.Default.GetString(buffer, 97, 28)
            If Convert.ToInt32(buffer(126)) <= 147 Then
                _TitleNumber = Convert.ToInt32(buffer(126).ToString())
            End If
            If Convert.ToInt32(buffer(127)) > 0 Then
                _Genre = Convert.ToInt16(buffer(127))
            End If
            _HasTag = True
            _HadTag = True
        Else
            _HasTag = False
            _HasTag = False
        End If

    End Sub

#Region " Public Properties "

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            If Value.Length > 30 Then
                _Title = Value.Substring(0, 30)
            Else
                _Title = Value
            End If
        End Set
    End Property

    Public Property Artist() As String
        Get
            Return _Artist
        End Get
        Set(ByVal Value As String)
            If Value.Length > 30 Then
                _Artist = Value.Substring(0, 30)
            Else
                _Artist = Value
            End If
        End Set
    End Property

    Public Property Album() As String
        Get
            Return _Album
        End Get
        Set(ByVal Value As String)
            If Value.Length > 30 Then
                _Album = Value.Substring(0, 30)
            Else
                _Album = Value
            End If
        End Set
    End Property

    Public Property Year() As String
        Get
            Return _Year
        End Get
        Set(ByVal Value As String)
            If Value.Length > 4 Then
                _Year = Value.Substring(0, 4)
            Else
                _Year = Value
            End If
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal Value As String)
            If Value.Length > 28 Then
                _Comment = Value.Substring(0, 28)
            Else
                _Comment = Value
            End If
        End Set
    End Property

    Public Property TitleNumber() As Short
        Get
            Return _TitleNumber
        End Get
        Set(ByVal Value As Short)
            If Value < 255 Then
                _TitleNumber = Value
            End If
        End Set
    End Property

    Public Property Genre() As Short
        Get
            Return _Genre
        End Get
        Set(ByVal Value As Short)
            If Value < 256 Then
                _Genre = Value
            End If
        End Set
    End Property

    Public Property HasTag() As Boolean
        Get
            Return _HasTag
        End Get
        Set(ByVal Value As Boolean)
            _HasTag = Value
        End Set
    End Property

#End Region
End Class

