using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildScene : ClickerScene {

    public DisplayTimer Timer;
    public SpriteRenderer Sprite;

	// Update is called once per frame
	void Update () {

        View.Fill();

        Timer.setTime(Build.InConstruction.span);
        if (Build.InConstruction.active == false)
        {
            button.onClick.Invoke();
        }
	}

    public override void ClickAction(int value, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setText("x" + value.ToString());

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionSpecial(int value, Sprite sprite, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getSpecialObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
    }

    public override void ClickActionCric(int value, Sprite sprite, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getCricObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

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

    public override void InitializeResource()
    {
        Profil.Resources = new I_Resource[1];
        Profil.Resources[0] = Build.InConstruction;

        Profil.Resources[0].setSprite(Sprite.sprite);
    }

}
