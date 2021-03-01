using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearch.Web.Application.Client
{
    public static class StaticApiClient
    {
        private static swaggerClient _client;
        public static swaggerClient Client
        {
            get => _client ??= new swaggerClient(new System.Net.Http.HttpClient());
        }
    }
}
