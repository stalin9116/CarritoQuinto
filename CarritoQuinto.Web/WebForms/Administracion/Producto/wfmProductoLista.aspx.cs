using CarritoQuinto.Web.Logica;
using CarritoQuinto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoQuinto.Web.WebForms.Administracion.Producto
{
    public partial class wfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadProducts();
            }
        }

        private void loadProducts()
        {
            Task<List<TBL_PRODUCTO>> _taskListProducto = Task.Run(() => logicaProducto.getAllProduct());
            _taskListProducto.Wait();
            var _listaProducto = _taskListProducto.Result;
            if (_listaProducto != null && _listaProducto.Count > 0)
            {
                gdvDatosProductos.DataSource = _listaProducto.Select(data => new
                {
                    ID = data.pro_id,
                    CODIGO = data.pro_codigo,
                    NOMBRE = data.pro_nombre,
                    PRECIO_C = data.pro_preciocompra.ToString("0.00"),
                    PRECIO_V = data.pro_precioventa.ToString("0.00"),
                    STOCK_MIN = data.pro_stockminimo,
                    STOCK_MAX = data.pro_stockmaximo,
                    CATEGORIA = data.TBL_CATEGORIA.cat_nombre,
                    ESTADO = data.pro_status
                }).ToList();
                gdvDatosProductos.DataBind();
            }
        }

        protected void gdvDatosProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            string codigo2 = Convert.ToString(e.CommandArgument);
            if (e.CommandName== "Modificar")
            {
                //esto
                Response.Redirect("wfmProductoNuevo.aspx?cod=" + codigo+ "&var="+codigo2);

            }
            else if(e.CommandName == "Eliminar") 
            {
                //esto
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => logicaProducto.getProductXID(int.Parse(codigo)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto!=null)
                {
                    Task<bool> _taskDeleteProduct = Task.Run(() => logicaProducto.deleteProduct(_infoProducto));
                    _taskDeleteProduct.Wait();
                    var result = _taskDeleteProduct.Result;
                    if (result)
                    {
                        loadProducts();
                    }

                }

            }
        }
    }
}