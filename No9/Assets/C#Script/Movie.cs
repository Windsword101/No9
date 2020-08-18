using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour
{
    public VideoPlayer video;
    private void Start()
    {
        InvokeRepeating("CheckVideo", 3f, 0.1f);
    }
    
    private void CheckVideo()
    {
        if(video.isPlaying == false)
        {
            SceneManager.LoadScene("BackgroundMusic");
        }
    }
}
