using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSpeedController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider speedSlider;
    public VideoLengthDisplay lengthDisplay;
    private float maxSpeed = 2f; // 최대 속도
    private void Start()
    {
        speedSlider.onValueChanged.AddListener(ChangeSpeed);
    }

    private void ChangeSpeed(float value)
    {
        float speedMultiplier = value* maxSpeed;
        videoPlayer.playbackSpeed = speedMultiplier;

        lengthDisplay.UpdateSpeedValue(speedMultiplier);
    }
}
