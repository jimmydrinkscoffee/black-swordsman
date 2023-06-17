using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoryGameManager : Singleton<StoryGameManager>
{
    const string _COMPLETED_LEVELS_KEY = "completedLevels";
    const string _CURRENT_LEVEL_KEY = "currentLevel";

    [SerializeField] List<string> _levels = new List<string>();

    List<string> _completedLevels;
    string _currentLevel;

    protected override void Awake()
    {
        base.Awake();
        _completedLevels = ES3.Load<List<string>>(_COMPLETED_LEVELS_KEY);
        _currentLevel = ES3.Load<string>(_CURRENT_LEVEL_KEY);
    }

    public void SaveGame()
    {
        ES3.Save<List<string>>(_COMPLETED_LEVELS_KEY, _completedLevels);
        ES3.Save<string>(_CURRENT_LEVEL_KEY, _currentLevel);
    }

    public string GetNextLevel()
    {
        var levels = _levels.Where(lv => !_completedLevels.Contains(lv)).ToList();
        if (levels.Count == 0)
        {
            return null;
        }

        _currentLevel = levels[Random.Range(0, levels.Count)];
        return _currentLevel;
    }

    public void CompleteCurrentLevel()
    {
        _completedLevels.Add(_currentLevel);
        _currentLevel = null;
    }

    protected override void OnApplicationQuit()
    {
        SaveGame();
        base.OnApplicationQuit();
    }
}