using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher.View.Expansion
{
    /// <summary>
    /// Logika interakcji dla klasy ExpansionButton.xaml
    /// </summary>
    public partial class ExpansionButton : UserControl
    {
        private readonly Color VANILLA_TRIANGLE_COLOR = Color.FromRgb(210, 173, 66);
        private readonly Color BURNING_CRUSADE_TRIANGLE_COLOR = Color.FromRgb(21, 71, 34);
        private readonly Color WRATH_OF_THE_LICH_KING_TRIANGLE_COLOR = Color.FromRgb(0, 130, 216);
        private readonly Color CATACLYSM_TRIANGLE_COLOR = Color.FromRgb(114, 38, 27);
        private readonly Color MISTS_OF_PANDARIA_TRIANGLE_COLOR = Color.FromRgb(2, 118, 90);
        private readonly Color WARLORDS_OF_DRAENOR_TRIANGLE_COLOR = Color.FromRgb(107, 38, 2);
        private readonly Color LEGION_TRIANGLE_COLOR = Color.FromRgb(71, 93, 28);
        private readonly Color BATTLE_FOR_AZEROTH_TRIANGLE_COLOR = Color.FromRgb(12, 63, 110);

        private const double ACTIVE_OPACITY = 1.0d;
        private const double MOUSE_OVER_INACTIVE_OPACITY = 0.9d;
        private const double MOUSE_LEAVE_INACTIVE_OPACITY = 0.6d;
        private readonly TimeSpan ANIMATION_DURATION = TimeSpan.FromSeconds(0.3f);
        public ExpansionButton()
        {
            InitializeComponent();
            
        }
        private src.Core.Expansion.Expansions _Expansion;

        public src.Core.Expansion.Expansions Expansion
        {
            get { return _Expansion; }
            set { _Expansion = value; OnExpansionChange(); }
        }
        /// <summary>
        /// Occurs at creating control 
        /// </summary>
        private void OnExpansionChange()
        {
            SetTriangleColor();
        }
        private void SetTriangleColor()
        {
            switch (Expansion)
            {
                case src.Core.Expansion.Expansions.Vanilla:
                    Triangle.Fill = new SolidColorBrush(VANILLA_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/vanilla.png", UriKind.Relative));
                    break;
                    case src.Core.Expansion.Expansions.TheBurningCrusade:
                    Triangle.Fill = new SolidColorBrush(BURNING_CRUSADE_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/tbc.png", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.WrathOfTheLichKing:
                    Triangle.Fill = new SolidColorBrush(WRATH_OF_THE_LICH_KING_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/wotlk.jpg", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.Cataclysm:
                    Triangle.Fill = new SolidColorBrush(CATACLYSM_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/cataclysm.png", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.MistsOfPandaria:
                    Triangle.Fill = new SolidColorBrush(MISTS_OF_PANDARIA_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/mop.png", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.WarlordsOfDraenor:
                    Triangle.Fill = new SolidColorBrush(WARLORDS_OF_DRAENOR_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/wod.png", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.Legion:
                    Triangle.Fill = new SolidColorBrush(LEGION_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/legion.png", UriKind.Relative));
                    break;
                case src.Core.Expansion.Expansions.BattleForAzeroth:
                    Triangle.Fill = new SolidColorBrush(BATTLE_FOR_AZEROTH_TRIANGLE_COLOR);
                    Icon.Source = new BitmapImage(new Uri("/View/Expansion/ExpansionIcons/bfa.png", UriKind.Relative));
                    break;
            }
        }

        private bool _Active = false;
        /// <summary>
        /// Indicates if it is currently choosen expansion
        /// </summary>
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; ActiveChanged(); }
        }


        private void ActiveChanged()
        {
            if (_Active)
            {
                //IconBorder.Visibility = Visibility.Visible;
                Triangle.Visibility = Visibility.Visible;
                Animate(MainGrid, OpacityProperty, ACTIVE_OPACITY);
                Marker.Opacity = 1.0f;
                //Opacity = 1.0f;
            }

            else
            {
                
                //IconBorder.Visibility = Visibility.Hidden;
                Triangle.Visibility = Visibility.Hidden;
                Marker.Opacity = 0.6f;
                Animate(MainGrid, OpacityProperty, MOUSE_LEAVE_INACTIVE_OPACITY);
            }
        }
        private void Animate(object obj, DependencyProperty prop, double to)
        {
            System.Windows.Media.Animation.DoubleAnimation da = new System.Windows.Media.Animation.DoubleAnimation();
            double from = (double)(obj as Grid).GetValue(prop);
            try
            {
                da.From = from;
                da.To = to;
                da.Duration = ANIMATION_DURATION;
                (obj as Grid).BeginAnimation(prop, da);
            }
            catch
            {

            }
        }
        private void ExpansionButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Animate(MainGrid, OpacityProperty, 1.0d);
            if (_Active)
                return;
            Animate(MainGrid, OpacityProperty, MOUSE_OVER_INACTIVE_OPACITY);

        }

        private void ExpansionButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_Active)
            {

                return;
            }

            Animate(MainGrid, OpacityProperty, MOUSE_LEAVE_INACTIVE_OPACITY);
        }

        private void ExpansionButton_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindGame_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
