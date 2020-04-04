using CameraSystem;
using UnityEngine;

/// <summary>
/// とりあえずサンプル.
/// </summary>
public class Sample : MonoBehaviour
{

    ICameraRig rig;

    void Start()
    {
        rig = CameraProvider.GetCameraRig();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig?.Recenter();            
        }
        
        Debug.Log($"Camera Rotation : {rig?.GetMainCameraRotation()}");
    }
    
}