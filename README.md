 # Unity_PlayGround
 Jeff's Unity Code Testing Repository

 ## 項目清單
 
 `0_360spline_Lookat`：自主鏡頭沿著parentPath飛行練習 <br>
 `1_RandCam`：鏡頭視角跟隨物件、動態更新視點飛行練習 <br>
 `2_Manual_MoveControl`：切換視角與控制角色練習 <br>
 
 ## 操作說明
 `2_Manual_MoveControl`：按下 **R** 可以切換視角
 ## Changelog

 #### 2024/05/18
 - 優化 `02自主控制切換練習`
   - `PlayerInput功能`是控制關鍵


 #### 2024/05/18
 - 建立 `02自主控制切換練習`

 # TODO
 -合併`CameraFollowRoot`功能
   - 傳入呼叫CameraFollowRoot的位置角度、Follow角色變化
     - 提示: `CameraFollowRoot`可以記錄鏡頭位置，也可以接受傳入函數
 - `MonitorCam`與`PlayerCam`合併

 ### 已完成的代辦事項
 - 中斷parentPath飛行並自主切換控制角色 `2_Manual_MoveControl`