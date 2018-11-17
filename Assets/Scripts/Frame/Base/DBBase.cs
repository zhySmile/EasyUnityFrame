namespace U3DEventFrame
{
    public abstract class DBBase : MonoBase
    {
        public ushort[] msgIds;
        
        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            DBManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            DBManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg(MsgBase msg)
        {
            DBManager.Instance.SendMsg(msg);
        }

        private void OnDestroy()
        {
            if (msgIds != null)
                UnRegistSelf(this, msgIds);
        }
    }
}