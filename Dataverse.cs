using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Deployment;
using Microsoft.Xrm.Tooling.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceModeloConexão
{
    public class Dataverse
    {
        //Constructor
        public Dataverse()
        {
            //AppConfig
            string appconfigPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(Path.GetFullPath($"{appconfigPath}\\{typeof(Dataverse).Namespace.Replace("_", "-")}\\App.config")) };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None); 
            var settings = config.AppSettings.Settings;


            string friendlyName = settings["friendlyName"].Value;
            string url = settings["url"].Value;
            string tenantid = settings["tenantid"].Value;
            string applicationid = settings["applicationid"].Value;
            string secret = settings["secret"].Value;
            string user = settings["user"].Value;
            string password = settings["password"].Value;
            string multipleFa = settings["multipleFa"].Value;

            this.ServiceClient = ClientSecret();


            if (this.ServiceClient != null && this.ServiceClient.IsReady)
            {
                Console.WriteLine("Conexão bem-sucedida!");
            }
            else
                throw new System.Exception(this.ServiceClient.LastCrmException.Message);





            CrmServiceClient ClientSecret()
            {
                string conn = $@"Url={url};
                            AuthType=ClientSecret;
                            TenantId={tenantid};
                            ClientId={applicationid};
                            ClientSecret={secret};
                            RequireNewInstance=True";

                return new CrmServiceClient(conn);
            }

        }
        //Constantes
        public string friendlyName = "friendlyName";
        public string url = "url";
        public string tenantid = "tenantid";
        public string applicationId = "applicationid";
        public string secret = "secret";
        public string user = "user";
        public string password = "password";
        public string multipleFa = "multipleFa";

        public enum eAuthType
        {
            UserPassword = 0,
            ClientSecret = 1
        }
        //Service
        public CrmServiceClient ServiceClient { get; private set; }

    }

}
