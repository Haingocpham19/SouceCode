using System.Collections.Generic;
using System.Linq;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;

        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public IList<Level> Gets()
        {
            return _levelRepository.Find().ToList();
        }

        public Level GetLevelByLevel(int level)
        {
            var specification = new Specification<Level>(m => true)
                .And(new LevelGetByLevel(level));

            return _levelRepository.Find(specification).FirstOrDefault();
        }
        
        public List<Level> GetLevelByLevel(List<int> levels)
        {
            var specification = new Specification<Level>(m => true)
                .And(new LevelGetByLevel(levels));

            return _levelRepository.Find(specification).ToList();
        }
        public Level GetByLevelId(int? id)
        {
            return _levelRepository.FindById(id);
        }
        public Level GetById(int id)
        {
            return _levelRepository.FindById(id);
        }
    }
}
