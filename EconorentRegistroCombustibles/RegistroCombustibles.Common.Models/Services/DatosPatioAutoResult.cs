using System;
using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Datos patio auto result.
    /// </summary>
    public class DatosPatioAutoResult
    {
        [XmlElement(ElementName = "mensajeSalida")]
        public string MensajeSalida { get; set; }
        [XmlElement(ElementName = "patente")]
        public string Patente { get; set; }
        [XmlElement(ElementName = "codigo")]
        public string Codigo { get; set; }
        [XmlElement(ElementName = "marca")]
        public string Marca { get; set; }
        [XmlElement(ElementName = "modelo")]
        public string Modelo { get; set; }
        [XmlElement(ElementName = "color")]
        public string Color { get; set; }
        [XmlElement(ElementName = "tipoGas")]
        public string TipoGas { get; set; }
        [XmlElement(ElementName = "gasDesc")]
        public string GasDesc { get; set; }
        [XmlElement(ElementName = "litrosTanque")]
        public string LitrosTanque { get; set; }
        [XmlElement(ElementName = "nivelGas")]
        public string NivelGas { get; set; }
        [XmlElement(ElementName = "kmsAuto")]
        public string KmsAuto { get; set; }
    }
}
