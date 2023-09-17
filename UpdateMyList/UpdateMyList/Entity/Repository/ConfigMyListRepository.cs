using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateMyList.Common;
using UpdateMyList.Entity.Model;

namespace UpdateMyList.Entity.Repository
{
    public interface IConfigMyListRepository : IBaseRepository<ConfigMyList>
    {
        void UpdateConfig(ConfigMyList data);
    }
    public class ConfigMyListRepository : BaseRepository<ConfigMyList>, IConfigMyListRepository
    {
        public ConfigMyListRepository(myListEntities context)
            : base(context)
        {
        }
        public void UpdateConfig(ConfigMyList data)
        {
            var config = _context.ConfigMyLists.FirstOrDefault();
            if (data != null && config != null)
            {
                config.UpdateDate = DateTime.Now;
                config.DataPerPage = data.DataPerPage;
                config.sortmode = data.sortmode;
                config.IsSimilar = data.IsSimilar;
                _context.SaveChanges();
            }
        }
    }
}
