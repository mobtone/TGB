using System.Collections.Generic;

namespace Easyweb.Site.Models
{
    public class MoodMatcherResult
    {
        public string SelectedMood { get; set; }
        public string SelectedSeason { get; set; }
        public List<Coffee> SuggestedCoffees { get; set; } = new List<Coffee>();
        public string ThemeClass { get; set; } = "theme-default";
        public List<string> AvailableMoods { get; } = new List<string> { "Cozy", "Energetic", "Relaxed", "Focused" };
        public List<string> AvailableSeasons { get; } = new List<string> { "Winter", "Spring", "Summer", "Autumn" };
    }
}
