using HandyControl.Controls;
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
    public class ChapterViewModel : WorkspaceViewModel
    {
        #region Fields
        private Chapter Chapter;
        private RelayCommand _CreateExtraDataCommand;
        private ObservableCollection<KeyValuePair<string, string>> _ExtraInformation;
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
        public ObservableCollection<KeyValuePair<string, string>> ExtraInformation
        {
            get { return this._ExtraInformation; }
            set
            {
                if (value == this._ExtraInformation)
                    return;
                this._ExtraInformation = value;
                //this.HasActiveDocument = value != null;
                base.OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand CreateExtraDataCommand
        {
            get
            {
                if (_CreateExtraDataCommand == null)
                {
                    _CreateExtraDataCommand = new RelayCommand(param => this.CreateExtraData());
                }
                return _CreateExtraDataCommand;
            }
        }
        #endregion


        public ChapterViewModel(Chapter chapter) : base("Chapter #" + chapter.Index, true, false)
        {
            this.Chapter = chapter;
            this.ExtraInformation = new ObservableCollection<KeyValuePair<string, string>>();
        }
        private void CreateExtraData()
        {
            NewExtraDataViewModel newReadingLogView = new NewExtraDataViewModel();
            var d = Dialog.Show(newReadingLogView);
            newReadingLogView.onCreated += delegate (object s, KeyValuePair<string, string> e)
            {
                d.Close();
                this.ExtraInformation.Add(e);
            };
            newReadingLogView.RequestClose += delegate { d.Close(); };
        }
    }
}
