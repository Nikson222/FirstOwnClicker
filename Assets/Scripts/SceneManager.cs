using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ChangeScenes(int numberScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numberScene);
    }
}
