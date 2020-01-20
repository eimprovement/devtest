using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public static  class Extensions
    {
        public static string ToJsonSerialize<T>(this T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToJsonDeserialize<T>(this T obj, string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static IRestResponse RestRequest(string endpoint, Method methodEnum, Dictionary<string,string> apiKey = null,string ContentType = null,string data = null, int attempts = 5)
        {             
            int counter = 0;

            IRestResponse response = null;

            while (counter <= attempts)
            {
                try
                {
                    var client = new RestClient(endpoint);

                    var request = new RestRequest(methodEnum);

                    if (apiKey != null)
                    {
                        request.AddHeader(apiKey.First().Key, apiKey.First().Value);
                    }

                    if (ContentType != null)
                    {
                        request.AddHeader("Content-Type", ContentType);
                    }

                    if (data != null)
                    {
                        request.AddParameter("undefined", data, ParameterType.RequestBody);
                    }

                    response = client.Execute(request);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception($"error endpoint:{endpoint} details:{response.StatusDescription}");
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    if (counter == attempts)
                    {
                        throw ex;
                    }

                    counter++;
                }
            }

            return response;
        }

    }
}
