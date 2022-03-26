using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewRoad : MonoBehaviour
{

    public GameObject[] GroundCopy;

    private void OnTriggerEnter(Collider other)
    {
        int randomNumberForRoad = Random.Range(0, GroundCopy.Length);
        print("Roads number > " + randomNumberForRoad);
        Instantiate(GroundCopy[randomNumberForRoad], new Vector3(-20.5f, 24.7464f, 310.4f), Quaternion.Euler(0, 0, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
