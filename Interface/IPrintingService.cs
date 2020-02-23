using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tournaments.WPF.Interface
{
    public interface IPrintingService
    {
        bool TryPrintData(UIElement _data, string _description);
    }
}
