using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAutoSS.ExportGenerator.Contracts
{
    public interface IReportGenerator
    {
        void GenerateReport(string pathForFile, string nameOfFile, string text);
    }
}
