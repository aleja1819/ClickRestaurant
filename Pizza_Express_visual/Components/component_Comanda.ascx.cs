using iTextSharp.text;
using iTextSharp.text.pdf;
using Pizza_Express_visual.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Pizza_Express_visual.Components
{

    public partial class component_Comanda : System.Web.UI.UserControl
    {


        QueryComanda accesoComanda = new QueryComanda();
        static List<object> productoDisponible = new List<object>();
        static List<Services.carro> carroCompra = new List<Services.carro>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carroCompra.Clear();

                uModalComanda.Update();
            }
        }

        void LimpiarCarro()
        {
            carroCompra.Clear();
        }


        private void calcularTotal()
        {
            int suma = 0;
            foreach (var item in carroCompra)
            {
                suma += item.precio_M;
            }
            ltotal.Text = "Total a pagar $" + suma;
        }
        protected void idMostrarMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("idselected"))
            {
                string codigoMenu = "";
                string nombreMenu = "";
                string precioMenu = "";
                string ingredientes = "";

                try
                {
                    codigoMenu = idMostrarMenu.Rows[fila].Cells[0].Text;
                    nombreMenu = idMostrarMenu.Rows[fila].Cells[1].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    precioMenu = idMostrarMenu.Rows[fila].Cells[2].Text.Replace("$", "").Replace(".", "");
                    ingredientes = idMostrarMenu.Rows[fila].Cells[4].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");

                    int codM = Convert.ToInt32(codigoMenu);
                    int precio = Convert.ToInt32(precioMenu);
                    //AGREGAR PRODUCTO AL CARRO
                    carro carro_compra = new carro();
                    carro_compra = carroCompra.First(p => p.codigo_M == codM);
                    carroCompra[carroCompra.IndexOf(carro_compra)].cantidad += 1;
                    carroCompra[carroCompra.IndexOf(carro_compra)].precio_M += precio;

                    idCargarSeleccion.DataSource = carroCompra;
                    idCargarSeleccion.DataBind();

                }
                catch (Exception)
                {

                    int codM = Convert.ToInt32(codigoMenu);
                    int precioM = Convert.ToInt32(precioMenu);

                    carroCompra.Add(new carro { codigo_M = codM, nombre_M = nombreMenu, precio_M = precioM, ingre_M = ingredientes, cantidad = 1 });

                }
                finally
                {
                    idCargarSeleccion.DataSource = carroCompra;
                    idCargarSeleccion.DataBind();
                    codigoMenu = "";

                }
                calcularTotal();
            }
        }

        protected void tabGrande_Click(object sender, EventArgs e)
        {

            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void tabmediana_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 2);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void tabindividual_Click(object sender, EventArgs e)
        {

            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 3);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idTablas_Click(object sender, EventArgs e)
        {

            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(3, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idsandiwch_Click(object sender, EventArgs e)
        {

            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(4, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {
            }

        }

        protected void idPicadillo_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(5, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idPlato_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(6, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idAgregado_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(9, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idEnsalda_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(10, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idVinos_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(12, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idBebidas_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(7, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idJugos_Click(object sender, EventArgs e)
        {
            try
            {

                productoDisponible = accesoComanda.filtrarCategoriaMenu(11, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void idLicores_Click(object sender, EventArgs e)
        {
            productoDisponible = accesoComanda.filtrarCategoriaMenu(13, 1);
            idMostrarMenu.DataSource = productoDisponible;
            idMostrarMenu.DataBind();
        }
        protected void idCargarSeleccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("ideditar"))
            {
                string codigoMenu = "";
                string nombre_menu = "";
                string precio_Menu = "";


                try
                {

                    codigoMenu = idCargarSeleccion.Rows[fila].Cells[0].Text;
                    nombre_menu = idCargarSeleccion.Rows[fila].Cells[1].Text.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#241;", "ñ").Replace(".", "");
                    precio_Menu = idCargarSeleccion.Rows[fila].Cells[3].Text.Replace("$", "").Replace(".", "");

                    int codM = Convert.ToInt32(codigoMenu);
                    int precio = Convert.ToInt32(precio_Menu);
                    carro carro_comp = new carro();
                    carro_comp = carroCompra.First(p => p.codigo_M == codM);

                    if (carro_comp.cantidad > 1)
                    {


                        //restar stock
                        int cantidadActual = carro_comp.cantidad;
                        int precioActual = carro_comp.precio_M;
                        int precioUnitario = (carro_comp.precio_M / carro_comp.cantidad);

                        carroCompra[carroCompra.IndexOf(carro_comp)].cantidad = cantidadActual - 1;
                        carroCompra[carroCompra.IndexOf(carro_comp)].precio_M = precioActual - precioUnitario;



                    }
                    else
                    {

                        carroCompra.Remove(carro_comp);
                    }
                    idCargarSeleccion.DataSource = carroCompra;
                    idCargarSeleccion.DataBind();
                    calcularTotal();
                }
                catch (Exception ex)
                {
                    string ms = ex.ToString();
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            carroCompra.Clear();
            idCargarSeleccion.DataSource = carroCompra;
            idCargarSeleccion.DataBind();
            calcularTotal();

        }

        private void agregarComanda(int numeroMesa)
        {

        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {    
            
            // Cambiar el color de la mesa

            string mesaSeleccionada = System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]+"";

            switch (mesaSeleccionada)
            {
                case "mesa1":
                    //
                    agregarComanda(1);

                    break;
                case "mesa2":

                    break;

                
            }


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
            foreach (var regist in carroCompra)
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
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

        protected void btnpago_Click(object sender, EventArgs e)
        {


            int id = Convert.ToInt32(Session["idUser"]);
            accesoComanda.addcomanda(

                carroCompra, 3, 4
            );

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

            iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 11, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED);
            Paragraph paragraph = new Paragraph(@"PIZZA EXPRESS", verdana);
            paragraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraph);

            Paragraph espacio = new Paragraph(" ");
            espacio.Alignment = Element.ALIGN_LEFT;
            doc.Add(espacio);

            iTextSharp.text.Font verda = FontFactory.GetFont("Verdana", 11, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK);
            Paragraph direccion = new Paragraph(@"Maipu #380 Linares", verda);
            Paragraph telefono = new Paragraph(@"Telefóno  (73) 222101", verda);
            direccion.Alignment = Element.ALIGN_CENTER;
            telefono.Alignment = Element.ALIGN_CENTER;
            doc.Add(direccion);
            doc.Add(telefono);

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

            iTextSharp.text.Font letra = FontFactory.GetFont("Verdana", 11, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED);
            Paragraph titulo = new Paragraph(@"DETALLE MESA", letra);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            Paragraph paragraph3 = new Paragraph(" ");
            paragraph3.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraph3);

            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BorderColor = BaseColor.BLACK;
            cell.BackgroundColor = BaseColor.RED;

            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.BOLDITALIC, BaseColor.WHITE);
            cell.Phrase = new Phrase("Cantidad", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Articulo", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Precio", letraBlanca);
            table.AddCell(cell);


            PdfPCell cell0 = new PdfPCell();
            foreach (var regist in carroCompra)
            {
                cell0.Phrase = new Phrase(regist.cantidad.ToString());
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.nombre_M);
                table.AddCell(cell0);

                cell0.Phrase = new Phrase(regist.precio_M.ToString());
                table.AddCell(cell0);

            }

            doc.Add(table);

            Paragraph subtotal = new Paragraph(ltotal.Text);
            Paragraph desc = new Paragraph("Dscto $" + 0);
            Paragraph Propina = new Paragraph("Propina $" + 0);
            Paragraph pagarT = new Paragraph(ltotal.Text);
            subtotal.Alignment = Element.ALIGN_RIGHT;
            desc.Alignment = Element.ALIGN_RIGHT;
            Propina.Alignment = Element.ALIGN_RIGHT;
            pagarT.Alignment = Element.ALIGN_RIGHT;
            paragraph2.PaddingTop = 1;
            doc.Add(subtotal);
            doc.Add(desc);
            doc.Add(Propina);
            doc.Add(pagarT);

            Paragraph noVali = new Paragraph("NO VALIDO COMO BOLETA");
            noVali.Alignment = Element.ALIGN_CENTER;
            doc.Add(noVali);

            doc.Close();
            LimpiarCarro();
            eShowPdf((path + nombre));



        }

        //  protected void PagarModal_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalComanda", "$('#myModalComanda').modal();", true);
        //    uModalComanda.Update();
        //}
        private void eShowPdf(string strS)
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




