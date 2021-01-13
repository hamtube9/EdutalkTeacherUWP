using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos.Exam
{
    public class ExamResultDto
    {
        public long Id { get; set; }
        public int? Time { get; set; }
        public string TypeName { get; set; }
        public GroupQuestionResultDto[] GroupQuestions { get; set; }
    }

    public class GroupQuestionResultDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public double? Score { get; set; }
        public long IsShuffle { get; set; }
        public QuestionResultDto[] Questions { get; set; }
    }

    public class QuestionResultDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public long IsShuffle { get; set; }
        public string Type { get; set; }
        public long Score { get; set; }
        public long Order { get; set; }
        public AnswerResultDto[] Answers { get; set; }
        public bool IsTrue { get; set; }
        public string StudentAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public FileAnswerDto[] StudentAnswerImage { get; set; }
        public FileAnswerDto[] StudentAnswerRecord { get; set; }

    }

    public partial class AnswerResultDto
    {
        public string Content { get; set; }
        public int? Position { get; set; }
        public string Audio { get; set; }
        public string Image { get; set; }
    }

    public partial class FileAnswerDto
    {
        public int Id { set; get; }
        public string PathString { set; get; }
    }
}
