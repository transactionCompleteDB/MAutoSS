namespace MAutoSS.ReportGenerator.Contracts
{
    public interface IReportGenerator
    {
        void GenerateReport(string pathForFile, string nameOfFile, string text);
    }
}