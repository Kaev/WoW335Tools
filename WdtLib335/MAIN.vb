Imports System.IO

Public Class MAIN
    Implements Chunk

    <Flags>
    Public Enum MAINFlags
        HasAdt
        Loaded
    End Enum

    Public Property Entries As MAIN(,)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
        Entries = New MAIN(63, 63) {}
        For y As UInt32 = 0 To 63
            For x As UInt32 = 0 To 63
                Entries(x, y) = New MAIN()
                Entries(x, y).Read(BinaryReader, ChunkSize)
            Next
        Next
    End Sub

    Public Class MAIN
        Implements Chunk

        Public Property Flags As MAINFlags
        Public Property Area As UInt32

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            Flags = BinaryReader.ReadUInt32()
            Area = BinaryReader.ReadUInt32()
        End Sub
    End Class
End Class


