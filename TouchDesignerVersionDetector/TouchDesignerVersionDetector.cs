using System;
using System.IO;

namespace Kodai
{
    class TouchDesignerVersionDetector
    {
        

        public TouchDesignerVersionDetector()
        {
            PrintHeader();

            Start();
        }



        void Start()
        {

            ToeExpander expander = new ToeExpander();

            Console.Write("\nInput .toe path : ");
            string toe_path = Console.ReadLine();

            if (expander.Expand(toe_path))
            {
                VersionDetector detector = new VersionDetector(toe_path);

                string version = detector.Detect();
                detector.DeleteGarbageDirectories();

                if (version != null)
                {
                    Console.Write("\nThis .toe version is : ");
                    MyConsole.ColoredWriteLine(version, ConsoleColor.Cyan);

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

            MyConsole.ColoredWriteLine(header, ConsoleColor.DarkGreen);
        }
        

        


    }
}
