using System.Collections.Generic;
using System.Linq;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IStsMastRepository : IBaseRepository<StsMast>
    {
        List<StsMastModel> Select();
        List<StsMastModel> SelectAll();
        List<StsMastModel> SelectAllType();
        int UpdateById(StsMastModel data);
        int Insert(StsMastModel model);
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
                      orderby a.sortSeq,a.stsId
                      where a.recStatus == RecStatus.Active
                      select new StsMastModel
                          {
                              stsId = a.stsId,
                              stsCode = a.stsCode,
                              stsDesc = a.stsDesc,
                              updateDate = a.updateDate,
                              recStatus = a.recStatus,
                              sortSeq = a.sortSeq
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
                          orderby a.sortSeq, a.stsId
                          select new StsMastModel
                          {
                              stsId = a.stsId,
                              stsCode = a.stsCode,
                              stsDesc = a.stsDesc
                          }).ToList();
            rs.AddRange(fromDb);

            return rs;
        }
        public List<StsMastModel> SelectAllType()
        {

            var rs = (from a in _context.StsMasts
                      orderby a.sortSeq, a.stsId
                      select new StsMastModel
                      {
                          stsId = a.stsId,
                          stsCode = a.stsCode,
                          stsDesc = a.stsDesc,
                          updateDate = a.updateDate,
                          recStatus = a.recStatus,
                          sortSeq = a.sortSeq
                      }).ToList();

            return rs;
        }
        public int UpdateById(StsMastModel data)
        {
            var stsmast = _context.StsMasts.FirstOrDefault(p => p.stsId == data.stsId);
            if (stsmast != null)
            {
                stsmast.stsCode = data.stsCode;
                stsmast.stsDesc = data.stsDesc;
                stsmast.recStatus = data.recStatus;
                stsmast.sortSeq = data.sortSeq;
                stsmast.updateBy = data.updateBy;
                stsmast.updateDate = data.updateDate;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(StsMastModel model)
        {
            if (model != null)
            {
                var stsmast = new StsMast();
                stsmast.stsCode = model.stsCode;
                stsmast.stsDesc = model.stsDesc;
                stsmast.recStatus = model.recStatus;
                stsmast.sortSeq = model.sortSeq;
                stsmast.createBy = model.createBy;
                stsmast.createDate = model.createDate;
                _context.StsMasts.Add(stsmast);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
