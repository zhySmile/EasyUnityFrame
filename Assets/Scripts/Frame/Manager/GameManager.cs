namespace U3DEventFrame
{
    public class GameManager : ManagerBase
    {
        public static GameManager Instance;

        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == (int)ManagerID.GameManager)
            {
                ProcessEvent(msg);
            }
            else
            {
                MsgCenter.Instance.SendToMsg(msg);
            }
        }
    }
}
