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

namespace wpfwdb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveSemesterInfoBtn_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedSemesterItem = semBox.SelectedItem as ComboBoxItem;
            string semester=selectedSemesterItem.Content.ToString();  
            int numOfWeeks= int.Parse(outputSemesterWeeksTB.Text);
            DateTime startDate = DateTime.Parse(dates.ToString());

            using (var context = new ApplicationDbContext())
            {
                //Create an object of the semester class
                Semesters semesters = new Semesters
                {
                    Name = semester,
                    Weeks = numOfWeeks,
                    StartDate = startDate
                };
                context.Semesters.Add(semesters);
                context.SaveChanges();
            }
            MessageBox.Show("Yanela and Fiso did this!!");
            LoadData();
        }

        private void addModuleBtn_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext()) 
            {
                var module = new Modules
                {
                    ModuleCode = moduleCodeTB.Text,
                    ModuleName = moduleNameTB.Text,
                    Credits = int.Parse(moduleCreditsTB.Text),
                    ClassHours = int.Parse(moduleClassHoursTB.Text)
                };
                context.Modules.Add(module);
                context.SaveChanges();
                MessageBox.Show("Module info has been saved");
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var context = new ApplicationDbContext())
            { 
                //Semester table data
                var semesterData = context.Semesters.ToList();
                //Module table data
                var moduleData = context.Modules.ToList();
                //Pass it onto the data gridviews
                gridModules.ItemsSource = moduleData;
                gridSemesters.ItemsSource = semesterData;
            }
        }
    }
}
