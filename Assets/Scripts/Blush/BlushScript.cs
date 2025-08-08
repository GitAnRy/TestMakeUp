using UnityEngine;

//Скрипт управляет поведением кисточки
//запускает анимации и взаимодействует с пользователем
public class BlushScript : MonoBehaviour
{
    //позиция по умолчанию
    private Vector2 fromPosition; 
    //позиция возле лица
    [SerializeField] Vector2 toPosition;
    //позиция теней
    private Vector2 blushPosition;
    [SerializeField] HandScript hand;
    [SerializeField] AttachScript attach;

    public int tipeBlush { get; private set; } = 0;

    private void Start()
    {
        fromPosition = transform.position;
    }

    //запускаем анимацию и перемещаем руку к кисточке
    public void activateBlush(Vector2 pos, int tipeBlush)
    {
        this.tipeBlush = tipeBlush;
        blushPosition = pos;
        hand.moveTo(fromPosition, moveToBlush);
    }

    //прикрепляем кисточку к руке и перемещаемся к теням
    private void moveToBlush()
    {
        attach.attach(hand.transform);
        hand.moveTo(blushPosition, startAnimationBlush);
    }

    //запускаем анимацию для окрашивания кисточки
    private void startAnimationBlush()
    {
        hand.startAnimationX(moveToDrag);
    }

    //перемещаем кисточку к лицу и ожидаем действий пользователя
    private void moveToDrag()
    {
        hand.moveToDrag(toPosition, moveToDefaul);
    }

    //возвращаем кисточку на место
    private void moveToDefaul()
    {
        hand.moveTo(fromPosition, cancelAnimate);
    }

    //завершаем анимацию
    private void cancelAnimate()
    {
        attach.clear();
        hand.toDefault();
        transform.position = fromPosition;
    }
}
