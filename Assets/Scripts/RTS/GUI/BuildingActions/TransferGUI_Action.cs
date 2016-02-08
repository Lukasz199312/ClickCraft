using UnityEngine;
using System.Collections;

public class TransferGUI_Action : MonoBehaviour {

    private PlacingToGrid _PlacingObject;
    private BuilderManager Builder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(PlacingToGrid _Place, BuilderManager Builder)
    {
        this._PlacingObject = _Place;
        this.Builder = Builder;
        
    }

    public void ActionClick()
    {
        Builder.Transfer(_PlacingObject);
    }
}
