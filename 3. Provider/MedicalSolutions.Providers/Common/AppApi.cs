using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSolutions.Providers.Common
{
    public class AppApi
    {
        public static string token = string.Empty;
        public static string baseUrl = string.Empty;

        public static T GetAsync<T, Y>(string url, Y para, bool isHeader = true)
        {
            var resultApi = new ResultApi<T>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (isHeader)
                    DefaultRequestHeaders(httpClient);

                if (para != null)
                {
                    url += ParaToString(para);
                }

                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(jsonData))
                        resultApi.Result = JsonConvert.DeserializeObject<T>(jsonData);
                }
            }

            return resultApi.Result;
        }

        public static T PostAsync<T, Y>(string url, Y para, bool isHeader = true)
        {
            var resultApi = new ResultApi<T>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (isHeader)
                    DefaultRequestHeaders(httpClient);

                StringContent? stringContent = new StringContent(JsonConvert.SerializeObject(para), UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(url, stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(jsonData))
                        resultApi.Result = JsonConvert.DeserializeObject<T>(jsonData);
                }
            }

            return resultApi.Result;
        }

        public static T PutAsync<T, Y>(string url, Y para, bool isHeader = true)
        {
            var resultApi = new ResultApi<T>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (isHeader)
                    DefaultRequestHeaders(httpClient);

                StringContent? stringContent = new StringContent(JsonConvert.SerializeObject(para), UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PutAsync(url, stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(jsonData))
                        resultApi.Result = JsonConvert.DeserializeObject<T>(jsonData);
                }
            }

            return resultApi.Result;
        }

        public static T DeleteAsync<T, Y>(string url, Y para, bool isHeader = true)
        {
            var resultApi = new ResultApi<T>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (isHeader)
                    DefaultRequestHeaders(httpClient);

                if (para != null)
                    url += ParaToString(para);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(jsonData))
                        resultApi.Result = JsonConvert.DeserializeObject<T>(jsonData);
                }
            }

            return resultApi.Result;
        }

        private static void DefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
        }

        private static string ParaToString<T>(T para)
        {
            string resultString = @"";

            var props = para.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(para);
                if (value != null)
                    resultString += "$" + $"{prop.Name}" + $"{value}";
            }

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                var value = prop.GetValue(para);

                if (value != null)
                {
                    if (string.IsNullOrEmpty(resultString))
                        resultString += "$" + $"{prop.Name}" + "=" + $"{value}";
                    else
                        resultString += "&" + $"{prop.Name}" + "=" + $"{value}";
                }
            }

            return resultString;
        }
    }
}
