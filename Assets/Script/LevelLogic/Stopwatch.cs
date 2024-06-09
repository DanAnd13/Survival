using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;  // ��������� ��������� ��� ����������� ����
    public static string stopwatchValue = "Life time: 00:00";
    public static int kills;
    private float elapsedTime;  // ³���������� ���
    private bool isRunning;  // ���� ����������
    private float nextPowerUpTime;

    void Start()
    {
        ResetStopwatch();
        StartStopwatch();
        kills = 0;
    }
    void FixedUpdate()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            // ϳ�������� ������ ����� �������
            if (elapsedTime >= nextPowerUpTime)
            {
                Timer.delay = Mathf.Max(1f, Timer.delay - 0.2f);
                EnemyMovement.bonusEnemyHP += 5f;
                EnemyMovement.bonusEnemyDamage += 5f;
                EnemyMovement.bonusEnemySpeed += 1f;
                nextPowerUpTime += 60f;  // ���������� ��� ���������� ��������� ����� 60 ������
            }
            UpdateStopwatchDisplay();
        }
    }
    // ����� ��� ������� ����������
    public void StartStopwatch()
    {
        isRunning = true;
    }

    // ����� ��� ������� ����������
    public void StopStopwatch()
    {
        isRunning = false;
    }

    // ����� ��� �������� ����������
    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        nextPowerUpTime = 60f;
        UpdateStopwatchDisplay();
    }

    // ����� ��� ��������� ����������� ���� �� UI
    void UpdateStopwatchDisplay()
    {
        if (stopwatchText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            stopwatchText.text = "Life time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            stopwatchValue = stopwatchText.text;
        }
    }
}
