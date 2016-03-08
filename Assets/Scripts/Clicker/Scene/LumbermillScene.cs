using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LumbermillScene : ClickerScene
{
    public DisplayTimer Timer;

	// Update is called once per frame
	void Update () {
        Timer.TimetText.text = ((Tree)Build).Capacity.get().ToString();
        if( ((Tree)Build).Capacity.get() <= 0)
        {
            button.onClick.Invoke();
            DisplaceGUI_Action.DeleteObject(Build.gameObject);
        }
	}

    public override void ClickAction(int value, I_Resource res)
    {
        value = CheckTreeCapacity(value);

        ObjectPool ObjectPooling = pManager.getObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setText("x" + value.ToString());
        ((Tree)Build).Capacity.subCapacty(value);

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionSpecial(int value, Sprite sprite, I_Resource res)
    {
        value = CheckTreeCapacity(value);

        ObjectPool ObjectPooling = pManager.getSpecialObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());
        ((Tree)Build).Capacity.subCapacty(value);

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionCric(int value, Sprite sprite, I_Resource res)
    {
        value = CheckTreeCapacity(value);

        ObjectPool ObjectPooling = pManager.getCricObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());
        ((Tree)Build).Capacity.subCapacty(value);

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void InitializeObjectPool(Sprite sprite)
    {
        pManager.getObjectPool();

        ObjectPool[] ObjectPooling = new ObjectPool[pManager.getPoolingList().Length - 1];
        ObjectPooling = pManager.getPoolingList();

        for(int i = 0; i < ObjectPooling.Length; i++)
        {
            ObjectPooling[i].setTexture(sprite);
        }
    }

    public override void BackToMap()
    {
       // button.onClick.Invoke();
        base.BackToMap();
        
    }

    private int CheckTreeCapacity(int Value)
    {
        if( ((Tree)Build).Capacity.get() - Value  <= 0 )
        {
            int tmp;
            tmp = Value - ((Tree)Build).Capacity.get();

            Value = Value - tmp;
        }

        return Value;
    }

}
