using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public string filename;

    public void Start()
    {
        VideoPlayer videoPlayer = this.GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        videoPlayer.Play();
        Debug.Log("Loading " + videoPlayer.url);
    }
}
