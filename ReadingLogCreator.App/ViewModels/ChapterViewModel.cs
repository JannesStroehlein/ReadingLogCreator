using ReadingLogCreator.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLogCreator.App.ViewModels
{
    public class ChapterViewModel : WorkspaceViewModel
    {
        #region Fields
        private Chapter Chapter;
        #endregion
        #region Properties
        public string Title => this.Chapter.Title;
        public int StartPage => this.Chapter.StartPage;
        public int EndPage => this.Chapter.EndPage;
        public int Index => this.Chapter.Index;

        public string Summary
        {
            get { return this.Chapter.Summary; }
            set
            {
                if (value == this.Chapter.Summary)
                    return;
                this.Chapter.Summary = value;
                base.OnPropertyChanged();
            }
        }
        public string Notes
        {
            get { return this.Chapter.Notes; }
            set
            {
                if (value == this.Chapter.Notes)
                    return;
                this.Chapter.Notes = value;
                base.OnPropertyChanged();
            }
        }

        public ObservableCollection<Character> Characters => this.Chapter.Characters;
        public ObservableCollection<FAQQuestion> Questions => this.Chapter.Questions;
        #endregion
        public ChapterViewModel(Chapter chapter) : base("Chapter #" + chapter.Index, true, false)
        {
            this.Chapter = chapter;
        }
    }
}
