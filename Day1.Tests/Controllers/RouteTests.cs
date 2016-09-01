using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;
using Day1.Controllers;
using Moq;

namespace Day1.Tests.Controllers
{
    [TestClass]
    public class RouteTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(
                It.IsAny<string>())).Returns<string>(s => s);

            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private bool TestIncomingRouteResult(RouteData routeResult,
            string controller, string action, object propertySet = null)
        {

            Func<object, object, bool> valCompare = (v1, v2) => StringComparer.InvariantCultureIgnoreCase
                .Compare(v1, v2) == 0;

            var result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet == null) return result;
            PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
            if (propInfo.Any(pi => !(routeResult.Values.ContainsKey(pi.Name)
                                     && valCompare(routeResult.Values[pi.Name],
                                         pi.GetValue(propertySet, null)))))
            {
                result = false;
            }
            return result;
        }

        private void TestRouteMatch(string url, string controller, string action,
    object routeProperties = null, string httpMethod = "GET")
        {
            // Организация
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Действие - обработка маршрута
            RouteData result
                = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Утверждение
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller,
                action, routeProperties));
        }

        private void TestRouteFail(string url)
        {
            // Организация
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Действие - обработка маршрута
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // Утверждение
            Assert.IsTrue(result?.Route == null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/Home/Index/aabbbb", "Home", "Index");

            TestRouteMatch("~/Home/Index/aaaaaa", "Home", "Index");

            TestRouteFail("~/Home/Index/123");
            TestRouteFail("~/Home");
        }
    }
}
