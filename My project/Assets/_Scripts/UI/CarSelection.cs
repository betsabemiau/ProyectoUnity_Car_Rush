using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    private Color _selectedColor = new Color(255, 255, 255, 0.39f);
    private Color _unselectedColor = new Color(0, 0, 0, 0.39f);

    [SerializeField] private Sprite redCar;
    [SerializeField] private Sprite blueCar;
    [SerializeField] private Image redCarUI;
    [SerializeField] private Image blueCarUI;

    private void Start()
    {
        SelectRedCar();
    }

    public void SelectRedCar()
    {
        GlobalVariables.currentSprite = redCar;
        redCarUI.color = _selectedColor;
        blueCarUI.color = _unselectedColor;
    }

    public void SelectBlueCar()
    {
        GlobalVariables.currentSprite = blueCar;
        redCarUI.color = _unselectedColor;
        blueCarUI.color = _selectedColor;
    }
}
