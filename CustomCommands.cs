using System.Windows.Input;

using MouseGestureIssue.MouseWheelGestures;

namespace MouseGestureIssue
{
	public static class CustomCommands
	{
		public static RoutedUICommand ZoomIn { get; } = new RoutedUICommand("Zoom in", "ZoomIn", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.OemPlus, ModifierKeys.Control), new MouseWheelGesture(WheelDirection.Down, ModifierKeys.Control) });

		public static RoutedUICommand ZoomOut { get; } = new RoutedUICommand("Zoom out", "ZoomOut", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.OemMinus, ModifierKeys.Control), new MouseWheelGesture(WheelDirection.Up, ModifierKeys.Control) });

		public static RoutedUICommand ZoomReset { get; } = new RoutedUICommand("Reset zoom", "ZoomReset", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.D0, ModifierKeys.Control) });
	}
}
