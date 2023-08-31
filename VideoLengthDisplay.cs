using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoLengthDisplay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Text timeText;
    private float currentTime;
    private string speedString; // speedString을 클래스 멤버 변수로 선언
    private float speedValue = 0.0f; // 초 속도를 나타내는 인스턴스 변수

    void Start()
    {
        currentTime = (float)videoPlayer.length; // 현재 시간 초기화
    }

    public void UpdateSpeedValue(float speedMultiplier)
    {
        speedString = speedMultiplier.ToString("F1"); // speedString 값을 클래스 멤버 변수에 저장
        speedValue = float.Parse(speedString); // speedValue를 업데이트하여 변경된 속도로 설정
    }

    void Update()
    {
        currentTime -= Time.deltaTime * speedValue;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        int a = Mathf.FloorToInt(currentTime/ speedValue); // currentTime을 정수로 변환

        int minutes = Mathf.FloorToInt(a / 60f);
        int seconds = Mathf.FloorToInt(a % 60f);

        string timeString = string.Format("예상 도착 시간 : {0}:{1:00}", minutes, seconds);
        timeText.text = timeString;
    }
}
