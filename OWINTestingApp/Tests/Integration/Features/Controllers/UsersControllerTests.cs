using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OWINTestingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;


namespace OWINTestingApp.Tests.Integration.Features.Controllers
{
    [TestClass]
    public class UsersControllerTests
    {
        private static IDisposable _webApp;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            _webApp = WebApp.Start<Startup>("http://localhost:9443/");
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            _webApp.Dispose();
        }

        [TestMethod]
        public async Task TestGetAllUsers()
        {
            using (var httpClient = new HttpClient())
            {
                // Arrange
                var uri = new Uri("http://localhost:9443/api/users");

                // Act
                var response = await httpClient.GetAsync(uri);
                var responseContent = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<List<User>>(responseContent)
                    .FirstOrDefault();

                // Assert
                Assert.IsNotNull(user);
                Assert.IsInstanceOfType(user, typeof(User));
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}