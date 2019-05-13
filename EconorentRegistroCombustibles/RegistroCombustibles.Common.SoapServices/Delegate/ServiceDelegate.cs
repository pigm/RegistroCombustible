using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RegistroCombustibles.Common.Services.Helpers;
using RegistroCombustibles.Common.Services.Properties;
using RegistroCombustibles.Common.Services.Result;
using RegistroCombustibles.Common.Utils.Utilitarios;

namespace RegistroCombustibles.Common.Services.Delegate
{
    /// <summary>
    /// Service delegate.
    /// </summary>
    public class ServiceDelegate
    {
        private const string MediaType = "text/xml";  
        static ServiceDelegate instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ServiceDelegate Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceDelegate();
                return instance;
            }
        }


        /// <summary>
        /// Obtienes the procedencias.
        /// </summary>
        /// <returns>The procedencias.</returns>
        public async Task<ServiceResult> UserLogin(JObject objectParam)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add(ConfigProperties.SOAP_ACTION, ConfigProperties.SOAP_ACTION_LOGIN);
                        client.Timeout = TimeSpan.FromSeconds(14);
                        //client.DefaultRequestHeaders.Add()
                        var uri = ConfigProperties.SOAP_ENDPOINT;
                        var soapRequest = ServiceHelper.PrepareRequest(0,objectParam);
                        var content = new StringContent(soapRequest, Encoding.UTF8, MediaType);
                        using (var response = await client.PostAsync(uri, content))
                        {
                            var soapResponse = await response.Content.ReadAsStringAsync();
                            var parseRespone = ServiceHelper.ParseSoapResponseLoginUsuario(soapResponse);
                            result.Success = true;
                            result.Response = parseRespone;
                        }
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Gets the branches.(Sucursales)
        /// </summary>
        /// <returns>The branches.</returns>
        public async Task<ServiceResult> GetBranches()
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add(ConfigProperties.SOAP_ACTION, ConfigProperties.SOAP_ACTION_SUCURSALES);
                        client.Timeout = TimeSpan.FromSeconds(14);
                        var uri = ConfigProperties.SOAP_ENDPOINT;
                        var soapRequest = ServiceHelper.PrepareRequest(1);
                        var content = new StringContent(soapRequest, Encoding.UTF8, MediaType);
                        using (var response = await client.PostAsync(uri, content))
                        {
                            var soapResponse = await response.Content.ReadAsStringAsync();
                            var parseRespone = ServiceHelper.ParseSoapResponseSucursales(soapResponse);
                            result.Success = true;
                            result.Response = parseRespone;
                        }
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Gets the vehiculo.
        /// </summary>
        /// <returns>The vehiculo.</returns>
        /// <param name="objectParam">Object parameter.</param>
        public async Task<ServiceResult> GetVehiculo(JObject objectParam)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add(ConfigProperties.SOAP_ACTION, ConfigProperties.SOAP_ACTION_DATOSVEHICULO);
                        client.Timeout = TimeSpan.FromSeconds(14);
                        //client.DefaultRequestHeaders.Add()
                        var uri = ConfigProperties.SOAP_ENDPOINT;
                        var soapRequest = ServiceHelper.PrepareRequest(2, objectParam);
                        var content = new StringContent(soapRequest, Encoding.UTF8, MediaType);
                        using (var response = await client.PostAsync(uri, content))
                        {
                            var soapResponse = await response.Content.ReadAsStringAsync();
                            var parseRespone = ServiceHelper.ParseSoapResponseDatosPatioAuto(soapResponse);
                            if (parseRespone.MensajeSalida != null)
                            {
                                result.Success = true;
                                result.Response = parseRespone;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "vehiculo no existe";
                                result.Response = 8;
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Cargas the gas.
        /// </summary>
        /// <returns>The gas.</returns>
        /// <param name="objectParam">Object parameter.</param>
        public async Task<ServiceResult> CargaGas(JObject objectParam)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add(ConfigProperties.SOAP_ACTION, ConfigProperties.SOAP_ACTION_CARGAGAS);
                        client.Timeout = TimeSpan.FromSeconds(14);
                        //client.DefaultRequestHeaders.Add()
                        var uri = ConfigProperties.SOAP_ENDPOINT;
                        var soapRequest = ServiceHelper.PrepareRequest(3, objectParam);
                        var content = new StringContent(soapRequest, Encoding.UTF8, MediaType);
                        using (var response = await client.PostAsync(uri, content))
                        {
                            var soapResponse = await response.Content.ReadAsStringAsync();
                            var parseRespone = ServiceHelper.ParseSoapResponseCargaGas(soapResponse);
                            if (parseRespone.MensajeSalida != null)
                            {
                                result.Success = true;
                                result.Response = parseRespone;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Error al ingresar los datos";
                                result.Response = 9;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Turno the specified objectParam.
        /// </summary>
        /// <returns>The turno.</returns>
        /// <param name="objectParam">Object parameter.</param>
        public async Task<ServiceResult> Turno(JObject objectParam)
        {
            ServiceResult result = new ServiceResult();
            if (GetNetworkStatus())
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add(ConfigProperties.SOAP_ACTION, ConfigProperties.SOAP_ACTION_TURNO);
                        client.Timeout = TimeSpan.FromSeconds(14);
                        //client.DefaultRequestHeaders.Add()
                        var uri = ConfigProperties.SOAP_ENDPOINT;
                        var soapRequest = ServiceHelper.PrepareRequest(4, objectParam);
                        var content = new StringContent(soapRequest, Encoding.UTF8, MediaType);
                        using (var response = await client.PostAsync(uri, content))
                        {
                            var soapResponse = await response.Content.ReadAsStringAsync();
                            var parseRespone = ServiceHelper.ParseSoapResponseTurno(soapResponse);
                            if (parseRespone.Estado == 200)
                            {
                                result.Success = true;
                                result.Response = parseRespone;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Sucursal no disponible";
                                result.Response = 10;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                    result.Response = 999;
                }
            }
            else
            {
                result.Success = false;
                result.Response = 1000;
                result.Message = ConfigProperties.NOTCONNECTION;
            }
            return result;
        }

        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        public bool GetNetworkStatus()
        {
            return ValidationUtils.GetNetworkStatus();
        }

    }
}

