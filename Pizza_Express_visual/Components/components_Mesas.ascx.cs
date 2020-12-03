// Importar genéricas
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Importar para comanda y Mesa
using Pizza_Express_visual.Services;
using System.Linq;
using System.Data;
using Pizza_Express_visual.Models;

//Importar para Comanda
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Pizza_Express_visual.Components
{
    public partial class components_Mesas : System.Web.UI.UserControl
    {

        //Conexion con Services
        private QueryMesas accesoMesas = new QueryMesas();
        private QueryComanda accesoComanda = new QueryComanda();
        static List<object> productoDisponible = new List<object>();
        static List<Services.carro> carroCompra = new List<Services.carro>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["envioComanda"] = 0;    // 0 = Primera Vez que se hace click en Generar Ticket Comanda, 1 = Segunda Vez

                volver();
                alertaMesas.Visible = false;
                
                mContenedor.SetActiveView(vMesas);
                uContenido.Update();

                uModalComanda.Update();

                //MOSTRAR LA LISTA DE LOS FORMAS DE PAGO DE LA BASE DE DATOS
                ftipoPago.DataSource = accesoComanda.filtrarTipoPago();
                ftipoPago.DataBind();

                try
                {
                    List<int> listaMesasImpagas = accesoMesas.estadoPagoMesas();                    

                    foreach (var mesa in listaMesasImpagas)
                    {
                        estadoOcupado(mesa);
                    }
                }
                catch{}
            }
            
        }


                                                /***************** Funciones para Mesas ******************/
        private void estadoOcupado(int idMesa)
        {
            switch (idMesa)
            {
                case 1: bMesa1.CssClass = "btn btn-danger"; break;
                case 2: bMesa2.CssClass = "btn btn-danger"; break;
                case 3: bMesa3.CssClass = "btn btn-danger"; break;
                case 4: bMesa4.CssClass = "btn btn-danger"; break;
                case 5: bMesa5.CssClass = "btn btn-danger"; break;
                case 6: bMesa6.CssClass = "btn btn-danger"; break;
                case 7: bMesa7.CssClass = "btn btn-danger"; break;
                case 8: bMesa8.CssClass = "btn btn-danger"; break;
                case 9: bMesa9.CssClass = "btn btn-danger"; break;
                case 10: bMesa10.CssClass = "btn btn-danger"; break;
                case 11: bMesa11.CssClass = "btn btn-danger"; break;
                case 12: bMesa12.CssClass = "btn btn-danger"; break;
                case 13: bMesa13.CssClass = "btn btn-danger"; break;
                case 14: bMesa14.CssClass = "btn btn-danger"; break;
                case 15: bMesa15.CssClass = "btn btn-danger"; break;
                case 16: bMesa16.CssClass = "btn btn-danger"; break;
                case 17: bMesa17.CssClass = "btn btn-danger"; break;
                case 18: bMesa18.CssClass = "btn btn-danger"; break;
            }
        }

        private void estadoDesocupado(int idMesa)
        {
            switch (idMesa)
            {
                case 1: bMesa1.CssClass = "btn btn-success"; break;
                case 2: bMesa2.CssClass = "btn btn-success"; break;
                case 3: bMesa3.CssClass = "btn btn-success"; break;
                case 4: bMesa4.CssClass = "btn btn-success"; break;
                case 5: bMesa5.CssClass = "btn btn-success"; break;
                case 6: bMesa6.CssClass = "btn btn-success"; break;
                case 7: bMesa7.CssClass = "btn btn-success"; break;
                case 8: bMesa8.CssClass = "btn btn-success"; break;
                case 9: bMesa9.CssClass = "btn btn-success"; break;
                case 10: bMesa10.CssClass = "btn btn-success"; break;
                case 11: bMesa11.CssClass = "btn btn-success"; break;
                case 12: bMesa12.CssClass = "btn btn-success"; break;
                case 13: bMesa13.CssClass = "btn btn-success"; break;
                case 14: bMesa14.CssClass = "btn btn-success"; break;
                case 15: bMesa15.CssClass = "btn btn-success"; break;
                case 16: bMesa16.CssClass = "btn btn-success"; break;
                case 17: bMesa17.CssClass = "btn btn-success"; break;
                case 18: bMesa18.CssClass = "btn btn-success"; break;
            }
        }

        protected void cargaDatosGrid(int nMesa)
        {
            /* Recibo la lista de pedidos por mesa 142, 143*/
            List<int> listaPedidosMesa = accesoMesas.estadoPagoMesaSeleccionada(nMesa);

            switch (listaPedidosMesa.Count)
            {
                case 0:
                    /* Si no se han realizado pedidos para esta mesa */
                    mContenedor.SetActiveView(vComanda);
                    uContenido.Update();
                    break;

                default:
                    /* La mesa tiene 1 o más pedidos */

                    Session["precioTotal"] = accesoMesas.precioTotal(listaPedidosMesa);
                    List<object> pedidosPendientes = accesoMesas.pedidosPendientes(nMesa);

                    gridUnPedido.DataSource = pedidosPendientes;
                    gridUnPedido.DataBind();

                    mContenedor.SetActiveView(vPendiente);
                    uContenido.Update();
                    break;
            }
        }


        // Enviar Comanada a la bd y cambiar de color la mesa
        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["envioComanda"]) == 0)
            {
                if (ltotal.Text == "Total a pagar $0")
                {
                    /* No se ha seleccionado ningún pedido */
                    alerta.Visible = true;
                    alerta.CssClass = "alert alert-danger animated zoomInUp";
                    mensaje3.Text = "DEBE AGREGAR POR LO MENOS UN PEDIDO";
                }
                else
                {

                    /* Guarda en la bd y vuelve a la vista*/

                    /* Inserta en la tabla ComandaMesa para crear el numero de comanda */
                    int codigo_usuario = Convert.ToInt32(Session["idUser"]);
                    int idMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
                    int idEstadoPago = 2;
                    int precio_total = Convert.ToInt32(Session["suma"]);
                    int idDetalleCaja = 1; // Debe ser obtenido desde una variable de sesion
                    DateTime fechaHoy = DateTime.Now;

                    /* Guarda una nueva comanda asignada a la mesa en la tabla ComandaMesa de la base de datos*/
                    accesoComanda.addComandaMesa(new Models.ComandaMesa
                    {
                        idMesa = idMesa,
                        idEstadoPago = idEstadoPago,
                        fecha = fechaHoy,
                        precio_total = precio_total,
                        codigo_usuario = codigo_usuario,
                        id_DetalleCaja = idDetalleCaja
                    });

                    /*Toma el codigo de la comanda recien creada*/
                    int codigo_comanda = accesoComanda.comandaCreada(fechaHoy);
                    Session["codigo_comanda"] = codigo_comanda;

                    /* Cambiar el estado de la mesa a 2 ocupado en la tabla Mesa de la base de datos */
                    accesoMesas.cambiarEstadoMesa(idMesa, idEstadoPago);
                    estadoOcupado(idMesa);

                    /* Tengo cuantos productos ha seleccionado */
                    int filas = idCargarSeleccion.Rows.Count;

                    /* Asigna datos a la lista que serán cargados en la base de datos */
                    List<string> listaPedidosMesa = new List<String>(63);
                    List<string> pedidosMesaX = new List<string>(8);

                    listaPedidosMesa.Add(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
                    listaPedidosMesa.Add(codigo_comanda + "");
                    listaPedidosMesa.Add(Session["suma"] + "");

                    for (int i = 0; i < filas; i++)
                    {
                        string nombreMenu = idCargarSeleccion.Rows[i].Cells[2].Text;
                        string codigoMenu = idCargarSeleccion.Rows[i].Cells[0].Text;
                        int cantidad = Convert.ToInt32(idCargarSeleccion.Rows[i].Cells[1].Text);
                        int subtotal = Convert.ToInt32(idCargarSeleccion.Rows[i].Cells[3].Text);
                        int pMenu = subtotal / cantidad;

                        listaPedidosMesa.Add(nombreMenu);
                        listaPedidosMesa.Add(cantidad + "");

                        pedidosMesaX.Add(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
                        pedidosMesaX.Add(codigo_comanda + "");
                        pedidosMesaX.Add(idEstadoPago + "");
                        pedidosMesaX.Add(codigoMenu);
                        pedidosMesaX.Add(nombreMenu);
                        pedidosMesaX.Add(pMenu + "");
                        pedidosMesaX.Add(cantidad + "");
                        pedidosMesaX.Add(subtotal + "");

                        /* Guarda en la tabla temporal el pedidosMesaX según la mesa seleccionada */
                        int IdMesaPedido = Convert.ToInt32(listaPedidosMesa[0]);

                        accesoComanda.addPedidosActivos(new Models.PedidosActivos
                        {
                            idMesa = Convert.ToInt32(pedidosMesaX[0]),
                            codigo_comanda = Convert.ToInt32(pedidosMesaX[1]),
                            idEstadoPago = Convert.ToInt32(pedidosMesaX[2]),
                            codigo_menu = Convert.ToInt32(pedidosMesaX[3]),
                            nombre_menu = pedidosMesaX[4],
                            precio_menu = Convert.ToInt32(pedidosMesaX[5]),
                            cantidad = Convert.ToInt32(pedidosMesaX[6]),
                            subtotal = Convert.ToInt32(pedidosMesaX[7])

                        });

                        /* Guarda en la tabla definitiva de los reportesVentas */
                        accesoComanda.addReportesVentas(new Models.ReportesVentas
                        {
                            idMesa = Convert.ToInt32(pedidosMesaX[0]),
                            codigo_comanda = Convert.ToInt32(pedidosMesaX[1]),
                            codigo_menu = Convert.ToInt32(pedidosMesaX[3]),
                            nombre_menu = pedidosMesaX[4],
                            precio_menu = Convert.ToInt32(pedidosMesaX[5]),
                            cantidad = Convert.ToInt32(pedidosMesaX[6]),
                        });

                        pedidosMesaX.Clear();
                    }




                    for (int i = (filas + 3); i <= 63; i++)
                    {
                        listaPedidosMesa.Add(null);
                    }

                    /* Guarda en la tabla DetalleMesaPedido de la base de datos*/
                    accesoComanda.addDetalleMesaPedido(new Models.Detalle_Mesa_Pedido
                    {
                        idMesa = Convert.ToInt32(listaPedidosMesa[0]),
                        codigo_comanda = Convert.ToInt32(listaPedidosMesa[1]),
                        precio_total = Convert.ToInt32(listaPedidosMesa[2]),
                        menu1 = listaPedidosMesa[3],
                        menu2 = listaPedidosMesa[5],
                        menu3 = listaPedidosMesa[7],
                        menu4 = listaPedidosMesa[9],
                        menu5 = listaPedidosMesa[11],
                        menu6 = listaPedidosMesa[13],
                        menu7 = listaPedidosMesa[15],
                        menu8 = listaPedidosMesa[17],
                        menu9 = listaPedidosMesa[19],
                        menu10 = listaPedidosMesa[21],
                        menu11 = listaPedidosMesa[23],
                        menu12 = listaPedidosMesa[25],
                        menu13 = listaPedidosMesa[27],
                        menu14 = listaPedidosMesa[29],
                        menu15 = listaPedidosMesa[31],
                        menu16 = listaPedidosMesa[33],
                        menu17 = listaPedidosMesa[35],
                        menu18 = listaPedidosMesa[37],
                        menu19 = listaPedidosMesa[39],
                        menu20 = listaPedidosMesa[41],
                        menu21 = listaPedidosMesa[43],
                        menu22 = listaPedidosMesa[45],
                        menu23 = listaPedidosMesa[47],
                        menu24 = listaPedidosMesa[49],
                        menu25 = listaPedidosMesa[51],
                        menu26 = listaPedidosMesa[53],
                        menu27 = listaPedidosMesa[55],
                        menu28 = listaPedidosMesa[57],
                        menu29 = listaPedidosMesa[59],
                        menu30 = listaPedidosMesa[61],
                        cantidad_m1 = Convert.ToInt32(listaPedidosMesa[4]),
                        cantidad_m2 = Convert.ToInt32(listaPedidosMesa[6]),
                        cantidad_m3 = Convert.ToInt32(listaPedidosMesa[8]),
                        cantidad_m4 = Convert.ToInt32(listaPedidosMesa[10]),
                        cantidad_m5 = Convert.ToInt32(listaPedidosMesa[12]),
                        cantidad_m6 = Convert.ToInt32(listaPedidosMesa[14]),
                        cantidad_m7 = Convert.ToInt32(listaPedidosMesa[16]),
                        cantidad_m8 = Convert.ToInt32(listaPedidosMesa[18]),
                        cantidad_m9 = Convert.ToInt32(listaPedidosMesa[20]),
                        cantidad_m10 = Convert.ToInt32(listaPedidosMesa[22]),
                        cantidad_m11 = Convert.ToInt32(listaPedidosMesa[24]),
                        cantidad_m12 = Convert.ToInt32(listaPedidosMesa[26]),
                        cantidad_m13 = Convert.ToInt32(listaPedidosMesa[28]),
                        cantidad_m14 = Convert.ToInt32(listaPedidosMesa[30]),
                        cantidad_m15 = Convert.ToInt32(listaPedidosMesa[32]),
                        cantidad_m16 = Convert.ToInt32(listaPedidosMesa[34]),
                        cantidad_m17 = Convert.ToInt32(listaPedidosMesa[36]),
                        cantidad_m18 = Convert.ToInt32(listaPedidosMesa[38]),
                        cantidad_m19 = Convert.ToInt32(listaPedidosMesa[40]),
                        cantidad_m20 = Convert.ToInt32(listaPedidosMesa[42]),
                        cantidad_m21 = Convert.ToInt32(listaPedidosMesa[44]),
                        cantidad_m22 = Convert.ToInt32(listaPedidosMesa[46]),
                        cantidad_m23 = Convert.ToInt32(listaPedidosMesa[48]),
                        cantidad_m24 = Convert.ToInt32(listaPedidosMesa[50]),
                        cantidad_m25 = Convert.ToInt32(listaPedidosMesa[52]),
                        cantidad_m26 = Convert.ToInt32(listaPedidosMesa[54]),
                        cantidad_m27 = Convert.ToInt32(listaPedidosMesa[56]),
                        cantidad_m28 = Convert.ToInt32(listaPedidosMesa[58]),
                        cantidad_m29 = Convert.ToInt32(listaPedidosMesa[60]),
                        cantidad_m30 = Convert.ToInt32(listaPedidosMesa[62])
                    });

                    mContenedor.SetActiveView(vMesas);
                    uContenido.Update();

                    btnGenerarPDF.Enabled = false;

                    Session["envioComanda"] = 1;

                    generarPDF();

                    volver();

                }
            }
            else
            {
                alerta.Visible = true;
                alerta.CssClass = "alert alert-danger animated zoomInUp";
                mensaje3.Text = "El Ticket ya ha sido generado, porfavor, presione en 'Finalizar Pedido Actual' para seleccionar otra mesa, o presione en 'Limpiar Pedido Actual' para agregar un nuevo pedido a esta misma mesa";
            }
        }

        // Identifica las mesas y los pedidos de estas para ser cargadas al grid
        protected void bMesa1_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "1";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa2_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "2";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }     
        protected void bMesa3_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "3";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa4_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "4";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa5_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "5";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa6_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "6";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa7_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "7";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa8_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "8";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa9_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "9";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa10_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "10";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa11_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "11";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa12_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "12";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa13_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "13";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa14_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "14";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa15_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "15";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa16_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "16";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa17_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "17";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }
        protected void bMesa18_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"] = "18";
            int nMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            alertaMesas.Visible = false;

            cargaDatosGrid(nMesa);
        }


                                        /***************** Funciones para Comandas ******************/
      
        void LimpiarCarro()
        {
            carroCompra.Clear();
        }
        private void volver()
        {
            carroCompra.Clear();
            idCargarSeleccion.DataSource = carroCompra;
            idCargarSeleccion.DataBind();            
            calcularTotal();
        }
        private void calcularTotal()
        {
            int suma = 0;
            foreach (var item in carroCompra)
            {
                suma += item.precio_M;
            }

            ltotal.Text = "Total a pagar $" + suma;
            Session["suma"] = suma;
        }
        // Botones de categorias de Menu
        protected void idGrande_Click(object sender, EventArgs e)
        {
            try
            {
                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
                alerta.Visible = false;
            }
            catch (Exception)
            {

            }
        }
        protected void idMediana_Click(object sender, EventArgs e)
        {
            try
            {
                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 2);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
                alerta.Visible = false;
            }
            catch (Exception)
            {

            }
        }
        protected void idIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                productoDisponible = accesoComanda.filtrarCategoriaMenu(2, 3);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
            }
            catch (Exception)
            {

            }
        }
        protected void idQueso_Click(object sender, EventArgs e)
        {
            try
            {
                productoDisponible = accesoComanda.filtrarCategoriaMenu(5, 1);
                idMostrarMenu.DataSource = productoDisponible;
                idMostrarMenu.DataBind();
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
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
                alerta.Visible = false;
            }
            catch (Exception)
            {

            }
        }
        protected void idLicores_Click(object sender, EventArgs e)
        {
            // por que no tiene try catch?
            productoDisponible = accesoComanda.filtrarCategoriaMenu(13, 1);
            idMostrarMenu.DataSource = productoDisponible;
            idMostrarMenu.DataBind();
            alerta.Visible = false;
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
        protected void btnpagos_Click(object sender, EventArgs e)
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
        private void eShowPdf(String strS)
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

        /* NO se utiliza por el momento*/
        private void generarPDF()
        {
            // Generar Pdf
            var doc = new Document(PageSize.A5);
            string path = Server.MapPath("Files");
            Random r = new Random();
            string nombre = "_" + r.Next(1, 500) + "_" + DateTime.Now.Second;
            PdfWriter pdfWrite = PdfWriter.GetInstance(doc, new FileStream(path + nombre, FileMode.OpenOrCreate));

            // Carga Imagen
            doc.Open();
            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(path + "/PIZZZA.jpg");
            tif.ScalePercent(13f, 9f);
            tif.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            doc.Add(tif);

            // Carga Título "Cocina"
            iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 18, iTextSharp.text.Font.BOLDITALIC, BaseColor.RED);
            Paragraph paragraph = new Paragraph(@"COCINA", verdana);
            paragraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraph);

            // Carga Fecha y hora
            Paragraph esp = new Paragraph(" ");
            Paragraph paragraph2 = new Paragraph("Fecha: " + DateTime.Now.ToString());
            Random m = new Random();
            // Carga numero mesa
            Paragraph mesa = new Paragraph("N° Mesa: " + System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            // Carga Garzón
            Paragraph garzon = new Paragraph("Garzón: GARZÓN PIZZERIA");
            Random c = new Random();
            // Carga comanda
            Paragraph comanda = new Paragraph("Comanda: " + Session["codigo_comanda"]);
            paragraph2.Alignment = Element.ALIGN_LEFT;
            paragraph2.PaddingTop = 1;
            doc.Add(esp);
            doc.Add(paragraph2);
            doc.Add(mesa);
            doc.Add(garzon);
            doc.Add(comanda);

            Paragraph paragraph3 = new Paragraph();
            Paragraph espacio = new Paragraph(" ");
            paragraph3.PaddingTop = 1;
            doc.Add(paragraph3);
            doc.Add(espacio);

            // Genera la tabla
            PdfPTable table = new PdfPTable(2);
            PdfPCell cell = new PdfPCell();
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.BorderColor = BaseColor.BLACK;
            cell.BackgroundColor = BaseColor.RED;

            // Carga los títulos de la tabla
            iTextSharp.text.Font letraBlanca = FontFactory.GetFont("Verdana", 12, iTextSharp.text.Font.BOLDITALIC, BaseColor.WHITE);
            cell.Phrase = new Phrase("Cantidad", letraBlanca);
            table.AddCell(cell);
            cell.Phrase = new Phrase("Detalle", letraBlanca);
            table.AddCell(cell);

            // Carga los elementos de pedido
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

            volver();

        }

        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + strS +".pdf");
            Response.TransmitFile(strS);
            //Response.End();
            Response.Flush();
            Response.Clear();

        }

        /***************** Funciones para Modal Pago ******************/
        private void calcularTotalPago()
        {
            /* Calcula el total a pagar en el modal */
            int pagoTotalInicial = Convert.ToInt32(Session["precioTotal"]);
            int pagoTotal;
            
            int propina = (tpropina.Text == "") ? propina = 0 : propina = Convert.ToInt32(tpropina.Text);
            int descuento = (tdescuento.Text == "") ? descuento = 0 : descuento = Convert.ToInt32(tdescuento.Text);
                       
            pagoTotal = (pagoTotalInicial + propina) - descuento;
            LTotalCancelar.Text = "" + pagoTotal;
        }

        protected void PagarModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalComanda", "$('#myModalComanda').modal();", true);
            uModalComanda.Update();
            int suma = Convert.ToInt32(Session["precioTotal"]);
            LTotalCancelar.Text = ""+suma;
        }
       
        protected void tpropina_TextChanged(object sender, EventArgs e)
        {
            calcularTotalPago();
        }

        protected void tdescuento_TextChanged(object sender, EventArgs e)
        {
            calcularTotalPago();
        }

        private void MostrarError(TextBox t, Label l, int r)
        {

            if (r == 0)
            {
                t.CssClass = "form-control is-invalid";
                l.CssClass = "invalid-feedback";
            }
            else
            {
                t.CssClass = "form-control is-valid";
                l.CssClass = "valid-feedback";
            }
        }
        private bool validaCampos()
        {

            bool correcto = true;

            if (tpropina.Text.Equals(""))
            {
                MostrarError(tpropina, validar_tpropina, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tpropina, validar_tpropina, 1);
            }
            if (tdescuento.Text.Equals(""))
            {
                MostrarError(tdescuento, validar_tdescuento, 0);
                correcto = false;
            }
            else
            {
                MostrarError(tdescuento, validar_tdescuento, 1);
            }
                return correcto;
            }
        private void limpiarTodo(int op)
        {

            if (op == 1)
            {
                ttransferencia.Text = "";
                tpropina.Text = "";
                tdescuento.Text = "";
                ftipoPago.SelectedIndex = 0;
            }
            else
            {
                ttransferencia.Text = "";
                tpropina.Text = "";
                tdescuento.Text = "";
                ftipoPago.SelectedIndex = 0;

            }
        }

        /* Genera el pago de los pedidos que existan*/
        protected void idregistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (validaCampos() == false)
                {

                }
                else
                {
                    int idtipoPago = Convert.ToInt32(ftipoPago.SelectedItem.Value);
                    int idMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
                    int descuento = Convert.ToInt32(tdescuento.Text);
                    int propina = Convert.ToInt32(tpropina.Text);
                    int transferencia = Convert.ToInt32(ttransferencia.Text);
                    int idEstadoPago = 1;


                    List<int> pedidosAPagar = accesoMesas.pedidosAPagar(idMesa);

                    List<int> comandasImpagas = accesoMesas.estadoPagoMesaSeleccionada(idMesa);

                    List<int> pedidosPagados = accesoMesas.pagarPedidos(pedidosAPagar);


                    accesoMesas.cambiarEstadoMesa(idMesa, idEstadoPago);

                    accesoMesas.cambiarEstadoPagoComanda(comandasImpagas, idEstadoPago);

                    estadoDesocupado(idMesa);

                    //accesoMesas.estadoPagoMesas();

                    //GUARDAR LOS DATOS EN LA LISTA         // ============== REVISAR ==================== //
                    foreach (int pedido in pedidosPagados)
                    {

                        accesoComanda.addPago(new Models.Detalle_Pago
                        {
                            codigo_tipoPago = idtipoPago,
                            numeroTransaccion = transferencia, // Debe permitir ingresar el numero de voucher emitido por la maquina redcompra
                            propina = propina,
                            descuento = descuento,
                            codigo_comanda = pedido
                        });
                    }

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalComanda", "$('#myModalComanda').modal('hide');", true);
                    uModalComanda.Update();

                    volver();
                    mContenedor.SetActiveView(vMesas);
                    uContenido.Update();

                    limpiarTodo(2);

                    alertaMesas.Visible = true;
                    alertaMesas.CssClass = "alert alert-primary animated zoomInUp";
                    mensajeMesas.Text = "PAGO AGREGADO CON EXITO.";

                }
            }
            catch (Exception)
            {
                alertaMesas.Visible = true;
                alertaMesas.CssClass = "alert alert-danger animated zoomInUp";
                mensajeMesas.Text = "PAGO NO REGISTRADO.";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            volver();
            int idMesa = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["mesaSeleccionada"]);
            mContenedor.SetActiveView(vMesas);
            uContenido.Update();
            

            if(Convert.ToInt32(Session["envioComanda"]) == 0)
            {
                alertaMesas.Visible = true;
                alertaMesas.CssClass = "alert alert-danger animated zoomInUp";
                alerta.Visible = false;
                mensajeMesas.Text = "EL PEDIDO ACTUAL, SE HA INTERRUMPIDO ";
            }
            else
            {
                estadoOcupado(idMesa);
                alertaMesas.Visible = true;
                alertaMesas.CssClass = "alert alert-primary animated zoomInUp";
                alerta.Visible = false;
                mensajeMesas.Text = "EL PEDIDO ACTUAL HA FINALIZADO EXITOSAMENTE";
            }

            Session["envioComanda"] = 0;
        }

        protected void gridCargaPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridUnPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Nuevo_Pedido_Click(object sender, EventArgs e)
        {
            mContenedor.SetActiveView(vComanda);
            uContenido.Update();
        }

        protected void btnVolverMesas_Click(object sender, EventArgs e)
        {
            volver();
            mContenedor.SetActiveView(vMesas);
            uContenido.Update();
            Session["envioComanda"] = 0;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (ltotal.Text != "Total a pagar $0")
            {
                volver();
                alerta.Visible = true;
                alerta.CssClass = "alert alert-primary animated zoomInUp";
                mensaje3.Text = "PUEDE REALIZAR UN NUEVO PEDIDO A ESTA MISMA MESA";
                Session["envioComanda"] = 0;
            }
            else
            {
                alerta.Visible = false;
            }
        }
    }
}