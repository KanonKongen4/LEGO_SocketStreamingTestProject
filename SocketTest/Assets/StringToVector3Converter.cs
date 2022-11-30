using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//:) This script is responsible for:
public class StringToVector3Converter : MonoBehaviour
{
    private DataReceiver receiver;
    public List<string> vector3Strings;

    public List<Vector3> coordinates;
    void Start()
    {
        receiver = GetComponent<DataReceiver>();
    }
    void Update()
    {
        if (receiver.lastReceivedData.Length > 0)
            StringToVector3s(receiver.lastReceivedData);
    }
    private void StringToVector3s(string str)
    {
        coordinates.Clear();
        vector3Strings.Clear();

        string[] strs = str.Split(')');

        foreach (string s in strs)
            vector3Strings.Add(s);

        vector3Strings.RemoveAt(vector3Strings.Count - 1);//Remove last entry because it is empty

        List<string> newList = new List<string>();

        for (int i = 0; i < vector3Strings.Count; i++)
        {
            string newString = vector3Strings[i].Remove(0, 2);
            if (i != 0)
                newString = newString.Remove(0, 1);
            newList.Add(newString);
        }

        vector3Strings = newList;

        foreach (string s in vector3Strings)
        {
            coordinates.Add(StringToVector3(s));
        }
    }

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
}
