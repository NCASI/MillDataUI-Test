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
    public class MillSearchLogic
    {
        private MillDataContext MillContext;
        private DbContextOptions<MillDataContext> options;

        public MillSearchLogic()
        {
            MillContext = new MillDataContext(options);
        }

        public IQueryable<MillInformation> SearchMill(MillSearchModel searchModel)
        {
            var result = MillContext.MillInformation.AsQueryable();

            if (searchModel != null)
            {
                result = result.Where(x => x.MillId == searchModel.MillId);
            }


            return result;
        }
    }
}
