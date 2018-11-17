namespace U3DEventFrame
{
    public abstract class GameBase : MonoBase
    {
        public ushort[] msgIds;

        public void RegistSelf(MonoBase mono, params ushort[] msgs)
        {
            GameManager.Instance.RegistMsg(mono, msgs);
        }

        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            GameManager.Instance.UnRegistMsg(mono, msgs);
        }

        public void SendMsg(MsgBase msg)
        {
            GameManager.Instance.SendMsg(msg);
        }

        private void OnDisable()
        {
            if (msgIds != null)
                UnRegistSelf(this, msgIds);
        }

        private HunkAssetResMsg _hunkAssetRes = null;
        
        public HunkAssetResMsg HunkAssetRes
        {
            get
            {
                if (_hunkAssetRes == null)
                {
                    _hunkAssetRes = new HunkAssetResMsg();
                }
                return _hunkAssetRes;
            }
            set { _hunkAssetRes = value; }
        }

        public void GetRes(bool single, ushort msgId, string scene, string bundle, string tmpRes, ushort backId)
        {
            HunkAssetRes.ChangeHunkAssetMsg(single, msgId, scene, bundle, tmpRes, backId);
            SendMsg(HunkAssetRes);
        }

        public void ReleaseRes(ushort msgId, string scene, string bundle, string resName)
        {
            HunkAssetRes.ChangeReleaseResMsg(msgId, scene, bundle, resName);
            SendMsg(HunkAssetRes);
        }
    }
}