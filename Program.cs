using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceModeloConexão
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

            // 
            var dataverse = new Dataverse(); // Conexão

            // Alterar alto para confirmar a conexão
            var entity = new Entity("", new Guid("")); // Nome lógico e id do registro teste
            entity[""] = $"{DateTime.Now.ToShortDateString()}"; // Campo que será alterado para teste
            dataverse.ServiceClient.Update(entity);

        }
    }
}
