using CarritoQuinto.Web.Logica.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoQuinto.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Carrito"] == null)
                {
                    List<clsCarrito> _listCarrito = new List<clsCarrito>();
                    Session["Carrito"] = _listCarrito;
                }
                else
                {
                    List<clsCarrito> _listCarrito = new List<clsCarrito>();
                    _listCarrito = (List<clsCarrito>)Session["Carrito"];
                    if (_listCarrito.Count > 0 && _listCarrito != null)
                    {
                        lblContador.Text = _listCarrito.Count.ToString();
                    }

                }
            }
        }
    }
}