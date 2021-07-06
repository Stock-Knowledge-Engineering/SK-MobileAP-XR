using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlaneController : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public Renderer _renderer;

    public void Update()
    {
        ScannedCheck();
    }

    private void ScannedCheck()
    {
        if (_renderer.isVisible)
        {
            _videoPlayer.Play();
        } else if (!_renderer.isVisible)
        {
            _videoPlayer.Pause();
        }
    }
}
