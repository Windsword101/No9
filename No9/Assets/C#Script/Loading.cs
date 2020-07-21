using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    public GameObject BossHp;
    private bool _pause;
    private Image loading;
    private float timer;
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        loading = GameObject.Find("Loading").GetComponent<Image>();
        text = GameObject.Find("LoadingText").GetComponent<Text>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _Loading();
        Bosshp();
    }
    public void menu()
    {
        Application.LoadLevel("Menu");
        pause.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void _Loading()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
            pause.SetActive(_pause);
        }
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
    private void Bosshp()
    {
        if (Application.loadedLevelName == "Dungeon") BossHp.SetActive(true);
        else BossHp.SetActive(false);


    }
}
