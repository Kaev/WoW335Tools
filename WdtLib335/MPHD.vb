Imports System.IO

Public Class MPHD
    Implements Chunk

    <Flags>
    Public Enum MPHDFlags
        UseGlobalMapObjectDefinition = &H01
        VertexBufferFormatPNC = &H02
        UseEnvTerrainShadersAndMCALSize4096 = &H04
        DisableSomeRenderStuff = &H08
        VertexBufferFormatPNG2 = &H10
        MCALSize4096 = &H80
    End Enum

    Public Property Flags As MPHDFlags
    Public Property Unknown As UInt32
    Public Property Unused As New List(Of UInt32)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
        Flags = BinaryReader.ReadUInt32()
        Unknown = BinaryReader.ReadUInt32()
        For i As Byte = 0 To 5
            Unused.Add(BinaryReader.ReadUInt32())
        Next
    End Sub
End Class
