using CarritoQuinto.Web.Logica;
using CarritoQuinto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarritoQuinto.Web.UserControl
{
    public partial class ucCategoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcCargar();
            }
        }

        public DropDownList DropDownList
        {
            get 
            { 
                return DropDownList1; 
            }
            
            set 
            {
                DropDownList1 = value; 
            }
        }


        public void UcCargar()
        {
            Task<List<TBL_CATEGORIA>> _taskCategoria = Task.Run(() => logcaCategoria.getAllCategory());
            _taskCategoria.Wait();
            var listaCategoria = _taskCategoria.Result;

            if (listaCategoria != null && listaCategoria.Count > 0)
            {
                var data = listaCategoria.OrderBy(lista => lista.cat_nombre).ToList();

                data.Insert(0, new TBL_CATEGORIA { cat_nombre = "Seleccione Categoria", cat_id = 0 });
                DropDownList1.DataSource = data;
                DropDownList1.DataTextField = "cat_nombre";
                DropDownList1.DataValueField = "cat_id";
                DropDownList1.DataBind();
            }



        }


    }
}