using UnityEngine;
using System.Collections;

public abstract class DataPacker : MonoBehaviour {

    public abstract object Unpack(object ob, object Data);
    public abstract string Pack(object ob);
}
