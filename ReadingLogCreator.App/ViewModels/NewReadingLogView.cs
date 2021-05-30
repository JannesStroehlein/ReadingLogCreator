using ReadingLogCreator.API;
using System;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    public class NewReadingLogView : WorkspaceViewModel
    {
        private RelayCommand _CancelCommand;       
        private RelayCommand _CreateCommand;       

        private string _Title;
        private string _Author;
        private DateTime _ReleaseDate;
        private bool _CanCreate;

        public event EventHandler<ReadingLog> onCreated;

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
        public string Author
        {
            get { return this._Author; }
            set
            {
                if (value == this._Author)
                    return;
                this._Author = value;
                base.OnPropertyChanged();
                this.CanCreate = this.CheckCanCreate();
            }
        }
        public DateTime ReleaseDate
        {
            get { return this._ReleaseDate; }
            set
            {
                if (value == this._ReleaseDate)
                    return;
                this._ReleaseDate = value;
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

        public NewReadingLogView() : base("New ReadingLog", false, true)
        {
            this.ReleaseDate = DateTime.Now;
        }

        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Title))
                return false;
            if (string.IsNullOrWhiteSpace(this.Author))
                return false;
            if (this.ReleaseDate == DateTime.MinValue)
                return false;
            return true;
        }
        private void Create()
        {
            EventHandler<ReadingLog> handler = this.onCreated;
            if (handler != null)
                handler(this, new ReadingLog() { Author = this.Author, Title = this.Title, ReleaseDate = this.ReleaseDate });
            this.Close();
        }
    }
}
