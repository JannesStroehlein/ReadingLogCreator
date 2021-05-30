using ReadingLogCreator.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLogCreator.App.ViewModels
{
    public class ReadingLogViewModel : WorkspaceViewModel
    {
        #region Fields
        private ReadingLog ReadingLog;
        #endregion
        #region Properties
        public string Title => this.ReadingLog.Title;
        public string Author => this.ReadingLog.Author;
        public int ReleaseYear => this.ReadingLog.ReleaseDate.Year;
        #endregion
        public ReadingLogViewModel(ReadingLog readingLog) : base("Home", false, false)
        {
            this.ReadingLog = readingLog;
        }
    }
}
