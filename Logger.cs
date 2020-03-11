using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Logger
    {
        StreamWriter writer = new StreamWriter("SQLHeadLog.log");

        public void openLogger()
        {
            writer.WriteLine("<---------->>[Start Logging]<<---------->");
        }

        public void writeToLogger(string data)
        {
            writer.WriteLine(data);
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
