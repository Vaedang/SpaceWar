using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    //UI
    public Text TxtScore;
    private int score;
    public GameObject pnlEndgame;
    public Button btnRestartGame;
    
    
    void Start()
    {
        
        score = 0;
        pnlEndgame.SetActive(false);
        UpdateScore();
        StartCoroutine(SpawnWaves());

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

    public void AddScore(int newScoreValue)
    {
        
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        TxtScore.text = score.ToString();
    }

     public void GameOver()
    {
        
        pnlEndgame.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

