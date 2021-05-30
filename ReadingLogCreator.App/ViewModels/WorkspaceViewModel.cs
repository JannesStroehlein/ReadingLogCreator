using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLogCreator.App.ViewModels
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        #region TabItemProperties
        private bool _closeable;
        private string _tabTitle;
        private bool _isSelected;
        private bool _pinned;
        public bool Closeable
        {
            get { return this._closeable; }
            set
            {
                if (value == this._closeable)
                    return;
                this._closeable = value;
                base.OnPropertyChanged();
            }
        }
        public string TabTitle
        {
            get { return this._tabTitle; }
            set
            {
                if (value == this._tabTitle)
                    return;
                this._tabTitle = value;
                base.OnPropertyChanged();
            }
        }
        public bool IsSelected
        {
            get { return this._isSelected; }
            set
            {
                if (value == this._isSelected)
                    return;
                this._isSelected = value;
                base.OnPropertyChanged();
            }
        }
        public bool Pinned
        {
            get { return !this._pinned; }
            set
            {
                if (value == this._pinned)
                    return;
                this._pinned = value;
                base.OnPropertyChanged();
            }
        }
        #endregion

        private bool _canClose;

        public event EventHandler<EventArgs> RequestClose;

        public bool CanClose
        {
            get { return this._canClose; }
            set
            {
                if (value == this._canClose)
                    return;
                this._canClose = value;
                base.OnPropertyChanged();
            }
        }

        public WorkspaceViewModel(string TabTitle, bool closeable, bool pinned)
        {
            this.Closeable = closeable;
            this.TabTitle = TabTitle;
            this.Pinned = pinned;
        }
        protected void Close()
        {
            EventHandler<EventArgs> handler = this.RequestClose;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }
}