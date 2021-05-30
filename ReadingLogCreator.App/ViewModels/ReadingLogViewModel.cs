using ReadingLogCreator.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    public class ReadingLogViewModel : WorkspaceViewModel
    {
        #region Fields
        private RelayCommand _openChapterViewCommand;
        private RelayCommand _deleteChapterCommand;

        private ReadingLog ReadingLog;
        private MainWindowViewModel MainWindowViewModel;
        #endregion
        #region Properties
        public string Title => this.ReadingLog.Title;
        public string Author => this.ReadingLog.Author;
        public int ReleaseYear => this.ReadingLog.ReleaseDate.Year;
        public ObservableCollection<Chapter> Chapters => this.ReadingLog.Chapters;
        #endregion

        #region Commands
        public ICommand OpenChapterViewCommand
        {
            get
            {
                if (_openChapterViewCommand == null)
                {
                    _openChapterViewCommand = new RelayCommand(param => this.OpenChapterView(param as Chapter));
                }
                return _openChapterViewCommand;
            }
        }
        public ICommand DeleteChapterCommand
        {
            get
            {
                if (_deleteChapterCommand == null)
                {
                    _deleteChapterCommand = new RelayCommand(param => this.DeleteChapter(param as Chapter));
                }
                return _deleteChapterCommand;
            }
        }
        #endregion
        public ReadingLogViewModel(ReadingLog readingLog, MainWindowViewModel parent) : base("Home", false, false)
        {
            this.ReadingLog = readingLog;
            this.MainWindowViewModel = parent;
        }
        private void OpenChapterView(Chapter chapter) => this.MainWindowViewModel.Workspaces.Add(new ChapterViewModel(chapter));
        private void DeleteChapter(Chapter chapter)
        {

        }
    }
}
