using System.Collections.Generic;
using System.Linq;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface ISeasonMastRepository : IBaseRepository<SeasonMast>
    {
        List<SeasonMastModel> Select(int listTypeId);
        List<SeasonMastModel> SelectAll(int listTypeId);
        List<SeasonMastModel> SelectAllType();
        #region temp
        //int UpdateById(SeasonMastModel data);
        //int Insert(SeasonMastModel model);
        #endregion

    }
    public class SeasonMastRepository : BaseRepository<SeasonMast>, ISeasonMastRepository
    {
        public SeasonMastRepository(myListEntities context)
            : base(context)
        {
        }

        public List<SeasonMastModel> Select(int listTypeId)
        {
            var groups = _context.SeasonGroups
                .Where(p => p.recStatus == RecStatus.Active && p.lisTypetId == listTypeId)
                .Select(o => o.seaId)
                .ToList();

            var rs = new List<SeasonMastModel>();
            rs.Add(new SeasonMastModel
            {
                seaId = 0,
                seaCode = null,
                seaDesc = string.Empty
            });
            if (groups.Count > 0)
            {
                rs.AddRange(from a in _context.SeasonMasts
                            orderby a.seaCode
                            where a.recStatus == RecStatus.Active && groups.Contains(a.seaId)
                            select new SeasonMastModel
                            {
                                seaId = a.seaId,
                                seaCode = a.seaCode,
                                seaDesc = a.seaDesc,
                                recStatus = a.recStatus,
                                createBy = a.createBy,
                                createDate = a.createDate,
                                updateBy = a.updateBy,
                                updateDate = a.updateDate,
                                sortSeq = a.sortSeq,
                            });
            }
            else
            {
                rs.AddRange(from a in _context.SeasonMasts
                            orderby a.seaCode
                            where a.recStatus == RecStatus.Active
                            select new SeasonMastModel
                            {
                                seaId = a.seaId,
                                seaCode = a.seaCode,
                                seaDesc = a.seaDesc,
                                recStatus = a.recStatus,
                                createBy = a.createBy,
                                createDate = a.createDate,
                                updateBy = a.updateBy,
                                updateDate = a.updateDate,
                                sortSeq = a.sortSeq,
                            });
            }


            return rs.ToList();
        }
        public List<SeasonMastModel> SelectAll(int listTypeId)
        {
            var groups = _context.SeasonGroups
                .Where(p => p.recStatus == RecStatus.Active && p.lisTypetId == listTypeId)
                .Select(o => o.seaId)
                .ToList();

            var rs = new List<SeasonMastModel>();
            rs.Add(new SeasonMastModel
            {
                sortSeq = 0,
                seaId = 0,
                seaCode = "0",
                seaDesc = "All"
            });
            if (groups.Count > 0)
            {
                rs.AddRange(from a in _context.SeasonMasts
                            orderby a.seaCode
                            where a.recStatus == RecStatus.Active && groups.Contains(a.seaId)
                            select new SeasonMastModel
                            {
                                seaId = a.seaId,
                                seaCode = a.seaCode,
                                seaDesc = a.seaDesc,
                                recStatus = a.recStatus,
                                createBy = a.createBy,
                                createDate = a.createDate,
                                updateBy = a.updateBy,
                                updateDate = a.updateDate,
                                sortSeq = a.sortSeq,
                            });
            }
            else
            {
                rs.AddRange(from a in _context.SeasonMasts
                            orderby a.seaCode
                            where a.recStatus == RecStatus.Active
                            select new SeasonMastModel
                            {
                                seaId = a.seaId,
                                seaCode = a.seaCode,
                                seaDesc = a.seaDesc,
                                recStatus = a.recStatus,
                                createBy = a.createBy,
                                createDate = a.createDate,
                                updateBy = a.updateBy,
                                updateDate = a.updateDate,
                                sortSeq = a.sortSeq,
                            });
            }

            return rs.ToList();
        }
        public List<SeasonMastModel> SelectAllType()
        {
            var rs = (from a in _context.SeasonMasts
                      orderby a.seaCode
                      select new SeasonMastModel
                      {
                          seaId = a.seaId,
                          seaCode = a.seaCode,
                          seaDesc = a.seaDesc,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = a.sortSeq,
                      }).ToList();

            return rs;
        }
        #region temp
        //public int UpdateById(SeasonMastModel data)
        //{
        //    var model = _context.SeasonMasts.FirstOrDefault(p => p.seaId == data.seaId);
        //    if (model != null)
        //    {
        //        model.seaCode = data.seaCode;
        //        model.seaDesc = data.seaDesc;
        //        model.recStatus = data.recStatus;
        //        model.sortSeq = data.sortSeq;
        //        model.updateBy = data.updateBy;
        //        model.updateDate = data.updateDate;
        //    }
        //    _context.SaveChanges();
        //    return model.seaId;
        //}
        //public int Insert(SeasonMastModel data)
        //{
        //    var model = new SeasonMast();
        //    if (data != null)
        //    {
        //        model.seaCode = data.seaCode;
        //        model.seaDesc = data.seaDesc;
        //        model.recStatus = data.recStatus;
        //        model.sortSeq = data.sortSeq;
        //        model.createBy = data.createBy;
        //        model.createDate = data.createDate;
        //        _context.SeasonMasts.Add(model);
        //    }
        //    _context.SaveChanges();
        //    return model.seaId;
        //}
        #endregion

    }
}
