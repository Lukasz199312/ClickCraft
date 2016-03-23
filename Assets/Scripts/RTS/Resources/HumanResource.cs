using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanResource : MonoBehaviour {

    public Text FieldText;

    [SerializeField]
    private static int Number = 0;
    private static int Max;

    public int Value;   //ToDelte
    void Start()
    {
        Debug.Log("DELETE START AND UPDATE!!!!!!!!!!!!!!!");
    }

    void Update()
    {
        FieldText.text = Number.ToString() + " / " + Max;
    }
    
    public static void add()
    {
        Number++;
 
    }

    public static void add(int Value)
    {
        Number += Value;
    }

    public static void sub()
    {
        Number--;
    }

    public static void sub(int Value)
    {
        Number -= Value;
    }

    public static int getCount()
    {
        return Number;
    }

    public static int getMax()
    {
        return Max;
    }

    public static void setMax(int Value)
    {
        Max = Value;
    }


}
