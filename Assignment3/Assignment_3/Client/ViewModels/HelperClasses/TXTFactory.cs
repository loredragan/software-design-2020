using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;
using Client.ViewModels.Interfaces;

namespace Client.ViewModels.HelperClasses
{
    public class TXTFactory : FileFactory
    {
        public override IFile CreateFile(IEnumerable<Ad> result) => new TXTFile(result);
    }
}
