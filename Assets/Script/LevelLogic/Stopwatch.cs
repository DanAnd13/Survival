using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;  // Текстовий компонент для відображення часу
    public static string stopwatchValue = "Life time: 00:00";
    public static int kills;
    private float elapsedTime = 0f;  // Відрахований час
    private bool isRunning = false;  // Стан секундоміра

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
            //підсилення ворогів кожну хвилину
            if (elapsedTime % 60f == 0)
            {
                Timer.delay = Mathf.Max(1f, Timer.delay - 0.2f);
                EnemyMovement.bonusEnemyHP += 5f;
                EnemyMovement.bonusEnemyDamage += 5f;
                EnemyMovement.bonusEnemySpeed += 1f;
            }
            UpdateStopwatchDisplay();
        }
    }
    // Метод для запуску секундоміра
    public void StartStopwatch()
    {
        isRunning = true;
    }

    // Метод для зупинки секундоміра
    public void StopStopwatch()
    {
        isRunning = false;
    }

    // Метод для скидання секундоміра
    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        UpdateStopwatchDisplay();
    }

    // Метод для оновлення відображення часу на UI
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
