using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using PhoneApp2.Resources;
using System.IO.IsolatedStorage;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {

        //声明IsolateStorangeSettings
        private IsolatedStorageSettings _appSettings;

        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            _appSettings = IsolatedStorageSettings.ApplicationSettings;
            BindKeyList();
            //实例化
         


            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textblock1.Text = DateTime.Now.ToShortTimeString();
            Uri bing = new Uri("http://cn.bing.com");
            jjmcWebSite.Navigate(bing);
            jjmcWebSite.IsScriptEnabled = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_appSettings.Contains(Key.Text))
            {
                _appSettings[Key.Text] = Value.Text;
            }
            else
            {
                _appSettings.Add(Key.Text,Value.Text);
                _appSettings.Save();
            }
            BindKeyList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Keys.SelectedIndex > -1)
            {
                _appSettings.Remove(Keys.SelectedItem.ToString());
                _appSettings.Save();
            }
            BindKeyList();
        }

        private void CleanAll_Click(object sender, RoutedEventArgs e)
        {
            _appSettings.Clear();
            BindKeyList();
        }

        private void BindKeyList()
        {

            if (_appSettings.Count != 0)
            {
                var result = _appSettings.Select(i => i.Key);
                Keys.ItemsSource = result;
            }
            else
            {
                Keys.ItemsSource = null;
            }
        }

        private void Keys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] != null)
            {
                string key = e.AddedItems[0].ToString();
                if (_appSettings.Contains(key))
                {
                    Key.Text = key;
                    Value.Text = _appSettings[key].ToString();
                }
            }
           
        }

        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}