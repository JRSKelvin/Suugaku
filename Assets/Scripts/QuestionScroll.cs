using UnityEngine;

public class QuestionScroll : MonoBehaviour
{
    public int questionNumber;
    [SerializeField] private InteractableObject[] hiddenSpot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (hiddenSpot.Length == 0) return;
        int randomSpot = Random.Range(0, hiddenSpot.Length);
        transform.parent = hiddenSpot[randomSpot].transform;
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevealScroll()
    {
        gameObject.SetActive(true);
    }
}
