using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//:) This script is responsible for:
public class SetLegoBlocksPositions : MonoBehaviour
{
    private Vector3 postionThatIsVeryFarAway = new Vector3 (9999,0,0);
    private StringToVector3Converter _converter;
    public List<GameObject> legoBlocks = new List<GameObject>();
    public List<Material> materials;

    void Start()
    {
        _converter = GetComponent<StringToVector3Converter>();
        InstantiateBlocks(300);
    }

    void Update()
    {
        ResetBlockPositions();
        if (_converter.coordinates.Count > 0)
        {
            SetBlocksAtPositions();
            SetColourAtPositions();
        }
    }

    private void SetBlocksAtPositions()
    {

        for(int i = 0; i < _converter.coordinates.Count; i++)
        {
            legoBlocks[i].transform.position = _converter.coordinates[i];
        }
    }

    private void SetColourAtPositions()
    {
        for (int i = 0; i < _converter.coordinates.Count; i++)
        {
            if(_converter.coordinates[i].y == 0)
            materials[i].color = Color.yellow;
            else if (_converter.coordinates[i].y == 1)
                materials[i].color = Color.blue;
            else if (_converter.coordinates[i].y == 2)
                materials[i].color = Color.red;
        }
    }

    private void InstantiateBlocks(int num)
    {
            for (int i = 0; i < num; i++)
        {
            GameObject legoBlock = Instantiate(Resources.Load("LegoBlock"), postionThatIsVeryFarAway, Quaternion.identity) as GameObject;
            legoBlocks.Add(legoBlock);
            materials.Add(legoBlock.GetComponent<Renderer>().material);
        }
    }
    private void ResetBlockPositions()
    {
        foreach (GameObject legoBlock in legoBlocks)
            legoBlock.transform.position = postionThatIsVeryFarAway;
    }
}
