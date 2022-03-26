using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BugSearcher : MonoBehaviour
{
    public GameObject currentObject;
    public DragAndShoot DAS;
    public Spawner SP;
    public Button againSpawnObjectBTN;
    public bool isControl;

    void Start()
    {
        againSpawnObjectBTN.onClick.AddListener(ResetItem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "throwObject") { 
            currentObject = other.gameObject;
            DAS = currentObject.GetComponent<DragAndShoot>();
        }
    }


    void ResetItem()
    {
        StartCoroutine(changeItem());
       
    }

    IEnumerator changeItem()
    {
        SP.sno = true;
        Destroy(currentObject);
        againSpawnObjectBTN.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        againSpawnObjectBTN.gameObject.SetActive(true);
    }



}
