Public Module Helper
    <Runtime.CompilerServices.Extension()>
    Public Function ReadVector3f(BinaryReader As IO.BinaryReader) As Vector3f
        Return New Vector3f(BinaryReader.ReadSingle(), BinaryReader.ReadSingle(), BinaryReader.ReadSingle())
    End Function

    Public Function SplitNullTerminatedStrings(Data As Byte()) As List(Of String)
        Dim retVal As New List(Of String)
        Dim sb As New Text.StringBuilder
        For i As UInt32 = 0 To Data.Length - 1
            Dim letter As Char = Convert.ToChar(Data(i))
            If letter = vbNullChar Then
                If sb.Length > 1 Then
                    retVal.Add(sb.ToString())
                    sb.Clear()
                    Continue For
                End If
            End If
            sb.Append(letter)
        Next
        Return retVal
    End Function
End Module
