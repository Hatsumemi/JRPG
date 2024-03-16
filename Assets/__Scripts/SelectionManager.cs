using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get { return _instance; } }
    private static SelectionManager _instance;
    
    public Material OutlineMaterial, DefaultMaterial;
    public GameUI UI;
    public SelectionMode CurrentSelectionMode;
    public List<SelectionInstructions> SelectionInstructionsTexts;
    
    private Character _selectedCharacter;
    private string _attackType;
    private void Awake()
    {
        if (_instance == null) _instance = this;
        
    }

    public void Update()
    {
        if (_selectedCharacter == null && !UI.InstructionText.gameObject.activeSelf)
        {
            UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
        }
        if (CurrentSelectionMode != SelectionMode.EnemyTurn && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                if (!hit.collider.TryGetComponent<Character>(out var character)) return;

                Debug.Log($"Character target {character.name} ");

                Debug.Log($"CurrentSelectionMode {CurrentSelectionMode}  ");

                if (CurrentSelectionMode == SelectionMode.EnemyToAttack)
                {
                    if (_selectedCharacter is Ally)
                    {
                        if (_attackType == "Attack")
                            _selectedCharacter.Attack(character);
                        else if (_attackType == "SpecialAttack")
                            _selectedCharacter.SpecialAttack(character);
                        else if (_attackType == "Ulti")
                            _selectedCharacter.Ulti(character);
                    }
                }
                SelectCharacter(character);
            }
        }
    }

    private string GetSelectionInstructionsText(SelectionMode selectionMode)
    {
        string result = "";
        foreach (SelectionInstructions instruction in SelectionInstructionsTexts)
        {
            if (instruction.SelectionMode == selectionMode) result += $"{instruction.SelectionInstructionsText}\n";
        }
        return result;
    }

    private void SelectCharacter<T>(T character) where T : Character
    {
        CurrentSelectionMode = SelectionMode.Default;
        if (_selectedCharacter != null) _selectedCharacter.Visual.material = DefaultMaterial;
        _selectedCharacter = character;
        _selectedCharacter.Visual.material = OutlineMaterial;
        UI.UpdateUI(_selectedCharacter);
    }

    public void SetAttackMode()
    {
        if (_selectedCharacter == null || _selectedCharacter.GetType() == typeof(Enemy)) return;

        Debug.Log("SetAttackMode");

        _attackType = "Attack";
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }

    public void SetSpecialAttackMode()
    {
        if (_selectedCharacter == null || _selectedCharacter.GetType() == typeof(Enemy)) return;

        Debug.Log("SetSpecialAttackMode");

        _attackType= "SpecialAttack";
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }
    
    public void SetUltiMode()
    {
        if (_selectedCharacter == null || _selectedCharacter.GetType() == typeof(Enemy)) return;

        Debug.Log("SetUltiMode");

        _attackType = "Ulti";
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }

    public void EscapeBattle()
    {
        if (_selectedCharacter == null) return;
        SceneManager.LoadScene(0);
    }
}
