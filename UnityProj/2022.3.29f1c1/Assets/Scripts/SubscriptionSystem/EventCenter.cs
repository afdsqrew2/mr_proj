public enum EventTypeCare//https://blog.csdn.net/weixin_45023328/article/details/108931399
{
    OpenTheDoorFront,
    OpenTheDoorBack,
    OpenTheHood,

    TaskOne,
    TaskTwo,
    TaskThree,

    SoftwareSelfTest,

    TheSecurityCheckIsComplete,

    TheCantileverIsFullyRotated, //悬臂全部旋转完毕
    TheCantileverIsFullyRotatedInformation, //悬臂全部旋转完毕发送通知
    TheCantileverIsFullyInspected, //悬臂全部检查完毕
    ShakeCare,//晃动汽车
    Can_tShakeCare,//晃动汽车

    AnimationClears,//动画清零

    WearLeftGlove,//带左手套
    WearRightGlove,//带右手套
    GameOver,//游戏结束
}