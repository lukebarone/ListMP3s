Option Strict On

Public Class ApiVideo
    Inherits Control

    ' -----------------------------------------------------------------------------
    ' The ApiVideo class plays media using the mciSendString API, this beats
    ' using the Media Player Component and the interop crap that comes with that.
    '
    ' This is version 1.0 and was released on 6 oktober 2005.
    '
    ' NOTE that midi and cda are not supported.
    '      (those can be easily implemented tho)
    '      (they just can't handle the arguments we provide in our play statement)
    ' -----------------------------------------------------------------------------

    ' Channels used with Mute.
    Public Enum Channels
        None = 0
        Left = 1
        Right = 2
        Both = 3
    End Enum

    ' We raise an event when the media ends.
    Public Event OnEnd(ByVal sender As Object, ByVal e As System.EventArgs)

#Region "API"

    ' Constants used with MCI.
    Private Const MCI_NOTIFY_SUCCESSFUL As Integer = &H1
    Private Const MM_MCINOTIFY As Integer = &H3B9
    Private Const MCIERR_BASE As Integer = 256

    ' I defined all the MCIERR constants to make debugging problems easier.
    ' (the IDE shows the name rather than the value when you hoover the mouse over a variable) 
    Private Enum MCIERR As Integer
        MCIERR_NO_ERROR = 0
        '    /* MCI error return values */
        MCIERR_INVALID_DEVICE_ID = (MCIERR_BASE + 1)
        MCIERR_UNRECOGNIZED_KEYWORD = (MCIERR_BASE + 3)
        MCIERR_UNRECOGNIZED_COMMAND = (MCIERR_BASE + 5)
        MCIERR_HARDWARE = (MCIERR_BASE + 6)
        MCIERR_INVALID_DEVICE_NAME = (MCIERR_BASE + 7)
        MCIERR_OUT_OF_MEMORY = (MCIERR_BASE + 8)
        MCIERR_DEVICE_OPEN = (MCIERR_BASE + 9)
        MCIERR_CANNOT_LOAD_DRIVER = (MCIERR_BASE + 10)
        MCIERR_MISSING_COMMAND_STRING = (MCIERR_BASE + 11)
        MCIERR_PARAM_OVERFLOW = (MCIERR_BASE + 12)
        MCIERR_MISSING_STRING_ARGUMENT = (MCIERR_BASE + 13)
        MCIERR_BAD_INTEGER = (MCIERR_BASE + 14)
        MCIERR_PARSER_INTERNAL = (MCIERR_BASE + 15)
        MCIERR_DRIVER_INTERNAL = (MCIERR_BASE + 16)
        MCIERR_MISSING_PARAMETER = (MCIERR_BASE + 17)
        MCIERR_UNSUPPORTED_FUNCTION = (MCIERR_BASE + 18)
        MCIERR_FILE_NOT_FOUND = (MCIERR_BASE + 19)
        MCIERR_DEVICE_NOT_READY = (MCIERR_BASE + 20)
        MCIERR_INTERNAL = (MCIERR_BASE + 21)
        MCIERR_DRIVER = (MCIERR_BASE + 22)
        MCIERR_CANNOT_USE_ALL = (MCIERR_BASE + 23)
        MCIERR_MULTIPLE = (MCIERR_BASE + 24)
        MCIERR_EXTENSION_NOT_FOUND = (MCIERR_BASE + 25)
        MCIERR_OUTOFRANGE = (MCIERR_BASE + 26)
        MCIERR_FLAGS_NOT_COMPATIBLE = (MCIERR_BASE + 28)
        MCIERR_FILE_NOT_SAVED = (MCIERR_BASE + 30)
        MCIERR_DEVICE_TYPE_REQUIRED = (MCIERR_BASE + 31)
        MCIERR_DEVICE_LOCKED = (MCIERR_BASE + 32)
        MCIERR_DUPLICATE_ALIAS = (MCIERR_BASE + 33)
        MCIERR_BAD_CONSTANT = (MCIERR_BASE + 34)
        MCIERR_MUST_USE_SHAREABLE = (MCIERR_BASE + 35)
        MCIERR_MISSING_DEVICE_NAME = (MCIERR_BASE + 36)
        MCIERR_BAD_TIME_FORMAT = (MCIERR_BASE + 37)
        MCIERR_NO_CLOSING_QUOTE = (MCIERR_BASE + 38)
        MCIERR_DUPLICATE_FLAGS = (MCIERR_BASE + 39)
        MCIERR_INVALID_FILE = (MCIERR_BASE + 40)
        MCIERR_NULL_PARAMETER_BLOCK = (MCIERR_BASE + 41)
        MCIERR_UNNAMED_RESOURCE = (MCIERR_BASE + 42)
        MCIERR_NEW_REQUIRES_ALIAS = (MCIERR_BASE + 43)
        MCIERR_NOTIFY_ON_AUTO_OPEN = (MCIERR_BASE + 44)
        MCIERR_NO_ELEMENT_ALLOWED = (MCIERR_BASE + 45)
        MCIERR_NONAPPLICABLE_FUNCTION = (MCIERR_BASE + 46)
        MCIERR_ILLEGAL_FOR_AUTO_OPEN = (MCIERR_BASE + 47)
        MCIERR_FILENAME_REQUIRED = (MCIERR_BASE + 48)
        MCIERR_EXTRA_CHARACTERS = (MCIERR_BASE + 49)
        MCIERR_DEVICE_NOT_INSTALLED = (MCIERR_BASE + 50)
        MCIERR_GET_CD = (MCIERR_BASE + 51)
        MCIERR_SET_CD = (MCIERR_BASE + 52)
        MCIERR_SET_DRIVE = (MCIERR_BASE + 53)
        MCIERR_DEVICE_LENGTH = (MCIERR_BASE + 54)
        MCIERR_DEVICE_ORD_LENGTH = (MCIERR_BASE + 55)
        MCIERR_NO_INTEGER = (MCIERR_BASE + 56)

        MCIERR_WAVE_OUTPUTSINUSE = (MCIERR_BASE + 64)
        MCIERR_WAVE_SETOUTPUTINUSE = (MCIERR_BASE + 65)
        MCIERR_WAVE_INPUTSINUSE = (MCIERR_BASE + 66)
        MCIERR_WAVE_SETINPUTINUSE = (MCIERR_BASE + 67)
        MCIERR_WAVE_OUTPUTUNSPECIFIED = (MCIERR_BASE + 68)
        MCIERR_WAVE_INPUTUNSPECIFIED = (MCIERR_BASE + 69)
        MCIERR_WAVE_OUTPUTSUNSUITABLE = (MCIERR_BASE + 70)
        MCIERR_WAVE_SETOUTPUTUNSUITABLE = (MCIERR_BASE + 71)
        MCIERR_WAVE_INPUTSUNSUITABLE = (MCIERR_BASE + 72)
        MCIERR_WAVE_SETINPUTUNSUITABLE = (MCIERR_BASE + 73)

        MCIERR_SEQ_DIV_INCOMPATIBLE = (MCIERR_BASE + 80)
        MCIERR_SEQ_PORT_INUSE = (MCIERR_BASE + 81)
        MCIERR_SEQ_PORT_NONEXISTENT = (MCIERR_BASE + 82)
        MCIERR_SEQ_PORT_MAPNODEVICE = (MCIERR_BASE + 83)
        MCIERR_SEQ_PORT_MISCERROR = (MCIERR_BASE + 84)
        MCIERR_SEQ_TIMER = (MCIERR_BASE + 85)
        MCIERR_SEQ_PORTUNSPECIFIED = (MCIERR_BASE + 86)
        MCIERR_SEQ_NOMIDIPRESENT = (MCIERR_BASE + 87)

        MCIERR_NO_WINDOW = (MCIERR_BASE + 90)
        MCIERR_CREATEWINDOW = (MCIERR_BASE + 91)
        MCIERR_FILE_READ = (MCIERR_BASE + 92)
        MCIERR_FILE_WRITE = (MCIERR_BASE + 93)

        MCIERR_NO_IDENTITY = (MCIERR_BASE + 94)

        '/* all custom device driver errors must be >= than this value */
        MCIERR_CUSTOM_DRIVER_BASE = (MCIERR_BASE + 256)
    End Enum

    ' The MCI api's we need.
    Private Declare Function mciSendString Lib "Winmm.dll" Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, ByVal cchReturn As Integer, ByVal hwndCallback As IntPtr) As MCIERR
    Private Declare Function mciGetErrorString Lib "Winmm.dll" Alias "mciGetErrorStringA" (ByVal fdwError As Integer, ByVal lpszErrorText As String, ByVal cchErrorText As Integer) As Integer

#End Region

#Region "Variables"

    Private pFileName As String     ' The media file currently open.
    Private pAlias As String        ' Each instance of this control gets its own unique alias.
    Private pLastError As MCIERR    ' The error returned by the last call to mciSendString.
    Private pOpenSuccess As Boolean ' Indicates that the Open command was successful.
    Private pSpeed As Integer       ' Playback speed (normal = 1000).
    Private pMute As Channels       ' The channels that are muted.  
    Private pBalance As Integer     ' Left and right balance.
    Private pVolume As Integer      ' Volume.
    Private pRepeat As Boolean      ' Indicates playback is looping.
    Private pTotalTime As Long      ' The length of the media in milliseconds.
    Private pTotalFrames As Long    ' The length of the media in frames.
    Private pClipStart As Long      ' The start frame or milliseconds of the play sequence.
    Private pClipEnd As Long        ' The end frame or milliseconds of the play sequence.  
    Private pClipFormat As String   ' The time format for clipping, either "frames" or "milliseconds".
    Private pPlaying As Boolean     ' Indicates if we are playing or not.
    Private pPaused As Boolean      ' Indicates if we are paused or not.

#End Region

    Public ReadOnly Property FileName() As String
        Get
            ' Return the filename of the current file.
            ' This is the file passed to the Open function.
            Return pFileName
        End Get
    End Property

    Public Function [Open](ByVal File As String) As Boolean

        ' Close the previous file.
        If pOpenSuccess = True Then
            Me.Close()
        End If

        ' Get the device type, this should either be "MPEGVideo" or "avivideo", other types (sequencer and cdaudio) are not supported.
        Dim Device_Type As String = "MPEGVideo"
        Dim MciExtension As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\MCI Extensions", False)
        If Not MciExtension Is Nothing Then
            Device_Type = CStr(MciExtension.GetValue(Replace(System.IO.Path.GetExtension(File), ".", ""), "MPEGVideo"))
        End If

        ' Try to open the file.
        pLastError = mciSendString("open """ & File & """ type " & Device_Type & " alias " & pAlias & "  parent " & Me.Handle.ToString & " style child", vbNullString, 0, IntPtr.Zero)
        If pLastError = MCIERR.MCIERR_NO_ERROR Then
            ' Init flags.
            pOpenSuccess = True
            pPlaying = False
            pPaused = False
            ' Remember the filename.
            pFileName = File
            ' Initialize the media.
            SizeMediaWindow()
            DoSpeed()
            DoMute()
            DoBalance()
            DoVolume()
            ' Get stats.
            pTotalTime = GetTotalTime()
            pTotalFrames = GetTotalFrames()
            Return True
        End If
        Return False

    End Function

    Public Function [Close]() As Boolean

        ' Close the media file.
        If pOpenSuccess = True Then
            pLastError = mciSendString("close " & pAlias, vbNullString, 0, IntPtr.Zero)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                pOpenSuccess = False
                pPlaying = False
                pPaused = False
                pFileName = ""     ' There is no file open.
                pTotalTime = -1    ' No media.
                pTotalFrames = -1  ' No media.
                Return True
            End If
        End If
        Return False

    End Function

    Public Function [Play]() As Boolean

        Return Me.Play(True, True, False)

    End Function

    Private Function [Play](ByVal WithClipStart As Boolean, ByVal WithClipEnd As Boolean, ByVal WithPauseState As Boolean) As Boolean

        ' Arguments:

        ' WithClipStart  indicates that the start index of the clipping should be used.
        ' WithClipEnd    indicates that the end index of the clipping should be used.
        '             
        '                With clipping you can specify what part of the media to play,
        '                for example play a single scene over and over.

        ' WithPauseState indicates that the current pause state should be respected.
        '                Play is also called when seeking and clipping to reflect the changes,
        '                in those cases the media should be paused again straight away.


        ' Start playing the media.
        If pOpenSuccess = True Then
            ' If we need to clip, we need to specify the timer format to use.
            If pClipFormat.Length > 0 Then
                pLastError = mciSendString("set " & pAlias & " time format " & pClipFormat, vbNullString, 0, IntPtr.Zero)
            End If
            ' Send the play command, we want to be notified when playing ends.
            pLastError = mciSendString("play " & pAlias & CStr(IIf((pClipStart <> -1) And WithClipStart = True, " from " & CStr(pClipStart), "")) & CStr(IIf((pClipEnd <> -1) And WithClipEnd = True, " to " & CStr(pClipEnd), "")) & " notify", vbNullString, 0, Me.Handle)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                pPlaying = True
                ' If we need to respect the pause state and we are paused, call pause.
                If WithPauseState = True And pPaused = True Then
                    Me.Pause()
                Else
                    ' We either are not paused, or we can ignore (reset) the pause state.
                    pPaused = False
                End If
            End If
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Public Function [Stop]() As Boolean

        ' Stop the media.
        If pOpenSuccess = True Then
            pLastError = mciSendString("stop " & pAlias, vbNullString, 0, IntPtr.Zero)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                ' After stop we rewind the media (just because this is somewhat the standard with other players)
                pLastError = mciSendString("seek " & pAlias & " to start", vbNullString, 0, IntPtr.Zero)
            End If
            pPlaying = False
            pPaused = False
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Public Function [Pause]() As Boolean

        ' Pause the media. (call resume after pause to continue)
        If pOpenSuccess = True Then
            pLastError = mciSendString("pause " & pAlias, vbNullString, 0, IntPtr.Zero)
            pPaused = (pLastError = MCIERR.MCIERR_NO_ERROR)
            Return pPaused
        End If
        Return False

    End Function

    Public Function [Resume]() As Boolean

        ' Resume the media.
        If pOpenSuccess = True And pPaused = True Then
            pLastError = mciSendString("resume " & pAlias, vbNullString, 0, IntPtr.Zero)
            pPaused = Not (pLastError = MCIERR.MCIERR_NO_ERROR)
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Public Property Repeat() As Boolean
        ' Set/return the repeat flag, when set the media will be played in a loop.
        Get
            Return pRepeat
        End Get
        Set(ByVal Value As Boolean)
            If pRepeat <> Value Then
                pRepeat = Value
            End If
        End Set
    End Property

    Public ReadOnly Property OriginalSize() As Size
        Get
            ' Obtain the original (screen) size of the media.
            If pOpenSuccess = True Then
                Dim SizeStr As String = Space(128)
                pLastError = mciSendString("where " & pAlias & " source", SizeStr, Len(SizeStr), IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim Items() As String = Split(Trim(SizeStr), " ")
                    Return New Size(CInt(Items(2)), CInt(Items(3)))
                End If
            End If
            Return New Size
        End Get
    End Property

    Public ReadOnly Property TotalFrames() As Long
        ' Returns the number of frames in the media, or -1 when no
        ' media is opened, or the media doesn't support frames.
        Get
            Return pTotalFrames
        End Get
    End Property

    Public ReadOnly Property TotalTime() As Long
        ' Returns the total time of the media in milliseconds.
        Get
            Return pTotalTime
        End Get
    End Property

    Public ReadOnly Property CurrentFrame() As Long
        ' Returns the current frame index in the media.
        Get
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format frames", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim PosStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " position", PosStr, Len(PosStr), IntPtr.Zero)
                    Return CLng(Trim(PosStr))
                End If
            End If
            Return -1
        End Get
    End Property

    Public ReadOnly Property CurrentTime() As Long
        ' Returns the current time index (milliseconds) in the media.
        Get
            If pOpenSuccess = True Then
                pLastError = mciSendString("set " & pAlias & " time format milliseconds", vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Dim PosStr As String = Space(128)
                    pLastError = mciSendString("status " & pAlias & " position", PosStr, Len(PosStr), IntPtr.Zero)
                    Return CLng(Trim(PosStr))
                End If
            End If
            Return -1
        End Get
    End Property

    Public Property Speed() As Integer
        ' Set/return the playback speed (range is 1 to 2000, where 1000 is normal speed)
        ' Note that speed set to zero will play the media as fast as possible (without dropping frames)
        Get
            Return pSpeed
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 2000 And Value <> pSpeed Then
                pSpeed = Value
                DoSpeed()
            End If
        End Set
    End Property

    Public Property Mute() As Channels
        ' Mute the specified channel(s).
        ' Note that Channels.Both is defined as "3" which equals "Channels.Left OR Channels.Right"
        ' this means that you can use bitwise operators.
        Get
            Return pMute
        End Get
        Set(ByVal Value As Channels)
            If Value >= Channels.None And Value <= Channels.Both And Value <> pMute Then
                pMute = Value
                DoMute()
            End If
        End Set
    End Property

    Public Property Balance() As Integer
        ' Sets/returns the left/right audio balance (range is 0 to 1000 where 500 is equal balance).
        Get
            Return pBalance
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 1000 And Value <> pBalance Then
                pBalance = Value
                DoBalance()
            End If
        End Set
    End Property

    Public Property Volume() As Integer
        ' Sets/returns the audio volume level (range is 0 to 1000 where 500 is normal).
        Get
            Return pVolume
        End Get
        Set(ByVal Value As Integer)
            If Value >= 0 And Value <= 1000 And Value <> pVolume Then
                pVolume = Value
                DoVolume()
            End If
        End Set
    End Property

    Public Function MoveToStart() As Boolean

        ' Move the media to its beginning.
        If pOpenSuccess = True Then
            pLastError = mciSendString("seek " & pAlias & " to start", vbNullString, 0, IntPtr.Zero)
            pPlaying = False ' Seeks stops playback and pause.
            pPaused = False
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Public Function MoveToEnd() As Boolean

        ' Move the media to its end.
        If pOpenSuccess = True Then
            pLastError = mciSendString("seek " & pAlias & " to end", vbNullString, 0, IntPtr.Zero)
            pPlaying = False ' Seeks stops playback.
            pPaused = False
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Public Function MoveToFrame(ByVal Frame As Long) As Boolean

        ' Move the media to the desired frame.
        Return MoveToPosition(Frame, "frames")

    End Function

    Public Function MoveToTime(ByVal Milliseconds As Long) As Boolean

        ' Move the media to the desired time index.
        Return MoveToPosition(Milliseconds, "milliseconds")

    End Function

    Private Function MoveToPosition(ByVal Index As Long, ByVal TimeFormat As String) As Boolean

        ' Move the media to its desired index using the specified time format.
        If pOpenSuccess = True Then
            ' Set the desired time format.
            pLastError = mciSendString("set " & pAlias & " time format " & TimeFormat, vbNullString, 0, IntPtr.Zero)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                ' Position the media to the index.
                pLastError = mciSendString("seek " & pAlias & " to " & CStr(Index), vbNullString, 0, IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    ' Resume playback (seek stops playback).
                    ' Note that we can't set the start position because that would cancel our seek.
                    If pPlaying = True Then
                        Me.Play(False, True, True)
                    End If
                End If
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
        End If
        Return False

    End Function

    Public Function ClipFrame(ByVal [Start] As Long, ByVal [End] As Long) As Boolean

        ' Clip the media to only play between the start and end frame.
        ' Set both values to -1 to undo clipping.
        Return Clip([Start], [End], Me.CurrentFrame, "frames")

    End Function

    Public Function ClipTime(ByVal [Start] As Long, ByVal [End] As Long) As Boolean

        ' Clip the media to only play between the start and end time.
        ' Set both values to -1 to undo clipping.
        Return Clip([Start], [End], Me.CurrentTime, "milliseconds")

    End Function

    Private Function Clip(ByVal [Start] As Long, ByVal [End] As Long, ByVal Current As Long, ByVal TimeFormat As String) As Boolean

        If pOpenSuccess = True Then
            If [Start] <> pClipStart Or [End] <> pClipEnd Or TimeFormat <> pClipFormat Then
                ' Set the start, end.
                pClipStart = [Start]
                pClipEnd = [End]
                ' Set the time format.
                If pClipStart = -1 And pClipEnd = -1 Then
                    ' Specifying -1 for both start and end disables clipping.
                    pClipFormat = ""
                Else
                    pClipFormat = TimeFormat
                End If

                ' We are playing so we need to apply the clip now.
                If pPlaying = True Then
                    ' If we are currently positioned before the start of the clip, we need to skip to the start.
                    ' If we are positioned in the clip range, or after it, MCI can handle it by itself.
                    Me.Play(([Start] > Current And [Start] <> -1), True, True)
                End If
                Return True
            End If
        End If
        Return False

    End Function

    Private Function SizeMediaWindow() As Boolean

        ' Size the media to fit our window, preserving aspect ratio.
        If pOpenSuccess = True Then
            ' Get the optimal size for the media.
            Dim OptimalSize As Size = Me.OriginalSize
            If OptimalSize.IsEmpty = False Then
                ' Calculate the ratio if we would size to the width.
                Dim wRatio As Double = (100 / OptimalSize.Width * Me.Width) / 100
                ' Verify if our window is high enough for this ratio.
                If OptimalSize.Height * wRatio > Me.Height Then
                    ' It isn't, calculate the ratio if we would size to the height.
                    wRatio = (100 / OptimalSize.Height * Me.Height) / 100
                End If
                ' Calculate the width and height for this ratio, and calculate Left and Top to center the media.
                Dim wWidth As Integer = CInt(OptimalSize.Width * wRatio)
                Dim wHeight As Integer = CInt(OptimalSize.Height * wRatio)
                Dim wLeft As Integer = CInt((Me.Width - wWidth) / 2)
                Dim wTop As Integer = CInt((Me.Height - wHeight) / 2)
                ' Send the command.
                pLastError = mciSendString("put " & pAlias & " window at " & CStr(wLeft) & " " & CStr(wTop) & " " & CStr(wWidth) & " " & CStr(wHeight), vbNullString, 0, IntPtr.Zero)
                Return (pLastError = MCIERR.MCIERR_NO_ERROR)
            End If
        End If
        Return False

    End Function

    Private Function DoSpeed() As Boolean

        ' Set the playback speed.
        If pOpenSuccess = True Then
            pLastError = mciSendString("set " & pAlias & " speed " & CStr(pSpeed), vbNullString, 0, IntPtr.Zero)
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Private Function DoMute() As Boolean

        ' Mute the channels. 
        If pOpenSuccess = True Then
            Select Case pMute
                Case Channels.None
                    pLastError = mciSendString("set " & pAlias & " audio all on", vbNullString, 0, IntPtr.Zero)
                Case Channels.Both
                    pLastError = mciSendString("set " & pAlias & " audio all off", vbNullString, 0, IntPtr.Zero)
                Case Channels.Left
                    pLastError = mciSendString("set " & pAlias & " audio left off", vbNullString, 0, IntPtr.Zero)
                    pLastError = mciSendString("set " & pAlias & " audio right on", vbNullString, 0, IntPtr.Zero)
                Case Channels.Right
                    pLastError = mciSendString("set " & pAlias & " audio left on", vbNullString, 0, IntPtr.Zero)
                    pLastError = mciSendString("set " & pAlias & " audio right off", vbNullString, 0, IntPtr.Zero)
            End Select
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Private Function DoBalance() As Boolean

        ' Set the balance factor.
        If pOpenSuccess = True Then
            pLastError = mciSendString("setaudio " & pAlias & " left volume to " & CStr(1000 - pBalance), vbNullString, 0, IntPtr.Zero)
            pLastError = mciSendString("setaudio " & pAlias & " right volume to " & CStr(pBalance), vbNullString, 0, IntPtr.Zero)
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Private Function DoVolume() As Boolean

        ' Set the volume factor.
        If pOpenSuccess = True Then
            pLastError = mciSendString("setaudio " & pAlias & " volume to " & CStr(pVolume), vbNullString, 0, IntPtr.Zero)
            Return (pLastError = MCIERR.MCIERR_NO_ERROR)
        End If
        Return False

    End Function

    Private Function GetTotalFrames() As Long

        ' Return the total number of frames in the media.
        If pOpenSuccess = True Then
            pLastError = mciSendString("set " & pAlias & " time format frames", vbNullString, 0, IntPtr.Zero)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                Dim FrameStr As String = Space(128)
                pLastError = mciSendString("status " & pAlias & " length", FrameStr, Len(FrameStr), IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Return CLng(Trim(FrameStr))
                End If
            End If
        End If
        Return -1

    End Function

    Private Function GetTotalTime() As Long

        ' Return the total playing time (in milliseconds) of the media.
        If pOpenSuccess = True Then
            pLastError = mciSendString("set " & pAlias & " time format milliseconds", vbNullString, 0, IntPtr.Zero)
            If pLastError = MCIERR.MCIERR_NO_ERROR Then
                Dim TimeStr As String = Space(128)
                pLastError = mciSendString("status " & pAlias & " length", TimeStr, Len(TimeStr), IntPtr.Zero)
                If pLastError = MCIERR.MCIERR_NO_ERROR Then
                    Return CLng(Trim(TimeStr))
                End If
            End If
        End If
        Return -1

    End Function

    Public Function GetLastError() As Integer

        ' Return the last MCI error code.
        Return pLastError

    End Function

    Public Function GetErrorString() As String

        ' Return a description for the last MCI error.
        If pLastError <> MCIERR.MCIERR_NO_ERROR Then
            Dim ErrorText As String = Space(128)
            If mciGetErrorString(pLastError, ErrorText, Len(ErrorText)) <> 0 Then
                Return Trim(ErrorText)
            End If
        End If

    End Function

    Public Sub New()

        ' Init all the variables to a default value.
        pFileName = ""                        ' No file loaded.
        pAlias = "ALIAS" & Me.Handle.ToString ' Create an unique alias (each instance of this control has an unique handle).
        pLastError = MCIERR.MCIERR_NO_ERROR   ' No error.
        pOpenSuccess = False                  ' Not open. 
        pSpeed = 1000                         ' Normal playback speed.
        pMute = Channels.None                 ' No channels muted. 
        pBalance = 500                        ' Normal left and right balance.
        pVolume = 500                         ' Normal volume.
        pRepeat = False                       ' Default to no playback looping.
        pTotalTime = -1                       ' No media.
        pTotalFrames = -1                     ' No media.
        pClipStart = -1                       ' Start at the beginning.
        pClipEnd = -1                         ' Play until the end.  
        pClipFormat = ""                      ' No clip format.
        pPlaying = False                      ' We are not playing.
        pPaused = False                       ' We are not paused.

    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

        ' Size the media window to reflect the new size.
        SizeMediaWindow()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        'Clean up before we dispose.
        Me.Close()
        MyBase.Dispose(disposing)

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Select Case m.Msg
            ' We handle autorepeat here, we get notified when playing ends with this message.
        Case MM_MCINOTIFY
                ' Only process the message if it indicates success. 
                If m.WParam.ToInt32 = MCI_NOTIFY_SUCCESSFUL Then
                    If pRepeat = True Then
                        Me.Stop()
                        Me.Play()
                    Else
                        ' Raise the End event to notify clients that we reached the end of the media.
                        Me.Stop()
                        Dim e As New System.EventArgs
                        RaiseEvent OnEnd(Me, e)
                        e = Nothing
                    End If
                End If
        End Select
        MyBase.WndProc(m)

    End Sub

End Class
