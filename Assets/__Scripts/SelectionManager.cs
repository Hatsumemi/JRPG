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
    private Ally _selectedAttack;
    private AttackType _attackType;
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
                        switch (_attackType)
                        {
                            case AttackType.Attack:
                                _selectedCharacter.Attack(character);
                                break;
                            case AttackType.Freeze:
                                _selectedCharacter.Freeze(character);
                                break;
                            case AttackType.Regen:
                                _selectedCharacter.Regen(character);
                                break;
                            case AttackType.Critical:
                                _selectedCharacter.Critical(character);
                                break;
                            case AttackType.TwoPlay:
                                _selectedCharacter.TwoTimes(character);
                                break;
                            case AttackType.MinDamage:
                                _selectedCharacter.MinPV(character);
                                break;
                            case AttackType.SkipTurn:
                                _selectedCharacter.Skip(character);
                                break;
                            case AttackType.ConstantPV:
                                break;
                            case AttackType.AnimSpell:
                                _selectedCharacter.Ulti(character);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                       
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

        _attackType = _selectedCharacter.SpecialAttacks[0];
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }

    public void SetSpecialAttackMode()
    {
        if (_selectedCharacter == null || _selectedCharacter.GetType() == typeof(Enemy)) return;

        Debug.Log("SetSpecialAttackMode");

        _attackType = _selectedCharacter.SpecialAttacks[1];
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }
    
    public void SetUltiMode()
    {
        if (_selectedCharacter == null || _selectedCharacter.GetType() == typeof(Enemy)) return;

        Debug.Log("SetUltiMode");

        _attackType = _selectedCharacter.SpecialAttacks[2];
        CurrentSelectionMode = SelectionMode.EnemyToAttack;
        UI.UpdateUI(instructionText: GetSelectionInstructionsText(CurrentSelectionMode));
    }

    public void EscapeBattle()
    {
        if (_selectedCharacter == null) return;
        SceneManager.LoadScene(0);
    }
}
