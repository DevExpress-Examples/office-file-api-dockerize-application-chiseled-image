using System.Runtime.InteropServices;
using DevExpress.Drawing;
using DevExpress.XtraRichEdit;

internal static class Program {
    public static int Main(string[] args) {
        try {
            var baseDir = AppContext.BaseDirectory;
            var docxPath = args.Length >= 1 ? args[0] : Path.Combine(baseDir, "fontTest.docx");

            // Include Fonts in the Application
            string[] fontFiles = ["Inter-Regular.ttf", "NotoSans-Regular.ttf"];
            string[] fontPaths = [.. fontFiles.Select(f => Path.Combine(baseDir, f))];

            // Use the Skia Drawing Engine
            Settings.DrawingEngine = DrawingEngine.Skia;

            // Register fonts before loading documents
            foreach (var fp in fontPaths) {
                DXFontRepository.Instance.AddFont(fp);
            }

            using var richEditDocumentServer = new RichEditDocumentServer();
            richEditDocumentServer.LoadDocument(docxPath, DocumentFormat.Docx);

            using var exportedPdf = new MemoryStream();
            richEditDocumentServer.ExportToPdf(exportedPdf);

            exportedPdf.Position = 0;
            using var ouput = Console.OpenStandardOutput();
            exportedPdf.CopyTo(ouput);
            ouput.Flush();

            Log("Done.");
            return 0;
        }
        catch (Exception ex) {
            Log("ERROR:");
            Log(ex.ToString());
            return 1;
        }
    }

    private static void Log(string message) =>
        Console.Error.WriteLine($"[{DateTimeOffset.UtcNow:O}] {message}");
}