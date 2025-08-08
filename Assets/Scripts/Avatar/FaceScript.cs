using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

//скрипт управляет поведением лица
//отслеживает вхождение в колайдер различных обьектов, и в зависимости от тригеров и 
//других параметров меняет свое поведение.
public class FaceScript : MonoBehaviour
{

    [SerializeField] GameObject acne;
    [SerializeField] GameObject blush;
    [SerializeField] SpriteRenderer blushRender;
    [SerializeField] Sprite[] blushSprites;

    [SerializeField] GameObject lipstick;
    [SerializeField] SpriteRenderer lipstickhRender;
    [SerializeField] Sprite[] lipstickSprites;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Color color = Color.white;
        color.a = 0f;

        switch (other.gameObject.tag) {

            case "Cream":
                acne.SetActive(false);
                break;

            case "Blush":
                int tipeBlush = other.GetComponent<BlushScript>().tipeBlush;
                blushRender.color = color;
                blushRender.sprite = blushSprites[tipeBlush];
                StartCoroutine(Animate(blushRender));
                break;

            case "Lipstick":
                int tipeLipstick = other.GetComponent<LipstickScript>().tipeLipstick;
                lipstickhRender.color = color;
                lipstickhRender.sprite = lipstickSprites[tipeLipstick];
                StartCoroutine(Animate(lipstickhRender));
                break;

        }
    }

    private IEnumerator Animate(SpriteRenderer render)
    {
        float elapsed = 0f;
        float duration = 0.15f;

        Color color = render.color;

        while (elapsed < duration)
        {
            color.a = elapsed / duration;
            render.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 1;
        render.color = color;
    }

    public void toDefault()
    {
        acne.SetActive(true);
        blushRender.sprite = null;
        blushRender.color = Color.white;
        lipstickhRender.sprite = null;
        lipstickhRender.color = Color.white;
    }

}
