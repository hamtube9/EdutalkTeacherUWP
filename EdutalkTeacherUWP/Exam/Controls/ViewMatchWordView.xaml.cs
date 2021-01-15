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
    public sealed partial class ViewMatchWordView : Page
    {
        public static readonly DependencyProperty GroupQuestionProperty = DependencyProperty.Register("GroupQuestion", typeof(GroupQuestionModel), typeof(ViewMatchWordView), new PropertyMetadata(null));

        public GroupQuestionModel GroupQuestion
        {
            get => (GroupQuestionModel)GetValue(GroupQuestionProperty);
            set => SetValue(GroupQuestionProperty, value);
        }
        public bool IsCorect { set; get; }
        public string StudentAnswer { set; get; }
        public string ResultAnswer { set; get; }
        public ViewMatchWordView()
        {
            this.InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            if (GroupQuestion == null)
            {
                return;
            }

            if (GroupQuestion.Questions.Count == 0)
            {
                return;
            }


            StudentAnswer = GroupQuestion.Questions.FirstOrDefault().StudentAnswer;

            ResultAnswer = GroupQuestion.Questions.FirstOrDefault().CorrectAnswer;
            if (StudentAnswer.ToLower() == ResultAnswer.ToLower())
            {
                IsCorect = true;
            }
            else
            {
                IsCorect = false;
            }
        }
    }
}
