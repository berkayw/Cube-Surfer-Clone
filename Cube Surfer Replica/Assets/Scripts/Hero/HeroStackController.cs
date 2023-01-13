using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    public List<GameObject> cubeList = new List<GameObject>();
    private GameObject lastCubeObject;


    void Start()
    {
        UpdateLastCubeObject();
    }

    public void StackCubes(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z); //+2f y to hero for adding new cube
        _gameObject.transform.position = new Vector3(lastCubeObject.transform.position.x, lastCubeObject.transform.position.y - 2f, lastCubeObject.transform.position.z); //Add cube to last cube's -2f y
        _gameObject.transform.SetParent(transform); //Stack cube to hero
        cubeList.Add(_gameObject);
        UpdateLastCubeObject();
    }

    public void UnstackCubes(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        cubeList.Remove(_gameObject);
        UpdateLastCubeObject();

    }

    private void UpdateLastCubeObject()
    {
        lastCubeObject = cubeList[cubeList.Count - 1];
    }
}