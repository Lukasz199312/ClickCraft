using UnityEngine;
using System.Collections;

public class PoolingManager : MonoBehaviour {

    public GameObject Source;
    public int count;
    public int SpecialCount;
    public Canvas canvas;

    private ObjectPool[] ObjectPooling = null;
    private ObjectPool[] SpecialBojectPooling = null;

	// Use this for initialization
	void Start () {
        ObjectPooling = new ObjectPool[count];
        SpecialBojectPooling = new ObjectPool[SpecialCount];

        for(int i=0; i < count; i++)
        {
            GameObject tmpobj = Instantiate(Source);
            tmpobj.transform.parent = this.transform;
            tmpobj.transform.position = this.transform.position;

            //To DELETE

            RectTransform rectest = tmpobj.GetComponent<RectTransform>();
           

            //rectest.position = rectest.TransformPoint(new Vector3(-100, 200, 300));
            //Debug.Log("************* "+rectest.position);


            ObjectPooling[i] = tmpobj.transform.GetChild(0).GetComponent<ObjectPool>();
            ObjectPooling[i].gameObject.SetActive(false);


            RectTransform rec = ObjectPooling[i].gameObject.transform.parent.gameObject.GetComponent<RectTransform>();

            rec.offsetMin = new Vector2(0, 0);
            rec.offsetMax = new Vector2(0, 0);

        }

        for(int i=0; i < SpecialCount; i++)
        {
            GameObject tmpobj = Instantiate(Source);
            tmpobj.transform.parent = this.transform;
            tmpobj.transform.position = this.transform.position;


            SpecialBojectPooling[i] = tmpobj.transform.GetChild(0).GetComponent<ObjectPool>();
            SpecialBojectPooling[i].gameObject.SetActive(false);



            RectTransform rec = SpecialBojectPooling[i].gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
            rec.offsetMin = new Vector2(0, 0);
            rec.offsetMax = new Vector2(0, 0);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public ObjectPool getObjectPool()
    {
        for(int i = 0; i < count; i++)
        {
            if (ObjectPooling[i].gameObject.activeInHierarchy == false) return ObjectPooling[i];
        }
        return ObjectPooling[0];
    }

    public ObjectPool[] getPoolingList()
    {
        return this.ObjectPooling;
    }

  
}
