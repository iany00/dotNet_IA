using System;
using System.Dynamic;
using System.Net.Http;
using Xunit;

namespace IntegrationTests
{
    public class ControllerTestsBase : IClassFixture<WebApiTestFactory>
    {
        protected HttpClient Client;
        protected dynamic Token;

        public ControllerTestsBase(WebApiTestFactory factory)
        {
          
        }
    }
}