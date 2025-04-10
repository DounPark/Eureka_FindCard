using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAnim : MonoBehaviour
{
    float time = 0;
    Text targetText;    // 텍스트 컴포넌트
    Image targetImage;  // 이미지 컴포넌트
    SpriteRenderer targetspriteRenderer;

    void Awake()
    {
        // 컴포넌트 자동 탐지
        targetText = GetComponent<Text>();
        targetImage = GetComponent<Image>();
        targetspriteRenderer = GetComponent<SpriteRenderer>();

        // 시작 시 알파값 0으로 초기화 (RGB는 유지)
        if(targetText != null) 
            targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 0);
            
        if(targetImage != null)
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0);
        if(targetspriteRenderer != null)
            targetspriteRenderer.color = new Color(targetspriteRenderer.color.r, targetspriteRenderer.color.g, targetspriteRenderer.color.b, 0);
    }

    void OnEnable()
    {
        time = 0; // 활성화될 때 시간 초기화
    }

    void Update()
    {
        if (time < 3f)
        {
            float alpha = Mathf.Clamp01(time / 3f); // 투명도 계산 (0~1)
            
            // 텍스트가 있으면 적용 (RGB는 유지, 알파만 변경)
            if(targetText != null) 
            {
                Color currentColor = targetText.color;
                targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }
                
            // 이미지가 있으면 적용 (RGB는 유지, 알파만 변경)
            if(targetImage != null)
            {
                Color currentColor = targetImage.color;
                targetImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }
            if(targetspriteRenderer != null)
            {
                Color currentColor = targetspriteRenderer.color;
                targetspriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }
        }
        time += Time.deltaTime;
    }

    public void ResetAnim()
    {
        // 초기화 시 투명도 0으로 설정 (RGB는 유지)
        if(targetText != null)
        {
            Color currentColor = targetText.color;
            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        }
            
        if(targetImage != null)
        {
            Color currentColor = targetImage.color;
            targetImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        }
        if(targetspriteRenderer != null)
        {
            Color currentColor = targetspriteRenderer.color;
            targetspriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        }
            
        time = 0;
    }
}
