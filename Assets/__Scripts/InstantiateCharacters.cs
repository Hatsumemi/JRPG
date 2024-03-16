using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InstantiateCharacters : MonoBehaviour
{
    public List<GameObject> PrefabsChara = new List<GameObject>();
    public List<GameObject> PrefabsEnnemies = new List<GameObject>();
    public GameObject[] PositionChars = new GameObject[2];
    public GameObject PositionEnemy;

    private GameObject[] _characters = new GameObject[2];


    void Start()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            int nb = 1 + i;
            string nbStr = "char0" + nb.ToString();
            _characters[i] = Instantiate(GetPrefab(PlayerPrefs.GetString(nbStr)));
            _characters[i].transform.position = PositionChars[i].transform.position;
        }

        GameObject enemy = Instantiate(PrefabsEnnemies[0]);
        enemy.transform.position = PositionEnemy.transform.position;
    }

    private GameObject GetPrefab(string prefabName)
    {
        foreach (var prefab in PrefabsChara)
        {
            if (prefab.name == prefabName)
                return prefab;
        }

        return null;
    }
}