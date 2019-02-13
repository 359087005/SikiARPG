/****************************************************
    文件：LoginWind.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 17:29:10
	功能：动态UI元素界面
*****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWindow : GameUIRoot
{
    public Animation tipsAnim;
    public Text txtTips;

    Queue<string> tipsQueue = new Queue<string>();
    bool isTipsShow = false;  //true表示有tips  false表示没有tips

    private void Update()
    {
        if (tipsQueue.Count > 0 && isTipsShow == false)
        {
            isTipsShow = true;
            SetTips(tipsQueue.Dequeue());
        }
    }

    protected override void InitWindow()
    {
        base.InitWindow();
        SetActive(txtTips, false);
    }
   
    public void AddTips(string tips)
    {
        tipsQueue.Enqueue(tips);
    }

    void SetTips(string tips)
    {
        SetActive(txtTips);
        SetText(txtTips, tips);

        AnimationClip clip = tipsAnim.GetClip("textTips");
        tipsAnim.Play();
        //延时关闭
        StartCoroutine(AnimPlayDone(clip.length, () =>
        {
            isTipsShow = false;
            SetActive(txtTips, false);
         }));
    }

    IEnumerator AnimPlayDone(float sec, Action ac)
    {
        yield return new WaitForSeconds(sec);
        if (ac != null)
        { ac(); }
    }
}