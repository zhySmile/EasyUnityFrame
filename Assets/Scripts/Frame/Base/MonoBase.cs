using System.Collections;
using UnityEngine;


namespace U3DEventFrame
{
	public abstract class MonoBase : MonoBehaviour
	{
		public abstract void ProcessEvent(MsgBase msg);
	}
}