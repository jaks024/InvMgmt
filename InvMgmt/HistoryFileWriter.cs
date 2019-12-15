using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvMgmt.Information.ViewModels;
using System.Collections.ObjectModel;

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using System.Diagnostics;
using System.IO;

namespace InvMgmt
{
	public class HistoryFileWriter
	{


		public void WriteToFile(string content, string savePath)
		{

			//PdfDocument doc = new PdfDocument();
			//PdfPage page = doc.AddPage();
			//XGraphics gfx = XGraphics.FromPdfPage(page);
			//XTextFormatter tf = new XTextFormatter(gfx);
			//XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

			//tf.DrawString("Histories of " + DateTime.Today.ToString("d MMM yyyy") + "\n\n" + content, font, XBrushes.Black,
			//		new XRect(40, 40, page.Width - 80, page.Height), XStringFormats.TopLeft);

			//string filename = "test.pdf";
			//doc.Save(filename);

			Document document = new Document();
			Section sec = document.AddSection();
			Paragraph para = sec.AddParagraph();
			para.Format.Alignment = ParagraphAlignment.Left;
			para.Format.Font.Size = 11;
			para.Format.Font.Color = Colors.Black;
			para.Format.LineSpacing = 1;
			
			para.AddText("Histories of " + DateTime.Today.ToString("d MMM yyyy"));
			para.AddLineBreak();
			para.AddLineBreak();
			para.AddText(content);

			PdfDocumentRenderer rend = new PdfDocumentRenderer(true);
			rend.Document = document;
			rend.RenderDocument();

			string fileName = savePath + "\\0_" + DateTime.Today.ToString("d_MMM_yyyy") + "_History.pdf";
			int count = 0;
			while (File.Exists(fileName))
			{
				count++;
				fileName = savePath + "\\" + count + "_" + DateTime.Today.ToString("d_MMM_yyyy") + "_History.pdf";
			}

			rend.PdfDocument.Save(fileName);
			Process.Start(fileName);
		}

	}
}
