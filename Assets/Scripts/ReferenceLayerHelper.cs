using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReferenceLayerHelper : MonoBehaviour
{
    [SerializeField]  List<LayerManager> layerManagers = new List<LayerManager>();

    public void NextLayer()
    {
        Debug.Log("Activated");
        var activeManager = layerManagers.FirstOrDefault(lm => lm.isActiveAndEnabled);
        if (activeManager != null)
        {
            Debug.Log(activeManager.name);
            activeManager.NextLayer();
        }
    }

   public void PreviousLayer()
    {
        var activeManager = layerManagers.FirstOrDefault(lm => lm.isActiveAndEnabled);
        if (activeManager != null)
        {
            Debug.Log(activeManager.name);
            activeManager.PreviousLayer();
        }
    }
}
