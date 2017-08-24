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

/****************************************************************************
* CLASS: MillSearchLogic
* This class handles application-wide mill search logic, such as
* the getMillKeyFromId query.
* 
* METHODS: 
*      getMillKeyFromId: Gets a MillKey from a MillID 
* ***************************************************************************/
namespace MillData.Models
{
    public class MillSearchLogic
    {
        private readonly MillDataContext db;

        public MillSearchLogic(MillDataContext context)
        {
            db = context;
        }

        //Gets the Mill Key corresponding to that Mill ID
        public int? getMillKeyFromId(int? id)
        {
            var results = db.MillInformation.Where(m => m.MillId == id)
                            .Select(u => new { key = u.PkMillKey }).SingleOrDefault();

            if (results != null)
                 return results.key;
            else
                return 0;
          
        }
    }
}
