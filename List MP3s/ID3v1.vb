Imports System.IO
Imports System.Text
Imports System.Text.ASCIIEncoding

Public Class ID3v1

	' Reads ID3 Version 1.1 tags

#Region " Private Members "

	Private _Tag(127) As Byte
	Private _FileName As String
	Private _Genres As String() = { _
	  "Blues", "Classic Rock", "Country", "Dance", "Disco", _
	   "Funk", "Grunge", "Hip-Hop", "Jazz", "Metal", _
	   "New Age", "Oldies", "Other", "Pop", "R&B", _
	   "Rap", "Reggae", "Rock", "Techno", "Industrial", _
	   "Alternative", "Ska", "Death Metal", "Pranks", "Soundtrack", _
	   "Euro-Techno", "Ambient", "Trip-Hop", "Vocal", "Jazz+Funk", _
	   "Fusion", "Trance", "Classical", "Instrumental", "Acid", _
	   "House", "Game", "Sound Clip", "Gospel", "Noise", _
	   "AlternRock", "Bass", "Soul", "Punk", "Space", _
	   "Meditative", "Instrumental Pop", "Instrumental Rock", "Ethnic", "Gothic", _
	   "Darkwave", "Techno-Industrial", "Electronic", "Pop-Folk", "Eurodance", _
	   "Dream", "Southern Rock", "Comedy", "Cult", "Gangsta", _
	   "Top 40", "Christian Rap", "Pop/Funk", "Jungle", "Native American", _
	   "Cabaret", "New Wave", "Psychadelic", "Rave", "Showtunes", _
	   "Trailer", "Lo-Fi", "Tribal", "Acid Punk", "Acid Jazz", _
	   "Polka", "Retro", "Musical", "Rock & Roll", "Hard Rock", _
	   "Folk", "Folk-Rock", "National Folk", "Swing", "Fast Fusion", _
	   "Bebob", "Latin", "Revival", "Celtic", "Bluegrass", _
	   "Avantgarde", "Gothic Rock", "Progressive Rock", "Psychedelic Rock", "Symphonic Rock", _
	   "Slow Rock", "Big Band", "Chorus", "Easy Listening", "Acoustic", _
	   "Humour", "Speech", "Chanson", "Opera", "Chamber Music", _
	   "Sonata", "Symphony", "Booty Bass", "Primus", "Porn Groove", _
	   "Satire", "Slow Jam", "Club", "Tango", "Samba", _
	   "Folklore", "Ballad", "Power Ballad", "Rhythmic Soul", "Freestyle", _
	   "Duet", "Punk Rock", "Drum Solo", "A capella", "Euro-House", _
	   "Dance Hall" _
	   }

#End Region

	Public Property FileName() As String
		Get
			Return _FileName
		End Get
		Set(ByVal Value As String)
			Dim Stream As FileStream
			Try

				' Read last 128 bytes of file
				Stream = New FileStream(Value, FileMode.Open)
				Stream.Seek(-128, SeekOrigin.End)
				Stream.Read(_Tag, 0, 128)

				' If tag not present, reset
				If Not ASCII.GetString(_Tag, 0, 3) = "TAG" Then ResetTag()

				_FileName = Value

			Catch ex As Exception
				_FileName = ""
				ResetTag()
			Finally
				If Not Stream Is Nothing Then Stream.Close()
			End Try
		End Set
	End Property
	Private Sub ResetTag()
		' Set all values to null
		Array.Clear(_Tag, 0, 128)
	End Sub
	Public ReadOnly Property Genre() As String
		Get
			If FileName = "" Then Return ""
			' 0 - 79 = standard genres
			' 80 - 125 = winamp genres
			If _Tag(127) < 126 Then
				Return _Genres(_Tag(127))
			Else
				Return ""
			End If
		End Get
	End Property

	Public ReadOnly Property SongTitle() As String
		Get
			Return ASCII.GetString(_Tag, 3, 30).Trim()
		End Get
	End Property
	Public ReadOnly Property Artist() As String
		Get
			Return ASCII.GetString(_Tag, 33, 30).Trim()
		End Get
	End Property
	Public ReadOnly Property Album() As String
		Get
			Return ASCII.GetString(_Tag, 63, 30).Trim()
		End Get
	End Property
	Public ReadOnly Property Year() As String
		Get
			Return ASCII.GetString(_Tag, 93, 4).Trim()
		End Get
	End Property
	Public ReadOnly Property Comment() As String
		Get
			' if last byte of comment is specified, but
			' second to last is null, then last byte = track
			If _Tag(125) = 0 And Not _Tag(126) = 0 Then
				Return ASCII.GetString(_Tag, 97, 28).Trim()
			Else
				Return ASCII.GetString(_Tag, 97, 30).Trim()
			End If
		End Get
	End Property
	Public ReadOnly Property Track() As String
		Get
			' if last byte of comment is specified, but
			' second to last is null, then last byte = track
			If _Tag(125) = 0 And Not _Tag(126) = 0 Then
				Return _Tag(126).ToString
			Else
				Return ""
			End If
		End Get
	End Property
End Class

