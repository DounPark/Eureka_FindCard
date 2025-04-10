using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Board : MonoBehaviour
{
    public GameObject card;
    public float spreadTime = 0.5f; // 카드 펼쳐지는 시간
    public Vector2 startPosition = new Vector2(0, 0); // 시작 위치(중앙)

    void Start()
    {
        // 카드 배열 생성 및 셔플 (기존과 동일)
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();
        
        // 카드 생성 코루틴 시작 (배열 전달)
        StartCoroutine(SpreadCards(arr));
        
        GameManager.Instance.cardCount = arr.Length;
    }

    IEnumerator SpreadCards(int[] cardArray)
    {
        for(int i = 0; i < cardArray.Length; i++)
        {
            GameObject go = Instantiate(card, startPosition, Quaternion.identity, this.transform);
            
            // 카드 타입 설정 (이 부분이 누락되었었음)
            go.GetComponent<Card>().Setting(cardArray[i]);
            
            // 목표 위치 계산
            float targetX = ((i % 4) * 1.4f) - 2.1f;
            float targetY = ((i / 4) * 1.4f) - 3.2f;
            Vector2 targetPos = new Vector2(targetX, targetY);
        
            // 이동 애니메이션 시작
            StartCoroutine(MoveCard(go.transform, targetPos));
            yield return new WaitForSeconds(0.01f); // 카드 간 간격
        }
    }

    IEnumerator MoveCard(Transform card, Vector2 targetPos)
    {
        float timer = 0;
        Vector2 startPos = card.position;
    
        while(timer < spreadTime)
        {
            timer += Time.deltaTime;
            card.position = Vector2.Lerp(startPos, targetPos, timer/spreadTime);
            yield return null;
        }
        card.position = targetPos; // 정확한 위치 보정
    }
}
