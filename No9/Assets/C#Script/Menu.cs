using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool ControlSound = true;
    [Header("聲音按鈕")]
    public Image SoundButtonImage;
    [Header("聲音開啟圖")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉圖")]
    public Sprite SoundCloseSprite;
    [Header("聲音拉霸")]
    public Slider SoundSlider;
    [Header("解析度下拉選單")]
    public Dropdown ScreenSizeDropdown;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        if (player == null) { }
        else
        {
            player.transform.position = new Vector2(-5.96f, -2.1f);
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        }

    }

    public void Update()
    {
        AudioListener.volume = SoundSlider.value;
        #region 解析度切換
        switch (ScreenSizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, false);
                break;
            case 2:
                Screen.SetResolution(1280, 720, false);
                break;
            case 3:
                Screen.SetResolution(800, 480, false);
                break;
        }
        #endregion
    }

    #region 下一關
    public void NextScene()
    {
        Application.LoadLevel("story");
    }
    #endregion

    #region 離開遊戲
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region 控制聲音
    public void Control_Sound()
    {
        ControlSound = !ControlSound;
        if (ControlSound == true)
        {
            AudioListener.pause = false;
            SoundButtonImage.sprite = SoundOpenSprite;
        }
        else
        {
            AudioListener.pause = true;
            SoundButtonImage.sprite = SoundCloseSprite;
        }
    }
    #endregion

}
