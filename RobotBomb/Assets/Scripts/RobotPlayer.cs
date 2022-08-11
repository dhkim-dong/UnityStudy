using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotPlayer : MonoBehaviour
{
    public float maxHp;
    public float curHp;
    public Image hpBar;
    bool isHit;

    private void Start()
    {
        maxHp = 10;
        curHp = maxHp;
    }

    private void Update()
    {
        OnShowPlayerHPSlider();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bomb") && !isHit)
        {
            isHit = true;
            curHp--;
            Invoke("HitOut", 0.1f);           
        }
    }

    public void HitOut()
    {
        isHit = false;
    }

    public void OnShowPlayerHPSlider()
    {
        hpBar.fillAmount = curHp / maxHp;
    }
}
