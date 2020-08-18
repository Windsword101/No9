using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public static string currentScene = "";
    public string toScene;
    private Image loading,dialogue;
    private GameObject player;
    private Text text,dialogueText;

    private void Start()
    {
        currentScene = Application.loadedLevelName;
        player = GameObject.Find("Player");
        loading = GameObject.Find("Loading").GetComponent<Image>();
        text = GameObject.Find("LoadingText").GetComponent<Text>();
        dialogue = GameObject.Find("IntoDialogue").GetComponent<Image>();
        dialogueText = GameObject.Find("dialogueText").GetComponent<Text>();
    }
    private void Update()
    {
        
    }

    public void LoadScene()
    {

        Application.LoadLevel(toScene);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            loading.enabled = true;
            text.enabled = true;
            #region No9切換場景
            if (currentScene == "No9" && gameObject.name == "GoToHouse")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotohouse").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToWellUp")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotowellup").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToWellDown")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotowelldown").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToChurch")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotochurch").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToDungeon")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotodungeon").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToUnderwater")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotounderwater").GetComponent<Transform>().position;
            }
            else if (currentScene == "No9" && gameObject.name == "GoToEnding")
            {
                LoadScene();
            }
            #endregion
            #region house切換場景
            else if (currentScene == "house" && gameObject.name == "GoToNo9")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotono9").GetComponent<Transform>().position;
            }
            else if (currentScene == "house" && gameObject.name == "GoToDungeon")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotodungeon").GetComponent<Transform>().position;
            }
            #endregion
            #region dungeon切換場景
            else if (currentScene == "Dungeon" && gameObject.name == "GoToNo9")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotono9").GetComponent<Transform>().position;
            }
            else if (currentScene == "Dungeon" && gameObject.name == "GoToHouse")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotohouse").GetComponent<Transform>().position;
            }
            else if (currentScene == "Dungeon" && gameObject.name == "GoToChurch")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotochurch").GetComponent<Transform>().position;
            }
            #endregion
            #region church切換場景
            else if (currentScene == "church" && gameObject.name == "GoToNo9")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotono9").GetComponent<Transform>().position;
            }
            else if (currentScene == "church" && gameObject.name == "GoToDungeon")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotodungeon").GetComponent<Transform>().position;
            }
            #endregion
            #region well切換場景
            else if (currentScene == "well" && gameObject.name == "GoToNo9")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotono9").GetComponent<Transform>().position;
            }
            #endregion
            #region underwater切换场景
            else if (currentScene == "underwater" && gameObject.name == "GoToNo9")
            {
                LoadScene();
                player.transform.position = GameObject.Find("gotono9").GetComponent<Transform>().position;
            }
            #endregion



        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.hintTimer = 0;
            dialogue.enabled = true;
            dialogueText.enabled = true;
            dialogueText.text = "press Z into room";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")  
        {
            dialogue.enabled = false;
            dialogueText.enabled = false;
        }
    }

}
