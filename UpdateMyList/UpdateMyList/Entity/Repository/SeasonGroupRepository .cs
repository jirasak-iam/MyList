using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface ISeasonGroupRepository : IBaseRepository<SeasonGroup>
    {
        List<SeasonGroupModel> SelectSeasonGroupBySeaId(int seaId);
        List<SeasonGroupModel> SelectSeasonGroupBySeaIdButClose(int seaId);
        int Insert(SeasonGroupModel data);
        int UpdateSeaGroup(SeasonGroupModel data);
    }
    public class SeasonGroupRepository : BaseRepository<SeasonGroup>, ISeasonGroupRepository
    {
        public SeasonGroupRepository(myListEntities context)
            : base(context)
        {
        }
        public List<SeasonGroupModel> SelectSeasonGroupBySeaId(int seaId)
        {
            var rs = (from a in _context.SeasonGroups
                      orderby a.seaGroupId
                      where a.recStatus == RecStatus.Active && a.seaId == seaId
                      select new SeasonGroupModel
                      {
                          seagroupId = a.seaGroupId,
                          seaId = a.seaId,
                          listTypeId = a.lisTypetId,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }
        public List<SeasonGroupModel> SelectSeasonGroupBySeaIdButClose(int seaId)
        {
            var rs = (from a in _context.SeasonGroups
                      orderby a.seaGroupId
                      where a.recStatus == RecStatus.Close && a.seaId == seaId
                      select new SeasonGroupModel
                      {
                          seagroupId = a.seaGroupId,
                          seaId = a.seaId,
                          listTypeId = a.lisTypetId,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate
                      }).ToList();
            return rs;
        }
        public int Insert(SeasonGroupModel data)
        {
            if (data != null)
            {
                var model = new SeasonGroup();
                model.seaId = data.seaId;
                model.lisTypetId = data.listTypeId;
                model.recStatus = data.recStatus;
                model.createBy = data.createBy;
                model.createDate = data.createDate;
                _context.SeasonGroups.Add(model);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int UpdateSeaGroup(SeasonGroupModel data)
        {
            var model = _context.SeasonGroups.FirstOrDefault(p => p.seaGroupId == data.seagroupId);
            if (model != null)
            {
                model.recStatus = data.recStatus;
                model.updateBy = data.updateBy;
                model.updateDate = data.updateDate;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
