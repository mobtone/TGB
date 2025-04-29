using Easyweb.Site.Models;
using System.Collections.Generic;

namespace Easyweb.Site.Services // Anpassa namespace
{
    public interface IMoodService
    {
        MoodMatcherResult GetMoodSuggestions(string mood, string season, List<Coffee> allCoffees);
    }
}