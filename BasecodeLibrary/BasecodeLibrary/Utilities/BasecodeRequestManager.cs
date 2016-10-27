using BasecodeLibrary.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasecodeLibrary.Utilities
{
    public static class BasecodeRequestManager
    {
        private static HttpClient _Request = new HttpClient() { Timeout = new TimeSpan(0, 0, 20) };

        public static async Task<HttpResponseMessage> BeginRequest(string url)
        {
            HttpResponseMessage response = null;

            try
            {               
                response = await _Request.GetAsync(url);
            }
            catch(Exception error)
            {
                BaseCodePageContainer.DispalyErrorMessage("An error occured while attempting to make a request for your data. Please check your connection and try to reload the application");
                Debug.WriteLine(error.Message);
                Debug.WriteLine(error.StackTrace);
            }

            return response;
        }
    }
}
