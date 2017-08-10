using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MillData.Models;
using Microsoft.EntityFrameworkCore;

namespace MillData.Models
{
    public class MillSearchModel
    {
        public int? MillId { get; set; }
        public void getID(int id)
        {
            //TODO: implement or delete
            
        }
    }

   
}
