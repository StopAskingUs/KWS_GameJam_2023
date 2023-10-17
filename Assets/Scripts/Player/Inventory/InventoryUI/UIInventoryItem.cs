using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIInventoryItem : MonoBehaviour {

    [SerializeField] private Image _itemImage;
    
    [SerializeField] private TMP_Text quantityTxt;

    [SerializeField] private Image borderImage;

    public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

    private bool empty = true;

    public void Awake() {

        ResetData();
        Deselect();
    }

    public void ResetData() {
        this._itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect() {
        borderImage.enabled = false;
    }
}

