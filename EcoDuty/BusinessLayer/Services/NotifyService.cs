using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessLayer.Services
{
    public static class NotifyService
    {
        public static void Log(string message)
        {
            using (StreamWriter writeFile = new StreamWriter("Log.txt", true))
            {
                writeFile.WriteLine(message);
            }
        }
    }
}
