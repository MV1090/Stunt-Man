using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    public BaseLevel[] allLevels;
    public enum LevelSelector
    {
        Level_1, Level_2, Level_3
    }

    private BaseLevel currentLevel;
    public Dictionary<LevelSelector, BaseLevel> levelDictionary = new Dictionary<LevelSelector, BaseLevel>();
    private Queue<LevelSelector> levelQueue = new Queue<LevelSelector>();

    public void Start()
    {
        if (allLevels == null)
            return;

        foreach (BaseLevel levelStage in allLevels)
        {
            if(levelStage == null) continue;

            levelStage.InitState(this);

            if (levelDictionary.ContainsKey(levelStage.level))
                    continue;
            levelDictionary.Add(levelStage.level, levelStage);
        }

        foreach (LevelSelector levelStage in levelDictionary.Keys)
        {
            levelDictionary[levelStage].gameObject.SetActive(false);
            levelQueue.Enqueue(levelStage);
        }

        SetNextLevel(LevelSelector.Level_1);
    }

    public void SetNextLevel(LevelSelector newLevel)
    {
        if (!levelDictionary.ContainsKey(newLevel))
            return;
        if (levelQueue.Count == 0)
            return;

        if(currentLevel != null)
        {
            currentLevel.ExitState();
            currentLevel.gameObject.SetActive(false);
            levelQueue.Dequeue();
        }

        currentLevel = levelDictionary[newLevel];
        currentLevel.EnterState();
        currentLevel.gameObject.SetActive(true);               
    }

    public void Update()
    {
      
    }

}
