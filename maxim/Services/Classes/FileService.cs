using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kargo.Services.Classes
{
    public static class FileService
    {
        public static void Write(string filename, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(filename);
                }
            }
        }
        public static string? ReadAs(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader sw = new StreamReader(fs))
                {
                    return sw.ReadLine();
                }
            }
        }
    }
}
