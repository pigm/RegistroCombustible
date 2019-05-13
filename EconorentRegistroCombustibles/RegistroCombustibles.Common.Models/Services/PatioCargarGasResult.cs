using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Patio cargar gas result.
    /// </summary>
    public class PatioCargarGasResult
    {
        [XmlElement(ElementName = "numOCCombustible")]
        public string NumOCCombustible { get; set; }
        [XmlElement(ElementName = "mensajeSalida")]
        public string MensajeSalida { get; set; }
    }
}
