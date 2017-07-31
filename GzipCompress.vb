Imports System.IO
Imports System.IO.Compression

sub Main()
	compress("Full_File_Path_And_Name_And_Extension")
end sub

Public Sub Compress(ByVal FilePath As String) 
	Dim UncompressedData As Byte() = System.IO.File.ReadAllBytes(FilePath) 
	Dim CompressedData As New MemoryStream()  
	Dim GZipper As New GZipStream(CompressedData, CompressionMode.Compress, True) 

	GZipper.Write(UncompressedData, 0, UncompressedData.Length)
	GZipper.Dispose()
	System.IO.File.WriteAllBytes(Left(FilePath, InStr(FilePath, ".") - 1) + ".gz", CompressedData.ToArray) 

	CompressedData.Dispose()
End Sub
