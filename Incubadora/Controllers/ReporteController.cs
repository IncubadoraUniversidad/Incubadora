using Incubadora.Business.Interface;
using Incubadora.Domain;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Incubadora.Helpers.HeaderAndFooter.HeaderAndFooter;

namespace Incubadora.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IProyectoBusiness proyectoBusiness;
        private readonly IGiroBusiness giroBusiness;
        private readonly IEmprendedorBusiness emprendedorBusiness;
        private readonly IFaseBusiness faseBusiness;
        private readonly IRecursoBusiness recursoBusiness;

        public ReporteController(
            IProyectoBusiness _proyectoBusiness,
            IEmprendedorBusiness _emprendedorBusiness,
            IGiroBusiness _giroBusiness,
            IFaseBusiness _faseBusiness,
            IRecursoBusiness _recursoBusiness)
        {
            proyectoBusiness = _proyectoBusiness;
            giroBusiness = _giroBusiness;
            emprendedorBusiness = _emprendedorBusiness;
            faseBusiness = _faseBusiness;
            recursoBusiness = _recursoBusiness;
        }
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Imprimir(string Id)
        {
            var proyecto = proyectoBusiness.GetProyectoById(Id);

            FileStream fs = new FileStream("c://pdf/" + proyecto.StrNombre  + ".pdf", FileMode.Create);
            MemoryStream ms = new MemoryStream();

            Document document = new Document(iTextSharp.text.PageSize.LETTER, 30f, 20f, 50f, 40f);
            PdfWriter pw = PdfWriter.GetInstance(document, fs);

             string pathImageLogo = Server.MapPath("/Img/logouttt.png");

            string pathImageSEPH = Server.MapPath("/Img/SEPH.png");
            string pathImageEH = Server.MapPath("/Img/escudoHidalgo.png");
            string pathImage30A = Server.MapPath("/Img/30a.png");

            pw.PageEvent = new HeaderFooter(pathImageLogo, pathImageSEPH, pathImageEH, pathImage30A);

            var giro = giroBusiness.GetGiroById(proyecto.IdGiro);
            var emprendedor = emprendedorBusiness.GetEmprendedorByIdProyecto(proyecto.IdEmprendedor);
            var fase = faseBusiness.GetFaseById(proyecto.IdFase);
            List<RecursoDomainModel> recursos = recursoBusiness.GetRecursosByUserId(emprendedor.IdUsuario).ToList();

            document.Open();

            document.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(new float[] { 5f, 28f, 67f });
            table.WidthPercentage = 100f;

            PdfPCell _cell = new PdfPCell();

            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Nombre del Proyecto: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(proyecto.StrNombre));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Nombre de la Empresa: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(proyecto.StrNombreEmpresa));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("RFC de la Empresa: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(proyecto.StrRFC));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Descripción del Proyecto: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(proyecto.StrDescripcion));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Giro del Proyecto: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(giro.StrValor));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Fase del Proyecto: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(fase.StrValor));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Nombre del Emprendedor: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(emprendedor.StrNombre + " " + emprendedor.StrApellidoPaterno + " " + emprendedor.StrApellidoMaterno));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Fecha del registro: "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("" + proyecto.DtFechaRegistro));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph(" "));
            _cell.Border = 0;
            table.AddCell(_cell);
            _cell = new PdfPCell(new Paragraph("Constituida Legal: "));
            _cell.Border = 0;
            table.AddCell(_cell);

            var constituida = "";
            if (proyecto.IntConstituidaLegal == 1)
            {
                constituida = "Sí";
            }
            else if (proyecto.IntConstituidaLegal == 2)
            {
                constituida = "No";
            }
            else if (proyecto.IntConstituidaLegal == 3)
            {
                constituida = "En proceso";
            }
            else
            {
                constituida = "Otro";
            }

            _cell = new PdfPCell(new Paragraph(constituida));
            _cell.Border = 0;
            table.AddCell(_cell);


            document.Add(table);

            PdfPTable table2 = new PdfPTable(5);
            table2.WidthPercentage = 100f;
            PdfPCell _cell2 = new PdfPCell();

            Font fuente = new Font();
            fuente.Color = BaseColor.WHITE;
            _cell2 = new PdfPCell(new Paragraph("Recurso", fuente)) { BackgroundColor = new BaseColor(0, 69, 161) };
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(_cell2);
            _cell2 = new PdfPCell(new Paragraph("Nombre", fuente)) { BackgroundColor = new BaseColor(0, 69, 161) };
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(_cell2);
            _cell2 = new PdfPCell(new Paragraph("Apellido Paterno", fuente)) { BackgroundColor = new BaseColor(0, 69, 161) };
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(_cell2);
            _cell2 = new PdfPCell(new Paragraph("Apellido Materno", fuente)) { BackgroundColor = new BaseColor(0, 69, 161) };
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(_cell2);
            _cell2 = new PdfPCell(new Paragraph("Observaciones", fuente)) { BackgroundColor = new BaseColor(0, 69, 161) };
            _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.AddCell(_cell2);

            document.Add(new Paragraph(" "));

            foreach (var item in recursos)
            {
                _cell2 = new PdfPCell(new Paragraph(item.StrNombreRecurso));
                _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(_cell2);
                _cell2 = new PdfPCell(new Paragraph(item.StrNombrePersona));
                _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(_cell2);
                _cell2 = new PdfPCell(new Paragraph(item.StrApellidoPaterno));
                _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(_cell2);
                _cell2 = new PdfPCell(new Paragraph(item.StrApellidoMaterno));
                _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(_cell2);
                _cell2 = new PdfPCell(new Paragraph(item.StrDescripcion));
                _cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.AddCell(_cell2);
            }

            document.Add(table2);

            //Chunk linea = new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(2f, 100f, BaseColor.GREEN, Element.ANCHOR, 50f));
            //document.Add(linea);


            PdfContentByte cb = pw.DirectContent;
            cb.MoveTo(50, 80);
            cb.LineTo(560, 80);
            cb.SetColorStroke(BaseColor.GREEN);
            cb.ClosePathStroke();

            document.Close();

            byte[] bytesStream = ms.ToArray();

            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return null;
            //return new FileStreamResult(ms, "application/pdf");
        }

    }
}