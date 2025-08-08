using UnityEngine;

public class LoofahScript : MonoBehaviour
{
    [SerializeField] FaceScript face;
    public void OnMouseDown()
    {
        face.toDefault();
    }
}
