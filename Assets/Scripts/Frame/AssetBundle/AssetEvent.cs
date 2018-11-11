using System;
using U3DEventFrame;

public class HunkAssetResMsg : MsgBase
{
    public string SceneName;
    public string BundleName;
    public string ResName;
    public ushort BackMsgId;
    public bool IsSingle;

    public HunkAssetResMsg()
    {
        this.IsSingle = true;
        this.msgId = 0;
        this.SceneName = null;
        this.BundleName = null;
        this.ResName = null;
        this.BackMsgId = 0;
    }

    public HunkAssetResMsg(bool single, ushort msgId, string scene, string bundle, string tmpRes, ushort backId)
    {
        this.IsSingle = single;
        this.msgId = msgId;
        this.SceneName = scene;
        this.BundleName = bundle;
        this.ResName = tmpRes;
        this.BackMsgId = backId;
    }

    public void ChangeHunkAssetMsg(bool single, ushort msgId, string scene, string bundle, string tmpRes, ushort backId)
    {
        this.IsSingle = single;
        this.msgId = msgId;
        this.SceneName = scene;
        this.BundleName = bundle;
        this.ResName = tmpRes;
        this.BackMsgId = backId;
    }

    /// <summary>
    /// 释放单个 obj
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="scene"></param>
    /// <param name="bundle"></param>
    /// <param name="tmpRes"></param>
    public void ChangeReleaseResMsg(ushort msgId, string scene, string bundle, string tmpRes)
    {
        this.msgId = msgId;
        this.SceneName = scene;
        this.BundleName = bundle;
        this.ResName = tmpRes;
    }

    /// <summary>
    /// 释放一个 bundle 中的所有 obj
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="scene"></param>
    /// <param name="bundle"></param>
    public void ChangeReleaseBundleResMsg(ushort msgId, string scene, string bundle)
    {
        this.msgId = msgId;
        this.SceneName = scene;
        this.BundleName = bundle;
    }

    /// <summary>
    /// 释放一个场景中的 obj
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="scene"></param>
    public void ChangeReleaseSceneResMsg(ushort msgId, string scene)
    {
        this.msgId = msgId;
        this.SceneName = scene;
    }

    /// <summary>
    /// 释放单个 bundle
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="scene"></param>
    /// <param name="bundle"></param>
    public void ChangeReleaseBundleMsg(ushort msgId, string scene, string bundle)
    {
        this.msgId = msgId;
        this.SceneName = scene;
        this.BundleName = bundle;
    }

    /// <summary>
    /// 释放一个场景的 bundle
    /// </summary>
    /// <param name="msgId"></param>
    /// <param name="scene"></param>
    public void ChangeReleaseSceneMsg(ushort msgId, string scene)
    {
        this.msgId = msgId;
        this.SceneName = scene;
    }
}

public class HunkAssetResesBackMsg : MsgBase
{
    public Object[] value;

    public HunkAssetResesBackMsg()
    {
        this.msgId = 0;
        this.value = null;
    }

    public HunkAssetResesBackMsg(ushort msgId, Object[] tmpValue)
    {
        this.msgId = msgId;
        this.value = tmpValue;
    }

    public void ChangeMsg(ushort msgId, params Object[] tmpValue)
    {
        this.msgId = msgId;
        this.value = tmpValue;
    }
    
    public void ChangeMsg(ushort msgId)
    {
        this.msgId = msgId;
    }

    public void ChangeMsg(Object[] tmpValue)
    {
        this.value = tmpValue;
    }
}

public class HunkAssetResBackMsg : MsgBase
{
    public Object[] value;

    public HunkAssetResBackMsg()
    {
        this.msgId = 0;
        this.value = null;
    }

    public HunkAssetResBackMsg(ushort msgId, Object[] tmpValue)
    {
        this.msgId = msgId;
        this.value = tmpValue;
    }

    public void ChangeMsg(ushort msgId, params Object[] tmpValue)
    {
        this.msgId = msgId;
        this.value = tmpValue;
    }
    
    public void ChangeMsg(ushort msgId)
    {
        this.msgId = msgId;
    }

    public void ChangeMsg(Object[] tmpValue)
    {
        this.value = tmpValue;
    }
}
