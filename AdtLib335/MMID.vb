Imports System.IO

Public Class MMID
    Implements Chunk

    Public Property Offsets As New List(Of UInt32)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        If ChunkSize > 0 Then
            For i As UInt32 = 0 To ChunkSize / 4 - 1
                Offsets.Add(New UInt32)
                Offsets(i) = BinaryReader.ReadUInt32
            Next
        End If
    End Sub
End Class
