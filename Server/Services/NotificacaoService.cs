using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Server.Services
{
    public static class NotificacaoService
    {        
        public static void EnviarNotificacao(string userId, string dog)
        {

            string OneSignalRestApiEndPoint = "https://onesignal.com/api/v1/notifications";
            string OneSignalRestAPIKey = "NzZlZDRiYTgtNjIwMS00OWE0LWFjMWUtMjU2MzZhNDI4Mzhl";
            string OneSignalAppApi = "c15eb0b0-0f36-4b0a-a9a5-d1ac179ecd45";

            var request = WebRequest.Create(OneSignalRestApiEndPoint)
                            as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            // One Signal Request Id
            request.Headers.Add("authorization", $"Basic {OneSignalRestAPIKey}");

            var obj = new
            {
                app_id = OneSignalAppApi,
                headings = new { en = "Findog" },
                contents = new { en = "O pet " + dog + " fugiu do raio!" },
                small_icon = "icon_notificacao",
                //large_icon = "0",
                included_segments = new string[] { "All" },
                //data = new { extra = notificacao.Extra, tipo = notificacao.Tipo },
                filters = new object[] { new { field = "tag", key = "UserId", value = userId } }, //Tags
            };


            var param = JsonConvert.SerializeObject(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                if (ex.Response != null)
                    System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            if (responseContent != null) System.Diagnostics.Debug.WriteLine(responseContent);
        }


    }
}