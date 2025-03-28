using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        GameObject interactionText = GameObject.FindWithTag("UI").transform.GetChild(0).gameObject;
        interactionText.SetActive(true);
        
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        interactionText.SetActive(false);
        SceneManager.LoadScene(2);
        Debug.Log("Mouse over");
    }

    private void OnMouseExit()
    {
        GameObject interactionText = GameObject.FindWithTag("UI").transform.GetChild(0).gameObject;
        interactionText.SetActive(false);
    }
}
