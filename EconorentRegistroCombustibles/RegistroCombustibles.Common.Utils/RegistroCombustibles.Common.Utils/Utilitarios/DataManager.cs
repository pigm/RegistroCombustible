using System.Collections.Generic;
using RegistroCombustibles.Common.Models.Modelo;
using RegistroCombustibles.Common.Models.Services;

namespace RegistroCombustibles.Common.Utils.Utilitarios
{
    /// <summary>
    /// Data manager.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Gets or sets the sucursales.
        /// </summary>
        /// <value>The sucursales.</value>
        public static List<Sucursal> Sucursales { get; set; }
        public static Sucursal SucursalSeleccionada { get; set; }
        public static List<Aeropuerto> Aeropuertos { get; set; }
        public static int TipoBusqueda = 1;
        public static DatosPatioAutoResult DatosPatioAuto { get; set; }
        public static string NombreUsuario { get; set; }
        public static int CodigoUsuario { get; set; }
        public static int CodigoAgencia { get; set; }
        public static int Region { get; set; }
        public static bool IsAeropuerto { get; set; }
        public static int SpinnerPosition { get; set; }
        public static bool AppCenterActive { get; set; }
    }
}
