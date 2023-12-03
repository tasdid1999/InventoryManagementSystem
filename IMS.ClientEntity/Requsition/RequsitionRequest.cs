using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMS.ClientEntity.Requsition
{

    
    public class RequsitionRequest
    { 
        public List<RequsitionDetailsRequest> RequsitionDetails { get; set; }
    }
}
