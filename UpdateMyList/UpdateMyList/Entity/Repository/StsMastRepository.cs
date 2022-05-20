using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IStsMastRepository : IBaseRepository<StsMast>
    {
        List<StsMastModel> Select();
        List<StsMastModel> SelectAll();
    }
    public class StsMastRepository : BaseRepository<StsMast>, IStsMastRepository
    {
        public StsMastRepository(myListEntities context)
            : base(context)
        {
        }
        public List<StsMastModel> Select()
        {

            var rs = (from a in _context.StsMasts
                          select new StsMastModel
                          {
                              stsId = a.stsId,
                              stsCode = a.stsCode,
                              stsDesc = a.stsDesc
                          }).ToList();

            return rs;
        }
        public List<StsMastModel> SelectAll()
        {
            List<StsMastModel> rs = new List<StsMastModel>();

            var all = new StsMastModel
            {
                stsId = 0,
                stsCode = "0",
                stsDesc = "All"
            };
            rs.Add(all);

            var fromDb = (from a in _context.StsMasts
                          select new StsMastModel
                          {
                              stsId = a.stsId,
                              stsCode = a.stsCode,
                              stsDesc = a.stsDesc
                          }).ToList();
            rs.AddRange(fromDb);

            return rs;
        }

    }
}
