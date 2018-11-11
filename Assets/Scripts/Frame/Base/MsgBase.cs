using System.Collections;
using UnityEngine;
using System;

using System.Net;

namespace U3DEventFrame
{
    public class MsgBase
    {
        // 0---65535
        public ushort msgId;

        public MsgBase()
        {
            msgId = 0;
        }

        public MsgBase(ushort tmpid)
        {
            msgId = tmpid;
        }

        public MsgBase(byte[] arr)
        {
        }

        public void ChangeEventId(ushort tmpid)
        {
            msgId = tmpid;
        }

        public virtual byte[] GetNetBytes()
        {
            return null;
        }

        public virtual byte GetState()
        {
            return 127;
        }

        public int GetManager()
        {
            int tmpid = msgId / FrameTools.MsgSpan;
            return tmpid * FrameTools.MsgSpan;
        }
    }
}
