using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinerScene : ClickerScene
{
    public ExperinceGUI ExperinceBar;

    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;

        ExperinceBar.Update(Profil.exp.Experince, Profil.exp.NextLevelExperince, Profil.exp.Level);

    }

	// Update is called once per frame
	void Update () {
       
	}

    public override void ClickAction(int value, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setText("x" + value.ToString());

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
        AddExperince(1);
    }

    public override void ClickActionSpecial(int value, Sprite sprite, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getSpecialObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

        res.add(value);
        
        ObjectPooling.gameObject.SetActive(true);
        AddExperince(1);
    }

    public override void ClickActionCric(int value, Sprite sprite, I_Resource res)
    {
        ObjectPool ObjectPooling = pManager.getCricObjectPool();
        ObjectPooling.SetPosition(GenerateNewPosition());
        ObjectPooling.setTexture(sprite);
        ObjectPooling.setText("x" + value.ToString());

        res.add(value);

        ObjectPooling.gameObject.SetActive(true);
        AddExperince(1);
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
        base.BackToMap();
        ExperinceBar.gameObject.SetActive(false);
    }

    private void AddExperince(float exp)
    {
        Profil.exp.addExperince(exp);
        ExperinceBar.Update(Profil.exp.Experince, Profil.exp.NextLevelExperince, Profil.exp.Level);
    }
}
