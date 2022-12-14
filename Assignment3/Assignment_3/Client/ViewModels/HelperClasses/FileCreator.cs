using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
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
