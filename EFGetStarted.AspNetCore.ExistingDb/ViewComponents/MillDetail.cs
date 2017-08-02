using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;

namespace MillData.ViewComponents
{

    public class MillDetail : ViewComponent
    {
        private readonly MillDataContext db;

        public MillDetail(MillDataContext context)
        {
            db = context;
        }

        //public  IViewComponentResult InvokeAsync(
        //int id)
        //{
        //    var items =   GetItems(id);
        //    return View(items);
        //}
        private IViewComponentResult GetItems(int id)
        {

         
            var result = from n in db.MillInformation
                         join c in db.ProductionData on n.PkMillKey equals c.FkMillKey
                         select n.Comments;

            return View(result);
        }
    }
}