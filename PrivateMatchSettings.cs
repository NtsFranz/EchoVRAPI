using System;

namespace EchoVRAPI
{
	/// <summary>
	/// Settings on the podium in Echo Arena
	/// </summary>
	[Serializable]
	public class PrivateMatchSettings
	{
		public enum DiscLocation
		{
			blue,
			mid,
			orange,
		}

		public enum RoundsPlayed
		{
			all,
			best_of
		}

		public enum Overtime
		{
			round_end,
			match_end,
			none
		}

		// Page 1
		public int minutes;
		public int seconds;
		public int blue_score;
		public int orange_score;

		// Page 2
		public DiscLocation disc_location;
		public bool goal_stops_time;
		public int respawn_time;
		public int catapult_time;

		// page 3
		public int round_count;
		public RoundsPlayed rounds_played;
		public int round_wait_time;
		public bool carry_points_over;

		// page 4
		public int blue_rounds_won;
		public int orange_rounds_won;
		public Overtime overtime;
		public bool standard_chassis;

		// page 5
		public bool mercy_enabled;
		public int mercy_score_diff;
		public bool team_only_voice;
		public bool disc_curve;

		// page 6
		public bool self_goaling; // this has a dash
		public bool goalie_ping_adv;
	}
}