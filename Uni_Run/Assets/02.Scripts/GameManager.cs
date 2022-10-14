using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// ���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public Text scoreText; // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUi; // ���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ
    public GameObject pauseUi;
    private bool pause = false;
    public GameObject[] lifes;

    private int score = 0; // ���� ����


    // ���� ���۰� ���ÿ� �̱����� ����
    // Start is called before the first frame update
    void Awake()
    {
        // �̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            // instance�� ��� �ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���

            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // ���ӿ��� ���¿��� ������ ������� �� �ְ� �ϴ� ó��
        if (pause == false && Input.GetKeyDown(KeyCode.Escape) && !isGameover)
        {
            pauseUi.SetActive(true);
            pause = true;
            Time.timeScale = 0f;
        }
        else if (pause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUi.SetActive(false);
            pause = false;
            Time.timeScale = 1f;
        }

        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        int hs = GameObject.Find("Player").GetComponent<PlayerController>().health;
        for (int i = 0; i < lifes.Length; i++)
        {
            this.lifes[i].SetActive(false);
        }
        for (int i = 0; i < hs; i++)
            this.lifes[i].SetActive(true);
    }

    // ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        if(!isGameover)
        {
            // ������ ����
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    // �÷��̾� ��� �� ���ӿ����� �����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUi.SetActive(true);
    }
}
