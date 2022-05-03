using PicViewer.Core;
using PicViewer.Models;
using PicViewer.Services;
using System;

namespace PicViewer
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {

        #region textboxes of main window

        // Info panel. Can into himself send message about error or action was successfully completed. Can be only read by user.
        public string infoPanel;
        public string InfoPanel
        {
            get { return infoPanel; }
            set
            {
                infoPanel = value;
                CheckChanges();
            }
        }

        // Textbox for specifying the directory from which to read the files
        public string copyfromPanel;
        public string CopyFromPanel
        {
            get { return copyfromPanel; }
            set
            {
                copyfromPanel = value;
                CheckChanges();
            }
        }

        // Textbox for specifying the directory from which to copy the files
        public string copytoPanel;
        public string CopyToPanel
        {
            get { return copytoPanel; }
            set
            {
                copytoPanel = value;
                CheckChanges();
            }
        }
        #endregion

        #region rule buttons of main window

        public Command OpenDirectory
        {
            get
            {
                return new Command
                (
                    (obj) =>
                    {
                        AppState appobj = DirectoryDataModel.OpenFolder(CopyFromPanel);
                        InfoPanel = appobj.InformationPanelState;
                        if (appobj.OperationStatus == 1)
                        {
                            ElementCounter = appobj.ElementCounterState;
                            WindowContent = appobj.ContentWindowState;
                        }
                    }
                );
            }
        }

        public Command ClickToLastFile
        {
            get
            {
                return new Command
                (
                    (obj) =>
                    {
                        AppState appobj = DirectoryDataModel.ToLastFile();
                        InfoPanel = appobj.InformationPanelState;
                        if (appobj.OperationStatus == 1)
                        {
                            ElementCounter = appobj.ElementCounterState;
                            WindowContent = appobj.ContentWindowState;
                        }
                    }
                );
            }
        }

        public Command ClickToNextFile
        {
            get
            {
                return new Command
                (
                    (obj) =>
                    {
                        AppState appobj = DirectoryDataModel.ToNextFile();
                        InfoPanel = appobj.InformationPanelState;
                        if (appobj.OperationStatus == 1)
                        {
                            ElementCounter = appobj.ElementCounterState;
                            WindowContent = appobj.ContentWindowState;
                        }
                    }
                );
            }
        }

        public Command CopyFile
        {
            get
            {
                return new Command
                (
                    (obj) =>
                    {

                    }
                );
            }
        }

        public Command DeleteFile
        {
            get
            {
                return new Command
                (
                    (obj) =>
                    {

                    }
                );
            }
        }
        #endregion

        #region for other elements of main window

        public string elementCounter = "0/0";

        public string ElementCounter
        {
            get { return elementCounter;}
            set 
            { 
                elementCounter = value;  
                CheckChanges(); 
            }
        }

        public Uri windowContent;

        public Uri WindowContent
        {
            get { return windowContent; }
            set 
            { 
                windowContent = value;
                CheckChanges();
            }
        }

        #endregion
    }
}