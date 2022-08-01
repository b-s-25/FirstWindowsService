using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
     

        Timer timer = new Timer();
        List<Details> details = null;
        public Service1()
        {
            InitializeComponent();

        }
        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; 
            timer.Enabled = true;
        }
        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
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
        public void Listing()
        {
            details = new List<Details>();

            details.Add(new Details() { EmployeId = "J01977", DisplayName = "Aarin Weathers", GiveName = "Aarin", SN = "Weathers", Department = "Security Operations Center (SOC)", Email = "Aarin.Weathers@interfacesys.com", Title = "Level 1 Tier 2 NOC Agent", Manager = "James Little" });
            details.Add(new Details() { EmployeId = "D03963", DisplayName = "Aaron Johnson", GiveName = "Aaron", SN = "Johnson", Department = "General Administration", Email = "Aaron.Johnson@interfacesys.com", Title = "Logistics Coordinator", Manager = "Rose Criswell" });
            details.Add(new Details() { EmployeId = "X04125", DisplayName = "Aaron Wagoner", GiveName = "Aaron", SN = "Wagoner", Department = "Customer Operations", Email = "aaron.wagoner@interfacesys.com", Title = "Project Manager", Manager = "Christina Heilig" });
            details.Add(new Details() { EmployeId = "I02168", DisplayName = "Aaron Wright", GiveName = "Aaron", SN = "Wright", Department = "Security Operations Center (SOC)", Email = "Aaron.Wright@interfacesys.com", Title = "Network Engineer", Manager = "Dallas Helquist" });

            using (var writer = new StreamWriter("Getuserdetails.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(details);
            }
             
        }
        //public FileResult GettingDetails()
        //{
        //    //byte[] result;
        //    //System.Diagnostics.Debugger.Launch();

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var streamWriter = new StreamWriter(memoryStream))
        //        {
        //            using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
        //            {
        //                csvWriter.WriteRecords(details);
        //                //streamWriter.Flush();
        //                result = memoryStream.ToArray();
        //            }
        //        }
        //    }


        //    return new FileStreamResult(new MemoryStream(result), "text/csv") { FileDownloadName = "UserDetails.csv" };

            ////anothe way 
            //using (var mem = new MemoryStream())
            //using (var writer = new StreamWriter(mem))
            //using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            //{
            //    csvWriter.Configuration.Delimiter = "";
            //    csvWriter.Configuration.Delimiter = ";";
            //    csvWriter.Configuration.HasHeaderRecord = true;
            //    csvWriter.Configuration.AutoMap<Details>();

            //    csvWriter.WriteHeader<Details>();
            //    csvWriter.WriteRecords(details);

            //    writer.Flush();
            //    var result = Encoding.UTF8.GetString(mem.ToArray());
            //    Console.WriteLine(result);
            //}
            // another way
            //using (var mem = new MemoryStream())
            //using (var writer = new StreamWriter(mem))
            //using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture))
            //{


            //    csvWriter.WriteField("EmployeId");
            //    csvWriter.WriteField("DisplayName");
            //    csvWriter.WriteField("GiveName");
            //    csvWriter.WriteField("SN");
            //    csvWriter.WriteField("Title");
            //    csvWriter.WriteField("Manager");

            //    csvWriter.NextRecord();

            //    foreach (var project in details)
            //    {
            //        csvWriter.WriteField(project.EmployeId);
            //        csvWriter.WriteField(project.DisplayName);
            //        csvWriter.WriteField(project.GiveName);
            //        csvWriter.WriteField(project.SN);
            //        csvWriter.WriteField(project.Title);
            //        csvWriter.WriteField(project.Manager);
            //        csvWriter.NextRecord();
            //    }

            //    writer.Flush();
            //    var result = Encoding.UTF8.GetString(mem.ToArray());
            //    Console.WriteLine(result);
            //}
        //}


    }
}
