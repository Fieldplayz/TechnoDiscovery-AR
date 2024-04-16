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
		//if there are still more layers left
		if (currentLayer < Layers.Length)
		{
			currentLayer++;

			UpdateLayerActivity();
		}
	}

	public void PreviousLayer()
	{
		//if there are still more layers left to go back
		if (currentLayer > 0)
		{
			currentLayer--;

            CountLayerBricks(currentLayer);
			UpdateLayerActivity();
		}
	}
	
	private void UpdateLayerActivity()
	{
		//reset counting varibles
		longBrickAmmount = 0;
		smallBrickAmmount = 0;
		slopedBrickAmmount = 0;
		roofAmmount = 0;
		windowAmmount = 0;
		doorAmmount = 0;
		
		layerCount.text = "Laag " + currentLayer.ToString();
		Debug.Log(currentLayer);
		
		//loop trough all layers
		for (int i = 0; i < Layers.Length; i++)
		{
			var layer = Layers[i];
			bool needsToBeActive = (i <= currentLayer);
			
			//if we are on the first layer we show the entire building
			if (currentLayer == 0) 
			{
				layer.SetActive(true);
			}
			else
			{		
				layer.SetActive(needsToBeActive);
			}
		}
		
		CountLayerBricks(currentLayer);
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
