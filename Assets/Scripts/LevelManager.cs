using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Building1()
    {
        PlayerPrefs.SetInt("SelectedBuilding", 1);
    }

    public void Building2()
    {
        PlayerPrefs.SetInt("SelectedBuilding", 2);
    }

    public void Building3()
    {
        PlayerPrefs.SetInt("SelectedBuilding", 3);
    }
}
