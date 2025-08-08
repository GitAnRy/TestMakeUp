using UnityEngine;

//Скрипт управляет поведением крема
//запускает анимации и взаимодействует с пользователем
public class CreamScript : MonoBehaviour
{
    private Vector2 fromPosition;
    [SerializeField] Vector2 toPosition;
    [SerializeField] HandScript hand;
    [SerializeField] AttachScript attach;
    
    private void Start()
    {
        fromPosition = transform.position;
    }

    public void OnMouseDown()
    {
        hand.moveTo(fromPosition, moveToDrag);
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
