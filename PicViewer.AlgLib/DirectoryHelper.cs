using System.Collections.Generic;
using System.IO;

namespace PicViewer.AlgLib
{
    public class DirectoryHelper
    {
        /// <summary>
        /// Get target direcotry and extensions, after return all files of directory with required extensions as list.
        /// Need for open all target files depending on the purpose of the program.
        /// </summary>
        /// <param name="_targetDirectoryName"></param>
        /// <param name="_targetExtensions"></param>
        /// <returns> List with all files of directory with required extensions </returns>
        public static List<string> GetFilesFromDirectory(string _targetDirectoryName, string[] _targetExtensions)
        {
            if (_targetExtensions.Length == 0) { return null; }
            List<string> output = new List<string>();
            string[] files = Directory.GetFiles(@_targetDirectoryName);
            foreach (var currentFile in files)
            {
                foreach (var currentExp in _targetExtensions)
                {
                    if (GetFileExtension(currentFile) == currentExp)
                    {
                        output.Add(currentFile);
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Let to get extension of file
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        private static string GetFileExtension(string _input)
        {
            var fileComponents = _input.Split('.');
            if (fileComponents == null)
            {
                return "";
            }
            else if (fileComponents.Length == 1) return "";
            return fileComponents[fileComponents.Length - 1];
        }
    }
}