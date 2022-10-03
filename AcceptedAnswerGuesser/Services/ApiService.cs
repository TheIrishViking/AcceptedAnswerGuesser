using AcceptedAnswerGuesser.Models;
using Newtonsoft.Json;
using System.Net;

namespace AcceptedAnswerGuesser.Services
{
    public class ApiService
    {
        //The API URL is configured using the following parameters:
        //page=1 @ pagesize=30 will limit the number of questions to 30
        //sort=creation & order=desc will make sure the 30 questions are recent
        //accepted=true & answers=2 will satisfy the given requirements that the question must have 2 or more answers with at least one of those answers marked accepted
        //the filter was setup within the api documentation so that the question body, answers, and answer body were all included in the response JSON

        string apiUrl = "https://api.stackexchange.com/2.3/search/advanced?page=1&pagesize=10&order=desc&sort=activity&accepted=True&answers=2&site=stackoverflow&filter=!nKzQUR3Egv";

        public async Task GetQuestionsAsync()
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All}))
            {                
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);  

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var questions = JsonConvert.DeserializeObject<QuestionModel.Questions>(data);
                }


            }
        }
    }
}
