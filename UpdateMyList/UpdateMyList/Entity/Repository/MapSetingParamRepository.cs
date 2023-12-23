using System.Collections.Generic;
using System.Linq;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IMapSetingParamRepository : IBaseRepository<MapSetingParam>
    {
        List<MapSettingParamModel> Select();
        List<MapSettingParamModel> SelectAll();
        List<MapSettingParamModel> SelectAllType();
        //int UpdateById(MapSettingParamModel data);
        //int Insert(MapSettingParamModel data);
    }
    public class MapSetingParamRepository : BaseRepository<MapSetingParam>, IMapSetingParamRepository
    {
        public MapSetingParamRepository(myListEntities context)
            : base(context)
        {
        }

        public List<MapSettingParamModel> Select()
        {
            var rs = (from a in _context.MapSetingParams
                      orderby a.sortSeq
                      where a.recStatus == RecStatus.Active
                      select new MapSettingParamModel
                      { 
                          mapId = a.mapId,
                          mapCode = a.mapCode,
                          mapDesc = a.mapDesc,
                          mapTbName = a.mapTbName,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = (a.sortSeq ?? 0)
                      }).ToList();

            return rs;
        }
        public List<MapSettingParamModel> SelectAll()
        {
            var rs = new List<MapSettingParamModel>();

            rs.Add(new MapSettingParamModel
            {
                mapId = 0,
                mapCode = string.Empty,
                mapDesc = string.Empty,
                sortSeq = 0
            });

            rs.AddRange(from a in _context.MapSetingParams
                        where a.recStatus == RecStatus.Active
                        select new MapSettingParamModel
                        {
                            mapId = a.mapId,
                            mapCode = a.mapCode,
                            mapDesc = a.mapDesc,
                            mapTbName = a.mapTbName,
                            recStatus = a.recStatus,
                            createBy = a.createBy,
                            createDate = a.createDate,
                            updateBy = a.updateBy,
                            updateDate = a.updateDate,
                            sortSeq = (a.sortSeq ?? 0)
                        });

            return rs.OrderBy(o => o.sortSeq).ToList();
        }
        public List<MapSettingParamModel> SelectAllType()
        {
            var rs = (from a in _context.MapSetingParams
                      orderby a.sortSeq
                      select new MapSettingParamModel
                      {
                          mapId = a.mapId,
                          mapCode = a.mapCode,
                          mapDesc = a.mapDesc,
                          mapTbName = a.mapTbName,
                          recStatus = a.recStatus,
                          createBy = a.createBy,
                          createDate = a.createDate,
                          updateBy = a.updateBy,
                          updateDate = a.updateDate,
                          sortSeq = (a.sortSeq ?? 0)
                      }).ToList();

            return rs;
        }
        public int UpdateById(MapSettingParamModel data)
        {
            var model = _context.MapSetingParams.FirstOrDefault(p => p.mapId == data.mapId);
            if (model != null)
            {
                model.mapCode = data.mapCode;
                model.mapDesc = data.mapDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.updateBy = data.updateBy;
                model.updateDate = data.updateDate;
                model.mapTbName = data.mapTbName;
            }
            var rs = _context.SaveChanges();
            return rs;
        }
        public int Insert(MapSettingParamModel data)
        {
            if (data != null)
            {
                var model = new MapSetingParam();
                model.mapCode = data.mapCode;
                model.mapDesc = data.mapDesc;
                model.recStatus = data.recStatus;
                model.sortSeq = data.sortSeq;
                model.createBy = data.createBy;
                model.createDate = data.createDate;
                model.mapTbName = data.mapTbName;
                _context.MapSetingParams.Add(model);
            }
            var rs = _context.SaveChanges();
            return rs;
        }
    }
}
