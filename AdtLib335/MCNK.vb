Imports System.IO
Imports AdtLib335

Public Class MCNK

    <Flags>
    Public Enum MCNKFlags
        HasMCSH = &H01
        Impass = &H02
        LiquidRiver = &H04
        LiquidOcean = &H08
        LiquidMagma = &H10
        LiquidSlime = &H20
        HasMCCV = &H40
        DoNotFixAlphaMap = &H8000
        HighResolutionHoles = &H10000
    End Enum

    Public Property Flags As MCNKFlags
    Public Property Index As Vector2u
    Public Property Layers As UInt32
    Public Property NumberDoodadRefs As UInt32
    Public Property OffsetMCVT As UInt32
    Public Property MCVTSubChunk As MCVT
    Public Property OffsetMCNR As UInt32
    Public Property MCNRSubChunk As MCNR
    Public Property OffsetMCLY As UInt32
    Public Property MCLYSubChunks As New List(Of MCLY)
    Public Property OffsetMCRF As UInt32
    Public Property MCRFSubChunk As MCRF
    Public Property OffsetMCAL As UInt32
    Public Property SizeAlpha As UInt32
    Public Property MCALSubChunk As MCAL
    Public Property OffsetMCSH As UInt32
    Public Property SizeShadow As UInt32
    Public Property MCSHSubChunk As MCSH
    Public Property AreaId As UInt32
    Public Property NumberMapObjectRefs As UInt32
    Public Property Holes As UInt16
    Public Property HolesAlign As UInt16
    Public Property ReallyLowQualityTextureingMap As UInt16()
    Public Property PredTex As UInt32
    Public Property EffectDoodad As UInt32
    Public Property OffsetMCSE As UInt32
    Public Property NumberSoundEmitters As UInt32
    Public Property MCSESubChunk As MCSE
    Public Property OffsetMCLQ As UInt32
    Public Property SizeLiquid As UInt32
    Public Property MCLQSubChunk As MCLQ
    Public Property Position As Vector3f
    Public Property OffsetMCCV As UInt32
    Public Property MCCVSubChunk As MCCV
    Public Property Unused1 As UInt32
    Public Property Unused2 As UInt32


    Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32, WDTFile As WdtLib335.Wdt)
        Dim posBeforeMCNK As Long = BinaryReader.BaseStream.Position

        Flags = BinaryReader.ReadUInt32()
        Index = BinaryReader.ReadVector2u()
        Layers = BinaryReader.ReadUInt32()
        NumberDoodadRefs = BinaryReader.ReadUInt32()
        OffsetMCVT = BinaryReader.ReadUInt32()
        OffsetMCNR = BinaryReader.ReadUInt32()
        OffsetMCLY = BinaryReader.ReadUInt32()
        OffsetMCRF = BinaryReader.ReadUInt32()
        OffsetMCAL = BinaryReader.ReadUInt32()
        SizeAlpha = BinaryReader.ReadUInt32()
        OffsetMCSH = BinaryReader.ReadUInt32()
        SizeShadow = BinaryReader.ReadUInt32()
        AreaId = BinaryReader.ReadUInt32()
        NumberMapObjectRefs = BinaryReader.ReadUInt32()
        Holes = BinaryReader.ReadUInt16()
        HolesAlign = BinaryReader.ReadUInt16()
        ReallyLowQualityTextureingMap = New UInt16(7) {}
        For i As Integer = 0 To 7
            ReallyLowQualityTextureingMap(i) = BinaryReader.ReadUInt16()
        Next
        PredTex = BinaryReader.ReadUInt32()
        EffectDoodad = BinaryReader.ReadUInt32()
        OffsetMCSE = BinaryReader.ReadUInt32()
        NumberSoundEmitters = BinaryReader.ReadUInt32()
        OffsetMCLQ = BinaryReader.ReadUInt32()
        SizeLiquid = BinaryReader.ReadUInt32()
        Position = BinaryReader.ReadVector3f()
        OffsetMCCV = BinaryReader.ReadUInt32()
        Unused1 = BinaryReader.ReadUInt32()
        Unused2 = BinaryReader.ReadUInt32()

        If OffsetMCVT > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCVT
            MCVTSubChunk = New MCVT
            MCVTSubChunk.Read(BinaryReader, ChunkSize)
        End If

        If OffsetMCNR > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCNR
            MCNRSubChunk = New MCNR
            MCNRSubChunk.Read(BinaryReader, ChunkSize)
        End If

        If OffsetMCLY > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCLY
            For i As Integer = 0 To Layers - 1
                Dim chunk As New MCLY
                chunk.Read(BinaryReader, ChunkSize)
                MCLYSubChunks.Add(chunk)
            Next
        End If

        If OffsetMCRF > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCRF
            MCRFSubChunk = New MCRF
            MCRFSubChunk.Read(BinaryReader, NumberDoodadRefs, NumberMapObjectRefs)
        End If

        If Not WDTFile Is Nothing Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCAL
            MCALSubChunk = New MCAL
            MCALSubChunk.Read(BinaryReader, MCLYSubChunks, WDTFile)
        End If

        If SizeShadow > 0 AndAlso OffsetMCSH > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCSH
            MCSHSubChunk = New MCSH
            MCSHSubChunk.Read(BinaryReader, ChunkSize)
        End If

        If NumberSoundEmitters > 0 AndAlso OffsetMCSE > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCSE
            MCSESubChunk = New MCSE
            MCSESubChunk.Read(BinaryReader, ChunkSize)
        End If

        If SizeLiquid > 0 AndAlso OffsetMCLQ > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCLQ
            MCLQSubChunk = New MCLQ
            MCLQSubChunk.Read(BinaryReader, ChunkSize)
        End If

        If OffsetMCCV > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCCV
            MCCVSubChunk = New MCCV
            MCCVSubChunk.Read(BinaryReader, ChunkSize)
        End If

        If SizeShadow > 8 AndAlso OffsetMCSH > 0 Then
            BinaryReader.BaseStream.Position = posBeforeMCNK + OffsetMCSH
            MCSHSubChunk = New MCSH
            MCSHSubChunk.Read(BinaryReader, ChunkSize)
        End If

        BinaryReader.BaseStream.Position = posBeforeMCNK + ChunkSize
    End Sub

    Public Class MCAL
        Public Property Layer As MCAL()

        Public Sub Read(ByRef BinaryReader As BinaryReader, MCLYSubChunks As List(Of MCLY), WDTFile As WdtLib335.Wdt)
            Dim posBeforeAlphaMapData As Long = BinaryReader.BaseStream.Position
            Layer = New MCAL(MCLYSubChunks.Count - 1) {}
            For i As Integer = 0 To MCLYSubChunks.Count - 1
                If MCLYSubChunks(i).Flags.HasFlag(MCLY.MCLYFlags.AlphaMap) Then
                    Layer(i) = New MCAL
                    Layer(i).AlphaMap = New Byte(63, 63) {}
                    Layer(i).Read(BinaryReader, MCLYSubChunks(i), WDTFile, posBeforeAlphaMapData)
                End If
            Next
        End Sub

        Public Class MCAL
            Public Property AlphaMap As Byte(,)

            Public Sub Read(ByRef BinaryReader As BinaryReader, MCLYSubChunk As MCLY, WDTFile As WdtLib335.Wdt, posBeforeAlphaMapData As Long)
                BinaryReader.BaseStream.Position = posBeforeAlphaMapData + MCLYSubChunk.OffsetInMCAL
                AlphaMap = New Byte(63, 63) {}

                If Not MCLYSubChunk.Flags.HasFlag(MCLY.MCLYFlags.CompressedAlphaMap) AndAlso
                  (Not WDTFile.MPHD.Flags.HasFlag(WdtLib335.MPHD.MPHDFlags.UseEnvTerrainShadersAndMCALSize4096) AndAlso
                   Not WDTFile.MPHD.Flags.HasFlag(WdtLib335.MPHD.MPHDFlags.MCALSize4096)) Then
                    ' Uncompressed (2048)
                    For y As Byte = 0 To 63
                        For x As Byte = 0 To 63 Step 2
                            Dim fullByte As Byte = BinaryReader.ReadByte()
                            Dim halfByteB As Byte = ((fullByte And &H0F) >> 0) * 17
                            Dim halfByteA As Byte = ((fullByte And &HF0) >> 4) * 17
                            AlphaMap(x, y) = halfByteA
                            AlphaMap(x + 1, y) = halfByteB
                        Next
                    Next

                ElseIf Not MCLYSubChunk.Flags.HasFlag(MCLY.MCLYFlags.CompressedAlphaMap) AndAlso
                       (WDTFile.MPHD.Flags.HasFlag(WdtLib335.MPHD.MPHDFlags.UseEnvTerrainShadersAndMCALSize4096) OrElse
                       WDTFile.MPHD.Flags.HasFlag(WdtLib335.MPHD.MPHDFlags.MCALSize4096)) Then
                    ' Uncompressed (4096)
                    For y As Byte = 0 To 63
                        For x As Byte = 0 To 63 Step 2
                            AlphaMap(x, y) = BinaryReader.ReadByte()
                        Next
                    Next

                ElseIf MCLYSubChunk.Flags.HasFlag(MCLY.MCLYFlags.CompressedAlphaMap) Then
                    ' Compressed
                    Dim posInAlphaMap = 0
                    Dim tempAlphaMap(4095) As Byte
                    While (posInAlphaMap < 4095)
                        Dim info As Byte = BinaryReader.ReadByte()
                        Dim mode As Byte = (info And &H80) >> 7
                        Dim count As Byte = (info And &H7F)

                        If mode = 0 Then ' Copy mode
                            For i As Integer = 0 To count - 1
                                tempAlphaMap(posInAlphaMap + i) = BinaryReader.ReadByte()
                            Next
                        Else ' Fill mode
                            Dim dataByte As Byte = BinaryReader.ReadByte()
                            For i As Integer = 0 To count - 1
                                tempAlphaMap(posInAlphaMap + i) = dataByte
                            Next
                        End If
                        posInAlphaMap += count
                    End While

                    ' Fill Alphamap with values now
                    For y As Byte = 0 To 63
                        For x As Byte = 0 To 63
                            AlphaMap(x, y) = tempAlphaMap(x * 63 + y)
                        Next
                    Next
                End If
            End Sub
        End Class
    End Class

    Public Class MCCV
        Implements Chunk

        Public Property Entries As MCCV()

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            Entries = New MCCV(144) {}
            For i As Integer = 0 To 144
                Entries(i) = New MCCV
                Entries(i).Red = BinaryReader.ReadByte()
                Entries(i).Green = BinaryReader.ReadByte()
                Entries(i).Blue = BinaryReader.ReadByte()
                Entries(i).Alpha = BinaryReader.ReadByte()
            Next
        End Sub

        Public Class MCCV
            Public Property Red As Byte
            Public Property Green As Byte
            Public Property Blue As Byte
            Public Property Alpha As Byte
        End Class
    End Class

    Public Class MCLQ
        Implements Chunk

        Public Property Unknown0 As Int16
        Public Property Unknown1 As Int16
        Public Property Height As Single

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            Unknown0 = BinaryReader.ReadInt16()
            Unknown1 = BinaryReader.ReadInt16()
            Height = BinaryReader.ReadSingle()
        End Sub
    End Class

    Public Class MCLY
        Implements Chunk

        <Flags>
        Public Enum MCLYFlags
            Rotate45 = &H1
            Rotate90 = &H2
            Rotate180 = &H4
            Fast = &H8
            Faster = &H10
            Fastest = &H20
            Animate = &H40
            Brighter = &H80
            AlphaMap = &H100
            CompressedAlphaMap = &H200
            SkyboxReflection = &H400
        End Enum

        Public Property TextureId As UInt32
        Public Property Flags As MCLYFlags
        Public Property OffsetInMCAL As UInt32
        Public Property EffectId As Int32

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            TextureId = BinaryReader.ReadUInt32()
            Flags = BinaryReader.ReadUInt32()
            OffsetInMCAL = BinaryReader.ReadUInt32()
            EffectId = BinaryReader.ReadInt32()
        End Sub
    End Class

    Public Class MCNR
        Implements Chunk

        Public Property Entries As MCNR()
        Public Property Unknown As UInt16()   ' Always 0 112 245 18 0 8 0 0 0 84 245 18 0

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            Entries = New MCNR(144) {}
            Unknown = New UInt16(12) {}
            For i As Byte = 0 To 144
                Entries(i) = New MCNR
                Entries(i).Read(BinaryReader, ChunkSize)
            Next

            For i As Byte = 0 To 12
                Unknown(i) = BinaryReader.ReadUInt16()
            Next
        End Sub

        Public Class MCNR
            Implements Chunk

            Public Property Normal As Byte()

            Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
                Normal = New Byte(2) {}
                For i As Byte = 0 To 2
                    Normal(i) = BinaryReader.ReadByte()
                Next
            End Sub
        End Class
    End Class

    Public Class MCRF

        Public Property DoodadsReferences As UInt32()
        Public Property WmoReferences As UInt32()

        Public Sub Read(ByRef BinaryReader As BinaryReader, NumberDoodadRefs As UInt32, NumberMapObjectRefs As UInt32)
            If Not NumberDoodadRefs - 1 < 0 Then
                DoodadsReferences = New UInt32(NumberDoodadRefs - 1) {}
                For i As UInt32 = 0 To DoodadsReferences.Length - 1
                    DoodadsReferences(i) = BinaryReader.ReadUInt32()
                Next
            End If

            If Not NumberMapObjectRefs - 1 < 0 Then
                WmoReferences = New UInt32(NumberMapObjectRefs - 1) {}
                For i As UInt32 = 0 To WmoReferences.Length - 1
                    WmoReferences(i) = BinaryReader.ReadUInt32()
                Next
            End If
        End Sub
    End Class

    Public Class MCSE
        Implements Chunk

        Public Property SoundEntriesAdvancedId As UInt32
        Public Property Position As Vector3f
        Public Property Size As Vector3f

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            SoundEntriesAdvancedId = BinaryReader.ReadUInt32()
            Position = BinaryReader.ReadVector3f()
            Size = BinaryReader.ReadVector3f()
        End Sub
    End Class

    Public Class MCSH
        Implements Chunk

        Public Property ShadowMap As Boolean(,)

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInteger) Implements Chunk.Read
            ShadowMap = New Boolean(63, 63) {}

            Dim tempShadowMap(4095) As Boolean
            For i As Integer = 0 To 511
                Dim byteData As Byte = BinaryReader.ReadByte()
                For bit As Byte = 0 To 7
                    tempShadowMap(i) = (1 = ((byteData >> bit) & 1))
                Next
            Next

            For y As Byte = 0 To 63
                For x As Byte = 0 To 63
                    ShadowMap(x, y) = tempShadowMap(x * 63 + y)
                Next
            Next
        End Sub
    End Class

    Public Class MCVT
        Implements Chunk

        Public Property Heights As Single()

        Public Sub Read(ByRef BinaryReader As BinaryReader, ChunkSize As UInt32) Implements Chunk.Read
            Heights = New Single(144) {}
            For i As Integer = 0 To 144
                Heights(i) = BinaryReader.ReadSingle()
            Next
        End Sub
    End Class
End Class
