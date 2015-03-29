using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Steppy.BusinessLayer.Models;

namespace Steppy.BusinessLayer.Helpers
{
    public static class ColorHelper
    {
        public static Color ConvertToColor(uint uintCol)
        {
            byte A = (byte)((uintCol & 0xFF000000) >> 24);
            byte R = (byte)((uintCol & 0x00FF0000) >> 16);
            byte G = (byte)((uintCol & 0x0000FF00) >> 8);
            byte B = (byte)((uintCol & 0x000000FF) >> 0);

            return Color.FromArgb(A, R, G, B);
        }

        public static Color ConvertStringToColor(string hex)
        {
            //remove the # at the front
            hex = hex.Replace("#", "");

            byte a = 255;
            byte r = 255;
            byte g = 255;
            byte b = 255;

            int start = 0;

            //handle ARGB strings (8 characters long)
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                start = 2;
            }

            //convert RGB characters to bytes
            r = byte.Parse(hex.Substring(start, 2), System.Globalization.NumberStyles.HexNumber);
            g = byte.Parse(hex.Substring(start + 2, 2), System.Globalization.NumberStyles.HexNumber);
            b = byte.Parse(hex.Substring(start + 4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }

        static readonly uint[] UintColors =
        { 
	        0xFFFFFF00,0xFFFFE135,0xFFFFFF66,0xFFF8DE7E,0xFF008000,0xFF008A00,
	        0xFFADFF2F,0xFF00FF00,0xFF7FFF00,0xFF32CD32,0xFF00FF7F,0xFF90EE90,
	        0xFF3CB371,0xFF00FA9A,0xFF808000,0xFF2E8B57,0xFFFF0000,0xFFFF4500,
	        0xFFFF8C00,0xFFFFA500,0xFFED2939,0xFF800000,0xFFA52A2A,0xFFD2691E,
	        0xFFFF7F50,0xFFDC143C,0xFFE9967A,0xFFFF1493,0xFFB22222,0xFFFF69B4,
	        0xFFCD5C5C,0xFFF08080,0xFFFFB6C1,0xFFFFA07A,0xFFFF00FF,0xFFC71585,
	        0xFFDA70D6,0xFFDB7093,0xFFFA8072,0xFFF4A460,0xFF000080,0xFF4B0082,
	        0xFF191970,0xFF0000FF,0xFF800080,0xFF8A2BE2,0xFF6495ED,0xFF00FFFF,
	        0xFF008B8B,0xFF483D8B,0xFF00BFFF,0xFF1E90FF,0xFFADD8E6,0xFF20B2AA,
	        0xFF87CEFA,0xFFB0C4DE,0xFF76608A,0xFF7B68EE,0xFF4169E1,0xFF6A5ACD,
	        0xFF708090,0xFF4682B4,0xFF008080,0xFF40E0D0,0xFFA9A9A9,0xFFD3D3D3
        };

        private static readonly string[] FlatColors =
        {
            "#1abc9c", "#9b59b6", "#34495e", "#27ae60", "#95a5a6", "#f1c40f", "#c0392b",
            "#d35400", "#2980b9"
        };

        public static List<ThemeOption> GetFlatThemes()
        {
            return FlatColors.Select(s => new ThemeOption(s)).ToList();
        }

        public static List<Color> GetBaseColorSelection()
        {
            return UintColors.Select(ConvertToColor).ToList();
        }
    }
}
