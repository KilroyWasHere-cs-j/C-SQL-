using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    class Logger
    {
        StreamWriter writer = new StreamWriter("SQLHeadLog.log");

        public void openLogger(string RAM, string CPU)
        {
            writer.WriteLine("<---------->>[Start Logging]<<---------->");
            writer.WriteLine("<----[CPU]>>{" + CPU + "}<<[CPU]---->");
            writer.WriteLine("<----[RAM]>>{" + RAM + "}<<[RAM]---->");
        }

        public void writeToLogger(string data, string RAM, string CPU)
        {
            writer.WriteLine(data); //try catch for if data file is closed
            writer.WriteLine("<----[CPU]>>{" + CPU + "}<<[CPU]---->");
            writer.WriteLine("<----[RAM]>>{" + RAM + "}<<[RAM]---->");
        }

        public void closeLogger()
        {
            writer.WriteLine("<---------->>[End Logging]<<---------->");
            writer.Close();
        }

        public void viewLogger()
        {
            System.Diagnostics.Process.Start("SQLHeadLog.log");
        }
    }
}
