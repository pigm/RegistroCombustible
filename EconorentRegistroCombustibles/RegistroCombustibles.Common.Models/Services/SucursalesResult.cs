using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Sucursales result.
    /// </summary>
    [XmlRoot(ElementName = "SucursalesResult")]
    public class SucursalesResult
    {
        [XmlElement(ElementName = "estado")]
        public int Estado { get; set; }

        [XmlElement(ElementName = "sucursales")]
        public List<Sucursal> Sucursales { get; set; }

        [XmlElement(ElementName = "aeropuertos")]
        public List<Aeropuerto> Aeropuertos { get; set; }
    }
}
