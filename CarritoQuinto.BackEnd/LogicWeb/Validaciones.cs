using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoQuinto.BackEnd.LogicWeb
{
    public class Validaciones
    {
        public static bool VerificarCedula(string TxtCedula)
        {
            int EsNumero;
            var Total = 0;
            const int LongitudCedula = 10;
            int[] cooeficiente = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            if (int.TryParse(TxtCedula, out EsNumero) && TxtCedula.Length == LongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(TxtCedula[0], TxtCedula[1], string.Empty));
                var digitoTres = Convert.ToInt32(TxtCedula[2] + string.Empty);
                if (provincia > 0 && provincia <= 24)
                {
                    var DigitoVerificador = Convert.ToInt32(TxtCedula[9] + string.Empty);
                    for (var i = 0; i < cooeficiente.Length; i++)
                    {
                        var valor = Convert.ToInt32(cooeficiente[i] + string.Empty) * Convert.ToInt32(TxtCedula[i] + string.Empty);
                        Total = valor >= 10 ? Total + (valor - 9) : Total + valor;
                    }
                    var digitoverificadorobtenido = 0;
                    if (Total < 10)
                    {
                        digitoverificadorobtenido = 10 - Total;
                    }
                    else
                    {
                        digitoverificadorobtenido = Total >= 10 ? (Total % 10) != 0 ? 10 - (Total % 10) : (Total % 10) : Total;
                    }
                    return digitoverificadorobtenido == DigitoVerificador;
                }
            }
            return false;
        }


        public static bool VerificarRUC(string TxtRuc)
        {
            //int EsNumero;
            var Total = 0;
            const int LongitudCedula = 13;

            if (TxtRuc.Length == LongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(TxtRuc[0], TxtRuc[1], string.Empty));
                var digitoTres = Convert.ToInt32(TxtRuc[2] + string.Empty);
                if (digitoTres < 6)
                {
                    int[] cooeficiente1 = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };

                    string ultimosdigitos = TxtRuc.Substring(10);
                    if (ultimosdigitos.Equals("000"))
                    {
                        return false;
                    }

                    if (provincia > 0 && provincia <= 24)
                    {
                        var DigitoVerificador = Convert.ToInt32(TxtRuc[9] + string.Empty);
                        for (var i = 0; i < cooeficiente1.Length; i++)
                        {
                            var valor = Convert.ToInt32(cooeficiente1[i] + string.Empty) * Convert.ToInt32(TxtRuc[i] + string.Empty);
                            Total = valor >= 10 ? Total + (valor - 9) : Total + valor;
                        }

                        var digitoverificadorobtenido = 0;
                        if (Total < 10)
                        {
                            digitoverificadorobtenido = 10 - Total;
                        }
                        else
                        {
                            digitoverificadorobtenido = Total >= 10 ? (Total % 10) != 0 ? 10 - (Total % 10) : (Total % 10) : Total;
                        }
                        //var digitoverificadorobtenido = Total >= 10 ? (Total % 10) != 0 ? 10 - (Total % 10) : (Total % 10) : Total;
                        return digitoverificadorobtenido == DigitoVerificador;
                    }
                }
                if (digitoTres == 9)
                {
                    int[] cooeficiente1 = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                    if (provincia > 0 && provincia <= 24)
                    {
                        string ultimosdigitos = TxtRuc.Substring(10);
                        if (ultimosdigitos.Equals("000"))
                        {
                            return false;
                        }

                        var DigitoVerificador = Convert.ToInt32(TxtRuc[9] + string.Empty);
                        for (var i = 0; i < cooeficiente1.Length; i++)
                        {
                            var valor = Convert.ToInt32(cooeficiente1[i] + string.Empty) * Convert.ToInt32(TxtRuc[i] + string.Empty);
                            Total = valor + Total;
                        }
                        var digitoverificadorobtenido = 11 - (Total % 11);
                        if (digitoverificadorobtenido == 11)
                        {
                            digitoverificadorobtenido = 0;
                        }
                        return digitoverificadorobtenido == DigitoVerificador;
                    }
                }
                if (digitoTres == 6)
                {
                    int[] cooeficiente1 = { 3, 2, 7, 6, 5, 4, 3, 2 };
                    if (provincia > 0 && provincia <= 24)
                    {
                        string ultimosdigitos = TxtRuc.Substring(9);
                        if (ultimosdigitos.Equals("0000"))
                        {
                            return false;
                        }
                        var DigitoVerificador = Convert.ToInt32(TxtRuc[8] + string.Empty);
                        for (var i = 0; i < cooeficiente1.Length; i++)
                        {
                            var valor = Convert.ToInt32(cooeficiente1[i] + string.Empty) * Convert.ToInt32(TxtRuc[i] + string.Empty);
                            Total = valor + Total;
                        }
                        var digitoverificadorobtenido = 11 - (Total % 11);
                        if (digitoverificadorobtenido == 11)
                        {
                            digitoverificadorobtenido = 0;
                        }
                        return digitoverificadorobtenido == DigitoVerificador;
                    }
                }

            }
            return false;
        }

    }
}