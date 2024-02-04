using GTA;

namespace FlightStick {
	/**
	 * <summary>
	 * Flattens <see cref="GTA.Player"/>, <see cref="GTA.Ped"/>, and <see cref="GTA.TaskInvoker"/>
	 * for more convenient use.
	 * </summary>
	 * <example>
	 * <code>Player.LeaveVehicle()</code> instead of <code>Game.Player.Character.Task.LeaveVehicle()</code>
	 * </example>
	 *
	 * <remarks>
	 * Methods and properties from each of the core classes have to be manually
	 * redefined and called, and I've only defined the ones I've needed so far.
	 * </remarks>
	 */
	public static class Player {
		private static GTA.Player player = Game.Player;
		private static Ped character = Game.Player.Character;
		private static TaskInvoker tasks = Game.Player.Character.Task;

		public static Vehicle CurrentVehicle => character.CurrentVehicle;
		public static bool IsInFlyingVehicle => character.IsInFlyingVehicle;
		public static bool IsInSub => character.IsInSub;

		public static void LeaveVehicle() => tasks.LeaveVehicle();
	}
}
