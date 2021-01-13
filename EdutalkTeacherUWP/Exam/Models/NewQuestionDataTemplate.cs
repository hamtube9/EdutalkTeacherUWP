using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EdutalkTeacherUWP.Exam.Models
{
    public class NewQuestionDataTemplate : DataTemplateSelector
    {
        public DataTemplate MatchTextImage { get; set; }
        public DataTemplate FillTextImage { get; set; }
        public DataTemplate FillTextScript { get; set; }
        public DataTemplate ArrangeSentences { get; set; }
        public DataTemplate SingleChoice { get; set; }
        public DataTemplate MatchImageToAudio { get; set; }
        public DataTemplate MatchTextToAudio { get; set; }
        public DataTemplate FillTextToAudio { get; set; }
        public DataTemplate Record { get; set; }
        public DataTemplate TypingCaptureImage { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is GroupQuestionModel model)
            {
                switch (model.Category.Category)
                {
                    case QuestionCategory.MatchTextImage:
                        return MatchTextImage;
                    case QuestionCategory.FillTextImage:
                        return FillTextImage;
                    case QuestionCategory.FillTextScript:
                        return FillTextScript;
                    case QuestionCategory.ArrangeSentences:
                        return ArrangeSentences;
                    case QuestionCategory.SingleChoice:
                        return SingleChoice;
                    case QuestionCategory.MatchImageToAudio:
                        return MatchImageToAudio;
                    case QuestionCategory.MatchTextToAudio:
                        return MatchTextToAudio;
                    case QuestionCategory.FillTextToAudio:
                        return FillTextToAudio;
                    case QuestionCategory.Record:
                        return Record;
                    case QuestionCategory.TypingCaptureImage:
                        return TypingCaptureImage;
                }
            }

            return MatchTextImage;
        }
    }
}
