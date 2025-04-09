using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 인스펙터에서 씬 이름 직접 입력
    [SerializeField] string targetScene = "EndScene";
    
    public void LoadTargetScene()
    {
        // 비동기 로딩 권장
        SceneManager.LoadSceneAsync(targetScene);
        
        // 로딩 확인용 디버그
        Debug.Log($"{targetScene} 씬 로딩 시작");
    }
}
