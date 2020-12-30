using System;
using System.IO;
using System.Text;

namespace MSTestProject
{
    class Reader
    {
        public string ReadTextFile(String fileName)
        {
            string builder = "";
            try
            {

                using (StreamReader reader = File.OpenText(fileName))
                {
                    string line; 
                    while ((line = reader.ReadLine()) != null)
                    {
                        builder+=line;
                    }

                    return builder;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
