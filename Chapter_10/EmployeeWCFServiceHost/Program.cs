using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EmployeeWCFService;


namespace EmployeeWCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Type t = typeof(EmployeeManager);
                Uri tcp = new Uri("net.tcp://localhost:8010/EmployeeWCFService");
                Uri http = new Uri("http://localhost:8000/EmployeeWCFService");
                ServiceHost host = new ServiceHost(t, tcp, http);
                host.Open();
                Console.WriteLine("Employee Manager Service Published.");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
