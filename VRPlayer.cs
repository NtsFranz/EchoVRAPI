using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

namespace EchoVRAPI
{
	public class VRPlayer
	{
		public List<float> vr_left { get; set; }
		public List<float> vr_position { get; set; }
		public List<float> vr_forward { get; set; }
		public List<float> vr_up { get; set; }
		
		[JsonIgnore]
		public Vector3 Position
		{
			get => vr_position?.ToVector3() ?? Vector3.Zero;
			set => vr_position = value.ToFloatList();
		}
		
		[JsonIgnore]
		internal Quaternion? rot;

		[JsonIgnore]
		public Quaternion Rotation
		{
			get
			{
				if (rot != null) return (Quaternion) rot;

				rot = Math2.QuaternionLookRotation(vr_forward.ToVector3(), vr_up.ToVector3());
				return (Quaternion) rot;
			}
			set
			{
				rot = value;
				vr_forward = value.Forward().ToFloatList();
				vr_up = value.Up().ToFloatList();
				vr_left = value.Left().ToFloatList();
			}
		}

		/// <summary>
		/// ↔ Mixes the two states with a linear interpolation based on t
		/// For binary or int values, the "from" state is preferred.
		/// </summary>
		/// <param name="from">The start state</param>
		/// <param name="to">The next state</param>
		/// <param name="t">Weighting of the two states</param>
		/// <returns>A mix of the two states</returns>
		internal static VRPlayer Lerp(VRPlayer from, VRPlayer to, float t)
		{
			t = Math2.Clamp01(t);

			VRPlayer newTransform = new VRPlayer()
			{
				vr_position = from.vr_position,
				vr_left = from.vr_left,
				vr_forward = from.vr_forward,
				vr_up = from.vr_up,
			};

			newTransform.Position = Vector3.Lerp(from.Position, to.Position, t);
			newTransform.Rotation = Quaternion.Lerp(from.Rotation, to.Rotation, t);

			return newTransform;
		}
	}
}