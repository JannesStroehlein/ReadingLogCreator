using ReadingLogCreator.API;
using System;
using System.Windows.Input;

namespace ReadingLogCreator.App.ViewModels
{
    public class NewChapterViewModel : CreationDialogViewModelBase<Chapter>
    {
        private string _Title;
        private int _StartPage;
        private int _EndPage;

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

        private bool CheckCanCreate()
        {
            if (string.IsNullOrWhiteSpace(this.Title))
                return false;
            if (this.EndPage < 0)
                return false;
            return true;
        }

        public override void Create()
        {
            this.RetrunObject(new Chapter() { Title = this.Title, StartPage = this.StartPage, EndPage = this.EndPage });
        }
    }
}
