using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip titleSong;
    [SerializeField] private AudioClip ingameSong;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayTitle()
    {
        GetComponent<AudioSource>().resource = titleSong;
        GetComponent<AudioSource>().Play();
    }

    public void PlayInGame()
    {
        GetComponent<AudioSource>().resource = ingameSong;
        GetComponent<AudioSource>().Play();
    }
}
