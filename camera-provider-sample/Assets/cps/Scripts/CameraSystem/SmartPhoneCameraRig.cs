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


        public bool GetDownClick() => true;
    }
}