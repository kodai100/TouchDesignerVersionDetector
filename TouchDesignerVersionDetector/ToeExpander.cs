using System;
using System.IO;
using System.Diagnostics;

namespace Kodai
{
    class ToeExpander
    {

        private static readonly string[] versions = { "088", "099" };
        private static readonly string default_td_path = "C:\\Program Files\\Derivative\\TouchDesigner{0}\\bin\\toeexpand.exe";

        private string expander_path = "";

        public ToeExpander()
        {

            expander_path = SearchDefaultInstalledDirectory();

            // null check
            if(expander_path == null)
            {
                MyConsole.ColoredWriteLine("\nCouldn't find TouchDesigner in default installation folder.", ConsoleColor.Yellow);
                expander_path = AnotherFolderPrompt();

                if (expander_path == null)
                {
                    MyConsole.StatusWriteLine("TouchDesigner is not found.", false);
                    Console.WriteLine("Press any key to close application.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
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
                    MyConsole.StatusWrite("Detected", true);
                    Console.WriteLine("TouchDesigner{0}", version);

                    MyConsole.StatusWrite("Expander", true);
                    Console.WriteLine(file);

                    return file;
                }
            }

            return null;
        }


        string SearchInstalledDirectory(string path)
        {

            string file = path + "\\bin\\toeexpand.exe";

            if (File.Exists(file))
            {

                MyConsole.StatusWrite("Detected", true);
                Console.WriteLine("TouchDesigner{0}", Path.GetDirectoryName(path));

                MyConsole.StatusWrite("Expander", true);
                Console.WriteLine(file);

                return file;
            }

            return null;
        }


        private string  AnotherFolderPrompt()
        {
            
            Console.Write("Input your installation directory (TouchDesignerXXX): ");

            string td_path = Console.ReadLine();

            if(td_path == "")
            {
                return null;
            }

            string tmp_expander_path = SearchInstalledDirectory(td_path);

            if(tmp_expander_path == null)
            {
                MyConsole.StatusWriteLine("\nWrong path", false);
                return AnotherFolderPrompt();
            }
            else
            {
                return tmp_expander_path;
            }
        }


        public bool Expand(string toe_path)
        {
            
            if (!File.Exists(toe_path))
            {
                Console.WriteLine("No such file : " + toe_path);
                return false;
            }

            MyConsole.StatusWrite("\nExecuted", true);
            Console.WriteLine("\"{0}\" \"{1}\"", Path.GetFileName(expander_path), Path.GetFileName(toe_path));

            Process p = Process.Start("\"" + expander_path + "\"", "\"" + toe_path + "\"");

            p.WaitForExit();

            MyConsole.StatusWriteLine("Expand process finished.", true);

            return true;
        }

    }
}
