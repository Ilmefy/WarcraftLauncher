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

namespace Launcher.View.AddonView.CategoryList
{
    /// <summary>
    /// Logika interakcji dla klasy CategoryButton.xaml
    /// </summary>
    public partial class CategoryButton : UserControl
    {
        private const double ACTIVE_OPACITY = 1.0d;
        private const double MOUSE_OVER_INACTIVE_OPACITY = 0.9d;
        private const double MOUSE_LEAVE_INACTIVE_OPACITY = 0.6d;
        private readonly TimeSpan ANIMATION_DURATION = TimeSpan.FromSeconds(0.3f);
        public CategoryButton()
        {
            InitializeComponent();
        }
        #region CategoryName
        private string _CategoryName;

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; OnCategoryNameChange(); }
        }
        private void OnCategoryNameChange()
        {
            CategoryNameLabel.Content = CategoryName;
        }
        #endregion
        #region Icon
        private string _IconSource;

        public string IconSource
        {
            get { return _IconSource; }
            set { _IconSource = value; OnIconSourceChange(); }
        }
        private void OnIconSourceChange()
        {
            Icon.Source = new BitmapImage(new Uri(IconSource, UriKind.Relative));
        }
        #endregion
        #region Active
        private bool _Active=false;

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; OnActiveChange(); }
        }
        private void OnActiveChange()
        {
            if (Active)
            {
                Container.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A5000000"));
                Border.Visibility = Visibility.Visible;
            }
                
            else
            {
                Border.Visibility = Visibility.Hidden;
                Container.Background = new SolidColorBrush(Colors.Transparent);
            }
                
        }
        #endregion
        #region Events
        private void Container_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Active = true;
            if(src.Addons.AddonGlobals.CurrentlySelectedCategoryButton!=null)
            {
                src.Addons.AddonGlobals.CurrentlySelectedCategoryButton.Active = false;
                if (src.Addons.AddonGlobals.CurrentlySelectedCategoryButton == this)
                {
                    src.Addons.AddonGlobals.CurrentlySelectedCategoryButton = null;
                    return;
                }
                    
            }
                
            src.Addons.AddonGlobals.CurrentlySelectedCategoryButton = this;
        }
        private void Container_MouseEnter(object sender, MouseEventArgs e)
        {
            Animate(Container, OpacityProperty, 1.0d);
            if (_Active)
                return;
            Animate(Container, OpacityProperty, MOUSE_OVER_INACTIVE_OPACITY);
        }

        private void Container_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_Active)
            {

                return;
            }

            Animate(Container, OpacityProperty, MOUSE_LEAVE_INACTIVE_OPACITY);
        }
        #endregion
        #region Category
        private src.Addons.AddonCategories.Categories _AddonCategory;

        public src.Addons.AddonCategories.Categories AddonCategory
        {
            get { return _AddonCategory; }
            set { _AddonCategory = value; OnAddonCategoryChange(); }
        }
        private void OnAddonCategoryChange()
        {
            CategoryNameLabel.Content = _AddonCategory.ToString();
            ChooseIcon();
        }

        #endregion
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
        /// <summary>
        /// Chooses icon. Icon is determined by category
        /// </summary>
        private void ChooseIcon()
        {
            Uri uri = new Uri($"/View/Icons/CategoryList/Icons/{AddonCategory.ToString()}.png", UriKind.Relative);
            Icon.Source = new BitmapImage(uri);
        }
    }
}
