/****************************************************
    文件：LoginWind.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/24 17:29:10
	功能：动态UI元素界面
*****************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWindow: GameUIRoot 
{
    public Animation tipsAnim;
	public Text txtTips;
	public override void InitWindow()
	{
		base.InitWindow();
		SetActive(tstTips,false);
	}

	public void SetTips(string tips)
	{
		SetActive(txtTips);
		SetText(txtTips,tips);
	
		AnimationClip clip = tipsAnim.GetClip("TipsShowAni");
		tipsAnim.Play();
		//延时关闭
		StartCoroutine(AnimPlayDone(clip.length,()=>
		{
			SetActive(txtTips,false);
		}));

	}

	IEnumerator AnimPlayDone(float sec,Action ac)
	{
	yield return new WaitForSeconds(sec);
		if(ac!= null)
{ac();}
	}
}