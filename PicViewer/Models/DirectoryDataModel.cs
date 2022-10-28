using PicViewer.AlgLib;
using PicViewer.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace PicViewer.Models
{
    public class DirectoryDataModel
    {
        // List for all target files with required extension
        private static List<string> FileList = new List<string>();
        private static int Current_Picture = 0;
        private static string Current_Path;

        public static AppState OpenFolder(string copyfrompanel)
        {
            if (Directory.Exists(copyfrompanel))
            {
                FileList = DirectoryHelper.GetFilesFromDirectory(copyfrompanel, new string[] { "bmp", "jpeg", "jpg", "png" });
                if (FileList.Count == 0)
                {
                    Current_Picture = 0;
                    Current_Path = "";
                    return new AppState
                    {
                        OperationStatus = 0,
                        InformationPanelState = "Указанная директория не имеет файлов изображения.",
                        ElementCounterState = "0/0"
                    };
                }
                else
                {
                    Current_Picture = 0;
                    Current_Path = FileList[0];
                    return new AppState
                    {
                        OperationStatus = 1,
                        InformationPanelState = "Папка открыта.",
                        ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                        CurrentNameOfPicture = FileList[0],
                        ContentWindowState = new Uri(FileList[0])
                    };
                }
            }
            else
            {
                Current_Picture = 0;
                Current_Path = "";
                return new AppState
                {
                    OperationStatus = 0,
                    InformationPanelState = "Указанной папки не существует.",
                    ElementCounterState = "0/0",
                };
            }
        }

        public static AppState ToLastFile()
        {
            if (FileList.Count <= 0)
            {
                return new AppState
                {
                    OperationStatus = 0,
                    InformationPanelState = "Введите название папки."
                };
            }
            Current_Picture--;
            if (Current_Picture < 0)
            {
                Current_Picture = FileList.Count - 1;
                Current_Path = FileList[Current_Picture];
                return new AppState
                {
                    OperationStatus = 1,
                    ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                    ContentWindowState = new Uri(FileList[Current_Picture])
                };
            }
            else
            {
                Current_Path = FileList[Current_Picture];
                return new AppState
                {
                    OperationStatus = 1,
                    ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                    ContentWindowState = new Uri(FileList[Current_Picture])
                };
            }
        }

        public static AppState ToNextFile()
        {
            if (FileList.Count <= 0)
            {
                return new AppState
                {
                    OperationStatus = 0,
                    InformationPanelState = "Введите название папки."
                };
            }
            Current_Picture++;
            if (Current_Picture > FileList.Count - 1)
            {
                Current_Picture = 0;
                Current_Path = FileList[Current_Picture];
                return new AppState
                {
                    OperationStatus = 1,
                    ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                    ContentWindowState = new Uri(FileList[Current_Picture])
                };
            }
            else
            {
                return new AppState
                {
                    OperationStatus = 1,
                    ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                    ContentWindowState = new Uri(FileList[Current_Picture])
                };
            }
        }

        public static AppState ToCopyFile (string copyfrompanel, string copytopanel)
        {
            if (Directory.Exists(copyfrompanel) && Directory.Exists(copytopanel))
            {
                if (FileList.Count == 0)
                {
                    return new AppState
                    {
                        OperationStatus = 0,
                        InformationPanelState = "Директория, из которой предполагается копирование, не имеет файлов изображения."
                    };
                }
                else
                {
                    File.Copy(FileList[Current_Picture], copytopanel + "\\" + Path.GetFileName(FileList[Current_Picture]), true);
                    return new AppState
                    {
                        OperationStatus = 1,
                        InformationPanelState = "Текущее изображение будет скопировано в целевую директорию"
                    };
                }
            }
            else
            {
                return new AppState
                {
                    OperationStatus = 0,
                    InformationPanelState = "Одной из указанных папок не существует."
                };
            }
        }

        public static AppState ToDeleteFile (string copyfromPanel)
        {
            if (FileList.Count <= 0)
            {
                return new AppState
                {
                    OperationStatus = 0,
                    InformationPanelState = "Введите название папки."
                };
            }
            else 
            {
                int mustDeletedFile = Current_Picture;
                Current_Picture--;
                
                if (Current_Picture < 0 && FileList.Count - 1 == 0)
                {
                    File.Delete(FileList[mustDeletedFile]);
                    return new AppState
                    {
                        OperationStatus = 0,
                        InformationPanelState = "В папке не осталось файлов."
                    };
                }
                else if (Current_Picture < 0)
                {
                    Current_Picture = FileList.Count - 2;
                    Current_Path = FileList[Current_Picture];
                }
                else
                {
                    Current_Path = FileList[Current_Picture];
                }

                File.Delete(FileList[mustDeletedFile]);
                FileList = DirectoryHelper.GetFilesFromDirectory(copyfromPanel, new string[] { "bmp", "jpeg", "jpg", "png" });

                return new AppState
                {
                    OperationStatus = 1,
                    InformationPanelState = "Текущее изображение будет удалено.",
                    ElementCounterState = (Current_Picture + 1).ToString() + "/" + (FileList.Count).ToString(),
                    ContentWindowState = new Uri(FileList[Current_Picture])
                };
            }
        }

    }
}