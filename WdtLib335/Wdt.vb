Public Class Wdt
    Public Property MVER As MVER
    Public Property MPHD As MPHD
    Public Property MAIN As MAIN
    Public Property MWMO As MWMO
    Public Property MODF As MODF
    Public Property IsGlobalModel

    Public Sub New()
        IsGlobalModel = False
    End Sub

    Public Sub New(FileName As String)
        IsGlobalModel = False
        Load(FileName)
    End Sub

    Public Sub Load(FileName As String)
        Dim BinaryReader As New IO.BinaryReader(IO.File.OpenRead(FileName))
        While (BinaryReader.BaseStream.Position < BinaryReader.BaseStream.Length)
            Dim chunkHeader As New ChunkHeader
            chunkHeader.Read(BinaryReader, 0)
            LoadChunk(BinaryReader, chunkHeader)
        End While
        IsGlobalModel = Not MODF Is Nothing AndAlso Not MWMO Is Nothing
    End Sub

    Public Sub LoadChunk(ByRef BinaryReader As IO.BinaryReader, ChunkHeader As ChunkHeader)
        Select Case ChunkHeader.Name
            Case "MVER"
                MVER = New MVER
                MVER.Read(BinaryReader, ChunkHeader.Size)
                If MVER.Version <> 18 Then
                    Throw New NotSupportedException("The wdt file is not version 18")
                    BinaryReader.BaseStream.Position = BinaryReader.BaseStream.Length
                End If
            Case "MPHD"
                MPHD = New MPHD
                MPHD.Read(BinaryReader, ChunkHeader.Size)
            Case "MAIN"
                MAIN = New MAIN
                MAIN.Read(BinaryReader, ChunkHeader.Size)
            Case "MWMO"
                MWMO = New MWMO
                MWMO.Read(BinaryReader, ChunkHeader.Size)
            Case "MODF"
                MODF = New MODF
                MODF.Read(BinaryReader, ChunkHeader.Size)
        End Select
    End Sub
End Class
