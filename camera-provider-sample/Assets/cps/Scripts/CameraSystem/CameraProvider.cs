using Common;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CameraSystem
{
    /// <summary>
    /// カメラを取得するためのプロバイダ.
    /// </summary>
    public class CameraProvider : SingletonMonoBehaviour<CameraProvider>
    {



        public enum DeviceId
        {
            Android,
            iOS,
            OculusGo,
            Pico,
        }

        [Header("今はとりあえずここに列挙してる")] 
        [SerializeField] DeviceId device;

        [SerializeField] GameObject androidCameraRig;
        [SerializeField] GameObject iOSCameraRig;
        [SerializeField] GameObject oculusGoCameraRigPf;
        [SerializeField] GameObject picoCameraRigPf;
        [Header("-----------------------------")]        
        
        CameraRig rig;
        
        
        protected override void Awake()
        {
            base.Awake();

            SceneManager.sceneUnloaded += CameraProvider.SceneUnLoadedListener;
            SceneManager.activeSceneChanged += CameraProvider.ActiveSceneChangedListener;
            SceneManager.sceneLoaded += CameraProvider.SceneLoadedListener;
        }
        
        
        // シーンのアンロードを検知.
        static void SceneUnLoadedListener(
            Scene scene )
        {
        }


        // シーン変更検知,Unityの仕様上Beforeには何も入っていない,Afterにロードされたシーンがある.
        static void ActiveSceneChangedListener(
            Scene before,
            Scene after )
        {
        }


        // シーンがロードされたことを検知.
        static void SceneLoadedListener(
            Scene scene,
            LoadSceneMode mode )
        {
            GameObject cameraRigObj = null;
            switch (Instance.device)
            {
                case DeviceId.Android:
                    cameraRigObj = Instantiate(Instance.androidCameraRig);
                    break;
                
                case DeviceId.iOS:
                    cameraRigObj = Instantiate(Instance.iOSCameraRig);
                    break;
                
                case DeviceId.OculusGo:
                    cameraRigObj = Instantiate(Instance.oculusGoCameraRigPf);
                    break;
                
                case DeviceId.Pico:
                    cameraRigObj = Instantiate(Instance.picoCameraRigPf);
                    break;
            }

            if (cameraRigObj != null)
            {
                CameraProvider.RemoveCloneString(cameraRigObj);
                Instance.rig = cameraRigObj.GetComponent<CameraRig>();
            }
        }


        static void RemoveCloneString(GameObject obj) => obj.name = obj.name.Replace("(Clone)", "");


        /// <summary>
        /// CameraRigの取得.
        /// </summary>
        /// <returns></returns>
        public static CameraRig GetCameraRig() => Instance.rig;


        /// <summary>
        /// メインカメラの取得.
        /// </summary>
        /// <returns></returns>
        public static GameObject GetMainCamera() => null;


        /// <summary>
        /// コントローラの取得.
        /// </summary>
        /// <returns></returns>
        public static GameObject GetController() => null;

    }
}
