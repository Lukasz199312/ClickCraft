using UnityEngine;
using System.Collections;

public abstract class DataPacker : MonoBehaviour {

    /// <summary>
    /// metoda wyloywana zwykle podczas wczytywania obiektu
    /// </summary>
    /// <param name="ob"></param>
    /// <param name="Data"></param>
    /// <returns></returns>
    public abstract object Unpack(object ob, object Data);
    /// <summary>
    /// metoda wyloywana zwykle podczas zapisywania obiektu
    /// </summary>
    /// <param name="ob"></param>
    /// <returns></returns>
    public abstract string Pack(object ob);
}
