using UnityEngine;

namespace CameraSystem
{
    public class PicoCameraRig : MonoBehaviour, ICameraRig
    {

        [SerializeField] Transform bothCamera;
        [SerializeField] Transform headAnchor;
                
        
        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("PicoCameraRig : Recenterしたよ");
        }


        public Transform GetMainCamera() => bothCamera;

        
        public Quaternion GetMainCameraRotation() => headAnchor.rotation;


        public void SetMainCameraRotation(Quaternion rot) => headAnchor.SetPositionAndRotation(headAnchor.position, rot);
        
        
        public bool GetDownClick() => true;

    }
}