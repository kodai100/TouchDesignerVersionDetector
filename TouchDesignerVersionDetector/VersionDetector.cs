using System;
using System.Text;
using System.IO;

namespace Kodai
{
    class VersionDetector
    {

        private static readonly string dir_suffix = ".dir";
        private static readonly string version_written_file = ".build";
        private static readonly string toc_suffix = ".toc";

        private string toe_path;


        public VersionDetector(string toe_path)
        {
            this.toe_path = toe_path;
        }

        public string Detect()
        {

            if (Directory.Exists(toe_path + dir_suffix))
            {

                // Console.WriteLine("Find dir");

                string version_file_path = toe_path + dir_suffix + "\\" + version_written_file;

                if (File.Exists(version_file_path))
                {
                    // Console.WriteLine("Find .build file");
                    
                    // open
                    using (StreamReader sr = new StreamReader(version_file_path, Encoding.GetEncoding("Shift_JIS")))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();

                            string[] values = line.Split(' ');

                            if (values[0].Equals("build"))
                            {

                                return values[1];
                            }

                        }

                    }

                }
            }

            return null;
        }



        public void DeleteGarbageDirectories()
        {

            Directory.Delete(toe_path + dir_suffix, true);
            File.Delete(toe_path + toc_suffix);
        }
    }
}
