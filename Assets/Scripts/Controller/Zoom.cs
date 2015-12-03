using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

    public float MaksZoomIn;
    public float MaksZoomOut;
    public float ZoomStep;
    public float Delay;

    private Touch FirstTouch;
    private Touch SecondTouch;

    private Vector2 FirstTouch_OldPosition;
    private Vector2 SecondTouch_OldPosition;

	// Use this for initialization
	void Start () {
        FirstTouch = new Touch();
        SecondTouch = new Touch();

        FirstTouch_OldPosition = new Vector2();
        SecondTouch_OldPosition = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 2) return;

        if (Input.touches[0].position.x < Input.touches[1].position.x )
        {
            FirstTouch = Input.touches[0];
            SecondTouch = Input.touches[1];

        } 
        else
        {
            FirstTouch = Input.touches[1];
            SecondTouch = Input.touches[0];
        }

        if (FirstTouch.phase == TouchPhase.Moved || SecondTouch.phase == TouchPhase.Moved)
        {
            if (FirstTouch.position.x - Delay > FirstTouch_OldPosition.x)
            {
                ZoomIn();

                FirstTouch_OldPosition = new Vector2(FirstTouch.position.x, FirstTouch.position.y);
                SecondTouch_OldPosition = new Vector2(SecondTouch.position.x, SecondTouch.position.y);
            }
            else if (SecondTouch.position.x + Delay < SecondTouch_OldPosition.x)
            {
                ZoomIn();

                FirstTouch_OldPosition = new Vector2(FirstTouch.position.x, FirstTouch.position.y);
                SecondTouch_OldPosition = new Vector2(SecondTouch.position.x, SecondTouch.position.y);
            }

            else if (FirstTouch.position.x + Delay < FirstTouch_OldPosition.x)
            {
                ZoomOut();

                FirstTouch_OldPosition = new Vector2(FirstTouch.position.x, FirstTouch.position.y);
                SecondTouch_OldPosition = new Vector2(SecondTouch.position.x, SecondTouch.position.y);
            }
            else if (SecondTouch.position.x - Delay > SecondTouch_OldPosition.x)
            {
                ZoomOut();

                FirstTouch_OldPosition = new Vector2(FirstTouch.position.x, FirstTouch.position.y);
                SecondTouch_OldPosition = new Vector2(SecondTouch.position.x, SecondTouch.position.y);
            }


        }
	}

    private void ZoomIn()
    {
        if (Camera.main.orthographicSize <= MaksZoomIn) return;
        Camera.main.orthographicSize -= ZoomStep;
    }

    private void ZoomOut()
    {
        if (Camera.main.orthographicSize >= MaksZoomOut) return;
        Camera.main.orthographicSize += ZoomStep;
    }
}
