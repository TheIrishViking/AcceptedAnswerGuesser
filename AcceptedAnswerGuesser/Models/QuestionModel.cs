using Newtonsoft.Json;

namespace AcceptedAnswerGuesser.Models
{
    public class QuestionModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Answer
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

            [JsonProperty("last_edit_date")]
            public int? LastEditDate { get; set; }
        }

        public class Question
        {
            [JsonProperty("tags")]
            public List<string> Tags { get; set; }

            [JsonProperty("answers")]
            public List<Answer> Answers { get; set; }

            [JsonProperty("owner")]
            public Owner Owner { get; set; }

            [JsonProperty("is_answered")]
            public bool IsAnswered { get; set; }

            [JsonProperty("view_count")]
            public int ViewCount { get; set; }

            [JsonProperty("accepted_answer_id")]
            public int AcceptedAnswerId { get; set; }

            [JsonProperty("answer_count")]
            public int AnswerCount { get; set; }

            [JsonProperty("score")]
            public int Score { get; set; }

            [JsonProperty("last_activity_date")]
            public int LastActivityDate { get; set; }

            [JsonProperty("creation_date")]
            public int CreationDate { get; set; }

            [JsonProperty("last_edit_date")]
            public int LastEditDate { get; set; }

            [JsonProperty("question_id")]
            public int QuestionId { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("closed_date")]
            public int? ClosedDate { get; set; }

            [JsonProperty("closed_reason")]
            public string ClosedReason { get; set; }
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

            [JsonProperty("accept_rate")]
            public int AcceptRate { get; set; }

            [JsonProperty("profile_image")]
            public string ProfileImage { get; set; }

            [JsonProperty("display_name")]
            public string DisplayName { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }
        }

        public class QuestionList
        {
            [JsonProperty("items")]
            public List<Question> Questions { get; set; }

            [JsonProperty("has_more")]
            public bool HasMore { get; set; }

            [JsonProperty("quota_max")]
            public int QuotaMax { get; set; }

            [JsonProperty("quota_remaining")]
            public int QuotaRemaining { get; set; }
        }


    }
}
