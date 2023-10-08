using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ChickenSelection : MonoBehaviour
{
    [Header ("Navigation Buttons")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text priceText;

    [Header("Chicken Attributes")]
    [SerializeField] private int[] chickenPrices;
    private int currentChicken;

    [Header("Sound")]
    [SerializeField] private AudioClip purchase;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        currentChicken = SaveManager.instance.currentChicken;
        SelectCar(currentChicken);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        //If current car unlocked show the play button
        if (SaveManager.instance.chickenUnlocked[currentChicken])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
        //If not show the buy button and set the price
        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            priceText.text = chickenPrices[currentChicken] + "$";
        }
    }

    private void Update()
    {
        //Check if we have enough money
        if (buy.gameObject.activeInHierarchy)
            buy.interactable = (SaveManager.instance.money >= chickenPrices[currentChicken]);
    }

    public void ChangeChicken(int _change)
    {
        currentChicken += _change;

        if (currentChicken > transform.childCount - 1)
            currentChicken = 0;
        else if (currentChicken < 0)
            currentChicken = transform.childCount - 1;

        SaveManager.instance.currentChicken = currentChicken;
        SaveManager.instance.Save();
        SelectCar(currentChicken);
    }
    public void BuyChicken()
    {
        SaveManager.instance.money -= chickenPrices[currentChicken];
        SaveManager.instance.chickenUnlocked[currentChicken] = true;
        SaveManager.instance.Save();
        source.PlayOneShot(purchase);
        UpdateUI();
    }
}