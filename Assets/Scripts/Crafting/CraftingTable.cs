using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    public Canvas canvas3D;
    public GameObject craftingPanel;
    bool areaCraft = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvas3D.gameObject.SetActive(true);
            areaCraft = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas3D.gameObject.SetActive(false);
            areaCraft = false;
            craftingPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && areaCraft == true)
        {
            if(craftingPanel.active)
            {
                craftingPanel.SetActive(false);
            }
            else
            {
                craftingPanel.SetActive(true);
            }
        }
    }
}
