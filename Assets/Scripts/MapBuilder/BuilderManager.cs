using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuilderManager : MonoBehaviour {

    public TouchController Controller;
    public GridManager Grid;

    public PlacingToGrid BuildingSkeleton;
    public SpriteRenderer BuildObjectSprite;
    public BoxCollider2D Collider2D;

    public Color32 NormalColor;
    public Color32 RedColor;

    private bool isBuild = false;
    private bool MoveObject = false;
    private GridElement OldPositionElement;
    private ItemShop shopitem;
    private GridElement FirstToucheelement;
    private bool flag = false;
    private PlacingToGrid BuildObjectPlacingToGrid;

	// Use this for initialization
	void Start () {
        OldPositionElement = new GridElement();

        OldPositionElement.setCol(0);
        OldPositionElement.setRow(0);
	}
	
	// Update is called once per frame
	void Update () {
        if(isBuild == false) return;

        if (Controller.TouchedObject != null && Controller.TouchedObject.Equals(BuildObjectPlacingToGrid.gameObject) && flag == false)
        {
            Controller.enableMove = false;
            FirstToucheelement = Grid.DetechTouchPositionOnGrid(Camera.main.ScreenToWorldPoint(Controller.touch.position));
            Debug.Log("SET FIRST ELEMENT");
            flag = true;

        }
        else if (Controller.enableMove == false)
        {
            GridElement element = Grid.DetechTouchPositionOnGrid(Camera.main.ScreenToWorldPoint(Controller.touch.position));


            Debug.Log("RESULT:" + (element.getCol() - FirstToucheelement.getCol()));

            if (element.getRow() - FirstToucheelement.getRow() == 0 && element.getCol() - FirstToucheelement.getCol() == 0) return;

            BuildObjectPlacingToGrid.Row = BuildObjectPlacingToGrid.Row + element.getRow() - FirstToucheelement.getRow();
            BuildObjectPlacingToGrid.Col = BuildObjectPlacingToGrid.Col + (element.getCol() - FirstToucheelement.getCol());

            FirstToucheelement = Grid.DetechTouchPositionOnGrid(Camera.main.ScreenToWorldPoint(Controller.touch.position));

            Grid.Place(BuildObjectPlacingToGrid);
            CheckGridCollision();

        }
        else flag = false;

	}

    private void CheckGridCollision()
    {
        List<PlacingToGrid> TillesList = Grid.getTilles();

        IEnumerator enumTille = TillesList.GetEnumerator();
        List<GridElement> RedElementList = new List<GridElement>();

        while (enumTille.MoveNext())
        {
            PlacingToGrid PlacingToGrid_Tille = (PlacingToGrid)enumTille.Current;
            if (Object.ReferenceEquals(BuildObjectPlacingToGrid.gameObject, PlacingToGrid_Tille.gameObject)) continue;

            IEnumerator TilleEnum = PlacingToGrid_Tille.GridElementList.GetEnumerator();


            foreach (GridElement Place_element in PlacingToGrid_Tille.GridElementList)
            {
                foreach (GridElement BuildElement in BuildObjectPlacingToGrid.GridElementList)
                {
                    if (Object.ReferenceEquals(Place_element.gameObject, BuildElement.gameObject))
                    {
                        Place_element.setRed(Grid.RedColor);
                        RedElementList.Add(BuildElement);

                    }
                    else
                    {
                        Place_element.ToggleOn();
                        Place_element.setGreen(Grid.GreenColor);
                    }
                }
            }


        }
        foreach (GridElement test1 in RedElementList)
        {
            test1.setRed(Grid.RedColor);
        }

        if (RedElementList.Count > 0)
        {
            BuildObjectSprite.color = RedColor;
            BuildObjectSprite.gameObject.transform.position = new Vector3(BuildObjectSprite.gameObject.transform.position.x,
                                                                          BuildObjectSprite.gameObject.transform.position.y,
                                                                          BuildObjectSprite.gameObject.transform.position.z - 1);
        }
        else BuildObjectSprite.color = NormalColor;
    }

    public void Build(ItemShop item)
    {

        if (BuildObjectPlacingToGrid == null)
        {
            BuildObjectPlacingToGrid = BuildingSkeleton;
        }
        shopitem = item;
        Debug.Log("BUILDER: " + item.DefaultGroup.name);

        Vector3 Position = Camera.main.ScreenToWorldPoint( new Vector3(Camera.main.transform.position.x + Screen.width / 2 ,
                                       Camera.main.transform.position.y + Screen.height / 2,
                                       0));
        Position.z = 0;



       // Building build = item.DefaultGroup.AddBuild(Position);

        GridElement element =  Grid.DetechTouchPositionOnGrid(Position);
       // PlacingToGrid placetogrid = build.GetComponent<PlacingToGrid>();
        
       // placetogrid.Col = element.getCol();
       // placetogrid.Row = element.getRow();

        BuildObjectSprite.gameObject.SetActive(true);
        BuildObjectSprite.transform.localScale = item.transform.localScale;

        BuildObjectSprite.sprite = item.Sprite.sprite;

        BuildObjectPlacingToGrid.Col_size = item.GetPlacingToGrid().Col_size;
        BuildObjectPlacingToGrid.Row_size = item.GetPlacingToGrid().Row_size;

        BuildObjectPlacingToGrid.setNormalSpace_x( item.GetPlacingToGrid().getNormalSpace_x());
        BuildObjectPlacingToGrid.setNormalSpace_y( item.GetPlacingToGrid().getNormalSpace_y());

        BuildObjectPlacingToGrid.setMirrorSpace_x(item.GetPlacingToGrid().getMirrorSpace_x());
        BuildObjectPlacingToGrid.setMirrorSpace_y(item.GetPlacingToGrid().getMirrorSpace_y());

        BuildObjectPlacingToGrid.Col = element.getCol();
        BuildObjectPlacingToGrid.Row = element.getRow();

        BuildObjectPlacingToGrid.ReloadNormal();

        BoxCollider2D boxcollider = item.GetComponent<BoxCollider2D>();

        Collider2D.size = new Vector2(boxcollider.size.x ,boxcollider.size.y);

        Grid.Place(BuildObjectPlacingToGrid);
        

        isBuild = true;
        CheckGridCollision();
    }

    public void Tranfer(PlacingToGrid PlacingObject)
    {
        BuildObjectPlacingToGrid = PlacingObject;

        isBuild = true;
    }

    public void FinalizeBuild()
    {
        Building build = shopitem.DefaultGroup.AddBuild(BuildObjectPlacingToGrid.transform.position);
        PlacingToGrid placetogrid = build.GetComponent<PlacingToGrid>();

        placetogrid.Col = BuildObjectPlacingToGrid.Col;
        placetogrid.Row = BuildObjectPlacingToGrid.Row;

        build.transform.localScale = new Vector3(BuildObjectPlacingToGrid.transform.localScale.x,
                                                 BuildObjectPlacingToGrid.transform.localScale.y,
                                                 build.transform.localScale.z);

        BuildObjectSprite.gameObject.SetActive(false);
        placetogrid.scale = BuildObjectPlacingToGrid.scale;

        BuildObjectPlacingToGrid = null;
        isBuild = false;
    }

    public void MirrorRescale()
    {
        BuildObjectPlacingToGrid.MirrorScale();
    }
}
