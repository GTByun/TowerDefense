using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public bool isEdit = false;
    public int editId;
    private UIController UIController;

    private void Awake()
    {
        UIController = GameManager.gameManager.UIController;
    }

    public void SetEditMode(bool edit)
    {
        isEdit = edit;
        if (editId > 14)
        {
            UIController.GameModeOn();
        }
    }

    public void SetEditId(int Id)
    {
        editId = Id;
    }
}
