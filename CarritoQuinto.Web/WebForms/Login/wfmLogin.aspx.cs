using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarritoQuinto.Web.Logica;
using CarritoQuinto.Web.Models;

namespace CarritoQuinto.Web.WebForms.Login
{
    public partial class wfmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtuser.Text.TrimStart().TrimEnd();
                string password = txtpassword.Text;

                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                {
                    TBL_USUARIO _infoUsuario = new TBL_USUARIO();
                    var _taskUser = Task.Run(() => logicaUsuario.getUserXLogin(user, password));
                    _taskUser.Wait();
                    _infoUsuario = _taskUser.Result;
                    if (_infoUsuario != null)
                    {
                        Response.Redirect("~/WebForms/Administracion/wfmProductos.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario o clave incorrecta');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Usuario o clave incorrecta');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error comunicacion con el server');</script>");
            }
        }
    }
}