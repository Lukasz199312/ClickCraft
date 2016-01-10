using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    public float MoveSpeed;
    public GridManager Grid;
    public bool enableMove = true;
    public GameObject TouchedObject;
    public Touch touch;

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
            this.touch = touch;
            PhaseAction(touch);
        }

        if (Input.touchCount == 0)
        {
            TouchedObject = null;
            enableMove = true;
        }

        if (Distance.sqrMagnitude == 0) return;
        if (Input.touchCount == 0) return;

        if(enableMove == true) MoveCamera();

	}

    private void PhaseAction(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            FirstTouch = Camera.main.ScreenToWorldPoint(touch.position);
            DetectTouchOnGameObject(touch);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            Distance = Camera.main.ScreenToWorldPoint(touch.position);
            Grid.DetechTouchPositionOnGrid(Distance);
            DetectTouchOnGameObject(touch);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            //Debug.Log("END");
            Distance = Vector3.zero;
            enableMove = true;
            DetectTouchOnGameObject(touch);
        }
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

    private GameObject DetectTouchOnGameObject(Touch touch)
    {
        //  Mask = 1 << 5;
        Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
       // if (Physics2D.Raycast(pos, Vector2.up, 0, 10, Mask) == true) Debug.Log("Its Work");
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0);
        if (hit != null && hit.collider != null)
        {
            //Debug.Log("I'm hitting " + hit.collider.name);
            TouchedObject = hit.collider.gameObject;
            return hit.collider.gameObject;
        }
        else
        {
            TouchedObject = null;
            return null;
        }
    }



}
