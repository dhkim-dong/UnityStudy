using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject gameOverPanel;
    public GameObject bombGenerator;
    public GameObject levelTxt;

    public Text scoreTxt;
    private float score;
    public float scoreValue;

    bool level1;

    private void Update()
    {
        score += scoreValue * Time.deltaTime;

        scoreTxt.text = string.Format("Score : {0:0}", score);

        if(player.transform.GetComponent<RobotPlayer>().curHp == 0)
        {
            bombGenerator.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        StageLevelUp();
    }

    public void GameReStart()
    {
        SceneManager.LoadScene("RobotBomb");
    }

    public void StageLevelUp()
    {
        if(score >= 20 && !level1)
        {
            Debug.Log("레벨이 증가하였습니다.");
            levelTxt.SetActive(true);
            level1 = true;
            bombGenerator.transform.GetComponent<BombGenerator>().interval -= 0.2f;
            Invoke("StageTxtOut", 1f);
        }
    }

    public void StageTxtOut()
    {
        levelTxt.SetActive(false);
    }
}
