using System.Collections.Generic;
using System.Xml.Schema;
using Core.Specification.Abstract;
using iChiba.OM.Model;
namespace iChiba.OM.Specification.Implement
{
    public class LevelGetByLevel : SpecificationBase<Level>
    {
        public LevelGetByLevel(int level)
            : base(m => m.Level1.Equals(level))
        {

        }
        
        public LevelGetByLevel(List<int> levels)
            : base(m => levels.Contains(m.Level1))
        {

        }
    }
}
