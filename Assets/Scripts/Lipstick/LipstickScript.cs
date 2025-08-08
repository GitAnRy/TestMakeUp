using UnityEngine;

//Скрипт управляет поведением помады
//запускает анимации и взаимодействует с пользователем
public class LipstickScript : MonoBehaviour
{
    private Vector2 fromPosition;
    [SerializeField] Vector2 toPosition;
    [SerializeField] HandScript hand;
    [SerializeField] AttachScript attach;
    public int tipeLipstick = 0;

    private void Start()
    {
        fromPosition = transform.position;
    }

    public void OnMouseDown()
    {
        Vector2 pos = fromPosition;
        pos.y -= 0.5f;
        hand.moveTo(pos, moveToDrag);
    }

    private void moveToDrag()
    {
        attach.attach(hand.transform);
        hand.moveToDrag(toPosition, moveToDefaul);
    }

    private void moveToDefaul()
    {
        hand.moveTo(fromPosition, cancelAnimate);
    }

    private void cancelAnimate()
    {
        attach.clear();
        hand.toDefault();
        transform.position = fromPosition;
    }
}
