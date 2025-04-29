using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Easyweb.Site.Models;
using Easyweb.Site.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

public class CustomDataController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMoodService _moodService;

    public CustomDataController(IHttpClientFactory httpClientFactory, IMoodService moodService)
    {
        _httpClientFactory = httpClientFactory;
        _moodService = moodService;
    }


    [HttpGet("/coffee")]
    public async Task<IActionResult> Index(string mood = null, string season = null, int page = 1)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://api.sampleapis.com/coffee/hot");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var coffeeList = JsonSerializer.Deserialize<List<Coffee>>(json);

        foreach (var coffee in coffeeList)
        {
            if (coffee.ingredients == null || !coffee.ingredients.Any())
            {
                if (coffee.title == "Black Coffee")
                {
                    coffee.ingredients = new List<string> { "Coffee", "Water" };
                }
                else if (coffee.title == "Caramel Latte")
                {
                    coffee.ingredients = new List<string> { "Espresso", "Steamed Milk", "Caramel Syrup" };
                }
                else if (coffee.title == "Machiatto")
                {
                    coffee.ingredients = new List<string> { "Espresso", "Foamed Milk" };
                }
                else if (coffee.title == "Mocha")
                {
                    coffee.ingredients = new List<string> { "Espresso", "Chocolate", "Steamed Milk" };
                }
                else if (coffee.title == "Chai Latte")
                {
                    coffee.ingredients = new List<string> { "Chai Tea", "Milk", "Water" };
                }
                else if (coffee.title == "Matcha Latte")
                {
                    coffee.ingredients = new List<string> { "Matcha Powder", "Milk", "Water" };
                }
                else if (coffee.title == "Espresso")
                {
                    coffee.ingredients = new List<string> { "Coffee", "Water" };
                }
                else if (coffee.title == "Hot Chocolate")
                {
                    coffee.ingredients = new List<string> { "Chocolate", "Milk", "Water" };
                }
                else if (coffee.title == "Latte")
                {
                    coffee.ingredients = new List<string> { "Espresso", "Milk", "Water" };
                }
                else if (coffee.title == "Cappuccino")
                {
                    coffee.ingredients = new List<string> { "Espresso", "Milk", "Water" };
                }
                else
                {
                    coffee.ingredients = new List<string> { "Default Ingredient 1", "Default Ingredient 2" };
                }
            }
        }

        const int pageSize = 6;

            int pageNumber = page <= 0 ? 1 : page;

            var pagedCoffeeList = coffeeList.ToPagedList(pageNumber, pageSize);


            var moodMatcherResult = _moodService.GetMoodSuggestions(mood, season, coffeeList);

            var viewModel = new CoffeeIndexViewModel
            {
                MainCoffeeListPaged = pagedCoffeeList,
                MoodMatcher = moodMatcherResult
            };

            return View(viewModel);
        }
    }

//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace Easyweb.Controllers;

//public class CustomDataController : Controller
//{
//    [HttpGet("/data")]
//    public virtual async Task<IActionResult> Index()
//    {
//        string result;

//        using (var client = new HttpClient())
//        {
//            var response = await client.GetAsync("https://swapi.dev/api/people/1/");
//            result = await response.Content.ReadAsStringAsync();
//        }

//        return Ok(result);
//    }
//}
