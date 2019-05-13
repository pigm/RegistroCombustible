using System;
namespace RegistroCombustibles.Utilitarios
{
    /// <summary>
    /// Mascaras edit text.
    /// </summary>
    public class MascarasEditText
    {
        /// <summary>
        /// Formatears the monto.
        /// </summary>
        /// <returns>The monto.</returns>
        /// <param name="monto">Monto.</param>
        public static string formatearMonto(string monto)
        {
            string montoPeso;
            if (monto == null || monto.Equals(""))
            {
                montoPeso = string.Empty;
            }
            else
            {
                monto = limpiarMontoPesos(monto);

                long num = Convert.ToInt64(monto);
                monto = String.Format("{0:N0}", num);

                montoPeso = monto.Replace(",", ".");
            }
            return montoPeso;
        }

        /// <summary>
        /// Limpiars the monto pesos.
        /// </summary>
        /// <returns>The monto pesos.</returns>
        /// <param name="monto">Monto.</param>
        public static string limpiarMontoPesos(string monto)
        {
            monto = monto.Replace(".", "");
            return monto;
        }



        public static string FormatearDecimal(string _decimal)
        {
            if (_decimal.Length > 2)
                _decimal = ObtenerDecimalFormateado(_decimal);
            else
                _decimal = LimpiaDecimal(_decimal);

            return _decimal;
        }
        public static string ObtenerDecimalFormateado(string decimales)
        {
            int cont = 0;
            string format;
            if (decimales.Length == 0)
                return "";
            else
            {
                decimales = LimpiaDecimal(decimales);
                format = "," + decimales.Substring(decimales.Length - 2);
                for (int i = decimales.Length - 3; i >= 0; i--)
                {
                    format = decimales.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }
        public static string LimpiaDecimal(string _decimal, int range = 0)
        {
            _decimal = _decimal.Replace(".", "").Replace(",", "");
            if (range == 1)
                _decimal = _decimal.Remove(_decimal.Length - 1);

            return _decimal;
        }

    }
}