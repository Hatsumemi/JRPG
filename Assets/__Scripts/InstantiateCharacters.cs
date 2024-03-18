using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InstantiateCharacters : MonoBehaviour
{
    public List<GameObject> PrefabsChara = new List<GameObject>();
    public List<GameObject> PrefabsEnemies = new List<GameObject>();
    public GameObject[] PositionChars = new GameObject[2];
    public GameObject PositionEnemy;
    public GameObject ParentCharacters;
    public GameObject ParentEnemies;
    public GameObject EnemyHere;

    private GameObject[] _characters = new GameObject[2];

    void Start()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            int nb = 1 + i;
            string nbStr = "char0" + nb.ToString();
            _characters[i] = Instantiate(GetPrefab(PlayerPrefs.GetString(nbStr)),ParentCharacters.transform);
            _characters[i].transform.position = PositionChars[i].transform.position;
        }

        EnemyHere = Instantiate(GetPrefabEnemy(PlayerPrefs.GetString("Enemy")), ParentEnemies.transform);
        EnemyHere.transform.position = PositionEnemy.transform.position;
        EnemyHere.GetComponent<Enemy>().InstantiateCharacters = this;
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

    private GameObject GetPrefabEnemy(string prefabName)
    {
        foreach (var prefab in PrefabsEnemies)
        {
            if (prefab.name == prefabName)
                return prefab;
        }

        return null;
    }

}