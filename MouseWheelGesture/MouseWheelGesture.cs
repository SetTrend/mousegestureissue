using System.Windows.Input;

namespace MouseGestureIssue.MouseWheelGestures
{
	public class MouseWheelGesture : MouseGesture
	{
		/// <summary>
		///		Direction of mouse wheel to accept.
		/// </summary>
		public WheelDirection Direction;



		/// <summary>
		///		Initializes a new instance of the <see cref="MouseWheelGesture"/> class.
		/// </summary>
		public MouseWheelGesture() { }

		/// <summary>
		///		Initializes a new instance of the <see cref="MouseWheelGesture"/>
		///		class using the specified <see cref="ModifierKeys"/>.
		/// </summary>
		/// <param name="modifiers">
		///		The modifiers associated with this gesture.
		/// </param>
		/// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
		///		<see cref="modifiers"/> is not a valid <see cref="ModifierKeys"/> value.
		/// </exception>
		public MouseWheelGesture(ModifierKeys modifiers) : base(MouseAction.None, modifiers) { }

		/// <summary>
		///		Initializes a new instance of the <see cref="MouseWheelGesture"/>
		///		class using the specified <see cref="ModifierKeys"/>.
		/// </summary>
		/// <param name="modifiers">
		///		The modifiers associated with this gesture.
		/// </param>
		/// <exception cref="System.ComponentModel.InvalidEnumArgumentException">
		///		<see cref="modifiers"/> is not a valid <see cref="ModifierKeys"/> value.
		/// </exception>
		public MouseWheelGesture(WheelDirection direction, ModifierKeys modifiers) : base(MouseAction.None, modifiers) => Direction = direction;



		/// <summary>
		///		Determines whether <see cref="MouseGesture"/>
		///		matches the input associated with the specified
		///		<see cref="InputEventArgs"/> object.
		/// </summary>
		/// <param name="targetElement">
		///		The target.
		/// </param>
		/// <param name="inputEventArgs">
		///		The input event data to compare with this gesture.
		/// </param>
		/// <returns>
		///		<c>true</c> if the event data matches this
		///		<see cref="MouseGesture"/>; <c>false</c> otherwise.
		/// </returns>
		public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
		{
			if (base.Matches(targetElement, inputEventArgs) && inputEventArgs is MouseWheelEventArgs args)
			{
				switch (Direction)
				{
					case WheelDirection.None:
						return args.Delta == 0;

					case WheelDirection.Up:
						return args.Delta > 0;

					case WheelDirection.Down:
						return args.Delta < 0;
				}
			}

			return false;
		}
	}
}
