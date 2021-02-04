using CarritoQuinto.Web.Logica;
using CarritoQuinto.Web.Logica.objetos;
using CarritoQuinto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoQuinto.Web.WebForms.Public
{
    public partial class wfmDetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int idProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProucto(idProducto);

                }
            }
        }

        private void loadProucto(int idProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => logicaProducto.getProductXID(idProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                imgProducto.ImageUrl = _infoProducto.pro_imagen;
                lblNombre.Text = _infoProducto.pro_nombre;
                lblDescripcion.Text = _infoProducto.pro_descripcion;
                lblPrecio.Text = _infoProducto.pro_precioventa.ToString("0.00");
            }
        }

        protected void btnComprar_Click(object sender, ImageClickEventArgs e)
        {
            List<clsCarrito> _listCarrito = new List<clsCarrito>();
            _listCarrito = (List<clsCarrito>)Session["Carrito"];

            clsCarrito _infoProducto = new clsCarrito();
            _infoProducto.cantidadProducto = int.Parse(txtCantidad.Text);
            _listCarrito.Add(_infoProducto);

            Session["Carrito"] = _listCarrito;
            Response.Redirect("wfmCatalogo.aspx",true);


        }
    }
}