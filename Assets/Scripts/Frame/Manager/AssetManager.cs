using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace U3DEventFrame
{
	public class AssetManager : ManagerBase
	{
		public static AssetManager Instance;

		public void SendMsg(MsgBase msg)
		{
			if (msg.GetManager() == (int)ManagerID.AssetManager)
			{
				ProcessEvent(msg);
			}
			else
			{
				MsgCenter.Instance.SendMsg(msg);
			}
		}

		private void Awake()
		{
			Instance = this;
		}
	}
}