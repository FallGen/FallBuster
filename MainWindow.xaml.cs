using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using static FallBuster.list_program;
using static FallBuster.list_torrent;
using static FallBuster.thema_color;

namespace FallBuster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(0, GetVisibility());
            load_customization_setting();
            load_characteristics();
        }

        //global
        bool main_gamburger = false;
        int selected_GB1 = 0;
        int selected_GB2 = 0;
        string selected_img = null;

        //анимации приложения
        #region
        private void anumation_main_slider()
        {
            DoubleAnimation main_slider = new DoubleAnimation();
            main_slider.Duration = TimeSpan.FromSeconds(0.2);

            if (main_gamburger)
            {
                //скрытая панель
                main_slider.From = 200;
                main_slider.To = 50;

                btn_customization.Content = Resources["img_customization"];
                btn_drivers.Content = Resources["img_drivers"];
                btn_tweaks.Content = Resources["img_tweaks"];
                btn_services.Content = Resources["img_services"];
                btn_characteristics.Content = Resources["img_characteristics"];
            }
            else
            {
                //открытая панель
                main_slider.From = 50;
                main_slider.To = 200;

                btn_customization.Content = "кастомизация";
                btn_drivers.Content = "драйвера и приложения";
                btn_tweaks.Content = "твики";
                btn_services.Content = "службы";
                btn_characteristics.Content = "характеристики";
            }

            main_panel.BeginAnimation(StackPanel.WidthProperty, main_slider);
        }

        private void animation_additional_slider()
        {
            DoubleAnimation main_slider = new DoubleAnimation();
            DoubleAnimation main_slider1 = new DoubleAnimation();

            main_slider1.Duration = main_slider.Duration = TimeSpan.FromSeconds(0.2);

            // сжатие дополнительной панели кастомизация
            if (!main_gamburger)
            {
                main_slider.From = 150;
                main_slider.To = 120;

                main_slider1.From = 250;
                main_slider1.To = 200;
            }
            else
            {
                main_slider.From = 120;
                main_slider.To = 150;

                main_slider1.From = 200;
                main_slider1.To = 250;
            }

            btn_customization_thema.BeginAnimation(Button.WidthProperty, main_slider);
            btn_customization_oboi.BeginAnimation(Button.WidthProperty, main_slider);
            btn_customization_cursor.BeginAnimation(Button.WidthProperty, main_slider);
            btn_customization_sounds.BeginAnimation(Button.WidthProperty, main_slider);
            bnt_customization_other.BeginAnimation(Button.WidthProperty, main_slider);

            btn_programm_programm.BeginAnimation(Button.WidthProperty, main_slider1);
            btn_programm_driver.BeginAnimation(Button.WidthProperty, main_slider1);
            btn_programm_torrent.BeginAnimation(Button.WidthProperty, main_slider1);
        }

        private void anumation_window()
        {
            DoubleAnimation main_slider = new DoubleAnimation();
            DoubleAnimation main_slider1 = new DoubleAnimation();
            DoubleAnimation main_slider2 = new DoubleAnimation();
            DoubleAnimation main_slider3 = new DoubleAnimation();
            main_slider3.Duration = main_slider2.Duration = main_slider1.Duration = main_slider.Duration = TimeSpan.FromSeconds(0.2);

            if (!main_gamburger)
            {
                main_slider.From = 240;
                main_slider.To = 140;

                main_slider1.From = 460;
                main_slider1.To = 400;

                main_slider2.From = 700;
                main_slider2.To = 600;

                main_slider3.From = 750;
                main_slider3.To = 600;

            }
            else
            {
                main_slider.From = 140;
                main_slider.To = 240;

                main_slider1.From = 400;
                main_slider1.To = 460;

                main_slider2.From = 600;
                main_slider2.To = 700;

                main_slider3.From = 600;
                main_slider3.To = 750;
            }

            //GB1_oboi.BeginAnimation(StackPanel.WidthProperty, main_slider);
            listbox_wallpaper.BeginAnimation(ListBox.WidthProperty, main_slider);
            image_panel.BeginAnimation(StackPanel.WidthProperty, main_slider1);
            sound_panel1.BeginAnimation(StackPanel.WidthProperty, main_slider);
            sound_panel2.BeginAnimation(StackPanel.WidthProperty, main_slider1);
            cursor_panel1.BeginAnimation(StackPanel.WidthProperty, main_slider);
            cursor_panel2.BeginAnimation(StackPanel.WidthProperty, main_slider1);

            program_panel.BeginAnimation(StackPanel.WidthProperty, main_slider3);
            //listview.BeginAnimation(.WidthProperty, main_slider3);
            //TB_panel.BeginAnimation(StackPanel.WidthProperty, main_slider3);
        }
        #endregion

        private void btn_main_slider_Click(object sender, RoutedEventArgs e)
        {
            anumation_main_slider();
            animation_additional_slider();
            anumation_window();

            main_gamburger = !main_gamburger;
        }

        private System.Windows.Visibility GetVisibility()
        {
            return Visibility;
        }

        // hexcolor
        // #CADEFC
        // #CCA8E9
        // #C3BEF0
        // #DEFCF9 
        private Style btn_style(bool status)
        {
            Style buttonStyle = new Style();

            buttonStyle.Setters.Add(new Setter { Property = FontFamilyProperty, Value = new FontFamily("Segoe UI") });
            buttonStyle.Setters.Add(new Setter { Property = FontSizeProperty, Value = Convert.ToDouble(14) });
            buttonStyle.Setters.Add(new Setter { Property = FontWeightProperty, Value = FontWeights.DemiBold });
            buttonStyle.Setters.Add(new Setter { Property = ForegroundProperty, Value = new SolidColorBrush(Colors.Black) });
            if (status)
            {
                buttonStyle.Setters.Add(new Setter { Property = BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(0xDE, 0xFC, 0xF9)) });

            }
            else
            {
                buttonStyle.Setters.Add(new Setter { Property = BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(0xCA, 0xDE, 0xFC)) });
            }

            return buttonStyle;
        }

        //главная панель управления
        #region
        private void selected_btn_slider_main(int value, System.Windows.Visibility visibility)
        {
            //отключение всех панелей GB
            //GB0.Visibility = Visibility.Collapsed;
            GB1.Visibility = System.Windows.Visibility.Collapsed;
            GB2.Visibility = System.Windows.Visibility.Collapsed;
            GB3.Visibility = System.Windows.Visibility.Collapsed;
            GB4.Visibility = System.Windows.Visibility.Collapsed;
            GB5.Visibility = System.Windows.Visibility.Collapsed;

            btn_main_slider.Style = btn_style(false);
            btn_customization.Style = btn_style(false);
            btn_drivers.Style = btn_style(false);
            btn_tweaks.Style = btn_style(false);
            btn_services.Style = btn_style(false);
            btn_characteristics.Style = btn_style(false);
            btn_1.Style = btn_style(false);
            btn_2.Style = btn_style(false);
            btn_exit.Style = btn_style(false);

            switch (value)
            {
                case 0:
                    //GB0.Visibility = Visibility.Visible;
                    break;
                case 1:
                    GB1.Visibility = System.Windows.Visibility.Visible;
                    btn_customization.Style = btn_style(true);

                    break;
                case 2:
                    GB2.Visibility = System.Windows.Visibility.Visible;
                    btn_drivers.Style = btn_style(true);

                    break;
                case 3:
                    GB3.Visibility = System.Windows.Visibility.Visible;
                    btn_tweaks.Style = btn_style(true);
                    break;
                case 4:
                    GB4.Visibility = System.Windows.Visibility.Visible;
                    btn_services.Style = btn_style(true);
                    break;
                case 5:
                    GB5.Visibility = System.Windows.Visibility.Visible;
                    btn_characteristics.Style = btn_style(true);
                    break;
            }
        }

        private void btn_customization_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(1, GetVisibility());
            selected_btn_slider_customization(selected_GB1);
        }

        private void btn_drivers_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(2, GetVisibility());
            selected_btn_slider_programm(selected_GB2);
            load_spisok_programm();
        }

        private void btn_tweaks_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(3, GetVisibility());
        }

        private void btn_services_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(4, GetVisibility());
        }

        private void btn_characteristics_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_main(5, GetVisibility());
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        //кастомайзерская панель управления
        #region
        private void selected_btn_slider_customization(int value)
        {
            selected_GB1 = value;

            GB1_thema.Visibility = System.Windows.Visibility.Collapsed;
            GB1_oboi.Visibility = System.Windows.Visibility.Collapsed;
            GB1_cursor.Visibility = System.Windows.Visibility.Collapsed;
            GB1_sounds.Visibility = System.Windows.Visibility.Collapsed;
            GB1_other.Visibility = System.Windows.Visibility.Collapsed;

            btn_customization_thema.Style = btn_style(false);
            btn_customization_oboi.Style = btn_style(false);
            btn_customization_cursor.Style = btn_style(false);
            btn_customization_sounds.Style = btn_style(false);
            bnt_customization_other.Style = btn_style(false);

            switch (value)
            {
                case 0:
                    GB1_thema.Visibility = System.Windows.Visibility.Visible;
                    btn_customization_thema.Style = btn_style(true);
                    break;
                case 1:
                    GB1_oboi.Visibility = System.Windows.Visibility.Visible;
                    btn_customization_oboi.Style = btn_style(true);
                    break;
                case 2:
                    GB1_cursor.Visibility = System.Windows.Visibility.Visible;
                    btn_customization_cursor.Style = btn_style(true);
                    break;
                case 3:
                    GB1_sounds.Visibility = System.Windows.Visibility.Visible;
                    btn_customization_sounds.Style = btn_style(true);
                    break;
                case 4:
                    GB1_other.Visibility = System.Windows.Visibility.Visible;
                    bnt_customization_other.Style = btn_style(true);
                    break;
            }
        }

        private class image_lisbox
        {
            public string image_path { get; set; }
        }

        List<string> temp_list = new List<string>();
        List<string> temp_list1 = new List<string>();

        private void view_wallpaper()
        {
            var urls = @"https://www.wallpaperflare.com/";
            List<image_lisbox> list = new List<image_lisbox>();

            temp_list = new List<string>();
            temp_list1 = new List<string>();

            HttpClientHandler hdl = new HttpClientHandler { };
            var clnt = new HttpClient(hdl);

            HttpResponseMessage resp = clnt.GetAsync(urls).Result;
            var html = resp.Content.ReadAsStringAsync().Result;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            //получение миниатюры фотографии
            var htmlNodes_src = doc.DocumentNode.SelectNodes("//html/body/main/ul/li/figure/a/img");
            foreach (var node in htmlNodes_src)
            {
                list.Add(new image_lisbox()
                {
                    image_path = node.Attributes["data-src"].Value
                });

                temp_list.Add(node.Attributes["data-src"].Value);
            }

            //получение ссылки для скачивания фото
            var htmlNodes_ref = doc.DocumentNode.SelectNodes("//html/body/main/ul/li/figure/a");
            foreach (var node in htmlNodes_ref)
            {
                temp_list1.Add(node.Attributes["href"].Value);
            }

            string[] mas_url_img = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                mas_url_img[i] = temp_list[i].ToString();
                //read_textbox.Text += temp_list[i] + "\n";
            }

            listbox_wallpaper.ItemsSource = list;
            //temp_label1.Content = "кол-во загруженных фото " + list.Count;
        }

        private void btn_customization_thema_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_customization(0);
        }

        private void btn_customization_oboi_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_customization(1);
            view_wallpaper();
        }

        private void btn_customization_cursor_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_customization(2);
            load_cursors();
        }

        private void btn_customization_sounds_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_customization(3);
            load_sounds();
        }
        private void bnt_customization_other_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_customization(4);
        }

        #endregion

        //смена обоев 
        #region
        public void save_wallpaper()
        {
            try
            {
                download_wallpaper_1step(temp_list1[listbox_wallpaper.SelectedIndex]);

                string path_wallpaper = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\wallpaper\wallpaper.jpg";

                wallpaper wallpaper = new wallpaper();

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(selected_img), path_wallpaper);
                }

                wallpaper.changewallpaper(path_wallpaper, 1, 0);
            }
            catch
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\wallpaper";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);

                save_wallpaper();
            }
        }

        //загрузка фотографии
        private void download_wallpaper_1step(string url)
        {
            try
            {
                HttpClientHandler hdl = new HttpClientHandler { };
                var clnt = new HttpClient(hdl);

                HttpResponseMessage resp = clnt.GetAsync(url).Result;
                var html = resp.Content.ReadAsStringAsync().Result;

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var htmlNodes_href = doc.DocumentNode.SelectNodes("//html/body/main/section[1]/div[1]/a");

                string href = string.Empty;

                foreach (var node in htmlNodes_href)
                {
                    href = node.Attributes["href"].Value;
                }

                download_wallpaper_2step(href);
            }
            catch { }
        }

        private void download_wallpaper_2step(string url)
        {
            HttpClientHandler hdl = new HttpClientHandler { };
            var clnt = new HttpClient(hdl);

            HttpResponseMessage resp = clnt.GetAsync(url).Result;
            var html = resp.Content.ReadAsStringAsync().Result;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var htmlNodes_src = doc.DocumentNode.SelectNodes("//html/body/main/section[1]/img");

            foreach (var node in htmlNodes_src)
            {
                selected_img = node.Attributes["src"].Value;
            }
        }

        private void btn_setwallpaper_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_wallpaper.SelectedIndex != -1)
                save_wallpaper();
        }

        #endregion

        private void listbox_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                string selected_url = temp_list[listbox_wallpaper.SelectedIndex];

                preview_selected_img.Source = new BitmapImage(new Uri(selected_url));
            }
            catch { }
        }

        private void desktop_icons_Click(object sender, RoutedEventArgs e)
        {
            class_desktop_icons class_desktop_icons = new class_desktop_icons();

            class_desktop_icons.ToggleDesktopIcons();

            save_customization_setting();
        }

        private void save_customization_setting()
        {
            string file_settings = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\settings\customization_setting";

            try
            {
                using (BinaryWriter file = new BinaryWriter(File.Open(file_settings, FileMode.Create)))
                {
                    file.Write((bool)desktop_icons.IsChecked);
                    file.Write((bool)tasckbar_windows.IsChecked);
                    file.Write(CB_thema_main.SelectedIndex);
                }
            }
            catch { }
        }

        private void load_customization_setting()
        {
            string file_settings = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\settings\customization_setting";

            try
            {
                using (BinaryReader file = new BinaryReader(File.Open(file_settings, FileMode.Open)))
                {
                    desktop_icons.IsChecked = file.ReadBoolean();
                    tasckbar_windows.IsChecked = file.ReadBoolean();
                    CB_thema_main.SelectedIndex = file.ReadInt32();
                }
            }
            catch
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\settings";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);
            }
        }

        private void tasckbar_windows_Click(object sender, RoutedEventArgs e)
        {
            taskbar taskbar = new taskbar();

            if ((bool)tasckbar_windows.IsChecked)
                taskbar.SetTaskbarState(taskbar.AppBarStates.AlwaysOnTop);
            else
                taskbar.SetTaskbarState(taskbar.AppBarStates.AutoHide);

            save_customization_setting();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void close_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void collapse_window_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #region
        private class cursors_listbox
        {
            public string name_cursors { get; set; }
        }

        List<cursors_listbox> cursors = new List<cursors_listbox>();
        List<string> cursors_string = new List<string>();

        private void load_cursors()
        {
            try
            {
                cursors.Clear();
                listbox_cursor.Items.Clear();
                cursors_string.Clear();

                string path1 = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp";
                string path2 = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main";

                bool flag = false;

                if (Directory.Exists(path1))
                    flag = true;
                else
                    throw new Exception();

                if (flag && !Directory.Exists(path2))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(@"https://github.com/FallGen/download_cursor/archive/refs/heads/main.zip"), $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\cursors.zip");
                    }

                    //РАБОЧАЯ РАСПАКОВКА
                    string startPath = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\cursors.zip";
                    string zipPath = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\";
                    ZipFile.ExtractToDirectory(startPath, zipPath, true);
                }

                string[] name_folders = Directory.GetDirectories($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main");
                foreach (string folder in name_folders)
                {
                    cursors.Add(new cursors_listbox()
                    {
                        name_cursors = folder.Replace($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main\", "")
                    });

                    cursors_string.Add(folder.Replace($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main\", ""));
                }

                for (int i = 0; i < cursors.Count; i++)
                {
                    listbox_cursor.Items.Add(cursors[i]);
                }
            }
            catch (Exception E)
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\temp";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);

                load_cursors();
            }
        }

        private void btn_setup_cursor_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_cursor.SelectedIndex != -1)
                setup_cursors();
        }

        private void setup_cursors()
        {
            try
            {
                //поиск файла инсталлятора
                string name_cursor = cursors_string[listbox_cursor.SelectedIndex];
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main\";

                string instal_file = string.Empty;

                string[] name_files = Directory.GetFiles(path + name_cursor);
                foreach (string filename in name_files)
                {
                    string temp_process = filename.Replace(path + name_cursor, "").Replace("\\", "");

                    if (temp_process.IndexOf(".inf") > -1)
                        instal_file = temp_process;
                }

                string command = $@"RunDll32 advpack.dll,LaunchINFSection C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main\{name_cursor}\" + instal_file + ",DefaultInstall";

                //РАБОЧАЯ УСТАНОВКА КУРСОРА

                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.WorkingDirectory = @"C:\Windows\System32";
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/user:Administrator \"cmd /C " + command;
                process.StartInfo = startInfo;
                process.Start();

                startInfo.Arguments = "/user:Administrator \"cmd /C " + "main.cpl";
                process.Start();
            }
            catch
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\temp";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);

                setup_cursors();
            }
        }


        private void listbox_cursor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            view_cursor();
        }

        private void view_cursor()
        {
            try
            {
                panel_view_cursor.Visibility = Visibility.Visible;
                List<string> list_name_cursors = new List<string>();

                string name_cursor = cursors_string[listbox_cursor.SelectedIndex];

                string[] exception = { "install", "install.inf", ".inf", ".install.inf", "readmi", ".txt", ".img", ".png", "ani", ".lnk", ".bat", ".jpg" };
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_cursor-main\";

                string[] name_files = Directory.GetFiles(path + name_cursor);
                foreach (string filename in name_files)
                {
                    string temp_process = filename.Replace(path + name_cursor, "").Replace("\\", "");
                    int flag = 0;

                    for (int i = 0; i < exception.Length; i++)
                        if (temp_process.ToLower().IndexOf(exception[i]) > -1)
                            flag += 1;

                    if (flag == 0) list_name_cursors.Add(temp_process);
                }

                temp_textbox.Text = "кол-во файлов: " + list_name_cursors.Count + "\n";

                if (list_name_cursors.Count > 3)
                {
                    Random rnd = new Random();

                    curcor1.Visibility = Visibility.Visible; curcor2.Visibility = Visibility.Visible;
                    curcor3.Visibility = Visibility.Visible; curcor4.Visibility = Visibility.Visible;
                    cursor_warning.Visibility = Visibility.Collapsed;

                    curcor1.Source = new BitmapImage(new Uri(path + name_cursor + @"\" + list_name_cursors[rnd.Next(0, list_name_cursors.Count)]));
                    curcor2.Source = new BitmapImage(new Uri(path + name_cursor + @"\" + list_name_cursors[rnd.Next(0, list_name_cursors.Count)]));
                    curcor3.Source = new BitmapImage(new Uri(path + name_cursor + @"\" + list_name_cursors[rnd.Next(0, list_name_cursors.Count)]));
                    curcor4.Source = new BitmapImage(new Uri(path + name_cursor + @"\" + list_name_cursors[rnd.Next(0, list_name_cursors.Count)]));
                }
                else
                {
                    curcor1.Visibility = Visibility.Collapsed; curcor2.Visibility = Visibility.Collapsed;
                    curcor3.Visibility = Visibility.Collapsed; curcor4.Visibility = Visibility.Collapsed;
                    cursor_warning.Visibility = Visibility.Visible;
                }
            }
            catch { }
        }


        #endregion

        //загрузка звуков
        #region
        private class sounds_listbox
        {
            public string name_sound { get; set; }
        }

        List<sounds_listbox> sounds = new List<sounds_listbox>();
        List<string> sounds_string = new List<string>();
        private UserControl sender;

        private void load_sounds()
        {
            try
            {
                sounds.Clear();
                listbox_sound.Items.Clear();
                sounds_string.Clear();

                string path1 = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp";
                string path2 = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main";

                bool flag = false;

                if (Directory.Exists(path1))
                    flag = true;
                else
                    throw new Exception();

                if (flag && !Directory.Exists(path2))
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(@"https://github.com/FallGen/download_sound/archive/refs/heads/main.zip"), $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\sounds.zip");
                    }

                    //РАБОЧАЯ РАСПАКОВКА
                    string startPath = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\sounds.zip";
                    string zipPath = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\";
                    //string extractPath = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\cursors";
                    ZipFile.ExtractToDirectory(startPath, zipPath, true);
                }

                string[] name_folders = Directory.GetDirectories($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main");
                foreach (string folder in name_folders)
                {
                    sounds.Add(new sounds_listbox()
                    {
                        name_sound = folder.Replace($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main\", "")
                    });

                    sounds_string.Add(folder.Replace($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main\", ""));
                }

                for (int i = 0; i < sounds.Count; i++)
                {
                    listbox_sound.Items.Add(sounds[i]);
                }
            }
            catch (Exception E)
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\temp";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);

                load_sounds();
            }
        }

        private void setup_sounds()
        {
            try
            {
                //поиск файла инсталлятора
                string name_sound = sounds_string[listbox_sound.SelectedIndex];
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main\";

                string instal_file = string.Empty;

                string[] name_files = Directory.GetFiles(path + name_sound);
                foreach (string filename in name_files)
                {
                    string temp_process = filename.Replace(path + name_sound, "").Replace("\\", "");

                    if (temp_process.IndexOf(".inf") > -1 || temp_process.IndexOf(".exe") > -1)
                        instal_file = temp_process;
                }

                if (instal_file.IndexOf(".inf") > -1)
                {
                    //РАБОЧАЯ УСТАНОВКА звука
                    string command = $@"RunDll32 advpack.dll,LaunchINFSection C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main\{name_sound}\" + instal_file + ",DefaultInstall";

                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.WorkingDirectory = @"C:\Windows\System32";
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/user:Administrator \"cmd /C " + command;
                    process.StartInfo = startInfo;
                    process.Start();

                    startInfo.Arguments = "/user:Administrator \"cmd /C " + "mmsys.cpl";
                    process.Start();
                }
                else
                    if (instal_file.IndexOf(".exe") > -1)
                {
                    Process.Start($@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\temp\download_sound-main\{name_sound}\" + instal_file);
                }
            }
            catch
            {
                //создание папки
                string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                string subpath = @"FallBuster\temp";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();
                dirInfo.CreateSubdirectory(subpath);

                setup_cursors();
            }
        }

        private void btn_download_sound_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_sound.SelectedIndex != -1)
                setup_sounds();
        }
        #endregion


        private void load_characteristics()
        {
            try
            {
                info_windows info = new info_windows();

                info_user.Content = "информация о " + Environment.MachineName + " пользователя " + Environment.UserName;

                string bit = string.Empty;
                bit = (Environment.Is64BitOperatingSystem) ? "x64" : "x86";

                info_windows.Content = info.get_info("Win32_OperatingSystem").Replace(@"|C:\Windows|\Device\Harddisk0\Partition3", "") + " " + bit + "\n";
                info_windows.Content += Environment.OSVersion.VersionString;

                info_cpu.Content = info.get_info("Win32_Processor");

                info_gpu.Content = info.get_info("Win32_VideoController");

                info_rom.Content = info.get_info("Win32_MemoryDevice");

                info_ram.Content = info.get_info("Win32_LogicalDisk") + info.get_info("Win32_DiskDrive");

                info_monitor.Content = info.get_info("Win32_DesktopMonitor");

                info_audio.Content = info.get_info("Win32_SoundDevice");

                info_motherboarddevice.Content = info.get_info("Win32_ComputerSystemProduct") + " " + info.get_info("Win32_MotherboardDevice");
            }
            catch
            {
                info_user.Content = "error";
            }

        }

        private void selected_btn_slider_programm(int value)
        {
            selected_GB2 = value;

            GB2_programm.Visibility = System.Windows.Visibility.Collapsed;
            GB2_driver.Visibility = System.Windows.Visibility.Collapsed;
            GB2_torrent.Visibility = System.Windows.Visibility.Collapsed;

            btn_programm_programm.Style = btn_style(false);
            btn_programm_driver.Style = btn_style(false);
            btn_programm_torrent.Style = btn_style(false);

            switch (value)
            {
                case 0:
                    GB2_programm.Visibility = System.Windows.Visibility.Visible;
                    btn_programm_programm.Style = btn_style(true);
                    break;
                case 1:
                    GB2_driver.Visibility = System.Windows.Visibility.Visible;
                    btn_programm_driver.Style = btn_style(true);
                    break;
                case 2:
                    GB2_torrent.Visibility = System.Windows.Visibility.Visible;
                    btn_programm_torrent.Style = btn_style(true);
                    break;
            }
        }

        private void btn_programm_programm_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_programm(0);
        }

        private void btn_programm_driver_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_programm(1);
        }

        //class programm
        //{
        //    public string name_programm { get; set; }
        //    public string image { get; set; }
        //    public string opisanie { get; set; }
        //}

        //List<programm> name_programm = new List<programm>();
        public List<item_program> items_program { get; set; } = class_list_program.getitem_programs();
        public List<name_thema> items_thema { get; set; } = class_name_thema.get_name_thema();
        public List<item_torrent> items_torrent { get; set; } = class_item_torrent.getitem_torrent();

        //public List<item> mylist { get; set; } = list.getitems();

        private void load_spisok_programm()
        {




            //name_programm = new List<programm>();
            //listbox_programm.Items.Clear();
            //textblock1.Items.Clear();
            //programm programm = new programm();
            //string[] qwe = { "qwe", "ddd" };

            // name_programm.Add(new programm);

            //for (int i = 0; i < qwe.Length; i++)
            //{
            //    name_programm.Add(new programm()
            //    {
            //        name_programm = qwe[i],
            //    });

            //    // (name_programm[i]);
            //    //listbox_programm.Items.Add(name_programm[i]);
            //}


            //programm.get_name_programm();

            //listbox_programm.Items.Add(programm);




        }

        private void listview_program_MouseUp(object sender, MouseButtonEventArgs e)
        {
            download_program();
        }

        private void download_program()
        {
            string str = items_program[listview_program.SelectedIndex].ToString();
            string name_program = str.Substring(0, str.IndexOf("|razdel|"));
            string download_link = str.Substring(name_program.Length + 8);

            if (MessageBox.Show("запустить процесс скачивания и установки " + name_program + "?", "уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)

                try
                {
                    //this.Cursor = Cursors.Wait;

                    //Random rnd = new Random();

                    //label_info.Content = "скачивание " + name_program;

                    string type = ".exe";

                    if (download_link.IndexOf(".zip") > -1)
                        type = ".zip";
                    else
                        if (download_link.IndexOf(".rar") > -1)
                        type = ".rar";
                    else
                        if (download_link.IndexOf(".msi") > -1)
                        type = ".msi";


                    tb_link.Text = name_program + "   " + download_link;

                    if (download_link != null && download_link != "" && download_link != string.Empty)
                    {

                        string small_path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\program\";
                        string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\program\" + name_program + type;

                        if (!File.Exists(path))
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(new Uri(download_link), path);
                            }

                        if (type.IndexOf(".exe") > -1 || type.IndexOf(".msi") > -1)
                            Process.Start(path);
                        else
                                if (type.IndexOf(".zip") > -1 || type.IndexOf(".rar") > -1)
                        {
                            if (!File.Exists(small_path + @"\" + name_program))
                            {
                                string startPath = path;
                                string zipPath = small_path;
                                ZipFile.ExtractToDirectory(startPath, zipPath, true);
                            }

                            string instal_file = string.Empty;

                            string[] name_files = Directory.GetFiles(small_path);
                            foreach (string filename in name_files)
                            {
                                string temp_process = filename.Replace(small_path, "");

                                if (temp_process.IndexOf(name_program) > -1 && temp_process.IndexOf(".exe") > -1)
                                    instal_file = temp_process;
                            }

                            tb_link.Text = name_program + "\n";
                            tb_link.Text += instal_file + "\n";
                            Process.Start(small_path + instal_file);
                        }
                        //label_info.Content = "для скачивания нажать на строку";

                        //this.Cursor = Cursors.Arrow;
                    }
                }
                catch
                {
                    //label_info.Content = "для скачивания нажать на строку";
                    //this.Cursor = Cursors.Arrow;

                    //создание папки
                    string path = $@"C:\Users\{Environment.UserName}\AppData\Roaming\";
                    string subpath = @"FallBuster\program";

                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                        dirInfo.Create();
                    dirInfo.CreateSubdirectory(subpath);

                    download_program();
                }

        }

        private void ooo_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_programm_torrent_Click(object sender, RoutedEventArgs e)
        {
            selected_btn_slider_programm(2);
        }

        private void link_open_dir(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", $@"C:\Users\{Environment.UserName}\AppData\Roaming\FallBuster\program\");
            }
            catch { }
        }

        private void listview_torrent_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void CB_thema_main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            save_customization_setting();
        }

        private void btn_123_Click(object sender, RoutedEventArgs e)
        {
            LockWorkStation();
        }



        //Компьютер\HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize
    }
}
