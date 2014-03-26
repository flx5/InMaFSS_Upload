using InMaFSS.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InMaFSS
{
    public delegate void OnWarning(String msg);

    class Upload
    {
        OnWarning mOnWarning;

        public Upload(OnWarning OnWarning)
        {
            this.mOnWarning = OnWarning;
        }

        public String Do()
        {
            String[] status = new String[3];
            status[0] = "Replacements: " + DoUpload(GetSubstitionFiles(), "replacements");
            status[1] = "Mensa: " + DoUpload(GetMensaFiles(), "mensa");
            status[2] = "Appointments: " + DoUpload(GetAppointmentFiles(), "appointments");

            return String.Join("\n\n", status);
        }

        private List<FileContainer> GetMensaFiles()
        {
            return GetFiles("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        private List<FileContainer> GetAppointmentFiles()
        {
            return GetFiles("ics", "text/calendar");
        }

        private List<FileContainer> GetSubstitionFiles()
        {
            return GetFiles("html", "text/html");
        }

        private List<FileContainer> GetFiles(String extension, String type)
        {
            List<FileContainer> files = new List<FileContainer>();
            Settings Settings = Settings.Default;
            if (Settings.Files == null)
                Settings.Files = new StringCollection();

            foreach (String file in Settings.Files)
            {
                if (!File.Exists(file))
                {
                    this.mOnWarning("Die Datei \"" + file + "\" existiert nicht");
                    continue;
                }

                if (Path.GetExtension(file) != "."+extension)
                    continue;

                files.Add(new FileContainer(file, type));
            }
            return files;
        }

        private String DoUpload(List<FileContainer> files, String endpoint)
        {
            if (files.Count == 0)
                return "NO FILE TO UPLOAD";
            // Ignore self signed SSL
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            AuthHelper.Init();
            HttpWebRequest req = AuthHelper.PrepareRequest(endpoint);

            if (req == null)
                return "FAILURE";

            return AuthHelper.SendMultipartRequest(req, files);
        }
    }
}
