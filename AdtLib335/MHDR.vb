Imports System.IO

Public Class MHDR
    Implements Chunk

    <Flags>
    Public Enum MHDRFlags
        MFBO = 1        ' Contains MFBO Chunk
        Northrend = 2   ' Is set for some Northrend ADTs
    End Enum

    Public Property Flags As MHDRFlags
    Public Property OffsetMCIN As UInt32
    Public Property OffsetMTEX As UInt32
    Public Property OffsetMMDX As UInt32
    Public Property OffsetMMID As UInt32
    Public Property OffsetMWMO As UInt32
    Public Property OffsetMWID As UInt32
    Public Property OffsetMDDF As UInt32
    Public Property OffsetMODF As UInt32
    Public Property OffsetMFBO As UInt32
    Public Property OffsetMH2O As UInt32
    Public Property OffsetMTXF As UInt32
    Public Property Unknown As New List(Of UInt32)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        Dim PosMHDR = BinaryReader.BaseStream.Position
        Flags = BinaryReader.ReadUInt32()
        OffsetMCIN = BinaryReader.ReadUInt32()
        OffsetMTEX = BinaryReader.ReadUInt32()
        OffsetMMDX = BinaryReader.ReadUInt32()
        OffsetMMID = BinaryReader.ReadUInt32()
        OffsetMWMO = BinaryReader.ReadUInt32()
        OffsetMWID = BinaryReader.ReadUInt32()
        OffsetMDDF = BinaryReader.ReadUInt32()
        OffsetMODF = BinaryReader.ReadUInt32()
        OffsetMFBO = BinaryReader.ReadUInt32()
        OffsetMH2O = BinaryReader.ReadUInt32()
        OffsetMTXF = BinaryReader.ReadUInt32()
        For i As Integer = 0 To 3
            Unknown.Add(New UInt32)
            Unknown(i) = BinaryReader.ReadUInt32()
        Next
    End Sub
End Class
