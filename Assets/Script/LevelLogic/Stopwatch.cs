using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    //public TextMeshProUGUI stopwatchText;  // ��������� ��������� ��� ����������� ����
    //public TextMeshProUGUI killCount;
    public static int kills;
    private float elapsedTime = 0f;  // ³���������� ���
    private bool isRunning = false;  // ���� ����������

    private void Start()
    {
        ResetStopwatch();
        StartStopwatch();
        kills = 0;
    }
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            //��������� ������ ����� �������
            if (elapsedTime % 60f == 0)
            {
                Timer.delay = Mathf.Max(1f, Timer.delay - 0.2f);
                EnemyMovement.bonusEnemyHP += 5f;
                EnemyMovement.bonusEnemyDamage += 5f;
                EnemyMovement.bonusEnemySpeed += 1f;
            }
            UpdateStopwatchDisplay();
            UpdateKillCountDisplay();
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
        UpdateStopwatchDisplay();
    }

    // ����� ��� ��������� ����������� ���� �� UI
    void UpdateStopwatchDisplay()
    {
        /*if (stopwatchText != null)
        {*/
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            //stopwatchText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        //}
    }
    //���� ������� ���
    void UpdateKillCountDisplay()
    {
        //killCount.text = kills.ToString();
    }
}
