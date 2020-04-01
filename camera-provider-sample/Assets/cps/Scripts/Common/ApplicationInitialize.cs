using UnityEngine;

namespace Common
{
    public static class ApplicationInitialize
    {

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeApp()
        {
            // ここでGameMangerを生成する.
            var go = GameObject.Instantiate(Resources.Load("Prefabs/GameManager")) as GameObject;
            go.name = go.name.Replace("(Clone)", "");
        }
    }
}
