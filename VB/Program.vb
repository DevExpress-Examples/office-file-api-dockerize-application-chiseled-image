Imports System.IO
Imports DevExpress.Drawing
Imports DevExpress.XtraRichEdit

Friend Module Program

    Public Function Main(ByVal args As String()) As Integer
        Try
            Dim baseDir = AppContext.BaseDirectory
            Dim docxPath = If(args.Length >= 1, args(0), Path.Combine(baseDir, "fontTest.docx"))
            ' Include Fonts in the Application
            Dim fonts As String() = {"Inter-Regular.ttf", "NotoSans-Regular.ttf"}
            Dim fontFiles As String() = fonts.Select(Function(f) Path.Combine(AppContext.BaseDirectory, f)).ToArray()
            ' Register fonts before loading documents
            For Each fp In fontFiles
                Call DXFontRepository.Instance.AddFont(fp)
            Next

            Dim richEditDocumentServer = New RichEditDocumentServer()
            richEditDocumentServer.LoadDocument(docxPath, DocumentFormat.Docx)
            Dim exportedPdf = New MemoryStream()
            richEditDocumentServer.ExportToPdf(exportedPdf)
            exportedPdf.Position = 0
            Dim ouput = Console.OpenStandardOutput()
            exportedPdf.CopyTo(ouput)
            ouput.Flush()
            Program.Log("Done.")
            Return 0
        Catch ex As Exception
            Program.Log("ERROR:")
            Log(ex.ToString())
            Return 1
        End Try
    End Function

    Private Sub Log(ByVal message As String)
        Console.Error.WriteLine($"[{DateTimeOffset.UtcNow:O}] {message}")
    End Sub
End Module
