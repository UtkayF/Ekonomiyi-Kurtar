using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Code_0 : MonoBehaviour
{

    public Spawner spawner;
    public DragAndShoot dragAndShoots;
    public GManager GM;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        GM = GameObject.Find("GameManager").GetComponent<GManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "throwObject")
        {
            dragAndShoots = other.gameObject.GetComponent<DragAndShoot>();
            if(dragAndShoots.ringGoes == false) { 
                dragAndShoots.ringGoes = true;
                Camera.main.gameObject.GetComponent<forCamera>().target = null;
                spawner.sno = true;

                GM.setSpawn = true;
                //DOLAR KURU DÜŞÜCEK
                GM.cuMoney = GM.cuMoney - GM.propsEarn;

                Destroy(this.gameObject);
            }
        }
    }

}
