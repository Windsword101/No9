using UnityEngine;
public class ChangeScene : MonoBehaviour
{
    public static string currentScene = "";
    public string toScene;
    private GameObject player;
    Vector3 x;

    private void Start()
    {
        currentScene = Application.loadedLevelName;
        player = GameObject.Find("Player");
        
    }

    public void LoadScene()
    {

        Application.LoadLevel(toScene);
        
    }
    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
    }
    public void LoadPlayerPosition()
    {
        PlayerPrefs.GetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.GetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.GetFloat("PlayerZ", player.transform.position.z);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            if (currentScene == "No9" && gameObject.name == "GoToHouse")
            {
                SavePlayerPosition();
                LoadScene();
                player.transform.position = GameObject.Find("gotohouse").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToWellUp")
            {
                SavePlayerPosition();
                LoadScene();
                player.transform.position = GameObject.Find("gotowellup").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToWellDown")
            {
                SavePlayerPosition();
                LoadScene();
                player.transform.position = GameObject.Find("gotowelldown").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToChurch")
            {
                SavePlayerPosition();
                LoadScene();
                player.transform.position = GameObject.Find("gotochurch").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToDungeon")
            {
                SavePlayerPosition();
                LoadScene();
                player.transform.SetPositionAndRotation(new Vector3(52.43f, -12.41f, 0), Quaternion.identity);
            }
        }
    }

}
