using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace SpirePdfArabicIssue
{
    class Program
    {
        const string _value = "أهلا وسهلا";

        static void Main(string[] _)
        {
            // Both examples generate arabic words where the letters are disjoint like this:
            // أ ه ل ا  و س ه ل ا
            ReproWithAlefRegularFont();
            ReproWithCustomNotoFont();
        }

        static void ReproWithAlefRegularFont()
        {
            // This is modified directly from https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Text/How-to-draw-right-to-left-text-on-PDF-in-C.html
            var doc = new PdfDocument();
            var page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins());
            var font = new PdfTrueTypeFont(new Font("Alef-Regular.ttf", 16f, FontStyle.Bold), true);
            var labelBounds = new RectangleF(20, 20, 400, font.Height);
            page.Canvas.DrawString(_value, font, PdfBrushes.Black, labelBounds, new PdfStringFormat() { RightToLeft = true });

            doc.SaveToFile("result1.pdf");
        }


        static void ReproWithCustomNotoFont()
        {
            // This uses the Google Noto font
            var doc = new PdfDocument();
            var page = doc.Pages.Add(PdfPageSize.A4, new PdfMargins());
            var font = new PdfTrueTypeFont("Fonts/NotoNaskhArabic-Regular.ttf", 16f);
            var labelBounds = new RectangleF(20, 20, 400, font.Height);
            page.Canvas.DrawString(_value, font, PdfBrushes.Black, labelBounds, new PdfStringFormat() { RightToLeft = true });

            doc.SaveToFile("result2.pdf");
        }
    }
}
