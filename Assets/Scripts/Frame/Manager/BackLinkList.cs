namespace U3DEventFrame
{
    public class BackLinkList : IlinkList<CheckBackMsg>
    {
        public BackLinkList()
        {
            _sendBackMsg = new MsgBase();
        }

        public LinkNode<CheckBackMsg> FindObj(int tmpId)
        {
            LinkNode<CheckBackMsg> pNext = this.Head;

            if (pNext.Data.msgId == tmpId)
            {
                return pNext;
            }

            while (pNext.Next != null)
            {
                LinkNode<CheckBackMsg> tmpNode = pNext.Next;

                if (tmpNode.Data.msgId == tmpId)
                {
                    return tmpNode;
                }

                pNext = pNext.Next;
            }

            return null;
        }

        public void RemoveCondition(float timer)
        {
            if (IsEmpty())
                return;

            LinkNode<CheckBackMsg> pNext = this.Head;

            while (pNext.Next != null)
            {
                LinkNode<CheckBackMsg> tmpNode = pNext.Next;

                if (tmpNode.Data.ReduceTime(timer))
                {
                    _sendBackMsg.ChangeEventId(tmpNode.Data.msgId);
                    MsgCenter.Instance.SendMsg(_sendBackMsg);
                    pNext.Next = tmpNode.Next;
                    tmpNode.Dispose();
                }
                else
                {
                    pNext = pNext.Next;
                }
            }

            if (this.Head.Data.ReduceTime(timer))
            {
                LinkNode<CheckBackMsg> tmpNode = this.Head;
                
            }
        }

        private MsgBase _sendBackMsg;
    }
}
