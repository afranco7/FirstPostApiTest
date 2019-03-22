using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstAPIRequest.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPIRequest
{
    class Request
    {
        public static string MyFirstGet()
        {

            string result;
            HttpWebResponse response;
            JObject responseBody;
            string payload = JsonConvert.SerializeObject(DataProvider.Persona1());
            //string APIurl = "https://httpbin.org/get?nombre=Alejandro&age=32";

            string APIurl = "https://httpbin.org/post";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIurl);
            request.Method = "POST";
            //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            //request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.ContentType = "application/json; charset=utf-8";

            Debug.WriteLine("Attempting to call TFS Rest API: " + APIurl);

            try
            {
                 if (request.Method == "PATCH" || request.Method == "POST" || request.Method == "PUT")
                 {
                     //https://httpbin.org/post
                     using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                     {
                         Debug.WriteLine("...Attempting to build Post/Patch request");
                         streamWriter.Write(payload);
                     }
                 }
                using (response = (HttpWebResponse)request.GetResponse())
                {

                    using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                    {
                        result = rdr.ReadToEnd();
                        responseBody = JObject.Parse(result);
                        // int age = (int)responseBody["args"]["age"];
                        int age = (int)responseBody["json"]["Age"];


                        Debug.WriteLine(result);
                    }
                }
            }
            catch (WebException e)
            {
                HttpWebResponse res = (HttpWebResponse)e.Response;

                using (StreamReader rdr = new StreamReader(res.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }

                responseBody = JObject.Parse(result);
                string errorMessage = responseBody.ToString();

                Assert.Fail(errorMessage);
            }

            return result;
        }
    }
}
