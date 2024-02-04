using GTA;
using JoystickLibrarySharp;

namespace FlightStick {
	public class FlightStickMappings : FlightStickHandler {
		private bool brake;

		public FlightStickMappings() {
			MapButton(Extreme3DProButton.Trigger, Control.VehicleFlyAttack);
			MapButton(Extreme3DProButton.Button2, Control.VehicleFlySelectNextWeapon);

			MapButton(Extreme3DProButton.Button3, Control.VehicleFlyUnderCarriage);
			MapButton(Extreme3DProButton.Button4, Control.NextCamera);

			MapButton(Extreme3DProButton.Button5, Control.VehiclePrevRadio);
			MapButton(Extreme3DProButton.Button6, Control.VehicleNextRadio);

			MapButton(Extreme3DProButton.Button7, Control.VehicleCinCam);
			MapButton(Extreme3DProButton.Button8, Player.LeaveVehicle);

			MapButtonToggle(Extreme3DProButton.Button11, () => brake = !brake);

			MapAxisLeftRight(Axis.Z, Control.VehicleFlyYawLeft, Control.VehicleFlyYawRight);
			MapAxis(Axis.Y, Control.VehicleFlyPitchUpDown, true);
			MapAxis(Axis.X, Control.VehicleFlyRollLeftRight);
			MapAxisToggle(Axis.Slider, Control.VehicleFlyThrottleDown, Control.VehicleFlyThrottleUp, () => brake);
		}

		protected override bool Disabled() {
			return !Player.IsInFlyingVehicle && !Player.IsInSub;
		}
	}
}
