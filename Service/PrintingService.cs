using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tournaments.WPF.Service
{
    public class PrintingService:Interface.IPrintingService
    {
        public bool TryPrintData(UIElement _data, string _description)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() != true)
                return false;
            try
            {

                dialog.PrintVisual(_data, _description);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
