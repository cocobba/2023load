using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoLengthDisplay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Text timeText;
    private float currentTime;
    private string speedString; // speedString�� Ŭ���� ��� ������ ����
    private float speedValue = 0.0f; // �� �ӵ��� ��Ÿ���� �ν��Ͻ� ����

    void Start()
    {
        currentTime = (float)videoPlayer.length; // ���� �ð� �ʱ�ȭ
    }

    public void UpdateSpeedValue(float speedMultiplier)
    {
        speedString = speedMultiplier.ToString("F1"); // speedString ���� Ŭ���� ��� ������ ����
        speedValue = float.Parse(speedString); // speedValue�� ������Ʈ�Ͽ� ����� �ӵ��� ����
    }

    void Update()
    {
        currentTime -= Time.deltaTime * speedValue;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
        }

        int a = Mathf.FloorToInt(currentTime/ speedValue); // currentTime�� ������ ��ȯ

        int minutes = Mathf.FloorToInt(a / 60f);
        int seconds = Mathf.FloorToInt(a % 60f);

        string timeString = string.Format("���� ���� �ð� : {0}:{1:00}", minutes, seconds);
        timeText.text = timeString;
    }
}
