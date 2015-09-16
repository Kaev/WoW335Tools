Imports System.IO

Public Class MMDX
    Implements Chunk

    Public Property Filenames As List(Of String)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        Dim chunkData As Byte() = BinaryReader.ReadBytes(ChunkSize)
        If chunkData.Count > 0 Then
            Filenames = SplitNullTerminatedStrings(chunkData)
        End If
    End Sub
End Class
