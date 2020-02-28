using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using log4net;
using Newtonsoft.Json;
using Exception = System.Exception;

using System.Net.Http.Headers;
using System.Threading.Tasks;

public static class ApiClient{
        private static string ApiToken = "your token";
        public static string UserId;
        private static ILog _log = LogManager.GetLogger(typeof(ApiClient));
        public static IList<T> TryGetList<T>(string url, out string error)
        {
            return TryGetOne<List<T>>(url, out error);
        }

        public static T TryGetOne<T>(string url,
            out string error)
        {
            return GetOrPost<T>(url, "", out error, "GET");
        }
        public static IList<T> SearchList<T>(string url, string jsonData, out string error)
        {
            return GetOrPost<List<T>>(url, jsonData, out error, "POST");
        }
        public static T Search<T>(string url, string jsonData, out string error)
        {
            return GetOrPost<T>(url, jsonData, out error, "POST");
        }
        public static T Post<T>(string url, string jsonData, out string error)
        {
            return GetOrPost<T>(url, jsonData, out error, "POST");
        }
        public static T Put<T>(string url, string jsonData, out string error)
        {
            return GetOrPost<T>(url, jsonData, out error, "PUT");
        }
        public static T Delete<T>(string url, out string error)
        {
            return GetOrPost<T>(url, "", out error, "DELETE");
        }

        public static HttpResponseMessage GetRaw(string url, out string error)
        {
            return GetOrPostRaw(url, "", out error, "GET");
        }
        public static HttpResponseMessage PostRaw(string url, string jsonData, out string error)
        {
            return GetOrPostRaw(url, jsonData, out error, "POST");
        }
        public static HttpResponseMessage PutRaw(string url, string jsonData, out string error)
        {
            return GetOrPostRaw(url, jsonData, out error, "PUT");
        }
        public static HttpResponseMessage DeleteRaw(string url, out string error)
        {
            return GetOrPostRaw(url, "", out error, "DELETE");
        }

        public static bool Post(string url, string jsonData, out string error)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Add("Api_Token", ApiToken);
                    http.DefaultRequestHeaders.Add("UserId", UserId.ToString());

                    HttpResponseMessage ret = http.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"))
                        .Result;


                    if (ret.IsSuccessStatusCode)
                    {
                        var str = ret.Content.ReadAsStringAsync().Result;
                        _log.Debug($"[VMSApi Update] remote result :{str}");
                        error = "";
                        return true;
                    }
                    else
                    {
                        _log.Error($"remote return status code {(int)ret.StatusCode}");
                        error = ret.Content.ReadAsStringAsync().Result;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                _log.Error(ex);

                error = ex.Message;
                return false;
            }
        }


        private static T GetOrPost<T>(string url, string jsonData, out string error, string method)
        {
            method = method.ToUpper();
            try
            {

                var ret = GetOrPostRaw(url, jsonData, out error, method);
                if (ret.IsSuccessStatusCode)
                {
                    var str = ret.Content.ReadAsStringAsync().Result;
                    var jsonArr = JsonConvert.DeserializeObject<T>(str);

                    error = "";
                    return jsonArr;
                }
                else
                {
                    _log.Error($"remote return status code {(int)ret.StatusCode}");
                    error = ret.Content.ReadAsStringAsync().Result;
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                error = ex.Message;
                _log.Error(ex);
                return default(T);
            }
        }

        private static HttpResponseMessage GetOrPostRaw(string url, string jsonData, out string error, string method)
        {
            method = method.ToUpper();
            try
            {
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Add("Api_Token", ApiToken);
                    if (!string.IsNullOrEmpty(UserId)){ 
                     http.DefaultRequestHeaders.Add("UserId", UserId);
                    }

                    HttpResponseMessage ret = null;
                    if (method == "GET")
                    {
                        ret = http.GetAsync(url).Result;
                    }
                    else if (method == "POST")
                    {
                        ret = http.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"))
                            .Result;
                    }
                    else if (method == "PUT")
                    {
                        ret = http.PutAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"))
                            .Result;
                    }
                    else if (method == "DELETE")
                    {
                        ret = http.DeleteAsync(url)
                            .Result;
                    }
                    else
                    {
                        throw new NotSupportedException();
                    }

                    error = "";
                    return ret;

                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                _log.Error(ex);
                return null;
            }
        }


        public static HttpResponseMessage PostFile(byte[] fileBytes,string name, string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Api_Token", ApiToken);
                    client.DefaultRequestHeaders.Add("UserId", UserId.ToString());

                    using (var content = new MultipartFormDataContent())
                    {
                        //byte[] fileBytes = new byte[file.InputStream.Length + 1];
                        //file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                        var fileContent = new ByteArrayContent(fileBytes);
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = name };
                        content.Add(fileContent);
                        var ret = client.PostAsync(url, content).Result;
                        return ret;
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

}