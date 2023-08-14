using Core.Specification.Abstract;
using iChiba.OM.Model;

namespace iChiba.OM.Specification.Implement
{
    public class CustomerGetByKeyword : SpecificationBase<Customer>
    {
        public CustomerGetByKeyword(string searchKeyword)
            : base(m => m.Phone.Contains(searchKeyword)
            || m.Code.Contains(searchKeyword)
            || m.Username.Contains(searchKeyword)
            || m.Email.Contains(searchKeyword)
            || m.Fullname.Contains(searchKeyword) || m.IdName.Contains(searchKeyword))
        {
        }
    }
}
