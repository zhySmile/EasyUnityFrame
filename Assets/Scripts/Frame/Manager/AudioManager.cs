namespace U3DEventFrame
{
    public class AudioManager : ManagerBase
    {
        public static AudioManager Instance;
        
        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == (int)ManagerID.AudioManager)
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