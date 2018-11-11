using System.Collections.Generic;
using UnityEngine;

namespace U3DEventFrame
{
	public class ManagerBase : MonoBase
	{
		public Dictionary<ushort, EventNode> EventTree = new Dictionary<ushort, EventNode>();

		public void ProcessSendBackMsg(int tmpId)
		{
			if (tmpId != -1)
			{
				LinkNode<CheckBackMsg> tmpMsg = _checkTimer.FindObj(tmpId);

				if (tmpMsg != null)
				{
					tmpMsg.Data.Reset();
				}
				else
				{
					_checkTimer.Append(new CheckBackMsg((ushort)tmpId));
				}
			}
		}

		public void BackMsgUpdate()
		{
			if (_checkTimer != null)
				_checkTimer.RemoveCondition(Time.deltaTime);
		}

		public void InitialBackMsg()
		{
			_checkTimer = new BackLinkList();
		}

		public void RegistMsg(MonoBase mono, params ushort[] msgs)
		{
			for (int i = 0; i < msgs.Length; i++)
			{
				EventNode tmp = new EventNode(mono);
				RegistMsg(msgs[i], tmp);
			}
		}

		public void UnRegistMsg(MonoBase mono, params ushort[] msgs)
		{
			for (int i = 0; i < msgs.Length; i++)
			{
				UnRegistMsg(msgs[i], mono);
			}
		}

		public override void ProcessEvent(MsgBase msg)
		{
			if (!EventTree.ContainsKey(msg.msgId))
			{
				Debug.LogWarning("msg not contain msgid = " + msg.msgId);
				Debug.LogWarning("msg manager = " + msg.GetManager());
				return;
			}
			else
			{
				EventNode tmp = EventTree[msg.msgId];

				do
				{
					tmp.data.ProcessEvent(msg);
					tmp = tmp.Next;
				} while (tmp != null);
			}
		}

		protected void RegistMsg(ushort id, EventNode node)
		{
			if (!EventTree.ContainsKey(id))
			{
				EventTree.Add(id, node);
			}
			else
			{
				EventNode tmp = EventTree[id];

				while (tmp.Next != null)
				{
					tmp = tmp.Next;
				}

				tmp.Next = node;
			}
		}

		private void Update()
		{
			BackMsgUpdate();
		}

		private void OnDestroy()
		{
			if (_checkTimer != null)
				_checkTimer.Dispose();
			
			List<ushort> tmpKeys = new List<ushort>(EventTree.Keys);

			for (int i = 0; i < tmpKeys.Count; i++)
			{
				EventNode tmpBase = EventTree[tmpKeys[i]];
				tmpBase = null;
			}
			
			EventTree.Clear();
			System.GC.Collect();
		}

		private void UnRegistMsg(ushort id, MonoBase node)
		{
			if (!EventTree.ContainsKey(id))
			{
				return;
			}
			else
			{
				EventNode tmp = EventTree[id];

				if (tmp.data == node)
				{
					EventNode header = tmp;

					if (header.Next != null)
					{
						EventTree[id] = tmp.Next;
						header.Next = null;
					}
					else
					{
						EventTree.Remove(id);
					}
				}
				else
				{
					while (tmp.Next != null && tmp.Next.data != node)
					{
						tmp = tmp.Next;
					}

					if (tmp.Next.Next != null)
					{
						EventNode curNode = tmp.Next;
						tmp.Next = curNode.Next;

						curNode.Next = null;
					}
					else
					{
						tmp.Next = null;
					}
				}
			}
		}

		private BackLinkList _checkTimer;
	}
}
