Imports System.IO

Public Class MTXF
    Implements Chunk

    Public Enum MTXFFlags
        DoNotLoadSpecularOrHeightTexture = 1   ' Probably just "disable all shading"
    End Enum

    Public Property Flags As MTXFFlags

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        Flags = BinaryReader.ReadUInt32()
    End Sub
End Class
