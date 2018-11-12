namespace U3DEventFrame
{
    public abstract class AudioBase : MonoBase
    {
        public ushort[] msgIds;
        
        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            AudioManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            AudioManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg(MsgBase msg)
        {
            AudioManager.Instance.SendMsg(msg);
        }

        private void OnDestroy()
        {
            UnRegistSelf(this, msgIds);
        }
    }
}