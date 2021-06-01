using ReadingLogCreator.API;
using System;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    public class NewReadingLogViewModel : CreationDialogViewModelBase<ReadingLog>
    {  
        private string _Title;
        private string _Author;
        private DateTime _ReleaseDate;

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

        public NewReadingLogViewModel()
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
        public override void Create()
        {
            this.RetrunObject(new ReadingLog() { Author = this.Author, Title = this.Title, ReleaseDate = this.ReleaseDate });
        }
    }
}
