using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace home_task_12
{
    class Program
    {
        private const string InputFile = "Input.txt";
        private const string WhiteListFile = "Whitelist.txt";
        private const string BlackListFile = "Blacklist.txt";
        private const string OutputBlack = "Output_blacklist.txt";
        private const string OutputWhite = "Output_whitelist.txt";
        private const string OutputBoth = "Output_black_and_white.txt";

        static List<string> input;
        static List<string> black;
        static List<string> white;
        static HashSet<string> forwritting;
        static List<string> forfilter;


        static void Main(string[] args)
        {
           input = new List<string>();
           black = new List<string>();
           white = new List<string>();
           forwritting = new HashSet<string>();
           forfilter = new List<string>();

           ReadInput();
           ReadWhitelist();
           WhiteList();
           ReadBlaclist();
           BlackList();
           BlackWhiteList();
        }

        static void ReadInput()
        {
            Readlines(InputFile, input);
        }

        static void ReadBlaclist()
        {
            Readlines(BlackListFile, black);
        }

        static void ReadWhitelist()
        {
            Readlines(WhiteListFile, white);
        }

        private static void Readlines(string path, List<string> list)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
        }

        private static void Writelines(string outpath, List<string> list)
        {
            using (StreamWriter writer = new StreamWriter(outpath))
            {
                foreach (string line in list)
                {
                    writer.WriteLine(line);
                }
           }
        }

        static void WhiteList()
        {
           for (int i = 0; i < input.Count; i++)
            {
                if (white.Contains(input[i]))
                {
                    forfilter.Add(input[i]);
                }
            }
            Writelines(OutputWhite, forfilter);
        }

        static void BlackList()
        {
                for (int i = 0; i < input.Count; i++)
                {
                    if (!black.Contains(input[i]))
                    {
                        forfilter.Add(input[i]);
                    }
                }
            Writelines(OutputBlack, forfilter);
        }

        static void BlackWhiteList()
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (!black.Contains(input[i]))
                {
                    forfilter.Add(input[i]);
                }
            }
            List<string> forfilter2 = new List<string>();
            for (int i = 0; i < forfilter.Count; i++)
            {
                if (white.Contains(forfilter[i]))
                {
                    forfilter2.Add(forfilter[i]);
                }
            }
            Writelines(OutputBoth, forfilter2);
        }
    }
}
