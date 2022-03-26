using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    public bool isShoot;
    public bool isRotation = false;
    public bool isOkay = false;
    public bool ringGoes = false;
    public GManager GM;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GM = GameObject.Find("GameManager").GetComponent<GManager>();
    }

    void Update()
    {
        if (isRotation)
            transform.Rotate(Vector3.left * 150f * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if(GM.GameStarted == true) { 
            mousePressDownPos = Input.mousePosition;
        }
    }

    private void OnMouseDrag()
    {
        if (GM.GameStarted == true)
        {
            Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;

            //print(forceV);

            if (!isShoot)
                DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }

    }

    private void OnMouseUp()
    {
        if (GM.GameStarted == true)
        {
            DrawTrajectory.Instance.HideLine();
            print("OnMouseUP");
            mouseReleasePos = Input.mousePosition;
            Shoot(mouseReleasePos - mousePressDownPos);
        }
    }

    private float forceMultiplier = 2f;
    void Shoot(Vector3 Force)
    {
        
        if (isShoot)
            return;
        
        if (GM.GameStarted == true)
        {
            rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
            isShoot = true;
            isRotation = true;
            //Spawner.Instance.NewSpawnRequest();
        }
    }

}