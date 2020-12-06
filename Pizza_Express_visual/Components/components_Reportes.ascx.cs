﻿using iTextSharp.text;
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
        static List<Services.productos> ListaProducto = new List<productos>();
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

        protected void venta_Click(object sender, EventArgs e)
        {
            active(1);
        }

        protected void producto_Click(object sender, EventArgs e)
        {
            active(2);
        }


        /////////////////////////SECCIONPRODUCTOS PRODUCTOS///////////////////////////
        protected void bBuscarNombre_Click(object sender, EventArgs e) //BOTON BUSCAR REPORTES PRODUCTOS
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
                    productos carro_comp = new productos();
                    carro_comp = ListaProducto.First(p => p.codigo_P == codM);


                    cargaReporte.DataSource = ListaProducto;
                    cargaReporte.DataBind();

                }
                catch (Exception)
                {

                    int codM = Convert.ToInt32(codigo_pro);
                    int cantidad = Convert.ToInt32(canti_pro);
                    DateTime fecha = Convert.ToDateTime(fecha_ingre);

                    ListaProducto.Add(new productos { codigo_P = codM, nombre_P = nombre_pro, rut_P = rut_pro, fecha_I = fecha, cantidad_P = cantidad });

                }
                finally
                {
                    cargaReporte.DataSource = ListaProducto;
                    cargaReporte.DataBind();
                    codigo_pro = "";

                }
                LinkButtonlimpiarseleccionventaPRO.Visible = true;
                ldetalleSeleciónP.Visible = true;
                bGenerarPdf.Visible = true;
            }
        }

        protected void cargaReporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("IDQuitar"))
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
                    productos carro_comp = new productos();
                    carro_comp = ListaProducto.First(p => p.codigo_P == codM);

                    if (carro_comp.cantidad_P > 1)
                    {
                        //restar stock
                        int cantidadActual = carro_comp.cantidad_P;
                        string nombreActual = carro_comp.nombre_P;
                        string precioActual = carro_comp.rut_P;

                        ListaProducto[ListaProducto.IndexOf(carro_comp)].cantidad_P = cantidad - cantidadActual;
                    }
                    else
                    {

                        ListaProducto.Remove(carro_comp);
                    }
                    cargaReporte.DataSource = ListaProducto;
                    cargaReporte.DataBind();
                    limpiarTodo(2);
                }
                catch (Exception ex)
                {
                    string ms = ex.ToString();
                }
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

            iTextSharp.text.Font verdana = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
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

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
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
            foreach (var regist in ListaProducto)
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


        /////////////////////////SECCIÓN VENTAS///////////////////////////

        protected void buscarVentas_Click(object sender, EventArgs e)   //  BOTTON BUSCAR VENTA
        {
            try
            {

                DateTime fechaInicial = Convert.ToDateTime(tfechaI.Text);
                DateTime fechaFinal = Convert.ToDateTime(tfechaF.Text);

                int cant = accesoReportes.reporteVenta(fechaInicial, fechaFinal).Count;

                idVentaSelect.DataSource = accesoReportes.reporteVenta(fechaInicial, fechaFinal);
                idVentaSelect.DataBind();


                Session["precioTotal"] = accesoReportes.listaPrecios(fechaInicial, fechaFinal);

                ltotalRangoFecha.Text = "Total Ventas del día $" + Session["precioTotal"];
                ltotalRangoFecha.Visible = true;

            }
            catch (Exception)
            {


            }
        }

        private void calcularTotalVentaSeleccion() //CALCULAR VENTAS SELECCIONADAS

        {
            int suma = 0;
            foreach (var item in ListaVentas)
            {
                suma += item.precio_V;
            }

            ltotalRangoFechaSelección.Text = "Total ventas seleccionadas $" + suma;
            ltotalRangoFechaSelección.Visible = true;
        }

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
                    ventas carrito = new ventas();
                    carrito = ListaVentas.First(v => v.codigo_C == codV);
                    ListaVentas[ListaVentas.IndexOf(carrito)].cantidad_V += 1;
                    ListaVentas[ListaVentas.IndexOf(carrito)].precio_V += precio;

                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();
                    ltotalRangoFechaSelección.Visible = true;

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
                calcularTotalVentaSeleccion();
                LinkButtonlimpiarseleccionventa.Visible = true;
                ldetalleSeleccion.Visible = true;
                bPDFVentas.Visible = true;

            }

        }

        protected void CargarVentasReporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("idQuitar"))
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
                    DateTime fecha = Convert.ToDateTime(fecha_Ven);
                    ventas carrito = new ventas();
                    carrito = ListaVentas.First(v => v.codigo_C == codV);


                    if (carrito.cantidad_V > 1)
                    {

                        //restar stock
                        int cantidadActual = carrito.cantidad_V;
                        int precioActual = carrito.precio_V;

                        ListaVentas[ListaVentas.IndexOf(carrito)].cantidad_V = cantidadActual - 1;
                        ListaVentas[ListaVentas.IndexOf(carrito)].precio_V = precio - precioActual;



                    }
                    else
                    {
                        ListaVentas.Remove(carrito);
                    }
                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();
                    calcularTotalVentaSeleccion();
                    limpiarTodo(2);


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
            string nombre = "Prod_" + r.Next(1, 500) + "_" + DateTime.Now.Second + ".pdf";
            PdfWriter pdfWrite = PdfWriter.GetInstance(doc, new FileStream(path + nombre, FileMode.OpenOrCreate));

            doc.Open();
            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(path + "/PIZZZA.jpg");
            tif.ScalePercent(13f, 9f);
            tif.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(tif);

            iTextSharp.text.Font verdana = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
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

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            cell.Phrase = new Phrase("cantidad", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Nombre", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Fecha Ingreso", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Precio", letraBlanca);
            table.AddCell(cell);


            PdfPCell cell0 = new PdfPCell();
            foreach (var regist in ListaVentas)
            {
                cell0.Phrase = new Phrase(regist.cantidad_V.ToString());
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

        private void limpiarTodo(int op)
        {
            if (op == 1)
            {

                ltotalRangoFechaSelección.Text = "";

            }
            ltotalRangoFechaSelección.Text = "Total ventas seleccionadas $0";
            ListaVentas.Clear();
            ListaProducto.Clear();

        }
        protected void LinkButtonlimpiarseleccionventa_Click(object sender, EventArgs e)
        {
            CargarVentasReporte.DataSource = null;
            CargarVentasReporte.DataBind();
            LinkButtonlimpiarseleccionventa.Visible = true;
            limpiarTodo(2);
            LinkButtonlimpiarseleccionventa.Visible = false;
            ldetalleSeleccion.Visible = false;
            bPDFVentas.Visible = false;
            ltotalRangoFechaSelección.Visible = false;

        }

        protected void LinkButtonlimpiarseleccionventaPRO_Click(object sender, EventArgs e)
        {
            cargaReporte.DataSource = null;
            cargaReporte.DataBind();
            LinkButtonlimpiarseleccionventa.Visible = true;
            limpiarTodo(2);

            LinkButtonlimpiarseleccionventaPRO.Visible = false;
            ldetalleSeleciónP.Visible = false;
            bGenerarPdf.Visible = false;

        }

        protected void bCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = idVentaSelect.Rows.Count;

                string codigo_Ven = "";
                string canti_Ven = "";
                string nombre_Ven = "";
                string fecha_Ven = "";
                string precio_Ven = "";

               

                            for (int i = 0; i < fila; i++)
                {

                    Session["codigo"] = idVentaSelect.Rows[i].Cells[0].Text; 
                    Session["cantidad"] = idVentaSelect.Rows[i].Cells[1].Text; 
                    Session["nombre"] = idVentaSelect.Rows[i].Cells[2].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");;
                    Session["fecha"] = idVentaSelect.Rows[i].Cells[3].Text; 
                    Session["precio"] = idVentaSelect.Rows[i].Cells[4].Text.Replace("$", "").Replace(".", "");

                    

                    int codV = Convert.ToInt32(Session["codigo"]);
                    int cantidad = Convert.ToInt32(Session["cantidad"]);
                    int precio = Convert.ToInt32(Session["precio"]);


                        //AGREGAR PRODUCTO AL CARRO
                        ventas carrito = new ventas();
                    carrito = ListaVentas.First(v => v.codigo_C == codV);
                    //ListaVentas[ListaVentas.IndexOf(carrito)].cantidad_V += 1;
                    //ListaVentas[ListaVentas.IndexOf(carrito)].precio_V += precio;

                    List<string> cargar = new List<string>();



                }


                    CargarVentasReporte.DataSource = ListaVentas;
                    CargarVentasReporte.DataBind();
                    ltotalRangoFechaSelección.Visible = true;

                }

            catch (Exception)
            {

                List<string> cargar = new List<string>();

                

                int codV = Convert.ToInt32(Session["codigo"]);
                int cantidad = Convert.ToInt32(Session["cantidad"]);
                int precio = Convert.ToInt32(Session["precio"]);
                DateTime fecha = Convert.ToDateTime(Session["fecha"]);
                string nombre = "" + (Session["nombre"]);

                cargar.Add(Session["codigo"]+"");
                cargar.Add(Session["cantidad"] + "");
                cargar.Add(Session["nombre"] + "");
                cargar.Add(Session["fecha"] + "");
                cargar.Add(Session["precio"] + "");


                ListaVentas.Add(new ventas
                {

                    codigo_C = Convert.ToInt32(cargar[0]),
                    cantidad_V = Convert.ToInt32(cargar[1]),
                    nombre_V = (cargar[2]),
                    fecha_V = Convert.ToDateTime(cargar[3]),
                    precio_V = Convert.ToInt32(cargar[4]),

                });

            }
            finally
            {

                CargarVentasReporte.DataSource = ListaVentas;
                CargarVentasReporte.DataBind();
                Session["codigo"] = "";


            }
            calcularTotalVentaSeleccion();
            LinkButtonlimpiarseleccionventa.Visible = true;
            ldetalleSeleccion.Visible = true;
            bPDFVentas.Visible = true;
        }

        }

    }
