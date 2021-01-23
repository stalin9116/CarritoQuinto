using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarritoQuinto.Web.Logica;
using CarritoQuinto.Web.Models;

namespace CarritoQuinto.Web.WebForms.Administracion.Producto
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {

                    int codProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProduct(codProducto);

                    if (Request["var"] != null)
                    {
                        int codProducto2 = Convert.ToInt32(Request["var"].ToString());
                        loadProduct(codProducto);
                    }
                    ;
                }

            }
        }

        private void loadProduct(int codProduct)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var taskProducto = Task.Run(() => logicaProducto.getProductXID(codProduct));
            taskProducto.Wait();
            _infoProducto = taskProducto.Result;
            if (_infoProducto != null)
            {
                lblId.Text = _infoProducto.pro_id.ToString();
                txtCodigo.Text = _infoProducto.pro_codigo;
                UC_Categoria1.DropDownList.SelectedValue = _infoProducto.cat_id.ToString();
                txtNombre.Text = _infoProducto.pro_nombre;
                txtDescripcion.Text = _infoProducto.pro_descripcion;
                txtPrecioCompra.Text = _infoProducto.pro_preciocompra.ToString("0.00");
                txtPrecioVenta.Text = _infoProducto.pro_precioventa.ToString("0.00");
                txtStockMinimo.Text = _infoProducto.pro_stockminimo.ToString();
                txtStockMaximo.Text = _infoProducto.pro_stockmaximo.ToString();

            }
        }



        //private void loadCategoria()
        //{
        //    Task<List<TBL_CATEGORIA>> _taskCategoria = Task.Run(() => logcaCategoria.getAllCategory());
        //    _taskCategoria.Wait();
        //    var listaCategoria = _taskCategoria.Result;

        //    if (listaCategoria != null && listaCategoria.Count > 0)
        //    {
        //        var data = listaCategoria.OrderBy(lista => lista.cat_nombre).ToList();

        //        data.Insert(0, new TBL_CATEGORIA { cat_nombre = "Seleccione Categoria", cat_id = 0 });
        //        ddlCategoria.DataSource = data;
        //        ddlCategoria.DataTextField = "cat_nombre";
        //        ddlCategoria.DataValueField = "cat_id";
        //        ddlCategoria.DataBind();
        //    }

        //}


        protected void imgbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            save();
        }

        protected void ImageRegresar_Click(object sender, ImageClickEventArgs e)
        {

        }

        private void newProduct()
        {
            lblId.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockMaximo.Text = "";
            txtStockMinimo.Text = "";
            UC_Categoria1.DropDownList.SelectedIndex = 0;
        }

        protected void imgbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }

        private void save()
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                updateProduct();
            }
            else
            {
                saveProduct();
            }
        }



        private void saveProduct()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                //_infoProducto.cat_id = Convert.ToInt16(ddlCategoria.SelectedValue);
                _infoProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                _infoProducto.pro_codigo = txtCodigo.Text;
                _infoProducto.pro_nombre = txtNombre.Text.ToUpper();
                _infoProducto.pro_descripcion = txtDescripcion.Text.ToUpper();
                _infoProducto.pro_stockminimo = int.Parse(txtStockMinimo.Text);
                _infoProducto.pro_stockmaximo = int.Parse(txtStockMaximo.Text);
                _infoProducto.pro_preciocompra = decimal.Parse(txtPrecioCompra.Text);
                _infoProducto.pro_precioventa = decimal.Parse(txtPrecioVenta.Text);

                //Imagen
                if (fuImagenProducto.HasFile)
                {
                    try
                    {
                        if (fuImagenProducto.PostedFile.ContentType == "image/png" || fuImagenProducto.PostedFile.ContentType == "image/jpg")
                        {
                            if (fuImagenProducto.PostedFile.ContentLength < 100000)
                            {
                                string nombreproducto = txtCodigo.Text + ".jpg";
                                fuImagenProducto.SaveAs(Server.MapPath("~/images/products/") + nombreproducto);
                            }
                            else
                            {
                                lblMesagge.Text = "El tamaño maximo es de 100 kb";
                                return;
                            }
                        }
                        else
                        {
                            lblMesagge.Text = "Solo se acepta imagen de tipo Png y Jpg";
                            return;
                        }
                    }
                    catch (Exception ex)
                    {

                        lblMesagge.Text = "Error al cargar imagen del producto";
                    }
                }

                _infoProducto.pro_imagen = @"~/images/products/" + txtCodigo.Text + ".jpg";
                var taskSaveProduct = Task.Run(() => Logica.logicaProducto.saveProduct(_infoProducto));
                taskSaveProduct.Wait();
                if (taskSaveProduct.Result)
                {
                    lblMesagge.Text = "Producto guardado correctamente";
                    newProduct();
                }
            }
            catch (Exception ex)
            {
                lblMesagge.Text = ex.Message;
            }
        }

        private void updateProduct()
        {
            try
            { 

                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => logicaProducto.getProductXID(Convert.ToInt32(lblId.Text)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto != null)
                {
                    _infoProducto.cat_id = Convert.ToInt16(UC_Categoria1.DropDownList.SelectedValue);
                    _infoProducto.pro_codigo = txtCodigo.Text;
                    _infoProducto.pro_nombre = txtNombre.Text.ToUpper();
                    _infoProducto.pro_descripcion = txtDescripcion.Text.ToUpper();
                    _infoProducto.pro_stockminimo = int.Parse(txtStockMinimo.Text);
                    _infoProducto.pro_stockmaximo = int.Parse(txtStockMaximo.Text);
                    _infoProducto.pro_preciocompra = decimal.Parse(txtPrecioCompra.Text);
                    _infoProducto.pro_precioventa = decimal.Parse(txtPrecioVenta.Text);

                    //Imagen
                    if (fuImagenProducto.HasFile)
                    {
                        try
                        {
                            if (fuImagenProducto.PostedFile.ContentType == "image/png" || fuImagenProducto.PostedFile.ContentType == "image/jpg" || fuImagenProducto.PostedFile.ContentType == "image/jpeg")
                            {
                                if (fuImagenProducto.PostedFile.ContentLength < 100000)
                                {
                                    string nombreproducto = txtCodigo.Text + ".jpg";
                                    fuImagenProducto.SaveAs(Server.MapPath("~/images/products/") + nombreproducto);
                                }
                                else
                                {
                                    lblMesagge.Text = "El tamaño maximo es de 100 kb";
                                    return;
                                }
                            }
                            else
                            {
                                lblMesagge.Text = "Solo se acepta imagen de tipo Png y Jpg";
                                return;
                            }
                        }
                        catch (Exception ex)
                        {

                            lblMesagge.Text = "Error al cargar imagen del producto";
                        }
                    }

                    _infoProducto.pro_imagen = @"~/images/products/" + txtCodigo.Text + ".jpg";
                    var taskSaveProduct = Task.Run(() => Logica.logicaProducto.updateProduct(_infoProducto));
                    taskSaveProduct.Wait();
                    if (taskSaveProduct.Result)
                    {
                        lblMesagge.Text = "Producto modificado correctamente";
                        newProduct();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMesagge.Text = ex.Message;
            }
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {

        }
    }
}