using System;
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
    public GameObject ParentCharacters;
    public GameObject ParentEnemies;
    public GameObject EnemyHere;
    public string EnemyName;

    private GameObject[] _characters = new GameObject[2];
    private Enemy _Enemy;
    private int _currentEnemy;

    void Start()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            int nb = 1 + i;
            string nbStr = "char0" + nb.ToString();
            _characters[i] = Instantiate(GetPrefab(PlayerPrefs.GetString(nbStr)),ParentCharacters.transform);
            _characters[i].transform.position = PositionChars[i].transform.position;
        }

        EnemyHere = Instantiate(PrefabsEnnemies[0], ParentEnemies.transform);
        EnemyName = EnemyHere.name;
        EnemyHere.transform.position = PositionEnemy.transform.position;
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
    
    public void ChangeEnemy()
    {
        _currentEnemy++;
        EnemyHere = Instantiate(PrefabsEnnemies[_currentEnemy]);
        EnemyHere.transform.position = PositionEnemy.transform.position;
        if (_currentEnemy == PrefabsEnnemies.Count)
            _currentEnemy = -1;
    }
}