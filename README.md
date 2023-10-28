# 游戏开发基底  
基于Unity所写的游戏通用模块，方便后续开发游戏。

## 模块
1.输入模块 ✔  
2.渲染模块  
3.UI模块 ✔  
4.音频模块  
5.相机模块  
6.动画模块  
7.资源加载模块  
8.模板数据加载模块  
9.AI模块 ✔  
9.网络模块  
10.数据序列化模块  ✔  
11.热更新模块

## 模块说明
System：模块的入口  
Domain：模块的核心业务  
Context：模块的上下文  
Getter/Setter：模块给外部调用的接口  
EventCenter：模块给外部注册的事件中心  

## 如何使用：  
1.Unity打开Package Manger窗口  
2.左上角选择add package from git url  
3.输入ssh://git@github.com/mxmx-fun/GameArchi.git?path=/Assets/com.moxi.gamearchi#main
