using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Birthday_Calculator
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

        private void datetimepicker__SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = DateTime.Now;
            DateTime? dateofbirth = datetimepicker_.SelectedDate;
            TimeSpan? age = date - dateofbirth;
            if (age.HasValue)
            {
                TimeSpan days = age.Value;
                double number_of_days = Convert.ToInt64(days.TotalDays);
                agetxtblock.Text = get_age(number_of_days);
            }

        }

        string get_age(double days)
        {
            Age age = new Age();
            int years = Convert.ToInt32(days / 365);
            age.years = years; 
            days = days % 365;

            int mounths = Convert.ToInt32(days / 30);
            age.mounths = mounths;
            days = days % 30;

            age.days = Convert.ToInt32(days);

            return age.ToString();
        }
    }
    class Age
    {
        public int years {  get; set; } 
        public int mounths {  get; set; } 
        public int days {  get; set; } 
        public Age() { }

        public override string ToString()
        {
            return $"Your age is {years} Years, {mounths} Months and {days} Days.";
        }
    }
}