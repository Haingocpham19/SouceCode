using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class RecruitmentService : IRecruitmentService
    {

        private readonly IRecruitmentCache recruitmentCache;

        public RecruitmentService(IRecruitmentCache recruitmentCache)
        {
            this.recruitmentCache = recruitmentCache;
        }

        public Task<IList<Recruitment>> GetAll(string languageId)
        {
            return recruitmentCache.GetAll();
        }
    }
}
