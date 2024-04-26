using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using System.Linq;
using System.Net.Http.Headers;
using TestProject1.PageObjects;
using TestProject1.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Tests
{
    //[Parallelizable(ParallelScope.All)]
    public class Tests : Base
    {
               

        [Test]
        public void DisclosureMenuItemDisplayed()
        {
            String expectedDisclosureMenuItem = "ESG DISCLOSURE";

            HaloHomePage haloHomePage = new HaloHomePage(GetDriver());
            var mainMenuButtonName = haloHomePage.GetDisclosureMainMenuItem().Text;
            Assert.That(mainMenuButtonName, Is.EqualTo(expectedDisclosureMenuItem));
            // StringAssert.AreEqualIgnoringCase(expectedDisclosureMenuItem, mainMenuButtonName);
        }


        [Test]
        public void DisclosureAdminSettingsDisplayed()
        {
            String expectedAdminSettingsTitle = "ESG Disclosure Settings";

            HaloHomePage haloHomePage = new HaloHomePage(GetDriver());
            haloHomePage.GetDisclosureMainMenuItem().Click();
            AdminSettingsPage adminSettingsPage = new AdminSettingsPage(GetDriver());
            String existingAdminSettingTitle = adminSettingsPage.GetAdminSettingsTitle();
            Assert.That(existingAdminSettingTitle, Is.EqualTo(expectedAdminSettingsTitle));
        }
        
        [Test]
        public async Task GETAsync()
        {
            HttpClient req = new HttpClient();
            req.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJraWQiOiJiL082T3ZWdjEreStXZ3JINVVpOVdUaW9MdDA9IiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiJvc3RydXR5bnNrMDAxIiwiYXVkaXRUcmFja2luZ0lkIjoiMzc1YzEyNGQtM2RiYy00MDk1LWIzYjQtODEzY2QxZTRiM2QyLTEyODIxNjYiLCJjb3VudHJ5Y29kZSI6IkxVIiwiaXNzIjoiaHR0cHM6Ly9sb2dpbi1zdGcucHdjLmNvbTo0NDMvb3BlbmFtL29hdXRoMiIsInRva2VuTmFtZSI6ImlkX3Rva2VuIiwidWlkIjoib3N0cnV0eW5zazAwMSIsImFjciI6IjQiLCJhenAiOiJ1cm46UHdDSGFsby1MdXgtT3BlbkFNLVN0YWdlIiwiYXV0aF90aW1lIjoxNzEyMTQ5MjM1LCJleHAiOjE3MTIxODU1MTksImlhdCI6MTcxMjE0OTUxOSwiZW1haWwiOiJvbGVnLnN0cnV0eW5za3lpQGx1LnB3Yy5jb20iLCJjbG91ZEVtYWlsIjoib2xlZy5zdHJ1dHluc2t5aUBwd2MubHUiLCJlbXBsb3llZXR5cGUiOiJDb250cmFjdG9yIiwiUHdDbG9zIjoiSUZTIiwicHdjR2xvYmFsR3JhZGVOYW1lIjoiQXNzb2NpYXRlIiwiZ2l2ZW5fbmFtZSI6Ik9sZWciLCJub25jZSI6IjYzODQ3NzQ2MzE4ODQxMDcxNy5ZakE1TmpVeE5XSXRZMk5pTWkwME9HRTVMVGhrTURBdE9UazRZakJsT0RNNU5qUTJaR1l4WmpjNE5tSXROamM1WkMwME1HWmhMVGhtWTJFdE1UazRaRGc0TkdGa1lUTTQiLCJwcmVmZXJyZWRNYWlsIjoib2xlZy5zdHJ1dHluc2t5aUBwd2MubHUiLCJMT1MiOiJJbnRlcm5hbCBGaXJtIFNlcnZpY2VzIiwiYXVkIjoidXJuOlB3Q0hhbG8tTHV4LU9wZW5BTS1TdGFnZSIsImNfaGFzaCI6IkJEQVlFLW5nT3NiX0NubkZHeVI5NlEiLCJ1cG4iOiJvbGVnLnN0cnV0eW5za3lpQGx1LnB3Yy5jb20iLCJvcmcuZm9yZ2Vyb2NrLm9wZW5pZGNvbm5lY3Qub3BzIjoiYW9FSHdwdy1HODdyMmE5dVpiVW5oWUhseDFVIiwic19oYXNoIjoiQUtJbUhzcTdpckVKbzBhb0dmZ3dkQSIsIm5hbWUiOiJPbGVnIFN0cnV0eW5za3lpIiwicmVhbG0iOiIvcHdjIiwidG9rZW5UeXBlIjoiSldUVG9rZW4iLCJmYW1pbHlfbmFtZSI6IlN0cnV0eW5za3lpIn0.RBK5Uvwwx5gwLQlKOnwb1iX7ILI__W4y3N54WFMrXO2Sbeb1fcXJ-ATI5yd9gLBIz1iGZzdcT_k0x8dmLpBzrv8pRePMHOsUWWoiOWJCnnO_dYYk_mDa7F1Z1D0aiX1cbQlWI3XUj-0jviYSnvWgX7Z_fmumFUt-hYjlqrtZGdJZ3GIZ7yifNGQAiayixpac5AfMv7kBmkWaytxSyY5lGLILOLqBzHvu4l99Ez25cvlgQFLkVagUbb5qp0rXirKa5l7XukUG6yNwBcgDidCes1L1JvN90BybV2y3RzGk1HAhiZRDIJ26197_epyresWhpP8rZIa0H-C77swg1W4NGg");

            var content = await req.GetAsync("https://lux-qa.pwchalo.com/esgcheck/api/sources");
            Console.WriteLine(await content.Content.ReadAsStringAsync());
        }

        /*[Test]
        public async Task GETAsync22()
        {
            var url = "https://lux-qa.pwchalo.com/esgcheck/api/sources";

            var request = System.Net.WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
        }*/
    }
}