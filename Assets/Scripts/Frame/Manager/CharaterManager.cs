namespace U3DEventFrame
{
    public class CharaterManager : ManagerBase
    {
        public static CharaterManager Instance;

        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == (int)ManagerID.CharaterManager)
            {
                ProcessEvent(msg);
            }
            else
            {
                MsgCenter.Instance.SendToMsg(msg);
            }
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}