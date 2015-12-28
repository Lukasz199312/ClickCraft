using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    public float MoveSpeed;
    public GridManager Grid;

    private Vector3 FirstTouch;
    private Vector3 Distance;

	// Use this for initialization
	void Start () {
        FirstTouch = new Vector3();
        Distance = new Vector3();
        Distance = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(Touch touch in Input.touches)
        {
            if (Input.touchCount > 1) return;
            PhaseAction(touch);
        }

        if (Distance.sqrMagnitude == 0) return;
        if (Input.touchCount == 0) return;
        MoveCamera();
        Grid.DetechTouchPositionOnGrid(FirstTouch);
	}

    private void PhaseAction(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            FirstTouch = Camera.main.ScreenToWorldPoint(touch.position);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            Distance = Camera.main.ScreenToWorldPoint(touch.position); ;
        }
        else if (touch.phase == TouchPhase.Ended) Distance = Vector3.zero;
        else if (touch.phase == TouchPhase.Stationary) Distance = Vector3.zero;
    }

    private void MoveCamera()
    {
        Vector3 Result = new Vector3();
        Vector3 Point = Vector3.MoveTowards(FirstTouch, Distance, MoveSpeed);

        Result = FirstTouch - Point;

        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + Result.x,
                                                     Camera.main.transform.position.y + Result.y,
                                                     Camera.main.transform.position.z);

        if (Point.sqrMagnitude == 0) Distance = Vector3.zero;
    }

    public Vector3 GetTouch()
    {
        return FirstTouch;
    }
}
