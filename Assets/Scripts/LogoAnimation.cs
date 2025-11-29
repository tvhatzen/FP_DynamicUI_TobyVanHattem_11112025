using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoAnimationPlayer : MonoBehaviour
{
    [Header("Set this to the UI Image that will animate")]
    public Image animatedImage;

    [Header("Drop your 24 sprites here, in order")]
    public Sprite[] frames;

    [Header("Frame rate (frames per second)")]
    public float fps = 12f;

    [Header("Delay between each animation cycle")]
    public float delay = 4f;

    private void Start()
    {
        animatedImage.enabled = false;
        StartCoroutine(PlayLoop());
    }

    private IEnumerator PlayLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            yield return StartCoroutine(PlayAnimation());
        }
    }

    private IEnumerator PlayAnimation()
    {
        animatedImage.enabled = true;

        float frameTime = 1f / fps;

        for (int i = 0; i < frames.Length; i++)
        {
            animatedImage.sprite = frames[i];
            yield return new WaitForSeconds(frameTime);
        }

        animatedImage.enabled = false;
    }
}