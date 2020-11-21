using CustomerControl.CrossCutting.Filter.Base;

namespace CustomerControl.CrossCutting.Filter
{
    public class CustomerFilter : BaseFilter
    {
        public CustomerFilter(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();
        }
    }
}