using InMaFSS.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace InMaFSS
{
    public class AuthHelper
    {
        static String APIUrl;
        static String TokenEndpoint;
        static String consumerKey;
        static String consumerSecret;

        private static String AccessToken;

        public static void Init()
        {
            Settings Settings = Settings.Default;
            String baseURL = Settings.URL;
            APIUrl = baseURL + "api/v1/";
            TokenEndpoint = baseURL + "oauth2/token.php";
            consumerKey = Settings.ConsumerKey;
            consumerSecret = Settings.ConsumerSecret;
        }


        private static String GetAccessToken()
        {
            String access_token = null;

            using (WebClient client = new WebClient())
            {
                NameValueCollection post = new NameValueCollection();
                post.Set("grant_type", "client_credentials");
                post.Set("client_id", consumerKey);
                post.Set("client_secret", consumerSecret);
                post.Set("scope", "update_substitutions update_mensa update_events");

                try
                {
                    byte[] response = client.UploadValues(TokenEndpoint, post);
                    XmlReader reader = JsonReaderWriterFactory.CreateJsonReader(response, System.Xml.XmlDictionaryReaderQuotas.Max);

                    while (reader.Read())
                    {
                        if (reader.Name == "access_token")
                        {
                            access_token = reader.ReadElementString();
                            break;
                        }

                    }
                }
                catch (WebException e)
                {
                    if (e.Response == null)
                        return null;

                    StreamReader read = new StreamReader(e.Response.GetResponseStream());
                    String res = read.ReadToEnd();
                    return null;
                }
            }

            return access_token;
        }

        public static HttpWebRequest PrepareRequest(String endpoint)
        {
            if (AccessToken == null)
                AccessToken = GetAccessToken();

            // If we were not able to obtain an access token, the value will still be null
            if (AccessToken == null)
                return null;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(APIUrl + endpoint);
            req.Headers.Add("Authorization", "OAuth2 " + AccessToken);
            return req;
        }

        public static String SendMultipartRequest(HttpWebRequest req, List<FileContainer> files)
        {
            String boundary = "fmnfmsdl4bnv943hskvnsdklgnsfdkagb";
            req.ContentType = "multipart/form-data, boundary=" + boundary;
            req.Method = "POST";

            Stream s = req.GetRequestStream();

            for (int i = 0; i < files.Count; i++ )
            {
                FileContainer file = files[i];
                String fileName = Path.GetFileName(file.file);
                
                WriteToStream(s, "--" + boundary + "\r\n");
                WriteToStream(s, "content-disposition: form-data; name=\"userfile" + i + "\"; filename=\"" + fileName + "\"\r\n");
                WriteToStream(s, "Content-Type: "+file.mimeType+"\r\n");
                WriteToStream(s, "Content-Transfer-Encoding: binary\r\n\r\n");
                WriteToStream(s, File.ReadAllBytes(file.file));
                WriteToStream(s, "\r\n");
            }

            WriteToStream(s, "--"+boundary+"--\r\n");
            
            return SendRequest(req);
        }

        private static void WriteToStream(Stream s, String val)
        {
            byte[] data = Encoding.UTF8.GetBytes(val);
            WriteToStream(s, data);
        }

        private static void WriteToStream(Stream s, byte[] data)
        {
            s.Write(data, 0, data.Length);
        }

        public static String SendRequest(HttpWebRequest req)
        {
            try
            {
                using (WebResponse resp = req.GetResponse())
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                StreamReader read = new StreamReader(e.Response.GetResponseStream());
                return read.ReadToEnd();
            }
        }
    }
}
