﻿/****************************************************
    文件：LoadingWind.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 15:58:42
	功能：登录面板
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoadingWind : GameUIRoot
{
    public Text textTips;
    public Image imgFG;
    public Image imgPoint;
    public Text textProgress;

    private float imgbgWidth;

    protected override void InitWindow()
    {
base.InitWindow();
        imgbgWidth = imgFG.GetComponent<RectTransform>().sizeDelta.x;
	
	SetText(textTips,"this is a tips");	
        imgFG.fillAmount = 0;
        SetText(textProgress,"0%");
        imgPoint.transform.localPosition = new Vector3(-494,0,0);
    }

    public void SetValue(float value)
    {
        imgFG.fillAmount = value;
        SetText(textProgress,(int)(value * 100) + "%");
        float pos = value * imgbgWidth - imgbgWidth / 2;
        imgPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos,0);
    }
}