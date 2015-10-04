using UnityEngine;
using System.Collections;

public abstract class DataPacker : MonoBehaviour {

    public abstract object Unpack(object ob);
    public abstract string Pack(object ob);
}
