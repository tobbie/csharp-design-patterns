
using FactoryMethod;


namespace DesignPatterns.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void FactoryMethod_CreatesCorrectReportTypes()
        {
            // Arrange
            var pdfFactory = new PdfReportFactory();
            var excelFactory = new ExcelReportFactory();
            var htmlFactory = new HtmlReportFactory();

            // Act
            var pdfReport = pdfFactory.CreateReport();
            var excelReport = excelFactory.CreateReport();
            var htmlReport = htmlFactory.CreateReport();

            // Assert
            Assert.IsType<PdfReport>(pdfReport);
            Assert.IsType<ExcelReport>(excelReport);
            Assert.IsType<HtmlReport>(htmlReport);
            Assert.Equal("PDF", pdfReport.GetFormat());
            Assert.Equal("Excel", excelReport.GetFormat());
            Assert.Equal("Html", htmlReport.GetFormat());
        }

        [Theory]
        [InlineData(typeof(PdfReport), "pdf", "PDF")]
        [InlineData(typeof(ExcelReport), "excel", "Excel")]
        [InlineData(typeof(HtmlReport), "html", "Html")]
        public void GenericReportFactory_CreatesCorrectReportTypes(Type expectedType, string reportType, string expectedFormat)
        {
            // Arrange & Act
            var factory = new GenericReportFactory(reportType);
            var report = factory.CreateReport();

            // Assert
            Assert.IsType(expectedType, report);
            Assert.Equal(expectedFormat, report.GetFormat());
        }
    }
}
