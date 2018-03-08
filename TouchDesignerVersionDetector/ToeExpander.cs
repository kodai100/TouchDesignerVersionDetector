using System;
using System.IO;
using System.Diagnostics;

namespace Kodai
{
    class ToeExpander
    {

        string extender_path = "";

        public ToeExpander(string extender_path)
        {

            if (!File.Exists(extender_path)) throw new Exception("Unresolved file path! : " + extender_path);
            
            this.extender_path = extender_path;
        }



        public bool Expand(string toe_path)
        {
            
            if (!File.Exists(toe_path))
            {
                Console.WriteLine("No such file : " + toe_path);
                return false;
            }

            Console.WriteLine("\nExec : \"{0}\" \"{1}\"", Path.GetFileName(extender_path), Path.GetFileName(toe_path));

            Process p = Process.Start("\"" + extender_path + "\"", "\"" + toe_path + "\"");

            p.WaitForExit();

            Console.WriteLine("Process finished.");

            return true;
        }

    }
}
