using Newtonsoft.Json;

namespace AcceptedAnswerGuesser.Models
{
    public class AnswerModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Item
        {
            [JsonProperty("owner")]
            public Owner Owner { get; set; }

            [JsonProperty("is_accepted")]
            public bool IsAccepted { get; set; }

            [JsonProperty("score")]
            public int Score { get; set; }

            [JsonProperty("last_activity_date")]
            public int LastActivityDate { get; set; }

            [JsonProperty("creation_date")]
            public int CreationDate { get; set; }

            [JsonProperty("answer_id")]
            public int AnswerId { get; set; }

            [JsonProperty("question_id")]
            public int QuestionId { get; set; }

            [JsonProperty("content_license")]
            public string ContentLicense { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }
        }

        public class Owner
        {
            [JsonProperty("account_id")]
            public int AccountId { get; set; }

            [JsonProperty("reputation")]
            public int Reputation { get; set; }

            [JsonProperty("user_id")]
            public int UserId { get; set; }

            [JsonProperty("user_type")]
            public string UserType { get; set; }

            [JsonProperty("profile_image")]
            public string ProfileImage { get; set; }

            [JsonProperty("display_name")]
            public string DisplayName { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("accept_rate")]
            public int? AcceptRate { get; set; }
        }

        public class Answers
        {
            [JsonProperty("items")]
            public List<Item> Items { get; set; }

            [JsonProperty("has_more")]
            public bool HasMore { get; set; }

            [JsonProperty("quota_max")]
            public int QuotaMax { get; set; }

            [JsonProperty("quota_remaining")]
            public int QuotaRemaining { get; set; }
        }


    }
}
