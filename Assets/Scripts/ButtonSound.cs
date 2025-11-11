using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Audio Settings")]
    public AudioSource audioSource;       // AudioSource to play sounds from
    public AudioClip hoverSound;          // Sound when the button is hovered
    public AudioClip clickSound;          // Sound when the button is clicked

    private void Reset()
    {
        // Auto-assign an AudioSource if one exists on the object
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlaySound(clickSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;

        audioSource.PlayOneShot(clip);
    }
}