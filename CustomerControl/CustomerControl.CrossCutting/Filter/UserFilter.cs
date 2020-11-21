using CustomerControl.CrossCutting.Filter.Base;

namespace CustomerControl.CrossCutting.Filter
{
    public class UserFilter : BaseFilter
    {
        public UserFilter(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();
        }
    }
}