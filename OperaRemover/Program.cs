using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

public class Program
{
    public static void Main()
    {
        string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName))
        {
            if (key != null)
            {
                foreach (string valueName in key.GetValueNames())
                {
                    if (valueName.Contains("Opera GX"))
                    {
                        Console.WriteLine("Entry with 'Opera GX' in its name found in Registry!");
                        System.Threading.Thread.Sleep(3000);
                        Console.WriteLine("Time to remove that cancer from your PC");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Meanwhile check out how Opera GX users look");
                        System.Threading.Thread.Sleep(2000);
                        System.Diagnostics.Process.Start("cmd", "/c start https://www.reddit.com/r/F1NN5TER/comments/181k6hr/average_male_operagx_user/");


                        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        string operaGXPath = Path.Combine(appDataPath, "Programs", "Opera GX");

                        if (Directory.Exists(operaGXPath))
                        {
                            Console.WriteLine("Opera GX found!");

                            try
                            {
                                Directory.Delete(operaGXPath, true);
                                Console.WriteLine("Opera GX folder deleted successfully!");
                                Console.WriteLine("Press any button to exit...");
                                Console.ReadLine();
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = "cmd.exe",
                                    Arguments = "/C curl parrot.live",
                                    UseShellExecute = false
                                };

                                Process process = new Process { StartInfo = startInfo };
                                process.Start();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Failed to delete Opera GX folder: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opera GX folder not found in Programs. Searching other drives...");

                            bool found = false;
                            foreach (DriveInfo drive in DriveInfo.GetDrives())
                            {
                                if (drive.IsReady && !drive.Name.StartsWith("C:"))
                                {
                                    if (SearchDirectory(drive.Name, "Opera GX", 5))
                                    {
                                        found = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Opera GX folder not found on drive {drive.Name}.");
                                    }
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Opera GX folder not found on any drive.\n\n Shit man, sorry you gotta do it by hand");
                            }
                        }

                        return;
                    }
                }
            }
        }

        Console.WriteLine("No entry with 'Opera GX' in its name found in Registry.");
    }

    private static bool SearchDirectory(string path, string folderName, int depth)
    {
        if (depth < 0)
        {
            return false;
        }

        try
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                if (Path.GetFileName(directory).Equals(folderName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Opera GX found in {directory}!");

                    try
                    {
                        Directory.Delete(directory, true);
                        Console.WriteLine("Opera GX folder deleted successfully!");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete Opera GX folder: {ex.Message}");
                    }
                }

                if (SearchDirectory(directory, folderName, depth - 1))
                {
                    return true;
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Ignore unauthorized access exceptions.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to search directory {path}: {ex.Message}");
        }

        return false;
    }
}
