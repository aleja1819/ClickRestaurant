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
       static List<object> prod_dispo = new List<object>();
       static List<Services.reporte> ListaReporte = new List<reporte>();
        private QueryReportes accesoReportes = new QueryReportes();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idTablaEnvio.DataSource = accesoReportes.listartodo();
                idTablaEnvio.DataBind();

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

            iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 18, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK);
            Paragraph paragraph = new Paragraph(@"Reporte Ingreso de Productos", verdana);
            paragraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraph);

            Paragraph noVali = new Paragraph(" ");
            noVali.Alignment = Element.ALIGN_CENTER;
            doc.Add(noVali);

            Paragraph paragraph2 = new Paragraph("Fecha Reporte: " + DateTime.Now.ToString());
            paragraph2.Alignment = Element.ALIGN_LEFT;
            paragraph2.PaddingTop = 1;
            doc.Add(paragraph2);

            Paragraph Vali = new Paragraph(" ");
            noVali.Alignment = Element.ALIGN_CENTER;
            doc.Add(Vali);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraph3);

            PdfPTable table = new PdfPTable(5);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BorderColor = BaseColor.BLACK;
            cell.BackgroundColor = BaseColor.RED;

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.BOLDITALIC, BaseColor.WHITE);
            cell.Phrase = new Phrase("Código", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Nombre", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Rut Proveedor", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Fecha Ingreso", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Cantidad", letraBlanca);
            table.AddCell(cell);


            PdfPCell cell0 = new PdfPCell();
            foreach (var regist in ListaReporte )
            {
                cell0.Phrase = new Phrase(regist.codigo_P.ToString());
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.nombre_P);
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.rut_P);
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.fecha_I.ToString());
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.cantidad_P.ToString());
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

                idTablaEnvio.DataSource = accesoReportes.filtrarPorNombre(date11, date21);
                idTablaEnvio.DataBind();

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

        protected void cargaReporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                string codigo_pro = "";
                string nombre_pro = "";
                string rut_pro = "";
                string fecha_ingre = "";
                string canti_pro = "";

                try
                {

                    codigo_pro = cargaReporte.Rows[fila].Cells[0].Text;
                    nombre_pro = cargaReporte.Rows[fila].Cells[1].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    rut_pro = cargaReporte.Rows[fila].Cells[2].Text;
                    fecha_ingre = cargaReporte.Rows[fila].Cells[3].Text;
                    canti_pro = cargaReporte.Rows[fila].Cells[4].Text;

                    int codM = Convert.ToInt32(codigo_pro);
                    int cantidad = Convert.ToInt32(canti_pro);
                    reporte carro_comp = new reporte();
                    carro_comp = ListaReporte.First(p => p.codigo_P == codM);

                    if (carro_comp.cantidad_P > 1)
                    {
                        //restar stock
                        int cantidadActual = carro_comp.cantidad_P;                                
                    }
                    else
                    {

                        ListaReporte.Remove(carro_comp);
                    }
                    cargaReporte.DataSource = ListaReporte;
                    cargaReporte.DataBind();
                }
                catch (Exception ex)
                {
                    string ms = ex.ToString();
                }
            }
        }

        protected void idTablaEnvio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("idseleccionar"))
            {
                string codigo_pro = "";
                string nombre_pro = "";
                string rut_pro = "";
                string fecha_ingre = "";
                string canti_pro = "";


                try
                {
                    codigo_pro = idTablaEnvio.Rows[fila].Cells[0].Text;
                    nombre_pro = idTablaEnvio.Rows[fila].Cells[1].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    rut_pro = idTablaEnvio.Rows[fila].Cells[2].Text;
                    fecha_ingre = idTablaEnvio.Rows[fila].Cells[3].Text;
                    canti_pro = idTablaEnvio.Rows[fila].Cells[4].Text;

                    int codM = Convert.ToInt32(codigo_pro);
                    int cantidad = Convert.ToInt32(canti_pro);
                    //AGREGAR PRODUCTO AL CARRO
                    reporte carro_comp = new reporte();
                    carro_comp = ListaReporte.First(p => p.codigo_P == codM);
                   

                    cargaReporte.DataSource = ListaReporte;
                    cargaReporte.DataBind();

                }
                catch (Exception)
                {

                    int codM = Convert.ToInt32(codigo_pro);
                    int cantidad = Convert.ToInt32(canti_pro);
                    DateTime fecha = Convert.ToDateTime(fecha_ingre);

                    ListaReporte.Add(new reporte { codigo_P = codM, nombre_P = nombre_pro, rut_P = rut_pro, fecha_I = fecha, cantidad_P = cantidad });

                }
                finally
                {
                    cargaReporte.DataSource = ListaReporte;
                    cargaReporte.DataBind();
                    codigo_pro = "";

                }
                
            }
        }
    }
}