using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] Text bulletTxt;

    private void Awake()
    {
        gameManager = this;
    }

    public static void UpdateBulletTxt(int amountBullet,int maxBullet)
    {
        gameManager.bulletTxt.text = amountBullet + "/" + maxBullet;
    }
}
