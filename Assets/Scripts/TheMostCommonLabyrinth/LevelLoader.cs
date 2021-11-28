using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheMostCommonLabyrinth
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(string sceneName) 
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
