using InMaFSS.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InMaFSS
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string mode = args.Length > 0 && args[0] != "gui" ? "cmd" : "gui"; //default to gui

            if (mode == "gui")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                //Get a pointer to the forground window.  The idea here is that
                //IF the user is starting our application from an existing console
                //shell, that shell will be the uppermost window.  We'll get it
                //and attach to it
                IntPtr ptr = GetForegroundWindow();

                int u;

                GetWindowThreadProcessId(ptr, out u);

                Process process = Process.GetProcessById(u);

                if (process.ProcessName == "cmd")    //Is the uppermost window a cmd process?
                {
                    AttachConsole(process.Id);
                }
                else
                {
                    //no console AND we're in console mode ... create a new console.
                    AllocConsole();
                }

                RunConsole(args);

                FreeConsole();
            }
        }

        static void WriteHeadline(String line)
        {
            Console.WriteLine();

            if (line != "")
                WriteHeadline("");

            int num = Console.WindowWidth;

            int startOfWord = num / 2 - line.Length / 2;
            int endOfWord = startOfWord + line.Length;

            for (int i = 0; i < num; i++)
            {
                if (i >= startOfWord && i <= endOfWord)
                {
                    if (i == startOfWord)
                        Console.Write(line);

                    continue;
                }

                Console.Write("=");
            }

            if (line != "")
                WriteHeadline("");

            Console.WriteLine();
        }

        static void RunConsole(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();

            Settings Settings = Settings.Default;

            for (int i = 0; i < args.Length; i++)
            {
                String arg = args[i];

                if (arg.StartsWith("--"))
                {
                    String cmd = arg.Substring(2);

                    String value = "";

                    if (cmd.IndexOf("=") >= 0)
                    {
                        value = cmd.Substring(cmd.IndexOf("=") + 1);
                        cmd = cmd.Substring(0, cmd.IndexOf("="));
                    }

                    switch (cmd)
                    {
                        case "show":
                            switch (value)
                            {
                                case "config":

                                    WriteHeadline("CONFIG");

                                    Console.WriteLine("Consumer-Key = " + Settings.ConsumerKey);
                                    Console.WriteLine("Consumer-Secret = " + Settings.ConsumerSecret);
                                    Console.WriteLine("URL = " + Settings.URL);

                                    Console.WriteLine("FILES:");

                                    foreach (String file in Settings.Files)
                                        Console.WriteLine("       " + file);

                                    WriteHeadline("END OF CONFIG");

                                    break;
                            }
                            break;

                        case "set":
                            if (i + 1 < args.Length)
                            {
                                String setKey = args[i + 1];
                                if (setKey.StartsWith("--") || !setKey.Contains("="))
                                    continue;

                                String setValue = setKey.Substring(setKey.IndexOf("=") + 1);
                                setKey = setKey.Substring(0, setKey.IndexOf("="));

                                switch (setKey.ToLower())
                                {
                                    case "consumerkey":
                                        Settings.ConsumerKey = setValue;
                                        break;
                                    case "consumersecret":
                                        Settings.ConsumerSecret = setValue;
                                        break;
                                    case "url":
                                        Settings.URL = setValue;
                                        break;
                                }

                                Settings.Save();
                            }
                            break;

                        case "files":
                        case "file":
                            if (i + 2 < args.Length)
                            {
                                String action = args[i + 1];
                                String file = args[i + 2];

                                switch (action)
                                {
                                    case "add":
                                        if (!File.Exists(file))
                                            Console.WriteLine("File does not exist: " + file);
                                        else
                                            if (Settings.Files.Contains(file))
                                                Console.WriteLine("File is in list yet");
                                            else
                                            {
                                                Settings.Files.Add(file);
                                                Console.WriteLine("File added to list: " + file);
                                            }
                                        break;
                                    case "remove":
                                        if (!Settings.Files.Contains(file))
                                            Console.WriteLine("File is not in list: " + file);
                                        else
                                            Settings.Files.Remove(file);
                                        Console.WriteLine("File removed from list: " + file);
                                        break;
                                }

                                Settings.Save();
                            }
                            break;
                        case "upload":
                            WriteHeadline("Begin of Upload");

                            Upload upload = new Upload(delegate(String msg)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(msg);
                                Console.ForegroundColor = ConsoleColor.White;
                            });

                            String result = upload.Do();

                            Console.WriteLine(result);

                            WriteHeadline("End of Upload");

                            break;
                    }
                }
            }
        }
    }
}
