using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace testIN
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите путь к файлу...");
                string textfile = Console.ReadLine();
                Console.WriteLine("Введите максимальное количество строк в файле...");
                int N = Convert.ToInt32(Console.ReadLine());
                string dicfile = "Dictionary.txt";
                //if ((new FileInfo(dicfile).Length > 2097152) || (new FileInfo(textfile).Length > 2097152))
                //{
                //    Console.WriteLine("Входные файлы имеют неверный объем!");
                //    Thread.Sleep(3000);
                //    Environment.Exit(0);
                //}
                List<string> dic = new List<string>();
                using (StreamReader sr = new StreamReader(dicfile, Encoding.GetEncoding("windows-1251")))
                {
                    string[] diction = sr.ReadToEnd().Split('\n');
                    foreach (string s in diction)
                    {
                        dic.Add(s.Replace('\r',' '));
                    }
                }
                using (StreamReader sr = new StreamReader(textfile, Encoding.GetEncoding("windows-1251")))
                {
                    string[] s = sr.ReadToEnd().Split('\n');
                    if (s.Count() > N)
                    {
                        int j=0;
                        while (s.Count() > N)
                        {
                            string[] first = new string[N];
                                for (int i = 0; i < N; i++)
                                {
                                    first[i] = s[i];
                                }
                            new Convertto().Funct(first, dic, "text" + (j+1).ToString() + ".html");
                            j++;
                            List <string> vspom = s.ToList();
                            vspom.RemoveRange(0, N);
                            s = vspom.ToArray();
                            vspom.Clear();
                        }
                        new Convertto().Funct(s, dic, "textLast.html");
                    }
                    else
                    {
                        new Convertto().Funct(s, dic, "text.html");
                    }
                }
                Console.WriteLine("Записано!");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
    class Convertto
    {
        public void Funct(string[] s, List<string> l, string htmlfilename)
        {
            string html="";
            html+="<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\"";
            html+="\"http://www.w3.org/TR/html4/strict.dtd\">";
            html+="<HTML>";
            html+="<BODY>";
            html+="<p>";
            for (int i = 0; i < s.Count(); i++)
                {
                    string[] s2 = s[i].Split(' ');
                    for (int j = 0; j < s2.Count(); j++)
                        {
                            s2[j] = s2[j] + " ";
                            foreach (string c in l)
                            {
                                if (s2[j] == c) s2[j] = "<b><i>" + s2[j] + "</i></b>";
                            }
                            html+=s2[j];
                        }
                        html+="\r\n";
                 }
                 html+="</p>";
                 html+="</BODY>";
                 html+="</HTML>";
                 using (StreamWriter sw = new StreamWriter(htmlfilename,false, Encoding.Default))
                 {
                     sw.WriteLine(html);
                 }
            }
        //public string tochka(string s)
        //{
        //    int k = s.LastIndexOf('.');
        //    string str = "", ctr = "";
        //    for (int i = 0; i < k + 1; i++)
        //    {
        //        ctr += s[i];
        //    }
        //    for (int i = k + 1; i < s.Length; i++)
        //    {
        //        str += s[i];
        //    }
        //    s = ctr + "\r\n" + str;
        //    return s;
        //}
    }
}
