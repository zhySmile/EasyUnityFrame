namespace U3DEventFrame
{
    public class DBManager : ManagerBase
    {
        public static DBManager Instance;

        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == (int)ManagerID.DBManager)
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