using DeviceDetectorNET;
using DMP.Dtos;
using DMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace DMP.Enrichers
{
    public static class UserAgentInfo
    {
        public static void UserAgent(EventDto eventDto, Event eventData)
        {
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36";

            var dd = new DeviceDetector(eventDto.UserAgent);
            dd.Parse();

            eventData.BrowserName = dd.GetBrowserClient().Match.Name;
            eventData.BrowserVersion = dd.GetBrowserClient().Match.Version;
            eventData.DeviceType = dd.GetDeviceName();
            eventData.DeviceFamily = dd.GetBrandName() + " " + dd.GetModel();
            eventData.DeviceOperatingSystem = dd.GetOs().Match.Name;
            eventData.DeviceOperatingSystemVersion = dd.GetOs().Match.Version;

            //Console.WriteLine("====== DeviceDetectorNET");
            //Console.WriteLine("isParsed: {0}", dd.IsParsed());
            //Console.WriteLine("isMobile: {0}", dd.IsMobile());
            //Console.WriteLine("isTablet: {0}", dd.IsTablet());
            //Console.WriteLine("isDesktop: {0}", dd.IsDesktop());
            //Console.WriteLine("====== result");
            //Console.WriteLine("deviceType: {0}", dd.GetDeviceName());
            //Console.WriteLine("device: {0} {1}", dd.GetBrandName(), dd.GetModel());
            //Console.WriteLine("client: {0} {1}", dd.GetBrowserClient().Match.Name, dd.GetBrowserClient().Match.Version);
            //Console.WriteLine("os: {0} {1} {2}", dd.GetOs().Match.Name, dd.GetOs().Match.Platform, dd.GetOs().Match.Version);
            //Console.WriteLine("======");
            //Console.WriteLine("OS: " + dd.GetOs());
            //Console.WriteLine("DeviceName: " + dd.GetDeviceName());
            //Console.WriteLine("Brand: " + dd.GetBrand());
            //Console.WriteLine("BrandName: " + dd.GetBrandName());
            //Console.WriteLine("Model: " + dd.GetModel());
            //Console.WriteLine("Client: " + dd.GetClient());
            //Console.WriteLine("BrowserClient: " + dd.GetBrowserClient());
            //var uaParser = Parser.GetDefault();
            //var client = uaParser.Parse(eventDto.UserAgent);
            //Console.WriteLine("====== UA-Parser");
            //Console.WriteLine("Browser " + client.UA);
            //Console.WriteLine(client.OS);
            //Console.WriteLine(client.Device);
        }
    }
}
