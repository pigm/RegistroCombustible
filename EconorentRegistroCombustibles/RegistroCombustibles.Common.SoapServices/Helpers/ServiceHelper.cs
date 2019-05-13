using System;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json.Linq;
using RegistroCombustibles.Common.Models.Services;
using RegistroCombustibles.Common.Services.Properties;

namespace RegistroCombustibles.Common.Services.Helpers
{
    public static class ServiceHelper
    {
        /// <summary>
        /// Prepares the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="typeRequest">Type request.</param>
        public static string PrepareRequest(int typeRequest, JObject paramsObject = null)
        {
            var request = string.Empty;
            switch (typeRequest)
            {
                case 0: //ws_login4D
                    request = String.Format(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:def=""http://www.4d.com/namespace/default"">
                                       <soapenv:Header/>
                                           <soapenv:Body>
                                              <def:ws_login4D soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                                                 <usuario xsi:type=""xsd:string"">{0}</usuario>
                                                 <clave xsi:type=""xsd:string"">{1}</clave>
                                                 <dispositivo xsi:type=""xsd:string"">{2}</dispositivo>
                                              </def:ws_login4D>
                                           </soapenv:Body>
                                        </soapenv:Envelope>
                                        ", paramsObject.GetValue("Usuario").ToString(),
                                            paramsObject.GetValue("Clave").ToString(),
                                            paramsObject.GetValue("Dispositivo").ToString()
                                           );
                    break;
                case 1: //ws_sucursales
                    request = @"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:def=""http://www.4d.com/namespace/default"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <def:ws_sucursales soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""/>
                               </soapenv:Body>
                            </soapenv:Envelope>";
                    break;
                case 2: //ws_Patio_datosAuto
                    request = String.Format(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:def=""http://www.4d.com/namespace/default"">
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <def:ws_Patio_datosAuto soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                                             <patenteAuto xsi:type=""xsd:string"">{0}</patenteAuto>
                                             <codigoAuto xsi:type=""xsd:string"">{1}</codigoAuto>
                                             <chasis xsi:type=""xsd:string"">{2}</chasis>
                                          </def:ws_Patio_datosAuto>
                                       </soapenv:Body>
                                    </soapenv:Envelope>
                                        ", paramsObject.GetValue("PatenteAuto").ToString(),
                                            paramsObject.GetValue("CodigoAuto").ToString(),
                                            paramsObject.GetValue("Chasis").ToString()
                                           );
                    break;
                case 3: //ws_Patio_cargarGas
                    request = String.Format(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:def=""http://www.4d.com/namespace/default"">
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <def:ws_Patio_cargarGas soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                                             <patenteAuto xsi:type=""xsd:string"">{0}</patenteAuto>
                                             <kmsAuto xsi:type=""xsd:int"">{1}</kmsAuto>
                                             <nivelGasSalida xsi:type=""xsd:string"">{2}</nivelGasSalida>
                                             <nivelGasEntrada xsi:type=""xsd:string"">{3}</nivelGasEntrada>
                                             <litrosCargados xsi:type=""xsd:float"">{4}</litrosCargados>
                                             <codigoEmpleado xsi:type=""xsd:int"">{5}</codigoEmpleado>
                                             <codigoAgencia xsi:type=""xsd:int"">{6}</codigoAgencia>
                                             <motivo xsi:type=""xsd:string"">{7}</motivo>
                                             <observacion xsi:type=""xsd:string"">{8}</observacion>
                                             <kmsAutoING xsi:type=""xsd:int"">{9}</kmsAutoING>
                                             <nivelGasEntradaING xsi:type=""xsd:string"">{10}</nivelGasEntradaING>
                                          </def:ws_Patio_cargarGas>
                                       </soapenv:Body>
                                    </soapenv:Envelope>
                                        ", paramsObject.GetValue("PatenteAuto").ToString(),
                                            paramsObject.GetValue("KmsAuto").ToString(),
                                            paramsObject.GetValue("NivelGasSalida").ToString(),
                                            paramsObject.GetValue("NivelGasEntrada").ToString(),
                                            paramsObject.GetValue("LitrosCargados").ToString(),
                                            paramsObject.GetValue("CodigoEmpleado").ToString(),
                                            paramsObject.GetValue("CodigoAgencia").ToString(),
                                            paramsObject.GetValue("Motivo").ToString(),
                                            paramsObject.GetValue("Observacion").ToString(),
                                            paramsObject.GetValue("KmsAutoING").ToString(),
                                            paramsObject.GetValue("NivelGasEntradaING").ToString()
                                           );
                    break;
                case 4: //ws_turno
                    request = String.Format(@"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:def=""http://www.4d.com/namespace/default"">
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <def:ws_turno soapenv:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">
                                             <codigo_sucursal xsi:type=""xsd:int"">{0}</codigo_sucursal>
                                          </def:ws_turno>
                                       </soapenv:Body>
                                    </soapenv:Envelope>
                                        ", paramsObject.GetValue("Codigo_sucursal").ToString()
                                           );
                    break;
            }
            return request;
        }


        /// <summary>
        /// Parses the SOAP response login usuario.
        /// </summary>
        /// <returns>The SOAP response login usuario.</returns>
        /// <param name="response">Response.</param>
        public static LoginResult ParseSoapResponseLoginUsuario(string response)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("ns1", ConfigProperties.SOAP_NAMESPACE);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("//ns1:ws_login4DResponse", nsmgr);
            LoginResult loginResult = new LoginResult();
            foreach (XmlNode xn in xNodelst)
            {
                var items = xn.ChildNodes;
                    try
                    {
                        loginResult.Estado = int.Parse(xn.ChildNodes[0].InnerText);
                        loginResult.Codigo_Usuario = int.Parse(xn.ChildNodes[1].InnerText);
                        loginResult.Region = int.Parse(xn.ChildNodes[2].InnerText);
                    }
                    catch
                    {
                        Console.WriteLine(items);
                        continue;
                    }
            }
            return loginResult;
        }


        /// <summary>
        /// Parses the SOAP response datos patio auto.
        /// </summary>
        /// <returns>The SOAP response datos patio auto.</returns>
        /// <param name="response">Response.</param>
        public static DatosPatioAutoResult ParseSoapResponseDatosPatioAuto(string response)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("ns1", ConfigProperties.SOAP_NAMESPACE);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("//ns1:ws_Patio_datosAutoResponse", nsmgr);
            DatosPatioAutoResult datosPatioAutoResult = new DatosPatioAutoResult();
            foreach (XmlNode xn in xNodelst)
            {
                var items = xn.ChildNodes;
                try
                {
                    datosPatioAutoResult.MensajeSalida = xn.ChildNodes[0].InnerText;
                    datosPatioAutoResult.Patente = xn.ChildNodes[1].InnerText;
                    datosPatioAutoResult.Codigo = xn.ChildNodes[2].InnerText;
                    datosPatioAutoResult.Marca = xn.ChildNodes[3].InnerText;
                    datosPatioAutoResult.Modelo = xn.ChildNodes[4].InnerText;
                    datosPatioAutoResult.Color = xn.ChildNodes[5].InnerText;
                    datosPatioAutoResult.TipoGas = xn.ChildNodes[6].InnerText;
                    datosPatioAutoResult.GasDesc = xn.ChildNodes[7].InnerText;
                    datosPatioAutoResult.LitrosTanque = xn.ChildNodes[8].InnerText;
                    datosPatioAutoResult.NivelGas = xn.ChildNodes[9].InnerText;
                    datosPatioAutoResult.KmsAuto = xn.ChildNodes[10].InnerText;
                }
                catch
                {
                    Console.WriteLine(items);
                    continue;
                }
            }
            return datosPatioAutoResult;
        }

        /// <summary>
        /// Parses the SOAP response carga gas.
        /// </summary>
        /// <returns>The SOAP response carga gas.</returns>
        /// <param name="response">Response.</param>
        public static PatioCargarGasResult ParseSoapResponseCargaGas(string response)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("ns1", ConfigProperties.SOAP_NAMESPACE);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("//ns1:ws_Patio_cargarGasResponse", nsmgr);
            PatioCargarGasResult patioCargarGasResult = new PatioCargarGasResult();
            foreach (XmlNode xn in xNodelst)
            {
                var items = xn.ChildNodes;
                try
                {
                    patioCargarGasResult.NumOCCombustible = xn.ChildNodes[0].InnerText;
                    patioCargarGasResult.MensajeSalida = xn.ChildNodes[1].InnerText;
                }
                catch
                {
                    Console.WriteLine(items);
                    continue;
                }
            }
            return patioCargarGasResult;
        }

        /// <summary>
        /// Parses the SOAP response sucursales.
        /// </summary>
        /// <returns>The SOAP response sucursales.</returns>
        /// <param name="response">Response.</param>
        public static SucursalesResult ParseSoapResponseSucursales(string response)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("ns1", ConfigProperties.SOAP_NAMESPACE);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("//ns1:ws_sucursalesResponse", nsmgr);
            SucursalesResult sucursalesResult = new SucursalesResult();
            List<Sucursal> listaSucursales = new List<Sucursal>();
            List<Aeropuerto> listaAeropuertos = new List<Aeropuerto>();

            foreach (XmlNode xn in xNodelst)
            {
                var items = xn.ChildNodes;
                try
                {
                    sucursalesResult.Estado = int.Parse(xn.ChildNodes[0].InnerText);
                   
                    foreach (XmlElement item in xn.ChildNodes)
                    {
                        if (item.LocalName.Equals("sucursales"))
                        {
                            foreach (XmlElement itemDetail in item)
                            {
                                try
                                {
                                    listaSucursales.Add(new Sucursal
                                    {
                                        Codigo = int.Parse(itemDetail.ChildNodes[0].InnerText),
                                        Nombre = itemDetail.ChildNodes[1].InnerText,
                                        Region = int.Parse(itemDetail.ChildNodes[2].InnerText),
                                        Combustible = int.Parse(itemDetail.ChildNodes[3].InnerText)
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.InnerException);
                                    continue;
                                }
                            }
                        }

                        if (item.LocalName.Equals("aeropuertos"))
                        {
                            foreach (XmlElement itemDetail in item)
                            {
                                try
                                {
                                    listaAeropuertos.Add(new Aeropuerto
                                    {
                                        Codigo = int.Parse(itemDetail.ChildNodes[0].InnerText),
                                        Nombre = itemDetail.ChildNodes[1].InnerText
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.InnerException);
                                    continue;
                                }
                            }
                        }
                    }
                    sucursalesResult.Sucursales = listaSucursales;
                    sucursalesResult.Aeropuertos = listaAeropuertos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    continue;
                }
            }
            return sucursalesResult;
        }

        /// <summary>
        /// Parses the SOAP response turno.
        /// </summary>
        /// <returns>The SOAP response turno.</returns>
        /// <param name="response">Response.</param>
        public static TurnoResult ParseSoapResponseTurno(string response)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xdoc.NameTable);
            nsmgr.AddNamespace("ns1", ConfigProperties.SOAP_NAMESPACE);
            XmlNodeList xNodelst = xdoc.DocumentElement.SelectNodes("//ns1:ws_turnoResponse", nsmgr);
            TurnoResult turnoResult = new TurnoResult();
            foreach (XmlNode xn in xNodelst)
            {
                var items = xn.ChildNodes;
                try
                {
                    turnoResult.Estado = int.Parse(xn.ChildNodes[0].InnerText);
                    turnoResult.Codigo_turno = int.Parse(xn.ChildNodes[1].InnerText);
                }
                catch
                {
                    Console.WriteLine(items);
                    continue;
                }
            }
            return turnoResult;
        }
    }
}
