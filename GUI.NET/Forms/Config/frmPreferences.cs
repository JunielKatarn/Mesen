﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mesen.GUI.Config;

namespace Mesen.GUI.Forms.Config
{
	public partial class frmPreferences : BaseConfigForm
	{
		public frmPreferences()
		{
			InitializeComponent();

			Entity = ConfigManager.Config.PreferenceInfo;

			AddBinding("AutomaticallyCheckForUpdates", chkAutomaticallyCheckForUpdates);
			AddBinding("SingleInstance", chkSingleInstance);
			AddBinding("AutoLoadIpsPatches", chkAutoLoadIps);
			AddBinding("AssociateNesFiles", chkNesFormat);
			AddBinding("AssociateFdsFiles", chkFdsFormat);
			AddBinding("AssociateMmoFiles", chkMmoFormat);
			AddBinding("AssociateMstFiles", chkMstFormat);

			AddBinding("UseAlternativeMmc3Irq", chkUseAlternativeMmc3Irq);
			AddBinding("AllowInvalidInput", chkAllowInvalidInput);
			AddBinding("RemoveSpriteLimit", chkRemoveSpriteLimit);

			AddBinding("FdsAutoLoadDisk", chkFdsAutoLoadDisk);
			AddBinding("FdsFastForwardOnLoad", chkFdsFastForwardOnLoad);

			AddBinding("PauseWhenInBackground", chkPauseWhenInBackground);
			AddBinding("AllowBackgroundInput", chkAllowBackgroundInput);

			AddBinding("PauseOnMovieEnd", chkPauseOnMovieEnd);
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			PreferenceInfo.ApplyConfig();
		}

		private void chkPauseWhenInBackground_CheckedChanged(object sender, EventArgs e)
		{
			chkAllowBackgroundInput.Enabled = !chkPauseWhenInBackground.Checked;
			if(!chkAllowBackgroundInput.Enabled) {
				chkAllowBackgroundInput.Checked = false;
			}
		}

		private void btnOpenMesenFolder_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(ConfigManager.HomeFolder);
		}
	}
}
