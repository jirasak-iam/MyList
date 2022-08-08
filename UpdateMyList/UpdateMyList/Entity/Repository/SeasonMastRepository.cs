using System.Collections.Generic;
using System.Linq;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface ISeasonMastRepository : IBaseRepository<SeasonMast>
    {
        List<SeasonMastModel> Select();
        List<SeasonMastModel> SelectAll();
        List<SeasonMastModel> SelectAllType();
        int UpdateById(SeasonMastModel data);
        int Insert(SeasonMastModel model);
    }
    public class SeasonMastRepository : BaseRepository<SeasonMast>, ISeasonMastRepository
    {
        public SeasonMastRepository(myListEntities context)
            : base(context)
        {
        }

        public List<SeasonMastModel> Select()
        {
            var rs = new List<SeasonMastModel>();
            rs.Add(new SeasonMastModel 
            { 
                seasonId = 0,
                seasonCode = null,
                seasonDesc = null
            });
            rs.AddRange(from a in _context.SeasonMasts
                        orderby a.seaCode
                        where a.recStatus == RecStatus.Active
                        select new SeasonMastModel
                        {
                            seasonId = a.seaId,
                            seasonCode = a.seaCode,
                            seasonDesc = a.seaDesc,
                            recStatus = a.recStatus,
                            createBy = a.createBy,
                            createDate = a.createDate,
                            updateBy = a.updateBy,
                            updateDate = a.updateDate,
                            sortSeq = a.sortSeq,
                        });

            return rs.ToList();
        }
        public List<SeasonMastModel> SelectAll()
        {
            var rs = new List<SeasonMastModel>();
            rs.Add(new SeasonMastModel
            {
                sortSeq = 0,
                seasonId = 0,
                seasonCode = "0",
                seasonDesc = "All"
            }) ;
            rs.AddRange(from a in _context.SeasonMasts
                        orderby a.seaCode
                        where a.recStatus == RecStatus.Active
                        select new SeasonMastModel
                        {
                            seasonId = a.seaId,
                            seasonCode = a.seaCode,
                            seasonDesc = a.seaDesc,
                            recStatus = a.recStatus,
                            createBy = a.createBy,
                            createDate = a.createDate,
                            updateBy = a.updateBy,
                            updateDate = a.updateDate,
                            sortSeq = a.sortSeq,
                        });

            return rs.ToList();
        }
        public List<SeasonMastModel> SelectAllType()
        {
            var rs = (from a in _context.SeasonMasts
                      orderby a.seaCode
                      select new SeasonMastModel
                      {
                          seasonId = a.seaId,
                          seasonCode = a.seaCode,
                          seasonDesc = a.seaDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        public int UpdateById(SeasonMastModel data)
        {
            var model = _context.SeasonMasts.FirstOrDefault(p => p.seaId == data.seasonId);
            if (model != null)
            {
                model.seaCode = data.seasonCode;
                model.seaDesc = data.seasonDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.updateBy = data.updateBy;
                model.updateDate = data.updateDate;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(SeasonMastModel data)
        {
            if (data != null)
            {
                var model = new SeasonMast();
                model.seaCode = data.seasonCode;
                model.seaDesc = data.seasonDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.createBy = data.createBy;
                model.createDate = data.createDate;
                _context.SeasonMasts.Add(model);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
