using PicViewer.Services;

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
        public Command ClickToNextFile
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

        public Command ClickToLastFile
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

        public Command OpenDirectory
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
    }
}