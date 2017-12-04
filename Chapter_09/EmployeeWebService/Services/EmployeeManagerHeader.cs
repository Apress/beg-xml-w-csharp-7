using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using EmployeeWebService.Models;
using System.Data.Entity;

namespace EmployeeWebService.Services
{
    public class EmployeeManagerHeader:SoapHeader
    {
        public string ClientKey { get; set; }
    }
}