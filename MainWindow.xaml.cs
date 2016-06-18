using Microsoft.Win32;
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



namespace FileTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog ofd_ = new OpenFileDialog();
        private string[] files_ = null;
        public MainWindow()
        {
            InitializeComponent();
            ofd_.Multiselect = true;
        }

        private void select_files_b_Click(object sender, RoutedEventArgs e)
        {
            ofd_.ShowDialog();
            files_ = ofd_.FileNames;
            
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            List<string> filesPath = new List<string>();
            List<string> filesName = new List<string>();
            if (!System.IO.Directory.Exists("Site"))
            {
                System.IO.Directory.CreateDirectory("Site");
            }

            if (!System.IO.Directory.Exists("Site\\files"))
            {
                System.IO.Directory.CreateDirectory("Site\\files");
            }
            foreach (string var in files_)
            {
                string fileName = "";
                List<char> file = new List<char>();

                for (int i = var.Length - 1; i >= 0; i--)
                {
                    if (var[i] == '\\')
                    {
                        break;
                    }
                    file.Add(var[i]);                    
                }

                file.Reverse();

                foreach (char item in file)
                {
                    fileName += item;
                }

                string sourceDest = "Site\\files\\" + fileName;
                System.IO.File.Copy(var, sourceDest, true);

                char last = 'x';
                do
                {
                    last = sourceDest[0];
                    sourceDest = sourceDest.Remove(0, 1);
                } while (last != '\\');


                filesPath.Add(sourceDest);
                filesName.Add(fileName);
            }
            HTMLCreator.createDocument(new Tree(page_tb.Text, backColor_tb.Text, textColor_tb.Text, author_tb.Text, filesPath, filesName));

        }
    }
}
