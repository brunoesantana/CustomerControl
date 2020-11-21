using RestSharp;
using System;
using System.Collections.Generic;

namespace CustomerControl.CrossCutting.Helper
{
    public class ApiHelper<T> where T : class
    {
        public IRestResponse<List<T>> SendRequest(string url, Method method)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(method);

                return client.Execute<List<T>>(request);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}