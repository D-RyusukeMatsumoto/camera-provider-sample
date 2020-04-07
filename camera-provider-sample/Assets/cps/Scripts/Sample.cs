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
        
        // TODO : 仮想コントローラに入力イベントハンドラを登録.
        rig.InputChange += InputEventHandler;
    }

    
    /// <summary>
    /// 入力イベントハンドラ.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void InputEventHandler(
        object sender,
        ControllerInputArgs e)
    {
        Debug.Log($"Event ID {e.Id.ToString()}");
    }


    void Update()
    {
        // TODO : Recenterサンプル,今はコメントアウト.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rig?.Recenter();
        }

        // TODO : 回転の確認,今はコメントアウト.
        //Debug.Log($"Camera Rotation : {rig?.GetMainCameraRotation()}");

    }


    
}