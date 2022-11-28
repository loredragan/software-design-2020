using Assignment_2.Models;
using Assignment_2.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public class PDFFactory : FileFactory
    {
        public override IFile CreateFile(IEnumerable<Ad> result) => new PDFFile(result);
    }
}
