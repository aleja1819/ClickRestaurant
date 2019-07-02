using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Pizza_Express_visual.Services;
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
                        int idR = Convert.ToInt32(Session["rol_user"]);
                        cargarMenu(idR);
                        vBienvenida.Visible = true;
                        mcontenedor.SetActiveView(vBienvenida);
                    }

                }
            }
            catch (Exception)
            {
                Session["name_user"] = "visita.cl";
                login.Visible = true;
            }


            mensaje.Text = "";
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

        protected void Menu_MontoInicial_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vMonto_Inicial);
            uContenido.Update();
        }

        protected void Menu_CartaMenu_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vCarta_menu);
            uContenido.Update();
        }

        protected void Menu_Inventario_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vInventario);
            uContenido.Update();
        }

        protected void Menu_NumeroMesa_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vNumero_mesa);
            uContenido.Update();
        }

        protected void Menu_Proveedores_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vProveedores);
            uContenido.Update();
        }

        protected void Menu_RegistrarProductos_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vRegistrar_producto);
            uContenido.Update();
        }

        protected void Menu_Reportes_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vReportes);
            uContenido.Update();
        }

        protected void Menu_Reservas_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vReservas);
            uContenido.Update();
        }

        protected void Menu_usuarios_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vUsuarios);
            uContenido.Update();
        }

        void cargarMenu(int idRol)
        {

            //PARTE 1

            Services.QueryUsuario queryUsuario = new Services.QueryUsuario();
            List<LinkButton> ListaMenu = new List<LinkButton>();
            ListaMenu.Add(Menu_administracion);
            ListaMenu.Add(Menu_ventas);
            queryUsuario.menu(idRol, ListaMenu);

            mostrar_usuario.Visible = true;
            MostrarLogo.Visible = false;

            Menu_administracion.Visible = true;
            Menu_ventas.Visible = true;
            Menu_home.Visible = true;

        }

        protected void bingresar_login_Click(object sender, EventArgs e)
        {
            try
            {
                Services.QueryUsuario user = new Services.QueryUsuario();
                int[] respuestas = user.validateUser(tnombre.Text.Trim(), tclave.Text.Trim());
                mensaje.CssClass = "text-danger";
                mensaje.Visible = true;
                if (respuestas[0] == 0)
                {
                    mensaje.Visible = true;
                    mensaje.Text = "ERROR DE CONEXION";
                }
                else
                {
                    if (respuestas[1] == 0)
                    {
                        mensaje.Text = "USUARIO NO EXISTE";
                    }
                    else
                    {
                        if (respuestas[2] == 0)
                        {
                            mensaje.Text = "USUARIO BLOQUEADO";
                        }
                        else
                        {
                            //AQUI EL USUARIO PUEDE INGRESAR AL SISTEMA

                            Session["idUser"] = respuestas[4];
                            Session["name_user"] = tnombre.Text;
                            Session["rol_user"] = respuestas[3];


                            //HABILITAR MENUS SEGUN EL ROL DEL USUARIO
                            cargarMenu(respuestas[3]);
                            login.Visible = false;
                            MostrarLogo.Visible = false;

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

        protected void Menu_comanda_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vComanda);
            uContenido.Update();
        }

        protected void Menu_test_Click(object sender, EventArgs e)
        {
            mcontenedor.SetActiveView(vtest);
            uContenido.Update();
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