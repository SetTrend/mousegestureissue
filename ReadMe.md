# MCVE: MouseGesture not getting called correctly when being added to InputGestureCollection

This repository serves as an minimal, complete, verifyable example for the following WPF issue, reported on GitHub:

[/dotnet/wpf/issues/5141](https://github.com/dotnet/wpf/issues/5141)

## Main Window Screenshot

![Main window screenshot](doc/MainWindow%20screenshot.png)

<hr/>

## Problem description:

Having created a custom command like this:

```c#
public static RoutedUICommand ZoomIn { get; } = new RoutedUICommand("Zoom in", "ZoomIn", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.OemPlus, ModifierKeys.Control), new MouseWheelGesture(WheelDirection.Down, ModifierKeys.Control) });
```

And having written a `MouseWheelGesture` like described here:
https://stackoverflow.com/questions/2271342/mousebinding-the-mousewheel-to-zoom-in-wpf-and-mvvm#answer-7527482

The `MouseWheelGesture.Matches()` method is not getting called when the mouse wheel is rotated while the <kbd>CTRL</kbd> key is getting pressed.

### Actual behavior:

The `MouseWheelGesture.Matches()` method is getting called for the <kbd>CTRL</kbd> key is being pressed, but not for the mouse wheel being rotated.

![MouseGesture not triggered](https://user-images.githubusercontent.com/9283914/130356654-6118fd82-daf8-451a-b620-b4983dd95911.gif)

### Expected behavior:

The `MouseWheelGesture.Matches()` method should be getting called when the mouse wheel being rotated with a `MouseWheelEventArgs` event argument.
<hr/>

## Steps To Reproduce:

1. Clone repository
1. Build Visual Studio 2019 .NET solution
1. Run/debug the solution
1. Activate the main window
1. Press <kbd>CTRL</kbd>+<kbd>+</kbd> to zoom in, <kbd>CTRL</kbd>+<kbd>-</kbd> to zoom out, or <kbd>CTRL</kbd>+<kbd>0</kbd> to reset zoom to 1.0.

   => Works as expected.
1. Move the mouse cursor to the main window, hold down <kbd>CTRL</kbd> key and rotate the mouse wheel.

   => Nothing happens. Yet, actually, zooming should be performed, just like when using the <kbd>CTRL</kbd>+<kbd>+</kbd>/<kbd>CTRL</kbd>+<kbd>-</kbd> keys