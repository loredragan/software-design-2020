using Client.ViewModels.Interfaces;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels.HelperClasses
{
    public abstract class FileFactory
    {
        public abstract IFile CreateFile(IEnumerable<Ad> result);
    }
}
