using CarritoQuinto.Web.Logica;
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
    public partial class wfmCatalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCatalogo();
            }
        }

        private void loadCatalogo()
        {
            try
            {
                Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => logicaProducto.getAllProduct());
                _taskProductos.Wait();
                var listaProducts = _taskProductos.Result;
                DataList1.DataSource = listaProducts.Select(data => new
                {
                    ID = data.pro_id,
                    Nombre = data.pro_nombre,
                    Precio = data.pro_precioventa.ToString("0.00"),
                    URL = data.pro_imagen

                }).ToList();
                DataList1.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName=="Comprar")
            {
                //Encriptar URL
                Response.Redirect("wfmDetalleProducto.aspx?cod="+codigo);
            }
        }
    }
}