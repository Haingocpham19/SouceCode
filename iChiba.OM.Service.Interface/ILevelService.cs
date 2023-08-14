using System.Collections.Generic;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface ILevelService
    {
        IList<Level> Gets();
        Level GetLevelByLevel(int level);
        List<Level> GetLevelByLevel(List<int> levels);
        Level GetByLevelId(int? id);
        Level GetById(int id);
    }
}