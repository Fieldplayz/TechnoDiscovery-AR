using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TransitionSettings sceneTransition;
    public TransitionSettings startTransition;
    public float loadDelay;

    private void Start()
    {
        TransitionManager.Instance().Transition(startTransition, 0);
    }

    public void ToMainScene()
    {
        Debug.Log("ToMainScene");
        TransitionManager.Instance().Transition("MainScene", sceneTransition, loadDelay);
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
