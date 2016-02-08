using UnityEngine;
using System.Collections;

public class PoolingManager : MonoBehaviour {

    public GameObject Source;
    public int count;

    private ObjectPool[] ObjectPooling = null;

	// Use this for initialization
	void Start () {
        ObjectPooling = new ObjectPool[count];

        for(int i=0; i < count; i++)
        {
            GameObject tmpobj = Instantiate(Source);
            tmpobj.transform.parent = this.transform;
            tmpobj.transform.position = this.transform.position;


            ObjectPooling[i] = tmpobj.transform.GetChild(0).GetComponent<ObjectPool>();
            ObjectPooling[i].gameObject.SetActive(false);

            RectTransform rec = ObjectPooling[i].gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
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
            return null;
        }
        return null;
    }


  
}
