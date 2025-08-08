using UnityEngine;

public class BookScript : MonoBehaviour, ChoosePageInterface
{
    public enum TipesPage : int
    {
        Powder,
        Blush,
        Lipstick,
        Eye,
    }

    private TipesPage currentPage = TipesPage.Blush;

    [SerializeField] TabScript[] tabs;
    [SerializeField] GameObject[] pages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in tabs)
        {
            item.setChoosePageInterface(this);
        }
    }

    public void chooseTab(TipesPage tipe)
    {
        tabs[(int) currentPage].chooseTab(false);
        pages[(int)currentPage].SetActive(false);
        currentPage = tipe;
        pages[(int)currentPage].SetActive(true);

    }
}
