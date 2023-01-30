using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Questao2.Filters;
using Questao2.Entities;

namespace Questao2.Business
{
    public class GoalCalculator
    {
        private readonly IFilterRule filterRule;

        public GoalCalculator(IFilterRule filterRule)
        {
            this.filterRule = filterRule;
        }

        public int GetTotalScoredGoals()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(filterRule.GetFilterUrl()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var root = JsonConvert.DeserializeObject<Root>(json);
                    return root.data.Sum(match => match.team1goals);
                }
                else
                {
                    throw new Exception("Error on API call");
                }
            }

        }
    }
}