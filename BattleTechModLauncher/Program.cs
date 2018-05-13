using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BattleTechModLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameDir = Directory.GetCurrentDirectory();
            var managedDir = Path.Combine(gameDir, Path.Combine("BattleTech_Data", "Managed"));
            var injectorExecutable = Path.Combine(managedDir, "BattleTechModLoaderInjector.exe");

            if (!File.Exists(injectorExecutable))
            {
                MessageBox.Show(
                    "Please reinstall BattleTech Mod Tools using the installer",
                    "Could not find BTMLInjector",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            try
            {
                if (RunApplication(injectorExecutable, managedDir, "/nokeypress", out var output) != 0)
                {
                    MessageBox.Show(
                        output,
                        "BTMLInjector was not successfull",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    e.ToString(),
                    "Error launching BTMLInjector",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            try
            {
                int rv;
                if (File.Exists(Path.Combine(gameDir, "steam_api64.dll")) || File.Exists(Path.Combine(gameDir, "steam_api.dll")))
                {
                    rv = StartApplication("cmd.exe", gameDir, "/c start /B steam://rungameid/637090");
                }
                else
                {
                    var quotedArgs = args
                        .Select(x => x.Replace("\"", "\\\""))
                        .Select(x => x.Contains(" ") ? "\"" + x + "\"" : x)
                        .ToList();
                    var argumentsString = string.Join(" ", quotedArgs);
                    rv = StartApplication("cmd.exe", gameDir, "/c start /B BattleTech.exe " + argumentsString);
                }

                if (rv != 0)
                {
                    MessageBox.Show(
                        "Try launching your game directly",
                        "Error launching BattleTech",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Try launching your game directly." + Environment.NewLine + "Error: " + e,
                    "Error launching BattleTech",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static int RunApplication(string executable, string workingDirectory, string arguments, out string output)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.FileName = executable;
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = arguments;

            using (var process = Process.Start(startInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return process.ExitCode;
            }
        }

        private static int StartApplication(string executable, string workingDirectory, string arguments)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            startInfo.FileName = executable;
            startInfo.WorkingDirectory = workingDirectory;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = arguments;

            using (var process = Process.Start(startInfo))
            {
                process.WaitForExit();
                return process.ExitCode;
            }
        }
    }
}
