using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Aeropuerto.
    /// </summary>
    [XmlRoot(ElementName = "aeropuerto")]
    public class Aeropuerto
    {
        [XmlElement(ElementName = "codigo")]
        public int Codigo { get; set; }

        [XmlElement(ElementName = "nombre")]
        public string Nombre { get; set; }
    }
}