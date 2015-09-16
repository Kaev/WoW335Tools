Imports System.IO

Public Class MCIN
    Implements Chunk

    Public Property Entries As New List(Of MCIN)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        For i As Integer = 0 To 16 * 16 - 1
            Entries.Add(New MCIN)
            Entries(i).Read(BinaryReader, ChunkSize)
        Next
    End Sub

    Public Class MCIN
        Implements Chunk

        Public Property OffsetMCNK As UInt32  ' Absolute Offsetet
        Public Property Size As UInt32        ' Size of MCNK chunk
        Public Property Flags As UInt32       ' Always 0, only set in the client
        Public Property AsyncId As UInt32     ' Always 0, only set in the client

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            OffsetMCNK = BinaryReader.ReadUInt32
            Size = BinaryReader.ReadUInt32
            Flags = BinaryReader.ReadUInt32
            AsyncId = BinaryReader.ReadUInt32
        End Sub
    End Class
End Class
