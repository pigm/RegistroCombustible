using System;
using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Turno result.
    /// </summary>
    public class TurnoResult
    {
        [XmlElement(ElementName = "estado")]
        public int Estado { get; set; }

        [XmlElement(ElementName = "codigo_turno")]
        public int Codigo_turno { get; set; }
    }
}
