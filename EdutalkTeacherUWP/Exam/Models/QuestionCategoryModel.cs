using EdutalkTeacherUWP.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class QuestionCategoryModel : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public QuestionCategory Category { get; set; }
    }
    public enum QuestionCategory
    {
        MatchTextImage,
        FillTextImage,
        FillTextScript,
        ArrangeSentences,
        SingleChoice,
        Record,
        MatchImageToAudio,
        MatchTextToAudio,
        FillTextToAudio,
        TypingCaptureImage
    }

}
