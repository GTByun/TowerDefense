using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public bool isEdit = false;
    public int editId;

    public void SetEditMode(bool edit)
    {
        isEdit = edit;
    }

    public void SetEditId(int Id)
    {
        editId = Id;
    }
}
