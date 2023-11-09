using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Stopper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool a=true;
		bool b = true;
		DispatcherTimer dt = new DispatcherTimer();
		Stopwatch sw = new Stopwatch();
		string ido = string.Empty;
		public MainWindow()
		{
			InitializeComponent();
			dt.Tick += dt_Tick;
			dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
		}

		void dt_Tick(object sender, EventArgs e)
		{
			if (sw.IsRunning)
			{
				TimeSpan ts = sw.Elapsed;
				ido = String.Format("{0:00}:{1:00}:{2:00}",
				ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				ora.Text = ido;
			}
		}

		private void startbtn_Click(object sender, RoutedEventArgs e)
		{
			sw.Start();
			dt.Start();
			if (a)
			{
				sw.Start();
				dt.Start();
				start.Content = "Stop";
				reset.Content = "Részidő";
				a = false;
				b = false;
			}
			else
			{
				sw.Stop();
				start.Content = "Start";
				reset.Content = "Reset";
				a = true;
				b = true;
			}
		}

		private void resetbtn_Click(object sender, RoutedEventArgs e)
		{
			if (b)
			{
				sw.Reset();
				ora.Text = "00:00:00";
				sw.Stop();
				start.Content = "Start";
				a = true;
				b = false;
			}
			else
			{
				reszido.Items.Add(ido);
			}
		}
	}
}
