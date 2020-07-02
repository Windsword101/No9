using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private Image loading;
    private float timer;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        loading = GameObject.Find("Loading").GetComponent<Image>();
        text = GameObject.Find("LoadingText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (loading.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f) 
            {
                loading.enabled = false;
                text.enabled = false;
                timer = 0f;
            } 
        }
    }
}
