using UnityEngine;
using static BookScript;

public class TabScript : MonoBehaviour
{
    
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite[] spriteArray;
    [SerializeField] bool choose = false;
    [SerializeField] TipesPage tipePage = 0;
    private Vector2 posDefault;

    ChoosePageInterface pageInterface;

    void Start()
    {
        posDefault = transform.localPosition;
        chooseTab(choose);
    }

    public void OnMouseDown()
    {
        if (choose)
            return;

        chooseTab(!choose);
        pageInterface.chooseTab(tipePage);
    }

    public void chooseTab(bool usl)
    {
        choose = usl;
        sprite.sprite = spriteArray[(choose) ? 0 : 1];
        transform.localPosition = new Vector2(posDefault.x, (choose) ? 6.1f : 6);
    }

    public void setChoosePageInterface(ChoosePageInterface i)
    {
        pageInterface = i;
    }
}
