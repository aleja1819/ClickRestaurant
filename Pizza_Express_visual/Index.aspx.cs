using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Pizza_Express_visual
{
    public partial class Index : System.Web.UI.Page
    { 


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (!Session["idUser"].Equals("") || !Session["idUser"].Equals(null))
                    {
                        int idRol = Convert.ToInt32(Session["rol_user"]);
                        cargarMenuUsuarios(idRol);
                        vBienvenida.Visible = true;
                        mcontenedor.SetActiveView(vBienvenida);
                    }

                }
            }
            catch (Exception)
            {
                Session["name_user"] = "Usuario no Registrado";
                login.Visible = true;
            }


            ErrorInicioSesion.Text = "";
        }

        protected void login_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            uModal.Update();
        }

        protected void Menu_home_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vBienvenida);
            uContenido.Update();
        }

        protected void Menu_CartaMenu_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vCarta_menu);
            uContenido.Update();
        }

        protected void Menu_Inventario_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vInventario);
            uContenido.Update();
        }


        protected void Menu_Proveedores_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vProveedores);
            uContenido.Update();
        }

        protected void Menu_RegistrarProductos_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vRegistrar_producto);
            uContenido.Update();
        }

        protected void Menu_Reportes_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vReportes);
            uContenido.Update();
        }

        protected void Menu_Reservas_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vReservas);
            uContenido.Update();
        }

        protected void Menu_usuarios_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vUsuarios);
            uContenido.Update();
        }

        protected void Menu_comanda_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vComanda);
            uContenido.Update();
        }

        protected void Menu_Caja_Click(object sender, EventArgs e)
        {
            alerta.Visible = false;
            mcontenedor.SetActiveView(vCaja);
            uContenido.Update();
        }

        void cargarMenuUsuarios(int idRol)
        {

            Services.QueryUsuario queryUsuario = new Services.QueryUsuario();
            List<LinkButton> ListaMenu = new List<LinkButton>();
            ListaMenu.Add(Menu_home);
            ListaMenu.Add(Menu_administracion);
            ListaMenu.Add(Menu_ventas);

            queryUsuario.menu(idRol, ListaMenu);

            mostrar_usuario.Visible = true;
            MostrarLogo.Visible = false;

            login.Visible = false;
            idCerrarSesion.Visible = true;

        }

        protected void bingresar_login_Click(object sender, EventArgs e)
        {
            try
            {
                Services.QueryUsuario user = new Services.QueryUsuario();
                int[] respuestas = user.validateUser(tnombres.Text.Trim(), tclave.Text.Trim());
                ErrorInicioSesion.CssClass = "text-danger";
                ErrorInicioSesion.Visible = true;
                if (respuestas[0] == 0)
                {
                    ErrorInicioSesion.Visible = true;
                    ErrorInicioSesion.Text = "Clave o Usuario Incorrecto";
                }
                else
                {
                    if (respuestas[1] == 0)
                    {
                        ErrorInicioSesion.Text = "Usuario no existe";
                    }
                    else
                    {
                        {
                            //AQUI EL USUARIO PUEDE INGRESAR AL SISTEMA

                            Session["idUser"] = respuestas[4];
                            Session["name_user"] = tnombres.Text;
                            Session["rol_user"] = respuestas[3];


                            //HABILITAR MENUS SEGUN EL ROL DEL USUARIO
                            cargarMenuUsuarios(respuestas[3]);
                            login.Visible = false;
                            MostrarLogo.Visible = false;

                            alerta.Visible = true;
                            alerta.CssClass = "alert alert-primary animated zoomInUp";
                            mensaje3.Text = "USUARIO INGRESADO EXITOSAMENTE.";

                            //CERRAR VENTANA MODAL
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('hide');", true);
                            mcontenedor.SetActiveView(vBienvenida);
                            uModal.Update();
                            uContenido.Update();
                            uBarraMenu.Update();


                        }
                    }

                }
            }

            catch (Exception)
            {

            }
        }

        protected void bCerrarSesion_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();

            Menu_administracion.Visible = false;
            Menu_ventas.Visible = false;
            Menu_home.Visible = false;
            mostrar_usuario.Visible = false;
            component_Bienvenidos.Visible = false;
            login.Visible = true;
            MostrarLogo.Visible = true;

            alerta.Visible = false;
            mcontenedor.SetActiveView(vBienvenida);
            uBarraMenu.Update();
            uContenido.Update();
            uModal.Update();
        }
        protected void Menu_home_Click1(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vBienvenida);
            uContenido.Update();
        }

        
    }
}