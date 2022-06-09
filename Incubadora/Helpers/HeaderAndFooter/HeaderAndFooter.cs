using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.Helpers.HeaderAndFooter
{
    public class HeaderAndFooter
    {
        public class HeaderFooter : PdfPageEventHelper
        {
            string PathImage = null;
            string PathImageSEPH = null;
            string PathImageEH = null;
            string PathImage30A = null;

            public HeaderFooter(string logoPath, string sepHPath, string escudoPath, string aniversario)
            {
                PathImage = logoPath;
                PathImageSEPH = sepHPath;
                PathImageEH = escudoPath;
                PathImage30A = aniversario;
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                //base.OnEndPage(writer, document);

                PdfPTable tbHeader = new PdfPTable(3);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;

                tbHeader.AddCell(new Paragraph());

                PdfPCell _cell = new PdfPCell(new Paragraph(""));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;

                tbHeader.AddCell(_cell);
                tbHeader.AddCell(new Paragraph());

                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 40, writer.DirectContent);

                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;

                tbFooter.AddCell(new Paragraph());

                _cell = new PdfPCell(new Paragraph(" "));
                _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell.Border = 0;

                tbFooter.AddCell(_cell);
                _cell = new PdfPCell(new Paragraph("Página " + writer.PageNumber + " de " + writer.CurrentPageNumber));
                _cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell.Border = 0;

                tbFooter.AddCell(_cell);

                tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 5, writer.DirectContent);

                //Begin image 

                Image logo = Image.GetInstance(PathImage);
                logo.SetAbsolutePosition(20, 730);

                logo.ScaleAbsolute(60f, 55f);
                document.Add(logo);

                Image escudo = Image.GetInstance(PathImageEH);
                escudo.SetAbsolutePosition(540, 730);

                escudo.ScaleAbsolute(60f, 55f);
                document.Add(escudo);

                Image seph = Image.GetInstance(PathImageSEPH);
                seph.SetAbsolutePosition(230, 730);

                seph.ScaleAbsolute(150f, 55f);
                document.Add(seph);

                Image ani = Image.GetInstance(PathImage30A);
                ani.SetAbsolutePosition(20, 10);

                ani.ScaleAbsolute(65, 60f);
                document.Add(ani);

                //End image
            }
        }
    }
}
   