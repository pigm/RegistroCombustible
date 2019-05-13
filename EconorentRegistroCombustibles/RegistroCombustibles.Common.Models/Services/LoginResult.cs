using System;
using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Login result.
    /// </summary>
    public class LoginResult
    {
        [XmlElement(ElementName = "estado")]
        public int Estado { get; set; }

        [XmlElement(ElementName = "codigo_usuario")]
        public int Codigo_Usuario { get; set; }

        [XmlElement(ElementName = "region")]
        public int Region { get; set; }
    }
}
