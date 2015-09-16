Imports System.IO

Public Class MFBO
    Implements Chunk

    Public Property Maximum As Plane
    Public Property Minimum As Plane

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        Maximum = BinaryReader.ReadPlane()
        Minimum = BinaryReader.ReadPlane()
    End Sub
End Class
