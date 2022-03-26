using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    [Range(3, 30)]
    private int lineSegmentCount = 20;

    /*
    [SerializeField]
    [Range(10, 100)]
    private int showPercentage = 50;
    */

    [SerializeField]
    private int linePointCount;

    private List<Vector3> linePoints = new List<Vector3>();

    #region Singleton

    public static DrawTrajectory Instance;

    private void Start()
    {
       // linePointCount = (int)(lineSegmentCount * (showPercentage / 100f));
    }

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {

        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / lineSegmentCount;

        linePoints.Clear();
        linePoints.Add(startingPoint);

        for (int i = 0; i < linePointCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                    velocity.x * stepTimePassed,
                    velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                    velocity.z * stepTimePassed
                    );

            Vector3 NewPointOnLine = -MovementVector + startingPoint;


            linePoints.Add(NewPointOnLine);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());

    }

    public void HideLine()
    {
        linePoints.Clear();
    }

}
