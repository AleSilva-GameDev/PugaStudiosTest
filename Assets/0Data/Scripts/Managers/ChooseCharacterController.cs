using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacterController : MonoBehaviour
{
    [Header("Settings")]
    public ChooseCharacter[] chooseCannon;
    public ChooseCharacter[] chooseDrone;
    public static int indexCannon = 0;
    public static int indexDrone = 0;

    [Header("UI - Cannon")]
    [SerializeField] Text textNameCannon;
    [SerializeField] Text textDescriptionCannon;
    [SerializeField] Image imageCannon;

    [Header("UI - Drone")]
    [SerializeField] Text textNameDrone;
    [SerializeField] Text textDescriptionDrone;
    [SerializeField] Image imageDrone;

    private void Start()
    {
        UpdateInformationsCannon();
        UpdateInformationsDrone();
    }

    void UpdateInformationsCannon()
    {
        imageCannon.sprite = chooseCannon[indexCannon].image;
        textNameCannon.text = chooseCannon[indexCannon].name;
        textDescriptionCannon.text = chooseCannon[indexCannon].description;
    }

    void UpdateInformationsDrone()
    {
        imageDrone.sprite = chooseDrone[indexDrone].image;
        textNameDrone.text = chooseDrone[indexDrone].name;
        textDescriptionDrone.text = chooseDrone[indexDrone].description;
    }

    // Cannon
    public void RightButtonCannon()
    {
        indexCannon++;

        if (indexCannon >= chooseCannon.Length)
        {
            indexCannon = 0;
        }

        UpdateInformationsCannon();
    }

    public void LeftButtonCannon()
    {
        indexCannon--;

        if (indexCannon < 0)
        {
            indexCannon = chooseCannon.Length - 1;
        }

        UpdateInformationsCannon();
    }
    //Cannon

    //Drone
    public void RightButtonDrone()
    {
        indexDrone++;

        if (indexDrone >= chooseDrone.Length)
        {
            indexDrone = 0;
        }

        UpdateInformationsDrone();
    }

    public void LeftButtonDrone()
    {
        indexDrone--;

        if (indexDrone < 0)
        {
            indexDrone = chooseDrone.Length - 1;
        }

        UpdateInformationsDrone();
    }
    //Drone

}
