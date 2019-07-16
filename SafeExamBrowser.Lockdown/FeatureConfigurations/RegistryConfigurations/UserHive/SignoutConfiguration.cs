﻿/*
 * Copyright (c) 2019 ETH Zürich, Educational Development and Technology (LET)
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;
using SafeExamBrowser.Contracts.Logging;

namespace SafeExamBrowser.Lockdown.FeatureConfigurations.RegistryConfigurations.UserHive
{
	[Serializable]
	internal class SignoutConfiguration : UserHiveConfiguration
	{
		protected override IEnumerable<RegistryConfigurationItem> Items => new []
		{
			new RegistryConfigurationItem($@"HKEY_USERS\{SID}\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoLogoff", 1, 0)
		};

		public SignoutConfiguration(Guid groupId, ILogger logger, string sid, string userName) : base(groupId, logger, sid, userName)
		{
		}
	}
}