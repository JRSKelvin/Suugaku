using UnityEngine;

public class HomeScreenUIManager : MonoBehaviour
{
    public void Play()
    {
        //Swap to difficulty selector
        Loader.LoadLevel(Loader.Scene.GameScene);
    }
}
