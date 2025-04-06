using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene 
    {
        HomeScene,
        GameScene
    }

    public static void LoadLevel(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
    }
}
