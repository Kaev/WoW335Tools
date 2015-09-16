Imports System.IO
Imports AdtLib335

Public Class MH2O
    Implements Chunk

    Public Property Headers As New Dictionary(Of MH2OHeader, MH2OHeaderData)

    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
        Dim posBeforeMH2O As Long = BinaryReader.BaseStream.Position
        Dim maxPosMH2O As Long = posBeforeMH2O + ChunkSize
        For i As UInt32 = 0 To 256 - 1
            Dim MH2OHeaderData As New MH2OHeaderData

            Dim header = New MH2OHeader
            header.Read(BinaryReader, ChunkSize)

            Dim posAfterHeaderData As Long = BinaryReader.BaseStream.Position

            If header.LayerCount > 0 Then
                Dim information As New MH2OInformation
                Dim heightmapData As New MH2OHeightmapData
                Dim renderMaskData As New MH2ORenderMask

                BinaryReader.BaseStream.Position = posBeforeMH2O + header.OffsetInformation
                information.Read(BinaryReader, ChunkSize)

                If information.OffsetHeightmapData <> 0 AndAlso information.Flags <> 2 Then
                    BinaryReader.BaseStream.Position = posBeforeMH2O + information.OffsetHeightmapData
                    heightmapData.Read(BinaryReader, information)
                End If

                If information.OffsetMask2 <> 0 Then
                    BinaryReader.BaseStream.Position = posBeforeMH2O + information.OffsetMask2
                    renderMaskData.Read(BinaryReader)
                End If

                MH2OHeaderData.MH2OHeightmapData = heightmapData
                MH2OHeaderData.MH2OInformation = information
                MH2OHeaderData.MH2ORenderMask = renderMaskData
            End If

            Headers.Add(header, MH2OHeaderData)
            BinaryReader.BaseStream.Position = posAfterHeaderData
        Next
        BinaryReader.BaseStream.Position = posBeforeMH2O + ChunkSize
    End Sub

    Public Class MH2OHeader
        Implements Chunk

        Public Property OffsetInformation As UInt32
        Public Property LayerCount As UInt32
        Public Property OffsetRenderMask As UInt32

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            OffsetInformation = BinaryReader.ReadUInt32()
            LayerCount = BinaryReader.ReadUInt32()
            OffsetRenderMask = BinaryReader.ReadUInt32()
        End Sub
    End Class

    Public Class MH2OInformation
        Implements Chunk

        Public Property LiquidTypeId As UInt16
        Public Property Flags As UInt16
        Public Property MinHeightLevel As Single
        Public Property MaxHeightLevel As Single
        Public Property OffsetX As Byte
        Public Property OffsetY As Byte
        Public Property Width As Byte
        Public Property Height As Byte
        Public Property OffsetMask2 As UInt32
        Public Property OffsetHeightmapData As UInt32

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            LiquidTypeId = BinaryReader.ReadUInt16()
            Flags = BinaryReader.ReadUInt16()
            MinHeightLevel = BinaryReader.ReadSingle()
            MaxHeightLevel = BinaryReader.ReadSingle()
            OffsetX = BinaryReader.ReadByte()
            OffsetY = BinaryReader.ReadByte()
            Width = BinaryReader.ReadByte()
            Height = BinaryReader.ReadByte()
            OffsetMask2 = BinaryReader.ReadUInt32()
            OffsetHeightmapData = BinaryReader.ReadUInt32()
        End Sub
    End Class

    Public Class MH2OHeightmapData

        Public Property Heightmap As Single(,)
        Public Property Transparency As Byte(,)

        Public Sub New()
            HeightMap = New Single(7, 7) {}
            Transparency = New Byte(7, 7) {}
            For y As Byte = 0 To 7
                For x As Byte = 0 To 7
                    HeightMap(x, y) = 0
                    Transparency(x, y) = 255
                Next
            Next
        End Sub

        Public Sub Read(ByRef BinaryReader As BinaryReader, MH2OInformation As MH2OInformation)
            For y As Byte = MH2OInformation.OffsetY To MH2OInformation.Height + MH2OInformation.OffsetY - 1
                For x As Byte = MH2OInformation.OffsetX To MH2OInformation.Width + MH2OInformation.OffsetX - 1
                    Heightmap(x, y) = BinaryReader.ReadSingle()
                Next
            Next

            For y As Byte = MH2OInformation.OffsetY To MH2OInformation.Height + MH2OInformation.OffsetY - 1
                For x As Byte = MH2OInformation.OffsetX To MH2OInformation.Width + MH2OInformation.OffsetX - 1
                    Transparency(x, y) = BinaryReader.ReadByte()
                Next
            Next
        End Sub
    End Class

    Public Class MH2ORenderMask
        Public Property Mask As Byte()
        Public Property Fatigue As Byte()

        Public Sub New()
            Mask = New Byte(7) {}
            Fatigue = New Byte(7) {}
            For i As Integer = 0 To 7
                Mask(i) = 255
            Next
        End Sub

        Public Sub Read(ByRef BinaryReader As BinaryReader)
            Mask = BinaryReader.ReadBytes(8)
            Fatigue = BinaryReader.ReadBytes(8)
        End Sub
    End Class

    Public Class MH2OHeaderData
        Public Property MH2OInformation As MH2O.MH2OInformation
        Public Property MH2OHeightmapData As MH2O.MH2OHeightmapData
        Public Property MH2ORenderMask As MH2O.MH2ORenderMask
    End Class
End Class

