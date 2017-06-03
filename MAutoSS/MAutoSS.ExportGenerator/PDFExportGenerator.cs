using iTextSharp.text;
using iTextSharp.text.pdf;
using MAutoSS.ReportGenerator.Contracts;
using System.IO;

namespace MAutoSS.ReportGenerator
{
    public class PDFReportGenerator : IReportGenerator
    {
        public void GenerateReport(string pathToSaveFile, string nameOfFile, string text)
        {
            string fullPath = pathToSaveFile + nameOfFile + ".pdf";
            FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(text));
            doc.Close();
        }
    }
}