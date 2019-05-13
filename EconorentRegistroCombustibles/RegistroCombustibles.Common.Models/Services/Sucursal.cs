using System.Xml.Serialization;

namespace RegistroCombustibles.Common.Models.Services
{
    /// <summary>
    /// Sucursal.
    /// </summary>
    //[XmlRoot(ElementName = "sucursal")]
    public class Sucursal
    {    
        public int Codigo { get; set; }           
        public string Nombre { get; set; }
        public int Region { get; set; }
        public int Combustible { get; set; }
    }
}