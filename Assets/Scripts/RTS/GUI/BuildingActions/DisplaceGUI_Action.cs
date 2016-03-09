using UnityEngine;
using System.Collections;

public class DisplaceGUI_Action : MonoBehaviour {

    private GameObject objectgame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(GameObject gm)
    {
        objectgame = gm;
    }

    public void DeleteObject()
    {
        IO_Observer Observer = objectgame.GetComponent<IO_Observer>();
        Observer.subject.Remove(Observer);

        Building BuildingObserve = objectgame.GetComponent<Building>();
        BuildingObserve.DefaultGrup.RemoveBuild(BuildingObserve);
        BuildingObserve.subject.Remove(BuildingObserve);
        

        PlacingToGrid place = objectgame.GetComponent<PlacingToGrid>();
        place.RelaseAll();

        IO_Basic.Delete(objectgame.name);
        objectgame.SetActive(false);
    }

    public static void DeleteObject(GameObject objectgame)
    {
        IO_Observer Observer = objectgame.GetComponent<IO_Observer>();
        Observer.subject.Remove(Observer);

        Building BuildingObserve = objectgame.GetComponent<Building>();
        BuildingObserve.DefaultGrup.RemoveBuild(BuildingObserve);
        BuildingObserve.subject.Remove(BuildingObserve);

        PlacingToGrid place = objectgame.GetComponent<PlacingToGrid>();
        place.RelaseAll();

        IO_Basic.Delete(objectgame.name);
        objectgame.SetActive(false);
    }
}
