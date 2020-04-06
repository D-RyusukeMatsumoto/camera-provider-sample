using System;
using UnityEngine;


namespace CameraSystem
{
    public class PicoCameraRig : MonoBehaviour, ICameraRig
    {
        public event EventHandler<ControllerInputArgs> InputChange;
        
        [SerializeField] Transform bothCamera;
        [SerializeField] Transform headAnchor;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputChange?.Invoke(this, new ControllerInputArgs(ControllerInputId.OnButton2Down));
            }
        }


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
        
        
        public bool GetDownClick()
        {
            return false;
        }

    }
}