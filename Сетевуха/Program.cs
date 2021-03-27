using System;
using System.IO;
using System.Net;
using System.Text;

namespace Сетевуха
{
    class Program
    {
        /// <summary>
        /// Считываю HTML код сайта.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            string url = "http://moodle.mdu.in.ua/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusCode);

            StreamReader sr;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = response.GetResponseStream();
                if (response.CharacterSet == "")
                {
                sr = new StreamReader(stream);
                }
                else 
                {
                    sr = new StreamReader(stream, Encoding.GetEncoding(response.CharacterSet));
                }
                Console.WriteLine(sr.ReadToEnd());
                sr.Close();
            }
            response.Close();
        }
    }
}
