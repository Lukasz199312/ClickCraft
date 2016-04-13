using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

    public ClickerScene Scene;
    public Randomness GeneratorRand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
             PhaseAction(touch);
        }
	}

    private void PhaseAction(Touch touch)
    {
       
        GeneratorRand.SceneGenerateResourceValue(Scene, touch);
    }

    public void Initialize(I_SceneRandGenerator SceneRand)
    {
        GeneratorRand = new Randomness();
        GeneratorRand.GenerateScene = SceneRand;
    }
}
