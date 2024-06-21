namespace SurveyAPI.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; } 
        public int QuestionId { get; set; }  
        public User User { get; set; }   
        public Question Question { get; set; } 
    }
}
