using HandyControl.Controls;
using Microsoft.Win32;
using ReadingLogCreator.API;
using ReadingLogCreator.App.ViewModels;
using ReadingLogCreator.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ReadingLogCreator.App
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private RelayCommand _saveCommand;
        private RelayCommand _saveAsCommand;
        private RelayCommand _openCommand;
        private RelayCommand _addCapterCommand;
        private RelayCommand _addCharacterCommand;
        private RelayCommand _closeCommand;
        private RelayCommand _newReadingLogCommand;

        private bool _CanSave;
        private bool _HasActiveDocument;
        private bool _MenuEnabled;
        private string _WindowTitle;

        private int _selectedIndex;
        private ObservableCollection<WorkspaceViewModel> _workspaces;
        private ReadingLog _activeDocument;

        private string SaveLocation;
        private string DefaultDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ReadingLogCreator";
        #endregion

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(false), param => this._CanSave);
                }
                return _saveCommand;
            }
        }
        public ICommand SaveAsCommand
        {
            get
            {
                if (_saveAsCommand == null)
                {
                    _saveAsCommand = new RelayCommand(param => this.Save(true), param => this._CanSave);
                }
                return _saveAsCommand;
            }
        }
        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                {
                    _openCommand = new RelayCommand(param => this.OpenFile());
                }
                return _openCommand;
            }
        }
        public ICommand AddChapterCommand
        {
            get
            {
                if (_addCapterCommand == null)
                    _addCapterCommand = new RelayCommand(param => this.AddChapter());
                return _addCapterCommand;
            }
        }
        public ICommand AddCharacterCommand
        {
            get
            {
                if (_addCharacterCommand == null)
                    _addCharacterCommand = new RelayCommand(param => this.AddCharacter());
                return _addCharacterCommand;
            }
        }
        public ICommand NewReadingLogCommand
        {
            get
            {
                if (_newReadingLogCommand == null)
                    _newReadingLogCommand = new RelayCommand(param => this.NewReadingLog());
                return _newReadingLogCommand;
            }
        }
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(param => this.Close());
                }
                return _closeCommand;
            }
        }
        #endregion

        #region Properties
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (this._workspaces == null)
                {
                    this._workspaces = new ObservableCollection<WorkspaceViewModel>();
                    this._workspaces.CollectionChanged += this.OnWorkspacesChanged;
                   
                }
                return _workspaces;
            }
        }
        public int SelectedIndex
        {
            get { return this._selectedIndex; }
            set
            {
                if (value == this._selectedIndex)
                    return;
                this._selectedIndex = value;
                base.OnPropertyChanged();
            }
        }
        public bool CanSave
        {
            get { return this._CanSave; }
            set
            {
                if (value == this._CanSave)
                    return;
                this._CanSave = value;
                this.UpdateWindowTitle();
                base.OnPropertyChanged();
            }
        }
        public bool HasActiveDocument
        {
            get { return this._HasActiveDocument; }
            set
            {
                if (value == this._HasActiveDocument)
                    return;
                this._HasActiveDocument = value;
                base.OnPropertyChanged();
            }
        }
        public bool MenuEnabled
        {
            get { return this._MenuEnabled; }
            set
            {
                if (value == this._MenuEnabled)
                    return;
                this._MenuEnabled = value;
                base.OnPropertyChanged();
            }
        }
        public ReadingLog ActiveDocument
        {
            get { return this._activeDocument; }
            set
            {
                if (value == this._activeDocument)
                    return;
                this._activeDocument = value;
                this.HasActiveDocument = value != null;
                base.OnPropertyChanged();
            }
        }
        public string WindowTitle
        {
            get { return this._WindowTitle; }
            set
            {
                if (value == this._WindowTitle)
                    return;
                this._WindowTitle = value;
                base.OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            this.MenuEnabled = true;

            this.UpdateWindowTitle();

            DirectoryInfo directory = new DirectoryInfo(this.DefaultDir);
            if (directory.GetFiles("*.json").Length > 0)
            {
                FileInfo myFile = (from f in directory.GetFiles("*.json")
                                   orderby f.LastWriteTime descending
                                   select f).First();
                if (myFile != null)
                    this.Open(myFile.FullName);
            }
        }
        private void Save(bool saveAs)
        {
            if (this.SaveLocation != null & !saveAs)
            {
                File.WriteAllText(this.SaveLocation, this.ActiveDocument.Serialize());
                this.CanSave = false;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Json Files |*.json|All files |*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.InitialDirectory = this.DefaultDir;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog().Value)
                {
                    File.WriteAllText(saveFileDialog.FileName, this.ActiveDocument.Serialize());
                    this.CanSave = false;
                }
                else
                    this.CanSave = true;
            }
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files |*.json|All files |*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = this.DefaultDir;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog().Value)
            {
                this.Open(openFileDialog.FileName);
            }
        }
        private void Open(string path)
        {
            this.ActiveDocument = ReadingLog.Deserialize(File.ReadAllText(path));
            this.SaveLocation = path;
            this.CanSave = false;
            this.UpdateWindowTitle();
            this.OpenReadingLogTab();
        }
        private void AddChapter()
        {

        }
        private void AddCharacter()
        {

        }
        private void NewReadingLog()
        {
            if (!this.CanSave)
            {
                this.MenuEnabled = false;
                NewReadingLogView newReadingLogView = new NewReadingLogView();
                newReadingLogView.onCreated += NewReadingLogView_onCreated;
                newReadingLogView.RequestClose += delegate { this.MenuEnabled = true; };
                this.Workspaces.Add(newReadingLogView);
            }
        }
        private void NewReadingLogView_onCreated(object sender, ReadingLog e)
        {
            this.ActiveDocument = e;
            this.CanSave = true;
            this.MenuEnabled = true;
            this.HasActiveDocument = true;
            this.OpenReadingLogTab();
        }
        private void Close()
        {
            Application.Current.Shutdown();
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            this.Workspaces.Remove(sender as WorkspaceViewModel);
        }
        private void UpdateWindowTitle()
        {
            this.WindowTitle = "ReadingLogCreator " + (this.ActiveDocument != null ? string.Format($"({this.ActiveDocument.Title})") : "") + (this.CanSave ? "*" : "");
        }
        private void OpenReadingLogTab()
        {
            this.Workspaces.Add(new ReadingLogViewModel(this.ActiveDocument));
        }
    }
}
