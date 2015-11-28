using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    public float MoveSpeed;

    private Vector3 FirstTouch;
    private Vector3 Distance;

	// Use this for initialization
	void Start () {
        FirstTouch = new Vector3();
        Distance = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(Touch touch in Input.touches)
        {
            Debug.Log("Phase: " + touch.phase);
            
            if(touch.phase == TouchPhase.Began)
            {
                FirstTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (FirstTouch.x < touch.position.x)
                {
                    transform.position = new Vector3(transform.position.x - MoveSpeed, transform.position.y, transform.position.z);
                }
                else if (FirstTouch.x > touch.position.x)
                {
                    transform.position = new Vector3(transform.position.x + MoveSpeed, transform.position.y, transform.position.z);
                }

                if(FirstTouch.y < touch.position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - MoveSpeed, transform.position.z);
                }
                else if (FirstTouch.y > touch.position.y)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + MoveSpeed, transform.position.z);
                }
                FirstTouch = touch.position;
                
            }
        }
	}

}
