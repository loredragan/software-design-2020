using Assignment_2.Models;
using Assignment_2.ViewModels.Interfaces;
using Assignment_2.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public class FileCreator
    {
        private readonly Dictionary<FileTypes, FileFactory> _factories;

        public FileCreator()
        {
            _factories = new Dictionary<FileTypes, FileFactory>
            {
                {FileTypes.Text, new TXTFactory()},
                {FileTypes.Pdf, new PDFFactory() }
            };
        }

        public IFile ExecuteCreation(FileTypes file, IEnumerable<Ad> result) => _factories[file].CreateFile(result);
    }
}
