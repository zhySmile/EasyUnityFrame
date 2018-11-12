namespace U3DEventFrame
{
    public abstract class CharaterBase : MonoBase
    {
        public ushort[] msgIds;
        
        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            CharaterManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            CharaterManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg(MsgBase msg)
        {
            CharaterManager.Instance.SendMsg(msg);
        }

        private void OnDestroy()
        {
            if (msgIds != null)
                UnRegistSelf(this, msgIds);
        }
    }
}
