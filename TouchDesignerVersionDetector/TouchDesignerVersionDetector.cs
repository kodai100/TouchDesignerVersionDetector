using System;
using System.IO;

namespace Kodai
{
    class TouchDesignerVersionDetector
    {

        private static string[] versions = { "088", "099" };
        private static string default_td_path = "C:\\Program Files\\Derivative\\TouchDesigner{0}\\bin\\toeexpand.exe";


        public TouchDesignerVersionDetector()
        {
            Start();
        }



        void Start()
        {
            PrintHeader();

            string expander_path = SearchDefaultInstalledDirectory();

            if (expander_path != null)
            {
                DetectionProcess(expander_path);
            }
            else
            {
                AnotherFolderPrompt();
            }
        }

        void DetectionProcess(string expander_path)
        {
            ToeExpander expander = new ToeExpander(expander_path);

            Console.Write("\nInput .toe path : ");
            string toe_path = Console.ReadLine();

            if (expander.Expand(toe_path))
            {
                VersionDetector detector = new VersionDetector(toe_path);

                string version = detector.Detect();
                if (version != null)
                {
                    Console.Write("\nThis .toe version is : ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(version);
                    Console.ResetColor();

                    Console.Write("\nEnter to end app.");
                    Console.ReadLine();
                }

            }
        }


        void PrintHeader()
        {

            string header = "===================================================\n"
                            + "TouchDesigner Version Detector 1.0.0\n"
                            + "(Copyright : 2018 Kodai Takao All Rights Reserved.)\n"
                            + "===================================================\n";

            ColoredWriteLine(header, ConsoleColor.DarkGreen);
        }


        void AnotherFolderPrompt()
        {
            Console.WriteLine("\nI couldn't find TouchDesigner in default installation folder.");
            Console.WriteLine("Didn't you installed it another folder ? (y/n)");

            string s = Console.ReadLine();

            if (s.Equals("y"))
            {
                Console.Write("\nInput TouchDesigner installed dir (TouchDesignerXXX dir): ");
                string td_path = Console.ReadLine();

                string expander_path = SearchInstalledDirectory(td_path);
                
            }
            else if (s.Equals("n"))
            {
                return;
            }
            else
            {
                AnotherFolderPrompt();
            }
        }

        
        string SearchDefaultInstalledDirectory()
        {
            foreach (string version in versions)
            {

                string file = string.Format(default_td_path, version);
                // Console.WriteLine("Searching... " + dir);

                if (File.Exists(file))
                {
                    Console.WriteLine("Detected TD : TouchDesigner{0}", version);
                    Console.WriteLine("Expander : {0}", file);
                    return file;
                }
            }

            return null;
        }


        string SearchInstalledDirectory(string path)
        {

            string file = path + "\\bin\\toeexpander.exe";

            if (File.Exists(file))
            {
                Console.WriteLine("Detected TD : TouchDesigner{0}", Path.GetDirectoryName(path));
                Console.WriteLine("Expander : {0}", file);
                return file;
            }

            return null;
        }


        void ColoredWriteLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        void ColoredWrite(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(line);
            Console.ResetColor();
        }


    }
}
