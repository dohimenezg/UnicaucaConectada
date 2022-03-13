using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EventosVista.MVVM.Model.Utils
{
    public static class Utilities
    {
        public static Boolean anyFieldEmpty(Panel panel)
        {
            foreach (var child in panel.Children)
            {
                if (child is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)child).Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
