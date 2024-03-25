using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LayerManager : MonoBehaviour
{
    [SerializeField] GameObject[] Layers;
    [SerializeField] TMP_Text longBrickCount;
    [SerializeField] TMP_Text smallBrickCount;
    [SerializeField] TMP_Text slopedBrickCount;
    [SerializeField] TMP_Text roofCount;

    int currentLayer;

    int longBrickAmmount;
    int smallBrickAmmount;
    int slopedBrickAmmount;
    int roofAmmount;

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

        if (currentLayer < Layers.Length)
        {
            currentLayer++;

            if(currentLayer == 1)
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
                for (int i = 0; i < currentLayer; i++)
                {
                    Layers[i].SetActive(true);
                }
            }

            CountLayerBricks();
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

    public void CountTotalBricks()
    {
        for (int i = 0; i < Layers.Length; i++)
        {
            for (int t = 0; t < Layers[i].transform.childCount; t++)
            {
                if (Layers[i].transform.GetChild(t).gameObject.CompareTag("LongBrick"))
                {
                    longBrickAmmount++;
                }
                else if (Layers[i].transform.GetChild(t).gameObject.CompareTag("SmallBrick"))
                {
                    smallBrickAmmount++;
                }
                else if (Layers[i].transform.GetChild(t).gameObject.CompareTag("SlopedBrick"))
                {
                    slopedBrickAmmount++;
                }
                else if (Layers[i].transform.GetChild(t).gameObject.CompareTag("Roof"))
                {
                    roofAmmount++;
                }
            }
        }

        longBrickCount.text = "Long Bricks: " + longBrickAmmount.ToString();
        smallBrickCount.text = "Small Bricks: " + smallBrickAmmount.ToString();
        slopedBrickCount.text = "Sloped Bricks: " + slopedBrickAmmount.ToString();
        roofCount.text = "Roofs: " + roofAmmount.ToString();
    }

    private void CountLayerBricks()
    {
            for (int t = 0; t < Layers[currentLayer].transform.childCount; t++)
            {
                if (Layers[currentLayer].transform.GetChild(t).gameObject.CompareTag("LongBrick"))
                {
                    longBrickAmmount++;
                }
                else if (Layers[currentLayer].transform.GetChild(t).gameObject.CompareTag("SmallBrick"))
                {
                    smallBrickAmmount++;
                }
                else if (Layers[currentLayer].transform.GetChild(t).gameObject.CompareTag("SlopedBrick"))
                {
                    slopedBrickAmmount++;
                }
                else if (Layers[currentLayer].transform.GetChild(t).gameObject.CompareTag("Roof"))
                {
                    roofAmmount++;
                }
        }

        longBrickCount.text = "Long Bricks: " + longBrickAmmount.ToString();
        smallBrickCount.text = "Small Bricks: " + smallBrickAmmount.ToString();
        slopedBrickCount.text = "Sloped Bricks: " + slopedBrickAmmount.ToString();
        roofCount.text = "Roofs: " + roofAmmount.ToString();
    }

}
