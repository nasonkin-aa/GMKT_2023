using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneManagers
{
    public static void SceneLoad(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public static void SceneNext()
    {
        SceneManager.LoadScene(SceneManager.loadedSceneCount + 1);
    }
}
