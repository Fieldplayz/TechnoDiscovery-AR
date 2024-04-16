using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LayerManager : MonoBehaviour
{
    [Header("Set to building's number")]
    [SerializeField] int buildingNumber;

    [SerializeField] GameObject[] Layers;
    [SerializeField] TMP_Text longBrickCount;
    [SerializeField] TMP_Text smallBrickCount;
    [SerializeField] TMP_Text slopedBrickCount;
    [SerializeField] TMP_Text roofCount;
    [SerializeField] TMP_Text doorCount;
    [SerializeField] TMP_Text windowCount;
    [SerializeField] TMP_Text layerCount;

    int currentLayer;

    int longBrickAmmount;
    int smallBrickAmmount;
    int slopedBrickAmmount;
    int roofAmmount;
    int doorAmmount;
    int windowAmmount;

    private void Awake()
    {
        int selectedBuilding = PlayerPrefs.GetInt("SelectedBuilding");
        if (selectedBuilding != buildingNumber)
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        CountTotalBricks();
    }

    public void NextLayer()
    {
        longBrickAmmount = 0;
        smallBrickAmmount = 0;
        slopedBrickAmmount = 0;
        roofAmmount = 0;
        windowAmmount = 0;
        doorAmmount = 0;
        
        //checks if the currentlyayer isn't higher than the layers length
        if (currentLayer < Layers.Length)
        {
            currentLayer++;
            
            layerCount.text = "Laag " + currentLayer.ToString();
            Debug.Log(currentLayer);
            

            if (currentLayer >= 1)
            {
                for (int i = 0; i <= Layers.Length; i++)
                {
                    Debug.Log(i);
                    Debug.Log("Currentlayer: " + currentLayer);

                    if (i == currentLayer)
                    {
                        break;
                    }
                    else
                    {
                        Layers[i].SetActive(true);
                    }
                }
                
            }
            else
            {
                for (int i = 0; i <= currentLayer; i++)
                {
                    Layers[i].SetActive(true);
                }
            }

            CountTotalBricks();
        }
        else if(currentLayer == Layers.Length)
        {
            currentLayer = 0;

            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i].SetActive(true);
            }

            CountTotalBricks();
        }
    }

    public void PreviousLayer()
    {
        longBrickAmmount = 0;
        smallBrickAmmount = 0;
        slopedBrickAmmount = 0;
        roofAmmount = 0;
        windowAmmount = 0;
        doorAmmount = 0;

        if (currentLayer > 0)
        {
            currentLayer--;

            layerCount.text = "Layer " + currentLayer.ToString();
            Debug.Log(currentLayer);


            if (currentLayer <= 1)
            {
                for (int i = 0; i <= Layers.Length; i++)
                {
                    if (Layers[i] != Layers[currentLayer])
                    {
                        Layers[i].SetActive(false);
                    }
                    else
                    {
                        Layers[i].SetActive(true);
                    }
                }

            }
            else
            {
                for (int i = 0; i <= currentLayer; i++)
                {
                    Layers[i].SetActive(true);
                }
            }

            CountTotalBricks();
        }
        else if (currentLayer == 0)
        {
            currentLayer = Layers.Length;

            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i].SetActive(true);
            }

            CountTotalBricks();
        }
    }
    public void CountTotalBricks()
    {
        for (int i = 0; i < Layers.Length; i++)
        {
            CountLayerBricks(i);
        }
    }

    private void CountLayerBricks(int layer)
    {
         for (int t = 0; t < Layers[layer].transform.childCount; t++)
         {
            var obj = Layers[layer].transform.GetChild(t).gameObject;
             if (obj.CompareTag("LongBrick"))
             {
                 longBrickAmmount++;
             }
             else if (obj.CompareTag("SmallBrick"))
             {
                 smallBrickAmmount++;
             }
             else if (obj.CompareTag("SlopedBrick"))
             {
                 slopedBrickAmmount++;
             }
             else if (obj.CompareTag("Roof"))
             {
                 roofAmmount++;
             }
             else if (obj.CompareTag("Door"))
             {
                 doorAmmount++;
             }
             else if (obj.CompareTag("Window"))
             {
                 windowAmmount++;
             }
         }

        UpdateCounters();
    }

    private void UpdateCounters()
    {
        longBrickCount.text = ": " + longBrickAmmount.ToString();
        smallBrickCount.text = ": " + smallBrickAmmount.ToString();
        slopedBrickCount.text = ": " + slopedBrickAmmount.ToString();
        roofCount.text = ": " + roofAmmount.ToString();
        doorCount.text = ": " + doorAmmount.ToString();
        windowCount.text = ": " + windowAmmount.ToString();
    }

}
