using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace BotW_VR_Installer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            MessageBox.Show(new Form { TopMost = true }, "Please select your Cemu.exe file.");

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "EXE files (*.exe)|*.exe";

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    if (Directory.Exists(Path.Combine(Path.GetDirectoryName(dialog.FileName), "hfiomlc01")))
                    {
                        string zipFilePath = Path.Combine(Environment.CurrentDirectory, "toinstallbotwvr.zip");
                        File.WriteAllBytes(zipFilePath, Properties.Resources.toinstallbotwvr);
                        FastZip fastZip = new FastZip();
                        fastZip.ExtractZip(zipFilePath, Path.GetDirectoryName(dialog.FileName), "");
                        File.Delete(zipFilePath);
                        SystemSounds.Exclamation.Play();
                        MessageBox.Show(new Form { TopMost = true }, "Breath of the Wild VR successfully installed!\nPlease launch the game by double clicking 'Run Cemu in VR.bat'.\n\nMake sure you read the file 'READ ME YOU NERD.txt'.\n\nProgram icon made by Freepik.");
                    }
                    else
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show(new Form { TopMost = true }, "It doesn't look like this is the right executable... Try running Cemu.exe once before installing this.");
                    }
                }
                catch
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show(new Form { TopMost = true }, "An error has occured. Please make sure Cemu is closed.");
                }
            }
        }

    }
}