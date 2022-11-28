using Assignment_2.Models;
using Assignment_2.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.ViewModels.HelperClasses
{
    public abstract class FileFactory
    {
        public abstract IFile CreateFile(IEnumerable<Ad> result);
    }
}
