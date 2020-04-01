using UnityEngine;

namespace CameraSystem
{
    public class AndroidCameraRig : MonoBehaviour, ICameraRig
    {
        
        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("AndroidCameraRig : Recenterしたよ");
        }

        public Transform GetMainCamera() => transform;


        public bool GetDownClick() => true;

    }
}