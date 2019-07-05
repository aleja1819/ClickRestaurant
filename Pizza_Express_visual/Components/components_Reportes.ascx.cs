using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pizza_Express_visual.Services;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace Pizza_Express_visual.Components
{
    public partial class components_Reportes : System.Web.UI.UserControl
    {

       private QueryReportes aR = new QueryReportes();
        static List<QueryReportes> queryRepo = new List<QueryReportes>();

        private QueryReportes accesoReportes = new QueryReportes();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idTabla.DataSource = accesoReportes.listartodo();
                idTabla.DataBind();

            }

        }

        protected void bGenerarPdf_Click(object sender, EventArgs e)
        {
            var doc = new Document(PageSize.A5);
            string path = Server.MapPath("Files");
            Random r = new Random();
            string nombre = "Prod_" + r.Next(1, 500) + "_" + DateTime.Now.Second;
            PdfWriter pdfWrite = PdfWriter.GetInstance(doc, new FileStream(path + nombre, FileMode.OpenOrCreate));

            doc.Open();
            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(path + "/PIZZZA.jpg");
            tif.ScalePercent(13f, 9f);
            tif.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(tif);

            //itsEvents ev = new itsEvents();
            //pdfWrite.PageEvent = ev;
            //doc.Open();

            iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 18, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED);
            Paragraph paragraph = new Paragraph(@"COCINA", verdana);
            paragraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraph);

            Paragraph paragraph2 = new Paragraph("Fecha: " + DateTime.Now.ToString());
            Random m = new Random();
            Paragraph mesa = new Paragraph("N° Mesa: " + m.Next(1, 20));
            Paragraph garzon = new Paragraph("Garzón: GARZÓN PIZZERIA");
            Random c = new Random();
            Paragraph comanda = new Paragraph("Comanda: " + c.Next(1, 5000));
            paragraph2.Alignment = Element.ALIGN_LEFT;
            paragraph2.PaddingTop = 1;
            doc.Add(paragraph2);
            doc.Add(mesa);
            doc.Add(garzon);
            doc.Add(comanda);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraph3);

            PdfPTable table = new PdfPTable(2);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BorderColor = BaseColor.BLACK;
            cell.BackgroundColor = BaseColor.RED;

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.BOLDITALIC, BaseColor.WHITE);
            cell.Phrase = new Phrase("Cantidad", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Detalle", letraBlanca);
            table.AddCell(cell);

            PdfPCell cell0 = new PdfPCell();
            foreach (var regist in )
            {
                cell0.Phrase = new Phrase(regist.cantidad.ToString());
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.nombre_M);
                table.AddCell(cell0);

            }

            doc.Add(table);
            doc.Close();
            ShowPdf((path + nombre));

        }
        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strS);
            //Response.AddHeader("Content-Disposition", "inline; filename=" + strS);
            // Response.ContentType = "application/octectstream";
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

    
    protected void bBuscarNombre_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime date11 = Convert.ToDateTime(tfechaini.Text);
                DateTime date21 = Convert.ToDateTime(tfechafin.Text);
                //var date1 = new DateTime(2019, 3, 1);
                //var date2 = new DateTime(2019, 5, 5);

                int cant = accesoReportes.filtrarPorNombre(date11, date21).Count;

                idTabla.DataSource = accesoReportes.filtrarPorNombre(date11, date21);
                idTabla.DataBind();

                //if (cant == 0 || string.IsNullOrEmpty(tfechaini.Text) || string.IsNullOrEmpty(tfechafin.Text))
                //{
                //    alerta.Visible = true;
                //    alerta.CssClass = "alert alert-danger animated zoomInUp";
                //    mensaje3.Text = "PRODUCTO NO ENCONTRADO.";
                //    idTabla.DataSource = accesoReportes.listartodo();
                //    idTabla.DataBind();
                //}
            }
            catch (Exception)
            {

               
            }

        }
    }
}