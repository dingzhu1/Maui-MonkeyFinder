using Maui_MonkeyFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FileSystem = Microsoft.Maui.Storage.FileSystem;

namespace Maui_MonkeyFinder.Services
{
    public class MonkeyService
    {
        private List<Monkey> monkeyList = new List<Monkey>();

        private HttpClient httpClient { get; }

        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList?.Count > 0)
            {
                return monkeyList;
            }
            //Onlin
            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
            }
            else
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
                using var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);
            }
            return monkeyList;
        }

        public MonkeyService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.Timeout = TimeSpan.FromSeconds(5); //10s超时时间
        }

        public async Task<List<Monkey>> ReadJson()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);
            return monkeyList;
        }
    }
}