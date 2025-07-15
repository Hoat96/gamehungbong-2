using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gamewinText;
    public List<GameObject> targets;
    public Button restartButton;
    
    public GameObject titleScreen;
    private float spawnRate = 2.0f;
    public bool isGameActive;

    private int scoreToWin; // lưu mốc điểm thắng
    
    private bool hasWin = false;// Biến để kiểm tra đã thắng chưa




   
    public void StartGame(int difficulty)
    {

        isGameActive = true;
        score = 0;
        // switch-case thiết lập game dựa trên độ khó
        switch (difficulty)
        {
            case 1:// Dễ
                scoreToWin = 400;
                spawnRate = 1.5f;
                break;
            case 2:// trung binh
                scoreToWin = 300;
                spawnRate = 1.0f;
                break;
            case 3:// kho
                scoreToWin = 200;
                spawnRate = 0.75f;
                break;
            default: // Mặc định nếu có lỗi
                scoreToWin = 200;
                spawnRate = 1.0f;
                break;
        }
       
        StartCoroutine(SpawnTarget());
     
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        

    }
    IEnumerator SpawnTarget()
    {
        
        while(isGameActive)
        {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
        }
        


    }
    public void UpdateScore(int scoreToAdd)
    {
        if (!isGameActive) return;

        score += scoreToAdd;
        scoreText.text = "Score:" + score;
        // Kiểm tra điều kiện thắng ngay sau khi cập nhật điểm
        if (score >= scoreToWin)
        {
            GameWin();
        }

    }
    public void GameOver()
    {
        //  Kiểm tra xem người chơi đã thắng chưa. Nếu đã thắng thì không làm gì cả.
        if (hasWin)
        {
            return; // Thoát khỏi hàm GameOver ngay lập tức
        }
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GameWin()
    {
        
        gamewinText.gameObject.SetActive(true); // Hiển thị text chiến thắng
        restartButton.gameObject.SetActive(true);
       
        hasWin = true; // Đánh dấu là đã thắng
        isGameActive = false; // Dừng game
       
    }


}
