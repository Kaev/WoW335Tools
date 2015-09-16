Imports System.IO

Public Class MVER

    Public Property Version As UInt32

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32)
        Version = BinaryReader.ReadUInt32()
    End Sub
End Class
