using UnityEngine;
using System.Collections;

public class BuilderManager : MonoBehaviour {

    public TouchController Controller;
    public GridManager Grid;

    public PlacingToGrid BuildObjectPlacingToGrid;
    public SpriteRenderer BuildObjectSprite;
    public BoxCollider2D Collider2D;

    private bool isBuild = false;
    private bool MoveObject = false;
    private GridElement OldPositionElement;
    private ItemShop shopitem;
    private GridElement FirstToucheelement;
    private bool flag = false;

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
        }
        else flag = false;

	}

    public void Build(ItemShop item)
    {
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

        BuildObjectPlacingToGrid.X_Space = item.GetPlacingToGrid().X_Space;
        BuildObjectPlacingToGrid.Y_Space = item.GetPlacingToGrid().Y_Space;

        BuildObjectPlacingToGrid.Col = element.getCol();
        BuildObjectPlacingToGrid.Row = element.getRow();

        BoxCollider2D boxcollider = item.GetComponent<BoxCollider2D>();

        Collider2D.size = new Vector2(boxcollider.size.x ,boxcollider.size.y);

        

        isBuild = true;
    }

    public void FinalizeBuild()
    {
        Building build = shopitem.DefaultGroup.AddBuild(BuildObjectPlacingToGrid.transform.position);
        PlacingToGrid placetogrid = build.GetComponent<PlacingToGrid>();

        placetogrid.Col = BuildObjectPlacingToGrid.Col;
        placetogrid.Row = BuildObjectPlacingToGrid.Row;

        BuildObjectSprite.gameObject.SetActive(false);
    }
}
