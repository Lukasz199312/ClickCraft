using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LumbermillScene : ClickerScene
{
    public DisplayTimer Timer;

	// Update is called once per frame
	void Update () {
        Timer.TimetText.text = _Resources[0].getValue().ToString();
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

    public override void BackToMap()
    {
       // button.onClick.Invoke();
        base.BackToMap();
        
    }

    private void CheckTreeCapacity()
    {
       // if( ((Tree)Build).subCapacty )
    }


    public override void InitializeResource()
    {
        Profil.Resources = new I_Resource[1];
        Profil.Resources[0] = ((Tree)Build).Capacity;
    }
}
