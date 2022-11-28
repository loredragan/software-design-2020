using Assignment_2.Models;
using Assignment_2.ViewModels.Interfaces;
using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    class TXTFile : IFile
    {
        private const string _format = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
        private SaveFileDialog _saveFileDialog;
        private IEnumerable<Ad> _result;
        public string SavedPath;
        
        public TXTFile(IEnumerable<Ad> result)
        {
            _saveFileDialog = new SaveFileDialog();
            _saveFileDialog.Filter = _format;
            _result = result;
        }
        public void GenerateReport()
        {
            var toCsv = LinqToCSV.ToCsv(_result);
            if (_saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(_saveFileDialog.FileName))
                {
                    
                    writer.Write(toCsv);
                    SavedPath = Path.GetFullPath(_saveFileDialog.FileName);
                    writer.Close();
                }
            }
        }
    }
}
