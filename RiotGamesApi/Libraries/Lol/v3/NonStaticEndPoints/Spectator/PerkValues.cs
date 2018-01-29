using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.Spectator
{
	public class PerkValues
	{
		public int[] perkIds { get; set; } = new int[0];
		public int perkStyle { get; set; }
		public int perkSubStyle { get; set; }
	}
}