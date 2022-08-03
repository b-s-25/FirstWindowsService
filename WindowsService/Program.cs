using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            bool DEBUG = true;
            if (DEBUG)
            {
                Service1 myService = new Service1();
                myService.Listing();
                //myService.GettingDetails();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
           

        }
    }
}
