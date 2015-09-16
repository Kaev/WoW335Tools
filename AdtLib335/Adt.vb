Public Class Adt
    ' Some little helper variables, just in case you need them.
    Public Shared ReadOnly AdtSize As Single = 533.33333
    Public Shared ReadOnly ChunksInAdt As UInt32 = 16 * 16
    Public Shared ReadOnly ChunkSize As Single = AdtSize / 16

    Public Property MCIN As MCIN
    Public Property MCNK As New List(Of MCNK)
    Public Property MDDF As MDDF
    Public Property MFBO As MFBO
    Public Property MH2O As MH2O
    Public Property MHDR As MHDR
    Public Property MMDX As MMDX
    Public Property MMID As MMID
    Public Property MODF As MODF
    Public Property MTEX As MTEX
    Public Property MTXF As New List(Of MTXF)
    Public Property MVER As MVER
    Public Property MWID As MWID
    Public Property MWMO As MWMO
    Public Property WDTFile As WdtLib335.Wdt

    Public Sub New(Filename As String)
        Load(Filename)
    End Sub

    Public Sub New(Filename As String, FilenameWdt As String)
        Load(Filename, FilenameWdt)
    End Sub

    Public Sub Load(Filename As String, Optional FilenameWdt As String = "")
        If Not String.IsNullOrEmpty(FilenameWdt) Then
            WDTFile = New WdtLib335.Wdt(FilenameWdt)
        End If

        Dim BinaryReader As New IO.BinaryReader(IO.File.OpenRead(Filename))
        While (BinaryReader.BaseStream.Position < BinaryReader.BaseStream.Length)
            Dim chunkHeader As New ChunkHeader
            chunkHeader.Read(BinaryReader, 0)
            LoadChunk(BinaryReader, chunkHeader)
        End While
    End Sub

    Private Sub LoadChunk(ByRef BinaryReader As IO.BinaryReader, ChunkHeader As ChunkHeader)
        Select Case ChunkHeader.Name
            Case "MVER"
                MVER = New MVER
                MVER.Read(BinaryReader, ChunkHeader.Size)
                If MVER.Version <> 18 Then
                    Throw New NotSupportedException("The adt file is not version 18")
                    BinaryReader.BaseStream.Position = BinaryReader.BaseStream.Length
                End If
            Case "MHDR"
                MHDR = New MHDR
                MHDR.Read(BinaryReader, ChunkHeader.Size)
            Case "MCIN"
                MCIN = New MCIN
                MCIN.Read(BinaryReader, ChunkHeader.Size)
            Case "MTEX"
                MTEX = New MTEX
                MTEX.Read(BinaryReader, ChunkHeader.Size)
            Case "MMDX"
                MMDX = New MMDX
                MMDX.Read(BinaryReader, ChunkHeader.Size)
            Case "MMID"
                MMID = New MMID
                MMID.Read(BinaryReader, ChunkHeader.Size)
            Case "MWMO"
                MWMO = New MWMO
                MWMO.Read(BinaryReader, ChunkHeader.Size)
            Case "MWID"
                MWID = New MWID
                MWID.Read(BinaryReader, ChunkHeader.Size)
            Case "MDDF"
                MDDF = New MDDF
                MDDF.Read(BinaryReader, ChunkHeader.Size)
            Case "MODF"
                MODF = New MODF
                MODF.Read(BinaryReader, ChunkHeader.Size)
            Case "MH2O"
                MH2O = New MH2O
                MH2O.Read(BinaryReader, ChunkHeader.Size)
            Case "MCNK"
                Dim chunk As New MCNK
                chunk.Read(BinaryReader, ChunkHeader.Size, WDTFile)
                MCNK.Add(chunk)
            Case "MFBO"
                MFBO = New MFBO
                MFBO.Read(BinaryReader, ChunkHeader.Size)
            Case "MTXF"
                For i As UInt32 = 0 To MTEX.Filenames.Count - 1
                    Dim chunk As New MTXF
                    chunk.Read(BinaryReader, ChunkHeader.Size)
                    MTXF.Add(chunk)
                Next
        End Select
    End Sub
End Class
