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
        if(AudioManager.Instance != null)
        {
            Destroy(AudioManager.Instance.gameObject); // ✅ 기존 매니저 파괴
        }
        SceneManager.LoadSceneAsync(targetScene);
        AudioManager.Instance?.GetComponent<AudioSource>().Play(); // ✅ 새 인스턴스 재생
    }
}
