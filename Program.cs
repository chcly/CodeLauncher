using System;
using System.Diagnostics;
using System.Reflection;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CodeLauncher -> alias
            // Code --extensions-dir="X:Path/to/EnvironVariable/"\
            //      --user-data-dir="Y:Path/to/EnvironVariable/"

            var code = System.Environment.GetEnvironmentVariable("VSCODE_PATH");
            var ext = System.Environment.GetEnvironmentVariable("VSCODE_EXTENSIONS");
            var usr = System.Environment.GetEnvironmentVariable("VSCODE_USER");

            if (ext is null || usr is null || code is null)
                throw new Exception("Missing environment variables");


            if (!Directory.Exists(ext))
                Directory.CreateDirectory(ext);

            if (!Directory.Exists(usr))
                Directory.CreateDirectory(usr);

            if (Directory.Exists(ext) && Directory.Exists(usr))
            {
                var parm = new ProcessStartInfo();
                if (code != null)
                {
                    // Must Rename to Code1.exe, just to be sure it's 
                    // being funneled through here

                    parm.FileName = Path.Combine(code, "Code1.exe");
                    if (!File.Exists(parm.FileName))
                        throw new Exception("Missing code executable");

                    parm.Arguments = $"--extensions-dir=\"{ext}\" --user-data-dir=\"{usr}\"";

                    foreach (var arg in args)
                        parm.Arguments += ' ' + arg;

                    Process.Start(parm);
                }
            }
            else throw new Exception("Missing directories");
        }
    }
}