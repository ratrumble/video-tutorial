using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;

    private void Start()
    {
        Debug.Log("this thing works");
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        Debug.Log("this thing works part 2");
        foreach (Enemy enemy in _enemies)
        {
            if(enemy != null)
            {
                return;
            }
        }
        Debug.Log("All enemies are dead");

        _nextLevelIndex++;

        string levelName = "level" + _nextLevelIndex;
        SceneManager.LoadScene(levelName);
    }
}
