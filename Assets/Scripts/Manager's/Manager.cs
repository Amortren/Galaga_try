using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Text txtHP;
    [SerializeField]
    private Text txtScore;
    private int Lives;
    private int score;
    private UnitSpawner unit;




    void Start()
    {
        Lives = 3;
        score = 0;
        txtScore.text = "Score " + score;
        txtHP.text = Lives + " HP";
    }

    
    void Update()
    {
        if (Lives == 0)
        {
            SceneManager.LoadScene(2);

        }
        
    }


    public void plusScore(int i)
    {
        score += i;
        txtScore.text = "Score " + score;
        
    }

    public void minusLives()
    {
        Lives -= 1;
        txtHP.text = Lives + " HP";
    } 
}
