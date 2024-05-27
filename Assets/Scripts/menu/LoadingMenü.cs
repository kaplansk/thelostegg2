
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingMenü : MonoBehaviour
{
    private Tween typeWriter;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float typeSpeed;

    [SerializeField] private string storyText;

 

    private void OnEnable()
    {
        StartCoroutine(LoadLevelAsync("AnaSahne1"));
        StoryText(storyText);
    }
    private void StoryText(string content)
    {
        string text1 = "";

        typeWriter = DOTween.To(() => text1, x => text1 = x, content, content.Length / typeSpeed).OnUpdate(() =>
        {
            text.SetText(text1);

        });


    }


    IEnumerator LoadLevelAsync(string levelToLoad)
    {

        yield return new WaitForSeconds(37f);
        AsyncOperation loadoperation = SceneManager.LoadSceneAsync(levelToLoad);

       
    }
}
