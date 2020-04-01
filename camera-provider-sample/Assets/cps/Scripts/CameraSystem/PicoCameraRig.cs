using UnityEngine;

namespace CameraSystem
{
    public class PicoCameraRig : MonoBehaviour, ICameraRig
    {
                
        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("PicoCameraRig : Recenterしたよ");
        }

        public Transform GetMainCamera() => transform;


        public bool GetDownClick() => true;

    }
}