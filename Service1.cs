using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Microsoft.Xrm.Sdk;


namespace WindowsServiceModeloConexão
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at foi alterado " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime); // Seleciona o método de iniciação do serviço
            timer.Interval = 60000; // Tempo marcado em milisegundos, 60000 = 1 minuto
            timer.Enabled = true; // Habilita o objeto de timer
        }

        protected override void OnStop()
        {
        }
        protected void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                var dataverse = new Dataverse(); // Conexão

                // Alterar alto para confirmar a conexão
                var entity = new Entity("", new Guid("")); // Nome lógico e id do registro teste
                entity[""] = $"{DateTime.Now.ToShortDateString()}"; // Campo que será alterado para teste
                dataverse.ServiceClient.Update(entity);

                WriteToFile("Service was ran at " + DateTime.Now);
            }
            catch (Exception ex) {
                WriteToFile("Ocorreu um erro" + ex.Message);
            }

        }

        protected void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path)) 
            { 
                Directory.CreateDirectory(path);
            }

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.ToShortDateString().Replace('/','_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else 
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
