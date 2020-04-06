using System;
using UnityEngine;


namespace CameraSystem
{
    
    /// <summary>
    /// 各種CameraRigが実装すべきインターフェースをまとめたインターフェース.
    /// </summary>
    public interface ICameraRig : 
        ICameraTransform,
        ICameraRigController
    {
    }


    /// <summary>
    /// サンプル用,Transform周り.
    /// </summary>
    public interface ICameraTransform
    {
        Transform GetMainCamera();
        Quaternion GetMainCameraRotation();
        void SetMainCameraRotation(Quaternion rot);
        void Recenter();
    }


    #region --- 入力回り ---
    /// <summary>
    /// 仮想的なコントローラの入力ID.
    /// </summary>
    [System.Flags]
    public enum ControllerInputId : int
    {
        OnButton1Down = 0,
        OnButton2Down = 1,
        OnButton3Down = 2,
    }

    
    /// <summary>
    /// 仮想的なコントローラのイベント引数.
    /// </summary>
    public class ControllerInputArgs : EventArgs
    {
        public ControllerInputArgs(
            ControllerInputId id)
        {
            Id = id;
        }
        
        public ControllerInputId Id { get; private set; }
    }

    
    /// <summary>
    /// サンプル用,キー入力的な.
    /// </summary>
    public interface ICameraRigController
    {
        event EventHandler<ControllerInputArgs> InputChange;

        bool GetDownClick();
        
    }
    #endregion --- 入力回り ---

}