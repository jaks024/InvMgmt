using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
using System.Collections.ObjectModel;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
namespace InvMgmt
{
	public class HistoryFileWriter
	{

		public void CreatePdf()
		{
			PdfDocument doc = new PdfDocument();
			PdfPage page = doc.AddPage();
			XGraphics gfx = XGraphics.FromPdfPage(page);
			XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
			gfx.DrawString("test test", font, XBrushes.Black,
				new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);

			string filename = "test.pdf";
			doc.Save(filename);

			
		}

	}
}
