using CarritoQuinto.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CarritoQuinto.Web.Logica
{
    public class logicaUsuario
    {
        private static BDDCARRITO2Entities dc = new BDDCARRITO2Entities();

        public static async Task<List<TBL_USUARIO>> getAllUsers()
        {
            try
            {
                return await dc.TBL_USUARIO.Where(data => data.usu_status == "A").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuarios");
            }
        }

        public static async Task<TBL_USUARIO> getUserXLogin(string userCorreo, string password)
        {
            try
            {
                return await dc.TBL_USUARIO.FirstOrDefaultAsync(data => data.usu_status == "A"
                                                                && data.usu_correo.Equals(userCorreo)
                                                                && data.usu_password.Equals(password));
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario");
            }
        }

    }
}