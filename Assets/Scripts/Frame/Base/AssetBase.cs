using System.Collections;
using UnityEngine;

namespace U3DEventFrame
{
	public abstract class AssetBase : MonoBase
	{
		public ushort[] msgIds;
		
		public HunkAssetResMsg HKResMsg
		{
			get
			{
				if (_hunkAssetResMsg == null)
				{
					_hunkAssetResMsg = new HunkAssetResMsg();
				}
				return _hunkAssetResMsg;
			}
		}
		
		public void RegistSelf(MonoBase mono, params ushort[] msgs)
		{
			AssetManager.Instance.RegistMsg(mono, msgs);
		}

		public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
		{
			if (AssetManager.Instance)
				AssetManager.Instance.UnRegistMsg(mono, msgs);
		}

		public void SendMsg(MsgBase msg)
		{
			AssetManager.Instance.SendMsg(msg);
		}

		public void GetRes(bool single, ushort msgId, string scene, string bundle, string tmpRes, ushort backId)
		{
			HKResMsg.ChangeHunkAssetMsg(single, msgId, scene, bundle, tmpRes, backId);
		}

		public void ReleaseRes(ushort msgId, string scene, string bundle, string resName)
		{
			HKResMsg.ChangeReleaseResMsg(msgId, scene, bundle, resName);
			SendMsg(HKResMsg);
		}

		private void OnDestroy()
		{
			if (msgIds != null)
				UnRegistSelf(this, msgIds);
		}

		private HunkAssetResMsg _hunkAssetResMsg = null;
	}
}
