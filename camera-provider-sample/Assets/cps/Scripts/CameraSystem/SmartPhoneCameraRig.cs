using System;
using UnityEngine;


namespace CameraSystem
{
    /// <summary>
    /// CameraRig,各デバイス用のカメラはこれをもとに設計する.
    /// </summary>
    public class SmartPhoneCameraRig : MonoBehaviour, ICameraRig
    {

        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("SmartPhoneCameraRig Recenterしたよ");
        }


        public Transform GetMainCamera() => transform;


        public Quaternion GetMainCameraRotation() => transform.rotation;

        
        public void SetMainCameraRotation(Quaternion rot) => transform.SetPositionAndRotation(transform.position, rot);


        public bool GetDownClick() => true;
    }
}