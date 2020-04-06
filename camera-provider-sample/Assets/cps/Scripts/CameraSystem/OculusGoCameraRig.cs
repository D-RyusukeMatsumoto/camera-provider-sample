using System;
using UnityEngine;

namespace CameraSystem
{
    public class OculusGoCameraRig : MonoBehaviour, ICameraRig
    {
        public event EventHandler<ControllerInputArgs> InputChange;

        [SerializeField] Transform centerCamera;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputChange?.Invoke(this, new ControllerInputArgs(ControllerInputId.OnButton3Down));
            }
        }
        
        /// <summary>
        /// カメラのリセンタ.
        /// </summary>
        public void Recenter()
        {
            Debug.Log("OculusGoCameraRig : Recenterしたよ");
        }

        
        public Transform GetMainCamera() => centerCamera;


        public Quaternion GetMainCameraRotation() => centerCamera.rotation;


        public void SetMainCameraRotation(Quaternion rot) => centerCamera.SetPositionAndRotation(centerCamera.position, rot);


        public bool GetDownClick()
        {
            return false;
        }
        
    }
}