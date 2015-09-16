Imports System.IO

Public Class MODF
    Implements Chunk

    <Flags>
    Public Enum MODFFlags
        Destroyable = 1     ' Set for destroyable buildings. This makes it a server-controllable game object.
    End Enum

    Public Property Entries As New List(Of MODF)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        If ChunkSize > 0 Then
            For i As UInt32 = 0 To ChunkSize / 64 - 1
                Entries.Add(New MODF)
                Entries(i).Read(BinaryReader, ChunkSize)
            Next
        End If
    End Sub

    Public Class MODF
        Implements Chunk

        Public Property MWIDEntry As UInt32
        Public Property UniqueId As UInt32
        Public Property Position As Vector3f
        Public Property Rotation As Vector3f
        Public Property LowerBounds As Vector3f     ' Position + Bounding Box
        Public Property UpperBounds As Vector3f     ' Position + Bounding Box
        Public Property Flags As MODFFlags
        Public Property DoodadSet As UInt16
        Public Property NameSet As UInt16           ' Used for renaming
        Public Property Padding As UInt16

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            MWIDEntry = BinaryReader.ReadUInt32()
            UniqueId = BinaryReader.ReadUInt32()
            Position = BinaryReader.ReadVector3f()
            Rotation = BinaryReader.ReadVector3f()
            LowerBounds = BinaryReader.ReadVector3f()
            UpperBounds = BinaryReader.ReadVector3f()
            Flags = BinaryReader.ReadUInt16()
            DoodadSet = BinaryReader.ReadUInt16()
            NameSet = BinaryReader.ReadUInt16()
            Padding = BinaryReader.ReadUInt16()
        End Sub
    End Class
End Class
