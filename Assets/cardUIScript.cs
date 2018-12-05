using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//引入命名空间UnityEngine.UI

public class cardUIScript : MonoBehaviour
{
    private float leftTime;//剩余时间
    public float totalTime;//总时间
    private Image cdImage;//Button控件的子控件，它的亮度调低一些，作为CD倒计时时候的等待效果图
    private Button cdButton;//button控件，把子控件Text删了
    // Use this for initialization
    void Start()
    {
        leftTime = 0;//起初，剩余时间等于总时间
        cdImage = transform.Find("Image").GetComponent<Image>();//获取button控件的子控件Image的Image组件(注意控件与组件的区分)
        cdButton = GetComponent<Button>();//获取自身的button组件
        cdButton.interactable = false;//button组件中的interactable属性赋值为false,同让button的按下效果失活
    }

    // Update is called once per frame
    void Update()
    {
        leftTime -= Time.deltaTime * 5;//剩余时间每秒减少5s等待
        if (cdImage.fillAmount > 0)
        {
            cdImage.fillAmount = leftTime / totalTime;//把比例值赋给Image中的fillAmount属性，为0-1的小数
        }
        else
        {
            cdButton.interactable = true;//button可按
        }
    }
    public void FireSkill()//公开使用技能的方法
    {
        Debug.Log("技能使用了");//控制台打印
        leftTime = totalTime;//剩余时间恢复
        cdButton.interactable = false;//button不可按
        cdImage.fillAmount = 1;//fillAmount重置为1
    }
}
/*--------------------- 
作者：一枫一叶舟
来源：CSDN
原文：https://blog.csdn.net/qq_23680543/article/details/77695602 
版权声明：本文为博主原创文章，转载请附上博文链接！*/

