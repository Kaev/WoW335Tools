Imports System.IO

Public Class MDDF
    Implements Chunk

    <Flags>
    Public Enum MDDFFlags
        Biodome = 1     ' Sets internal flags to | 0x800 (WDOODADDEF.var0xC
        Shrubbery = 2   ' Unknown if used at all
    End Enum

    Public Property Entries As New List(Of MDDF)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        For i As Integer = 0 To ChunkSize / 36 - 1
            Entries.Add(New MDDF)
            Entries(i).Read(BinaryReader, ChunkSize)
        Next
    End Sub

    Public Class MDDF
        Implements Chunk

        Public Property MMIDEntry As UInt32
        Public Property UniqueId As UInt32
        Public Property Position As Vector3f
        Public Property Rotation As Vector3f
        Public Property Scale As UInt16         ' 1024 = 1.0f
        Public Property Flags As MDDFFlags

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            MMIDEntry = BinaryReader.ReadUInt32()
            UniqueId = BinaryReader.ReadUInt32()
            Position = BinaryReader.ReadVector3f()
            Rotation = BinaryReader.ReadVector3f()
            Scale = BinaryReader.ReadUInt16()
            Flags = BinaryReader.ReadUInt16()
        End Sub
    End Class
End Class
