using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    public abstract class FileFactory
    {
        public abstract IFile CreateFile(IEnumerable<Ad> result);
    }
}
