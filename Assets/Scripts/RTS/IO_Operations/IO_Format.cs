using UnityEngine;
using System.Collections;

public enum Format
{
    SIMPLE,
    STRING,
    BUILDING_GROUP,
    BUILDING,
    PROFIL,


};

public class IO_Format : MonoBehaviour {

    public Format format;
    public Object Data;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public string GetData()
    {
        if (format == null)
        {
            Debug.LogError("NullPointer : format");
            return null;
        }

        switch (format)
        {
            case Format.SIMPLE:
                return new SimpleDataPacker().Pack(Data);

            case Format.STRING:
                return new StringDataPacker().Pack(Data);
            case Format.BUILDING_GROUP:
                return new BuildingGroupDataPacker().Pack(Data);
            case Format.BUILDING:
                return new BuildingDataPacker().Pack(Data);
            case Format.PROFIL:
                return new ProfilDataPacker().Pack(Data);

            default:
                Debug.LogError("Not Know Value");
                return null;
        }
    }

    public bool setData(string _Data)
    {

        if (format == null)
        {
            Debug.LogError("NullPointer : format");
            return false;
        }

        switch (format)
        {
            case Format.SIMPLE:
                SimpleData simpledata  = (SimpleData) new SimpleDataPacker().Unpack(_Data, Data);
                return true;
                break;

            case Format.STRING:
                StringData stringdata = (StringData)new StringDataPacker().Unpack(_Data, Data);
                return true;
                break;

            case Format.BUILDING_GROUP:
                new BuildingGroupDataPacker().Unpack(_Data, Data);
                return true;
                break;

            case Format.BUILDING:
                new BuildingDataPacker().Unpack(_Data, Data);
                return true;
                break;

            case Format.PROFIL:
                new ProfilDataPacker().Unpack(_Data, Data);
                return true;
                break;

            default:
                return false;
        }
    }

}
