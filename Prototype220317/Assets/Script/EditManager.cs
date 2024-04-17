using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public bool isEdit = false;
    public int editId;
    private UIController uIController;

    private void Awake()
    {
        uIController = GameManager.gameManager.UIConroller;
    }

    public void SetEditMode(bool edit)
    {
        isEdit = edit;
        if (editId > 14)
        {
            uIController.GameModeOn();
        }
    }

    public void SetEditId(int Id)
    {
        editId = Id;
    }
}
