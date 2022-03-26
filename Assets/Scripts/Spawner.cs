using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector3 SpawnPos;
    public GameObject[] spawnObject;
    //private float newSpawnDuration = 1f;
    public bool sno = true;

    #region Singleton

    public static Spawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        if (sno == true)
        {
            SpawnPos = transform.position;
            int randomInt = Random.Range(0, spawnObject.Length);
            GameObject copyOfObject = spawnObject[randomInt];
            Quaternion copyOfObjectTheRotation = copyOfObject.transform.rotation;
            GameObject newObject = Instantiate(spawnObject[randomInt], SpawnPos, copyOfObjectTheRotation);

            Camera.main.gameObject.GetComponent<forCamera>().target = newObject.gameObject.transform;
            sno = false;
        }

    }

    private void Update()
    {
        if (sno == true)
        {
            int randomInt = Random.Range(0, spawnObject.Length);
            GameObject copyOfObject = spawnObject[randomInt];
            Quaternion copyOfObjectTheRotation = copyOfObject.transform.rotation;
            GameObject newObject = Instantiate(spawnObject[randomInt], SpawnPos, copyOfObjectTheRotation);

            Camera.main.gameObject.GetComponent<forCamera>().target = newObject.gameObject.transform;
            sno = false;
        }
    }

}