using EdutalkTeacherUWP.Exam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Exam.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewFillTextScriptView : UserControl
    {
        public static readonly DependencyProperty GroupQuestionProperty = DependencyProperty.Register("GroupQuestion", typeof(GroupQuestionModel), typeof(ViewFillTextScriptView), new PropertyMetadata(null));

        public GroupQuestionModel GroupQuestion
        {
            get => (GroupQuestionModel)GetValue(GroupQuestionProperty);
            set => SetValue(GroupQuestionProperty, value);
        }


        public ViewFillTextScriptView()
        {
            this.InitializeComponent();
            SetSource();
            SetData();
        }

        void SetSource()
        {
            if (string.IsNullOrEmpty(GroupQuestion?.Media))
            {
                playButton.Visibility = Visibility.Collapsed;
                return;
            }
            playButton.Visibility = Visibility.Visible;
            playButton.Source = GroupQuestion.Media;
        }

        private void SetData()
        {
            if (GroupQuestion == null)
            {
                return;
            }
            foreach (var item in GroupQuestion.Questions)
            {
                if (item.StudentAnswer == item.CorrectAnswer)
                {
                    item.Answer = new AnswerModel()
                    {
                        Answer = item.StudentAnswer,
                        IsTrue = true
                    };
                }
                else
                {
                    item.Answer = new AnswerModel()
                    {
                        Answer = item.StudentAnswer,
                        IsTrue = false
                    };
                }
            }
        }
    }
}
