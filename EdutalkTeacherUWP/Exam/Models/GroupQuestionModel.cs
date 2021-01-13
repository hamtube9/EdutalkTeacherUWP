using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
   public class GroupQuestionModel : ModelBase
    {
        public long Id { get; set; }
        public QuestionCategoryModel Category { get; set; }
        public IList<QuestionModel> Questions { get; set; }
        //public QuestionModel Question { set; get; }
        public string Media { get; set; }
        public string Script { get; set; }
        public string Image { get; set; }
        public QuestionState State { get; set; }
        public bool IsSelected { get; set; }
        public int Number { get; set; }
        public double Score { get; set; }
        public double Mark { get; set; }
    }
    public enum QuestionState
    {
        Normal, Read, Answered
    }
}
