using System.Collections.Generic;
using X.PagedList;

namespace Easyweb.Site.Models
{
    public class CoffeeIndexViewModel
    {
        public IPagedList<Coffee> MainCoffeeListPaged { get; set; }
        public MoodMatcherResult MoodMatcher { get; set; }
    }
}
