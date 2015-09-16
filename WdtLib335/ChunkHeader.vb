Imports System.IO

Public Class ChunkHeader
    Implements Chunk

    Public Property Name As Char()
    Public Property Size As UInt32

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
        Name = BinaryReader.ReadChars(4)
        Array.Reverse(Name)
        Size = BinaryReader.ReadUInt32()
    End Sub
End Class
