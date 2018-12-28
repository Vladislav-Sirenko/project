using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class MemoryStreamLogger : IDisposable
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger(string name)
        {
            memoryStream = new FileStream($@"c:\temp\{name.Split(' ')[0]}.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Dispose()
        {
            streamWriter.Dispose();
            memoryStream.Dispose();
        }

        public void Log(string message)
        {
            streamWriter.Write(message);
        }

    }
}
