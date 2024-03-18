using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using DG.Tweening;

public class ChoosingEnemy : MonoBehaviour
{
    public GameObject Enemy;

    public Sprite BoarImage;
    public Sprite DinoImage;
    public Sprite GhostImage;
    public Sprite SlimeImage;
    public Sprite GiantImage;

    public Image Fade;

    private string _choosed;



    private void Start()
    {
        Fade.DOFade(0, 1);
        StartCoroutine(WaitToChoose());
        _choosed = "Boar";

    }

    
    public void Validate()
    {
        PlayerPrefs.SetString("Enemy", _choosed);

        Fade.gameObject.SetActive(true);
        Fade.DOFade(1,1);
        StartCoroutine(WaitForStart());
    }

    public void Boar()
    {
        Enemy.gameObject.GetComponent<Image>().sprite = BoarImage;
        _choosed = "Boar";
        
    }

    public void Dino()
    {
        Enemy.gameObject.GetComponent<Image>().sprite = DinoImage;
        _choosed = "Dino";
        
    }

    public void Ghost()
    {
        Enemy.gameObject.GetComponent<Image>().sprite = GhostImage;
        _choosed = "Ghost";
        
    }

    public void Slime()
    {
        Enemy.gameObject.GetComponent<Image>().sprite = SlimeImage;
        _choosed = "Slime";
        
    }

    public void Giant()
    {
        Enemy.gameObject.GetComponent<Image>().sprite = GiantImage;
        _choosed = "Giant";
        
    }


    IEnumerator WaitToChoose()
    {
        yield return new WaitForSeconds(1);
        Fade.gameObject.SetActive(false);
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainGame");
    }
}
