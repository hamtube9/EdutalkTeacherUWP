using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class AnswerModel : ModelBase
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Audio { set; get; }
        public string Image { set; get; }
        public IList<string> Images { set; get; }
        public int? Position { get; set; }
        public string Key { get; set; }
        public bool IsSelected { get; set; }
        public bool IsTrue { get; set; }
        public CheckAnswer Check { set; get; } = CheckAnswer.Normal;
    }

    public enum CheckAnswer
    {
        IsTrue, IsWrong, Normal
    }
}
