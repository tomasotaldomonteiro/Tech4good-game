using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehaviour : MonoBehaviour
{
    private GameObject textCanvas;

    public float health = -10;
    // Start is called before the first frame update
    void Start()
    {
        textCanvas = transform.GetChild(0).gameObject;
        textCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0)
        {
            textCanvas.SetActive(true);
            StartCoroutine(DespawnAlly());
        }
    }

    private IEnumerator DespawnAlly()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
