using System;
using System.IO;
using Ini.Net;

namespace inu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            { 
                Console.WriteLine("No params. Use help for a list of commands.");
                return;
            }
            if (args[0] == "help")
            {
                Console.WriteLine("checkkey [filepath] [section] [key]");
                Console.WriteLine("checksec [filepath] [section]");
                Console.WriteLine("read [filepath] [section] [key]");
                Console.WriteLine("write [filepath] [section] [key]");
                Console.WriteLine("delkey [filepath] [section] [key]");
                Console.WriteLine("delsec [filepath] [section]");
                Console.WriteLine("raw [filepath]");
                return;
            }

            var iniFile = new IniFile(args[1]);
            if (args[0] == "read")
            {
                if (iniFile.KeyExists(args[2], args[3]))
                {
                    Console.WriteLine("[" + args[2] + "][" + args[3] + "] = " + iniFile.ReadString(args[2], args[3]));
                }
                else
                {
                    Console.WriteLine("Key does not exist.");
                }
            } 
            if (args[0] == "write")
            {
                iniFile.WriteString(args[2], args[3], args[4]);
                Console.WriteLine("[" + args[2] + "][" + args[3] + "] = " + args[4]);
            }
            if (args[0] == "delkey")
            {
                if (iniFile.KeyExists(args[2], args[3]))
                {
                    iniFile.DeleteKey(args[2], args[3]);
                    Console.WriteLine("Deleted [" + args[2] + "][" + args[3] + "].");
                }
                else
                {
                    Console.WriteLine("Key does not exist.");
                }
            }
            if (args[0] == "delsec")
            {
                if (iniFile.SectionExists(args[2]))
                {
                    iniFile.DeleteSection(args[2]);
                    Console.WriteLine("Deleted [" + args[2] + "].");
                }
                else
                {
                    Console.WriteLine("Key does not exist.");
                }
            }
            if (args[0] == "raw")
            {
                Console.WriteLine(File.ReadAllText(args[1]));
            }
            if (args[0] == "checkkey")
            {
                if (iniFile.KeyExists(args[2], args[3]))
                {
                    Console.WriteLine("[" + args[2] + "][" + args[3] + "] true");
                }
                else
                {
                    Console.WriteLine("[" + args[2] + "][" + args[3] + "] false");
                }
            }
            if (args[0] == "checksec")
            {
                if (iniFile.SectionExists(args[2]))
                {
                    Console.WriteLine("[" + args[2] + "] true");
                }
                else
                {
                    Console.WriteLine("[" + args[2] + "] false");
                }
            }
        }
    }
}
