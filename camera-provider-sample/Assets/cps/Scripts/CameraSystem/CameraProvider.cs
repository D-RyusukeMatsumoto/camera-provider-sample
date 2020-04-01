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
            SmartPhone,
            OculusGo,
            Pico,
        }

        [Header("今はとりあえずここに列挙してる")] 
        [SerializeField] DeviceId device;

        [SerializeField] GameObject smartPhoneCameraRig;
        [SerializeField] GameObject oculusGoCameraRigPf;
        [SerializeField] GameObject picoCameraRigPf;
        [Header("-----------------------------")]        
        
        ICameraRig rig;
        
        
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
            Instance.rig = null;
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
            // 既にCameraRigが存在する場合は生成しない.
            if (Instance.rig != null) return;

            GameObject cameraRigObj = null;
            switch (Instance.device)
            {
                case DeviceId.SmartPhone:
                    cameraRigObj = Instantiate(Instance.smartPhoneCameraRig);
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
                Instance.rig = cameraRigObj.GetComponent<ICameraRig>();
            }
        }


        /// <summary>
        /// GameObject生成時の(Clone)文字列を削除.
        /// </summary>
        /// <param name="obj"></param>
        static void RemoveCloneString(GameObject obj) => obj.name = obj.name.Replace("(Clone)", "");


        /// <summary>
        /// CameraRigの取得.
        /// </summary>
        /// <returns></returns>
        public static ICameraRig GetCameraRig() => Instance.rig;
        
        
    }
}
