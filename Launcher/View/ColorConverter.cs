using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Launcher.View
{
    class UIColorConverter
    {
        /// <summary>
        /// Darkens color
        /// </summary>
        /// <param name="solidColorBrush"></param>
        /// <returns></returns>
        public static SolidColorBrush DarkDarkColor(SolidColorBrush solidColorBrush)
        {
            Color Media_Color = solidColorBrush.Color;

            System.Drawing.Color color = System.Drawing.Color.FromArgb(Media_Color.A, Media_Color.R, Media_Color.G, Media_Color.B);
            var colorDarkened = System.Windows.Forms.ControlPaint.DarkDark(color);
            return new SolidColorBrush(Color.FromArgb(colorDarkened.A, colorDarkened.R, colorDarkened.G, colorDarkened.B));
        }
        public static SolidColorBrush DarkColor(SolidColorBrush solidColorBrush)
        {
            Color Media_Color = solidColorBrush.Color;

            System.Drawing.Color color = System.Drawing.Color.FromArgb(Media_Color.A, Media_Color.R, Media_Color.G, Media_Color.B);
            var colorDarkened = System.Windows.Forms.ControlPaint.Dark(color);
            return new SolidColorBrush(Color.FromArgb(colorDarkened.A, colorDarkened.R, colorDarkened.G, colorDarkened.B));
        }
        public static SolidColorBrush LightLight(SolidColorBrush solidColorBrush)
        {
            Color Media_Color = solidColorBrush.Color;

            System.Drawing.Color color = System.Drawing.Color.FromArgb(Media_Color.A, Media_Color.R, Media_Color.G, Media_Color.B);
            var colorLightened = System.Windows.Forms.ControlPaint.LightLight(color);
            return new SolidColorBrush(Color.FromArgb(colorLightened.A, colorLightened.R, colorLightened.G, colorLightened.B));
        }
        public static SolidColorBrush Light(SolidColorBrush solidColorBrush)
        {
            Color Media_Color = solidColorBrush.Color;

            System.Drawing.Color color = System.Drawing.Color.FromArgb(Media_Color.A, Media_Color.R, Media_Color.G, Media_Color.B);
            var colorLightened = System.Windows.Forms.ControlPaint.Light(color);
            return new SolidColorBrush(Color.FromArgb(colorLightened.A, colorLightened.R, colorLightened.G, colorLightened.B));
        }
    }
}
