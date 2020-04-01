using UnityEngine;

namespace CameraSystem
{
    public class OculusGoCameraRig : MonoBehaviour, ICameraRig
    {
        
        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("OculusGoCameraRig : Recenterしたよ");
        }

        public Transform GetMainCamera() => transform;


        public bool GetDownClick() => true;
        
    }
}