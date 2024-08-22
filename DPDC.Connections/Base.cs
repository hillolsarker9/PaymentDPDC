using DPDC.Manager.Connections;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DPDC.Connections
{
    public abstract class Base
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Base(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string DPDC = "DPDC";

        //protected IDatabaseHub DatabaseHub = new DatabaseHub();
        //protected IDatabaseHub DatabaseHubRpt = new DatabaseHubRpt();

        public string GetClientIP()
        {
            var clientIp = "";
            var context = _httpContextAccessor.HttpContext;

            // Check if HttpContext or RemoteIpAddress is null
            if (context == null || context.Connection == null || context.Connection.RemoteIpAddress == null)
            {
                return "";
            }
            else
            {
                clientIp = context.Connection.RemoteIpAddress.ToString();
                // Add custom conditions here, e.g., filtering local IPs
                if (clientIp == "::1" || clientIp.StartsWith("192.168"))
                {
                    return "Local"; // Handle local IPs differently
                }  
            }
            return clientIp;
        }

    }
}
