using AcceptedAnswerGuesser.Models;
using Newtonsoft.Json;
using System.Net;

namespace AcceptedAnswerGuesser.Services
{
    public class ApiService
    {
        //The Questions API URL is configured using the following parameters:
        //page=1 @ pagesize=10 will limit the number of questions to 10
        //sort=creation & order=desc will make sure the 30 questions are recent
        //accepted=true & answers=2 will satisfy the given requirements that the question must have 2 or more answers with at least one of those answers marked accepted
        //the filter was setup within the api documentation so that the question body was included in the response JSON

        string questionsApiUrl = "https://api.stackexchange.com/2.3/search/advanced?page=1&pagesize=10&order=desc&sort=creation&accepted=True&answers=2&site=stackoverflow&filter=!nKzQUR3Egv";

        public async Task<QuestionModel.Questions?> GetQuestionsAsync()
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All}))
            {                
                client.BaseAddress = new Uri(questionsApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(questionsApiUrl);  

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var questions = JsonConvert.DeserializeObject<QuestionModel.Questions>(data);

                    return questions;
                }

                return null;
            }
        }

        //The Answers API URL is configured using the following parameters:
        //questionID will need to be provided in the string before calling the api
        //the filter was setup within the api documentation so that the answewr body was included in the response JSON

        string answersApiUrl = "https://api.stackexchange.com/2.3/questions/" + "{questionID}" + "/answers?order=desc&sort=creation&site=stackoverflow&filter=!nKzQURF6Y5";

        public async Task GetAnswersAsync(int questionID)
        {
            //insert question ID into the answersApiUrl string
            answersApiUrl = answersApiUrl.Replace("{questionID}", questionID.ToString());

            using (HttpClient client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All }))
            {
                client.BaseAddress = new Uri(answersApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(answersApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var answers = JsonConvert.DeserializeObject<QuestionModel.Questions>(data);
                }


            }
        }
    }
}
