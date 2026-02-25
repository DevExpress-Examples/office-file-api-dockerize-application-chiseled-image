Imports DevExpress.Drawing
Imports DevExpress.XtraRichEdit

Friend Module Program

    Public Function Main(ByVal args As String()) As Integer
        Try
            Dim baseDir = AppContext.BaseDirectory
            Dim docxPath = If(args.Length >= 1, args(0), Path.Combine(baseDir, "fontTest.docx"))
            ' Include Fonts in the Application
            Dim fontFiles As String() = _("Inter-Regular.ttf", "NotoSans-Regular.ttf")
             ''' Cannot convert LocalDeclarationStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax' to type 'Microsoft.CodeAnalysis.VisualBasic.Syntax.ExpressionSyntax'.
'''    at ICSharpCode.CodeConverter.VB.CommonConversions.RemodelVariableDeclaration(VariableDeclarationSyntax declaration) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommonConversions.cs:line 478
'''    at ICSharpCode.CodeConverter.VB.MethodBodyExecutableStatementVisitor.VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\MethodBodyExecutableStatementVisitor.cs:line 59
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingMethodBodyVisitor.cs:line 24
''' 
''' Input:
'''             string[] fontPaths = [.. fontFiles.Select(f => Path.Combine(baseDir, f))];
''' 
'''  ' Use the Skia Drawing Engine
Settings.DrawingEngine = DrawingEngine.Skia
            ' Register fonts before loading documents
            For Each fp In fontPaths
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
