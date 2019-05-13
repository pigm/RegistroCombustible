using System;
namespace RegistroCombustibles.Common.Services.Properties
{
    public static class ConfigProperties
    {
        public static string SOAP_ENDPOINT = "http://200.50.110.76:8080/4DSOAP/";//DESA
        //public static string SOAP_ENDPOINT = "http://200.50.110.78:8080/4DSOAP/";//QA
        //public static string SOAP_ENDPOINT   = "http://200.50.110.77:8080/4DSOAP/";//PRODUCCION
        public static string SOAP_NAMESPACE = "http://www.4d.com/namespace/default";
        public static string SOAP_ACTION = "SOAPAction";
        public static string SOAP_ACTION_LOGIN = "A_WebService#ws_login4D";
        public static string SOAP_ACTION_DATOSVEHICULO = "A_WebService#ws_Patio_datosAuto";
        public static string SOAP_ACTION_CARGAGAS = "A_WebService#ws_Patio_cargarGas";
        public static string SOAP_ACTION_TURNO = "A_WebService#ws_turno";
        public static string SOAP_ACTION_SUCURSALES = "A_WebService#ws_sucursales";
        public static string NOTCONNECTION = "Dispositivo sin conexión a internet";
    }
}
