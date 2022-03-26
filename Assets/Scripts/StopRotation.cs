using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopRotation : MonoBehaviour
{
    public Spawner spawner;
    public DragAndShoot dragAndShoots;
    public TextMeshProUGUI H_Bar_text;
    public GManager GM;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene") { 
            spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            GM = GameObject.Find("GameManager").GetComponent<GManager>();
            H_Bar_text = GameObject.Find("H_Bar_text").GetComponent<TextMeshProUGUI>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "throwObject")
        {
            dragAndShoots = other.gameObject.GetComponent<DragAndShoot>();

            if (other.gameObject.GetComponent<DragAndShoot>().isRotation == true) { 
                other.gameObject.GetComponent<DragAndShoot>().isRotation = false;
                other.gameObject.GetComponent<DragAndShoot>().isOkay = false;
                if (other.gameObject.GetComponent<DragAndShoot>().isOkay == false){

                    if (dragAndShoots.ringGoes == false) { 
                        Camera.main.gameObject.GetComponent<forCamera>().target = null;
                        spawner.sno = true;
                        GM.healthValue = GM.healthValue - 1;
                        
                    }

                    Destroy(other.gameObject);
                }
            }
        }
    }

}
