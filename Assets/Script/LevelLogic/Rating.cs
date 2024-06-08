using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class Rating : MonoBehaviour
{
    [System.Serializable]
    public struct Leaderboard
    {
        public string date;
        public int kills;
        public string lifeTime;
    }

    static string filePath;
    public TextMeshProUGUI ratingText;
    static public List<Leaderboard> users = new List<Leaderboard>();
    static string json;

    void Start()
    {
        filePath = Application.persistentDataPath + "/Leaderboard.json";
        Open();
    }
    public static void Create()
    {
        if (users.Count >= 18)
        {
            users.RemoveAt(users.Count - 1);
        }

        Leaderboard existingUser = users.Find(u => u.date == DateTime.Now.ToString("dd.MM.yyyy"));
        Leaderboard newUser = new Leaderboard();
        newUser.date = DateTime.Now.ToString("dd.MM.yyyy");
        newUser.kills = Stopwatch.kills;
        newUser.lifeTime = Stopwatch.stopwatchValue;
        users.Add(newUser);
        users.Sort((a, b) => b.date.CompareTo(a.date));

        json = JsonUtility.ToJson(new LeaderboardListWrapper(users));
        File.WriteAllText(filePath, json);
    }

    void Update()
    {
        ratingText.text = "";
        foreach (Leaderboard user in users)
        {
            ratingText.text += user.date + ". " + user.kills + " kills. " + user.lifeTime + "\n";
        }
    }

    public static void Open()
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            LeaderboardListWrapper wrapper = JsonUtility.FromJson<LeaderboardListWrapper>(json);
            users = new List<Leaderboard>(wrapper.users);
        }
    }
    public static void WriteToJSON()
    {
        filePath = Application.persistentDataPath + "/Leaderboard.json";
        Open();
        Create();
    }

    [System.Serializable]
    private class LeaderboardListWrapper
    {
        public Leaderboard[] users;

        public LeaderboardListWrapper(List<Leaderboard> users)
        {
            this.users = users.ToArray();
        }
    }
}
