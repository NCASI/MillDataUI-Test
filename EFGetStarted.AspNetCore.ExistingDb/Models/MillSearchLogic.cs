using System.Linq;

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

        public int? getMillIdFromKey(int? key)
        {
            var results = db.MillInformation.Where(m => m.PkMillKey == key)
                            .Select(u => new { id = u.MillId }).SingleOrDefault();

            if (results != null)
                return results.id;
            else
                return 0;

        }

        public int? getFacilityKeyFromMillKey(int? id)
        {
            int? millkey = getMillKeyFromId(id);


            if (millkey > 0)
            {
                var results = db.Env_Facility.Where(m => m.PkEnvFacilityKey == millkey)
                                    .Select(u => new { key = u.PkEnvFacilityKey }).SingleOrDefault();
                return results.key;
            }
            else
                return 0;
        }
    }
}
