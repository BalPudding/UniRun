using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; //생성할 발판의 원본 프리팹
    public int count = 3; //생성할 발판 수

    public float timeBetSpawnMin = 1.25f; //다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; //다음 배치까지의 시간 간격 최댓값
    private float timeBetSpawn; //다음 배치까지의 시간 간격

    public float yMin = -3.5f; //배치할 위치의 최소 y 값
    public float yMax = 1.5f; //배치할 위치의 최대 y 값
    private float xPos = 20f; //배치할 위치의 x 값

    private GameObject[] platforms; //미리 생성한 발판들
    private int currentIndex = 0; //사용할 현재 순번의 발판

    //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime; //마지막 배치 시점

    // Start is called before the first frame update
    void Start()
    //변수를 초기화하고 사용할 발판을 미리 생성
    {
        
    }

    // Update is called once per frame
    void Update()
    //순서를 돌아가며 주기적으로 발판을 배치
    {
        
    }
}
