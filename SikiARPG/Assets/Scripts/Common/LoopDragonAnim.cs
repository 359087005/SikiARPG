/****************************************************
    文件：GameUIRoot.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：2019/1/25 14:54:58
	功能：飞龙循环动画
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoopDragonAnim : MonoBehaviour 
{
	private Animation anim;
	private void Awake()
	{
		anim = this.GetComponent<Animation>();
	}

	private void Start()
	{
		if(anim!= null)
		{InvokeRepeating("PlayDragonAnim",0,20);}
	}

	private void PlayDragonAnim()
	{
		if(anim!=null)
		{
			anim.Play();
		}
	
	}
}