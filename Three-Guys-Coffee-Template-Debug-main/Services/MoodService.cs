using Easyweb.Site.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Easyweb.Site.Services
{
    public class MoodService : IMoodService
    {
        public MoodMatcherResult GetMoodSuggestions(string mood, string season, List<Coffee> allCoffees)
        {
            var result = new MoodMatcherResult
            {
                SelectedMood = mood,
                SelectedSeason = season,
                SuggestedCoffees = new List<Coffee>()
            };

            if (string.IsNullOrEmpty(mood) && string.IsNullOrEmpty(season))
            {
                result.ThemeClass = "theme-default";
                return result;
            }

            if (mood == "Cozy" && (season == "Winter" || season == "Autumn"))
            {
                result.SuggestedCoffees.AddRange(allCoffees.Where(c => c.title == "Mocha" || c.title == "Hot Chocolate" || c.title == "Chai Latte").Take(3));
                result.ThemeClass = "theme-cozy-winter";
            }
            else if (mood == "Energetic")
            {
                result.SuggestedCoffees.AddRange(allCoffees.Where(c => c.title == "Espresso" || c.title == "Black Coffee").Take(2));
                result.ThemeClass = "theme-energetic";
            }
            else if (mood == "Relaxed")
            {
                result.SuggestedCoffees.AddRange(allCoffees.Where(c => c.title == "Latte" || c.title == "Cappuccino").Take(2));
                result.ThemeClass = "theme-relaxed";
            }
            else if (mood == "Focused")
            {
                result.SuggestedCoffees.AddRange(allCoffees.Where(c => c.title == "Black Coffee" || c.title == "Espresso").Take(2));
                result.ThemeClass = "theme-focused";
            }
            else if (season == "Summer")
            {
                result.SuggestedCoffees.AddRange(allCoffees.Where(c => c.title == "Black Coffee" || c.title == "Espresso").Take(2));
                result.ThemeClass = "theme-summer";
            }

            if (!result.SuggestedCoffees.Any() && allCoffees.Any())
            {
                var random = new Random();
                result.SuggestedCoffees.Add(allCoffees[random.Next(allCoffees.Count)]);
                if (allCoffees.Count > 1) result.SuggestedCoffees.Add(allCoffees[random.Next(allCoffees.Count)]);
                result.SuggestedCoffees = result.SuggestedCoffees.Distinct().Take(2).ToList();
                result.ThemeClass = "theme-neutral";
            }
            else if (!result.SuggestedCoffees.Any())
            {
                result.ThemeClass = "theme-neutral";
            }

            return result;
        }
    }
}
