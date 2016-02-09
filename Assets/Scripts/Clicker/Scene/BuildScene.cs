using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildScene : ClickerScene {

    public Sprite res;

	
	// Update is called once per frame
	void Update () {

	}

    public override void ClickAction()
    {
        ObjectPool ObjectPooling = pManager.getObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.gameObject.SetActive(true);
    }

    public override void InitializeObjectPool()
    {
        pManager.getObjectPool();

        ObjectPool[] ObjectPooling = new ObjectPool[pManager.getPoolingList().Length - 1];
        ObjectPooling = pManager.getPoolingList();

        for(int i = 0; i < ObjectPooling.Length; i++)
        {
            ObjectPooling[i].setTexture(res);
        }
    }
}
