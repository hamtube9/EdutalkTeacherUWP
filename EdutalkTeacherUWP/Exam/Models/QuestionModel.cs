using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class QuestionModel : ModelBase
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Question { get; set; }
        public string Audio { get; set; }
        //public IList<string> Questions { get; set; }
        public string Type { get; set; }
        public IList<AnswerModel> Answers { get; set; }
        public AnswerModel Answer { get; set; }
        public int Index { get; set; }
        public bool IsTrue { get; set; }
        public string StudentAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsSelected { set; get; }
        public double Score { get; set; }
        public double Mark { get; set; }
        public string FileRecord { get; set; }
        public IList<string> FileImages { get; set; }
    }
}
