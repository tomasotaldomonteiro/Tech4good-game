using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyManager : MonoBehaviour
{
    public bool alliesSaved = false;
    private List<GameObject> allies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        AddAllies();
    }

    // Update is called once per frame
    void Update()
    {
        CountAllies();
    }

    void AddAllies()
    {
        GameObject[] foundAllies = GameObject.FindGameObjectsWithTag("Ally");
        
        allies.AddRange(foundAllies);
        
        Debug.Log(allies.Count);
    }

    void CountAllies()
    {
        allies.RemoveAll(ally => ally == null || !ally.activeInHierarchy);

        if (allies.Count == 0)
        {
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        alliesSaved = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Ending");
    }
}
