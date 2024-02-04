using System;
using System.Collections.Generic;
using GTA;
using JoystickLibrarySharp;

namespace FlightStick {
	[ScriptAttributes(NoDefaultInstance = true)]
	public class FlightStickHandler : Script {
		protected readonly int id;
		protected static Extreme3DProService es = new Extreme3DProService();
		private HashSet<Extreme3DProButton> held = new HashSet<Extreme3DProButton>();

		protected event EventHandler<Extreme3DProButton> Pressed;
		protected event EventHandler<Extreme3DProButton> Held;
		protected event EventHandler<Extreme3DProButton> Released;

		protected FlightStickHandler(int index = 0) {
			es.Initialize();
			var ids = es.GetIDs();
			if(ids.Count == 0) return;
			id = ids[index];

			Tick += OnTick;
		}

		protected virtual bool Disabled() {
			return false;
		}

		private void OnTick(object sender, EventArgs e) {
			if(Disabled()) return;

			var buttons = new bool[12];
			es.GetButtons(id, ref buttons);

			for(var i = 0; i < buttons.Length; i++) {
				var button = (Extreme3DProButton) i;
				var buttonDown = buttons[i];

				switch(buttonDown) {
					case true when !held.Contains(button):
						held.Add(button);
						Pressed?.Invoke(this, button);
						break;
					case true when held.Contains(button):
						Held?.Invoke(this, button);
						break;
					case false when held.Contains(button):
						held.Remove(button);
						Released?.Invoke(this, button);
						break;
				}
			}
		}

		protected void MapButton(Extreme3DProButton button, Control control, int value = 1) {
			Pressed += (sender, pressed) => {
				if(pressed == button)
					Game.SetControlValueNormalized(control, value);
			};
			Released += (sender, released) => {
				if(released == button)
					Game.SetControlValueNormalized(control, 0);
			};
		}

		/**
		 * <summary>
		 * Alias for <see cref="MapButton(JoystickLibrarySharp.Extreme3DProButton, Action)"/>,
		 * making it clearer that the Action needs to be a lambda that toggles the desired variable.
		 * </summary>
		 */
		protected void MapButtonToggle(Extreme3DProButton button, Action toggleFunc) {
			MapButton(button, toggleFunc);
		}

		protected void MapButton(Extreme3DProButton button, Action action) {
			Pressed += (sender, pressed) => {
				if(pressed == button) action();
			};
		}

		protected int X => GetAxis(Axis.X);
		protected int Y => GetAxis(Axis.Y);
		protected int Z => GetAxis(Axis.Z);
		protected int Slider => GetAxis(Axis.Slider);

		private int GetAxis(Axis.AxisFunc axis) {
			var value = 0;
			axis(id, ref value);
			return value;
		}

		protected static class Axis {
			public delegate bool AxisFunc(int id, ref int value);

			public static readonly AxisFunc X = es.GetX;
			public static readonly AxisFunc Y = es.GetY;
			public static readonly AxisFunc Z = es.GetZRot;
			public static readonly AxisFunc Slider = es.GetSlider;
		}

		protected void MapAxis(Axis.AxisFunc axis, Control control, bool invert = false) {
			Tick += (sender, args) => {
				var value = GetAxis(axis);
				var normal = Normalize(value) * (invert ? -1 : 1);
				Game.SetControlValueNormalized(control, normal);
			};
		}

		protected void MapAxisLeftRight(Axis.AxisFunc axis, Control leftControl, Control rightControl) {
			MapAxisNegPos(axis, leftControl, rightControl);
		}

		protected void MapAxisNegPos(Axis.AxisFunc axis, Control negControl, Control posControl) {
			Tick += (sender, args) => {
				var value = GetAxis(axis);
				var normal = Normalize(value);
				Game.SetControlValueNormalized(normal < 0 ? negControl : posControl, normal);
			};
		}

		protected void MapAxisToggle(Axis.AxisFunc axis, Control trueControl, Control falseControl, Func<bool> getToggle) {
			Tick += (sender, args) => {
				var value = GetAxis(axis);
				var normal = Normalize(value);
				Game.SetControlValueNormalized(getToggle() ? trueControl : falseControl, normal);
			};
		}

		protected static float Normalize(int i) {
			return (float) i / 100;
		}
	}
}
