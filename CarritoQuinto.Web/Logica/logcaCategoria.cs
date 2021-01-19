using CarritoQuinto.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarritoQuinto.Web.Logica
{
    public class logcaCategoria
    {

        private static BDDCARRITO2Entities dc = new BDDCARRITO2Entities();

        public static async Task<List<TBL_CATEGORIA>> getAllCategory()
        {
            try
            {
                return await dc.TBL_CATEGORIA.Where(data => data.cat_status == "A").ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener categoraias" + ex.Message);
            }
        }

        public static async Task<TBL_CATEGORIA> getCategoryXId(int idCategoria)
        {
            try
            {
                return await dc.TBL_CATEGORIA.Where(data => data.cat_status == "A"
                                                    && data.cat_id.Equals(idCategoria)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener categoraia" + ex.Message);
            }
        }

    }
}