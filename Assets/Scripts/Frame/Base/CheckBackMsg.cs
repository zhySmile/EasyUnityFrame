namespace U3DEventFrame
{
    public class CheckBackMsg : MsgBase
    {
        public float DelayTime;
        public float TimerCount;

        public CheckBackMsg(ushort msgid)
        {
            this.msgId = msgid;
            this.DelayTime = 5;
            this.TimerCount = this.DelayTime;
        }

        public bool ReduceTime(float timer)
        {
            this.TimerCount -= timer;

            if (this.TimerCount <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.TimerCount = this.DelayTime;
        }
    }
}
