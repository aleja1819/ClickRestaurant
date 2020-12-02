using iTextSharp.text;
using iTextSharp.text.pdf;
using Pizza_Express_visual.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Pizza_Express_visual.Components
{
    public partial class components_Reportes : System.Web.UI.UserControl
    {

        //private QueryReportes aR = new QueryReportes();
        //static List<object> prod_dispo = new List<object>();
        static List<Services.reporte> ListaReporte = new List<reporte>();
        static List<Services.ventas> ListaVentas = new List<ventas>();
        private QueryReportes accesoReportes = new QueryReportes();

        void active(int switch_on)
        {
            switch (switch_on)
            {
                case 1:
                    mcontenedor.SetActiveView(vVenta);
                    venta.CssClass = "nav-link small text-uppercase active";
                    producto.CssClass = "nav-link small text-uppercase";
                    break;
                case 2:
                    mcontenedor.SetActiveView(vProducto);
                    venta.CssClass = "nav-link small text-uppercase";
                    producto.CssClass = "nav-link small text-uppercase active";
                    break;
                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idTablaEnvio.DataSource = accesoReportes.listartodo();
                idTablaEnvio.DataBind();

                active(1);
                alerta.Visible = false;

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
            foreach (var regist in ListaReporte)
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
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

        protected void bBuscarNombre_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime FechaInicial = Convert.ToDateTime(tfechaini.Text);
                DateTime FechaFinal = Convert.ToDateTime(tfechafin.Text);

                int cant = accesoReportes.filtrarPorNombre(FechaInicial, FechaFinal).Count;

                idTablaEnvio.DataSource = accesoReportes.filtrarPorNombre(FechaInicial, FechaFinal);
                idTablaEnvio.DataBind();
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

        protected void venta_Click(object sender, EventArgs e)
        {
            active(1);
        }

        protected void producto_Click(object sender, EventArgs e)
        {
            active(2);
        }

        protected void buscarVentas_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fechaInicial = Convert.ToDateTime(tfechaI.Text);
                DateTime fechaFinal = Convert.ToDateTime(tfechaF.Text);

                int cant = accesoReportes.reporteVenta(fechaInicial, fechaFinal).Count;

                idVentaSelect.DataSource = accesoReportes.reporteVenta(fechaInicial, fechaFinal);
                idVentaSelect.DataBind();

            }
            catch (Exception)
            {


            }
        }


        //ENVIAR AL CARRITO
        protected void idVentaSelect_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("idseleccionar"))
            {
                string codigo_Ven = "";
                string canti_Ven = "";
                string nombre_Ven = "";
                string fecha_Ven = "";
                string precio_Ven = "";
                try
                {
                    codigo_Ven = idVentaSelect.Rows[fila].Cells[0].Text;
                    canti_Ven = idVentaSelect.Rows[fila].Cells[1].Text;
                    nombre_Ven = idVentaSelect.Rows[fila].Cells[2].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    fecha_Ven = idVentaSelect.Rows[fila].Cells[3].Text;
                    precio_Ven = idVentaSelect.Rows[fila].Cells[4].Text.Replace("$", "").Replace(".", "");

                    int codV = Convert.ToInt32(codigo_Ven);
                    int cantidad = Convert.ToInt32(canti_Ven);
                    int precio = Convert.ToInt32(precio_Ven);
                    //AGREGAR PRODUCTO AL CARRO
                    ventas carro_comp = new ventas();
                    carro_comp = ListaVentas.First(v => v.codigo_C == codV);

                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();

                }
                catch (Exception)
                {

                    int codV = Convert.ToInt32(codigo_Ven);
                    int cantidad = Convert.ToInt32(canti_Ven);
                    int precio = Convert.ToInt32(precio_Ven);
                    DateTime fecha = Convert.ToDateTime(fecha_Ven);

                    ListaVentas.Add(new ventas { codigo_C = codV, cantidad_V = cantidad, nombre_V = nombre_Ven, fecha_V = fecha, precio_V = precio });

                }
                finally
                {
                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();
                    codigo_Ven = "";

                }

            }
        }

        protected void CargarVentasReporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                string codigo_Ven = "";
                string canti_Ven = "";
                string nombre_Ven = "";
                string fecha_Ven = "";
                string precio_Ven = "";

                try
                {

                    codigo_Ven = CargarVentasReporte.Rows[fila].Cells[0].Text;
                    canti_Ven = CargarVentasReporte.Rows[fila].Cells[1].Text;
                    nombre_Ven = CargarVentasReporte.Rows[fila].Cells[2].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    fecha_Ven = CargarVentasReporte.Rows[fila].Cells[3].Text;
                    precio_Ven = CargarVentasReporte.Rows[fila].Cells[4].Text.Replace("$", "").Replace(".", "");

                    int codV = Convert.ToInt32(codigo_Ven);
                    int cantidad = Convert.ToInt32(canti_Ven);
                    int precio = Convert.ToInt32(precio_Ven);
                    ventas carro_comp = new ventas();
                    carro_comp = ListaVentas.First(v => v.codigo_C == codV);

                    if (carro_comp.cantidad_V > 1)
                    {
                        //restar stock
                        int cantidadActual = carro_comp.cantidad_V;
                    }
                    else
                    {

                        ListaVentas.Remove(carro_comp);
                    }
                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();
                }
                catch (Exception ex)
                {
                    string ms = ex.ToString();
                }
            }
        }

        protected void bPDFVentas_Click(object sender, EventArgs e)
        {
            var doc = new Document(PageSize.A5);
            string path = Server.MapPath("Files");
            Random r = new Random();
            string nombre = "Prod_" + r.Next(1, 500) + "_" + DateTime.Now.Second+".pdf";
            PdfWriter pdfWrite = PdfWriter.GetInstance(doc, new FileStream(path + nombre, FileMode.OpenOrCreate));

            doc.Open();
            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(path + "/PIZZZA.jpg");
            tif.ScalePercent(13f, 9f);
            tif.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(tif);

            iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 18, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK);
            Paragraph paragraph = new Paragraph(@"Reporte de Ventas", verdana);
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

            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BorderColor = BaseColor.BLACK;
            cell.BackgroundColor = BaseColor.RED;

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.BOLDITALIC, BaseColor.WHITE);
            cell.Phrase = new Phrase("Nombre", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Fecha Ingreso", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Precio", letraBlanca);
            table.AddCell(cell);


            PdfPCell cell0 = new PdfPCell();
            foreach (var regist in ListaVentas)
            {
                cell0.Phrase = new Phrase(regist.cantidad_V);
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.nombre_V);
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.fecha_V.ToString());
                table.AddCell(cell0);

                cell0.Phrase = new Phrase("$ " + regist.precio_V.ToString());
                table.AddCell(cell0);

            }

            doc.Add(table);
            doc.Close();
            ShowPdfL((path + nombre));

        }
        private void ShowPdfL(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strS);
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
    }
}