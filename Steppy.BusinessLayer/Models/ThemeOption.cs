using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Steppy.BusinessLayer.Helpers;

namespace Steppy.BusinessLayer.Models
{
    public class ThemeOption
    {
        public string HexCode { get; set; }

        public Color Color { get; set; }

        public ThemeOption(string hex)
        {
            HexCode = hex;
            Color = ColorHelper.ConvertStringToColor(hex);
        }

        public ThemeOption(Color color)
        {
            Color = color;
            HexCode = color.ToString();
        }
    }
}
