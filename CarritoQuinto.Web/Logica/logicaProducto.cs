using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CarritoQuinto.Web.Models;

namespace CarritoQuinto.Web.Logica
{
    public class logicaProducto
    {
        private static BDDCARRITO2Entities dc = new BDDCARRITO2Entities();

        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await dc.TBL_PRODUCTO.Where(data => data.pro_status == "A").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener productos");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXID(int idProducto)
        {
            try
            {
                return await dc.TBL_PRODUCTO.Where(data => data.pro_status == "A"
                                                   && data.pro_id.Equals(idProducto)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_status = "A";
                _infoProducto.pro_fechacreacion = DateTime.Now;
                //Producto al contexto
                dc.TBL_PRODUCTO.Add(_infoProducto);
                //Commit a la base
                resultado = await dc.SaveChangesAsync() > 0;
                
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar el producto");
            }
        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_fechacreacion = DateTime.Now;
                //Actualizamos el contexto - commit
                await dc.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<bool> deleteProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.pro_fechacreacion = DateTime.Now;
                _infoProducto.pro_status = "I";

                //Forma fisica
                //dc.TBL_PRODUCTO.Remove(_infoProducto);

                //Actualizamos el contexto - commit
                await dc.SaveChangesAsync();

                resultado = true;
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}