﻿using Microsoft.AspNetCore.Components;
using Something3.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Something3.UI.Pages
{
    public partial class CreateData : ComponentBase
    {
        private readonly Random _random = new Random();
        [Inject]
        public HttpClient Http { get; set; }
        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        private Something3WithId[] somethings;

        protected override async Task OnInitializedAsync()
        {
            somethings = await Http.GetFromJsonAsync<Something3WithId[]>("https://localhost:44327/api/things");
        }

        protected async Task AddSomething()
        {
            var value = new Dictionary<string, string>
        {
        { "FullName", RandomString(RandomNumber(10,20),true) }
        };

            var content = new FormUrlEncodedContent(value);
            var response = await Http.PostAsync(@"https://localhost:44327/api/things", content);
            somethings = response.Content.ReadFromJsonAsync<Something3WithId[]>().Result;
        }
    }
}
