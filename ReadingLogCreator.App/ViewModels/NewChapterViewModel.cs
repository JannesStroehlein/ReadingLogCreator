using ReadingLogCreator.API;
using System;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    public class NewChapterViewModel : WorkspaceViewModel
    {
        private RelayCommand _CancelCommand;
        private RelayCommand _CreateCommand;

        private string _Title;
        private int _StartPage;
        private int _EndPage;
        private bool _CanCreate;

        public event EventHandler<Chapter> onCreated;

        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new RelayCommand(param => this.Close());
                }
                return _CancelCommand;
            }
        }
        public ICommand CreateCommand
        {
            get
            {
                if (_CreateCommand == null)
                {
                    _CreateCommand = new RelayCommand(param => this.Create());
                }
                return _CreateCommand;
            }
        }

        public string Title
        {
            get { return this._Title; }
            set
            {
                if (value == this._Title)
                    return;
                this._Title = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public int StartPage
        {
            get { return this._StartPage; }
            set
            {
                if (value == this._StartPage)
                    return;
                this._StartPage = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public int EndPage
        {
            get { return this._EndPage; }
            set
            {
                if (value == this._EndPage)
                    return;
                this._EndPage = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public bool CanCreate
        {
            get { return this._CanCreate; }
            set
            {
                if (value == this._CanCreate)
                    return;
                this._CanCreate = value;
                base.OnPropertyChanged();
            }
        }

        public NewChapterViewModel() : base("New Chapter", false, true)
        {
        }

        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Title))
                return false;
            if (this.EndPage < 0)
                return false;
            return true;
        }
        private void Create()
        {
            EventHandler<Chapter> handler = this.onCreated;
            if (handler != null)
                handler(this, new Chapter() {Title = this.Title, StartPage = this.StartPage, EndPage = this.EndPage});
            this.Close();
        }
    }
}
