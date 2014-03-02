﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using Aura.Shared.Util.Configuration;

namespace Aura.Channel.Util.Configuration.Files
{
	public class AutobanConfFile : ConfFile
	{
		/// <summary>
		/// Turn autoban on?
		/// </summary>
		public bool Enabled;

		/// <summary>
		/// The ban threshold. When a player's score is greater than
		/// or equal to this number, they're banned.
		/// </summary>
		public int BanAt;
		
		/// <summary>
		/// The amount to increase a player's score by when a Mild incident occurs
		/// </summary>
		public int MildAmount;
		
		/// <summary>
		/// The amount to increase a player's score by when a Moderate incident occurs
		/// </summary>
		public int ModerateAmount;
		
		/// <summary>
		/// The amount to increase a player's score by when a Severe incident occurs
		/// </summary>
		public int SevereAmount;
		
		/// <summary>
		/// The amount of time it takes to reduce a player's score by one point.
		/// 
		/// Specify zero to disable reduction
		/// </summary>
		public TimeSpan ReductionTime;
		
		/// <summary>
		/// The "seed" ban length. This is used as the ban time for the first offense
		/// and in calculations for subsequent offenses
		/// </summary>
		public TimeSpan InitialBanTime;

		/// <summary>
		/// The type of susequent ban length increase.
		/// <remarks>
		/// Options are:
		/// 
		/// None = BanTime
		/// Linear = BanTime * i
		/// Exponential = BanTime * 2^(i-1)
		/// 
		/// Where i is the number of times the player has been autobanned
		/// </remarks>
		/// </summary>
		public AutobanLengthIncrease LengthIncrease;

		/// <summary>
		/// Determines if we should reset the play's Ban Score to 0
		/// when they're autobanned. If false, only the passage of time
		/// (if enabled) will reduce the band score.
		/// </summary>
		public bool ResetScoreOnBan;

		public void Load()
		{
			this.Require("system/conf/autoban.conf");

			Enabled = this.GetBool("enabled", true);
			BanAt = this.GetInt("ban_at", 10);
			MildAmount = this.GetInt("mild_amount", 1);
			ModerateAmount = this.GetInt("moderate_amount", 5);
			SevereAmount = this.GetInt("severe_amount", 10);
			ReductionTime = this.GetTimeSpan("reduction_time", TimeSpan.FromDays(7));
			InitialBanTime = this.GetTimeSpan("initial_ban_time", TimeSpan.FromDays(7));
			LengthIncrease = this.GetEnum("length_increase", AutobanLengthIncrease.Exponential);
			ResetScoreOnBan = this.GetBool("reset_on_ban", false);
		}
	}
}
