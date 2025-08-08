using UnityEngine;

//Скрипт отслеживает нажатие на паллетку и передает нужную позицию и цвет кисточке
public class PalleteScript : MonoBehaviour
{
    [SerializeField] BlushScript blush;
    [SerializeField] int tipeBlush;
    
    public void OnMouseDown()
    {
        Vector2 pos = transform.position;
        pos.y -= 1f;
        blush.activateBlush(pos, tipeBlush);
    }
}
