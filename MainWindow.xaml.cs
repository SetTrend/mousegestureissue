using System;
using System.Windows;

namespace MouseGestureIssue
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		internal static readonly DependencyProperty ScalingProperty = DependencyProperty.Register("Scaling", typeof(double), typeof(MainWindow), new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender), ValidateZoomCallback);



		internal double Scaling
		{
			get => (double)GetValue(ScalingProperty);
			set
			{
				try
				{
					SetValue(ScalingProperty, value);
				}
				catch (ArgumentException) { }
			}
		}



		public MainWindow() => InitializeComponent();



		private static bool ValidateZoomCallback(object value) => value is double d && d >= .1 && d < 5;



		private void ZoomIn_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => Scaling *= 1.1;

		private void ZoomOut_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => Scaling /= 1.1;

		private void ZoomReset_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) => Scaling = 1;
	}
}
