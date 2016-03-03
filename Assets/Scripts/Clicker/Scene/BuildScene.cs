using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildScene : ClickerScene {

	// Update is called once per frame
	void Update () {
        
	}

    public override void ClickAction(int value)
    {
        ObjectPool ObjectPooling = pManager.getObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setText("x" + value.ToString());

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionSpecial(int value, Sprite sprite)
    {
        ObjectPool ObjectPooling = pManager.getSpecialObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionCric(int value, Sprite sprite)
    {
        ObjectPool ObjectPooling = pManager.getCricObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

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

}
