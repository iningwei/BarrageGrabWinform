# 抖音弹幕监听器
+ Github大佬请移步[Gitee](https://gitee.com/haodong108/dy-barrage-grab)，参与Issues讨论

## ⛳近期更新

2023-04-24 v2.6.5

1. 新增了若干用户字段，包括用户shortid,粉丝数,关注数,主播关注状态,消费等级,并修正了粉丝团等级的错误赋值;礼物消息新增了GroupId用于帮助区分礼物连送分组;   字段详解见 [BarrageMessages.cs](./BarrageGrab/JsonEntity/BarrageMessages.cs)

2023-04-10 v2.6.4

1. 修改为礼物消息为增量推送，不再逐个推送，增量字段为GiftCount

2023-04-09 v2.6.3

1. 新增直播间下线消息，直播间分享消息类型。
2. [重要更新] 修复了礼物重复的问题 详见 [Issue #I6TFBV](https://gitee.com/haodong108/dy-barrage-grab/issues/I6TFBV)，并且现在一个弹幕消息对应一个礼物单位(假设有大佬连送500个小心心，则理论上会推送500次礼物消息)，原先的GiftCount更名为RepeatCount

2023-04-01 v2.6.2(beta)

1. Json输出添加了弹幕ID字段，尝试过滤重复的弹幕ID，尝试处理ws数据粘包问题（说是尝试是因为断点打不中，对我来说概率太低了）

2023-03-28 v2.6.1

1. 丰富了用户的数据信息，支持房间号过滤(见配置文件)


## 😎介绍及配置

### 介绍

基于系统代理抓包打造的抖音弹幕服务推送程序，它能够抓取电脑上所有抖音弹幕来源数据，主要包括三种来源：**浏览器进程** ，**抖音客户端**，**抖音直播伴侣**。它可以监听**弹幕**，**点赞**，**关注**，**送礼**，**进入直播间**，**直播间统计**，**粉丝团**系列消息，你可使用它做直播间数据分析，以及弹幕互动游戏，语音播报等。

### <a id="tag1">配置文件</a>

程序中有基本的配置可以过滤弹幕进程，弹幕数据通过Websocket服务推送，其他程序只需接入ws服务器就能接收到到弹幕数据消息

``` xml
	<appSettings>
		<!--过滤Websocket数据源进程,可用','进行分隔，程序将会监听以下进程的弹幕信息-->
		<add key="processFilter" value="直播伴侣,chrome,msedge,douyin"/>
		<!--Websocket监听端口-->
		<add key="wsListenPort" value="8888"/>
		<!--在控制台输出弹幕-->
		<add key="printBarrage" value="true"/>
		<!--要在控制台打印的弹幕类型,可以用','隔开   all[全部]，1[普通弹幕]，2[点赞消息]，3[进入直播间]，4[关注消息]，5[礼物消息]，6[统计消息]，7[粉丝团消息]-->
		<add key="printFilter" value="all"/>
		<!--系统代理端口-->
		<add key="proxyPort" value="8827"/>
		<!--开启内置的域名过滤，设置为false会解包所有https请求，cpu占用很高，建议在无法获取弹幕数据时调整 -->
		<add key="filterHostName" value="true"/>
		<!--已知的弹幕域名列表，用作过滤规则中，凡是webcast开头的域名程序都会自动列入白名单-->
		<add key="hostNameFilter" value="
			webcast3-ws-web-hl.douyin.com,
             webcast3-ws-web-lf.douyin.com,
			webcast100-ws-web-lq.amemv.com,
             frontier-im.douyin.com,            
		"/>
        <!--要进行过滤的房间ID,不填代表监听所有，多项使用','分隔，浏览器进入直播间 F12 控制台输入 'window.localStorage.playRoom' 即可快速看到房间ID (不是地址栏中的那个)，也可以通过推送的弹幕流数据中获取到房间ID -->
		<add key="roomIds" value=""/>		
	</appSettings>
```


### <a id="tag2">关于域名白名单的问题</a>

如果你在使用过程中发现有获取不到弹幕的问题，请将`filterHostName` 设置为 `false`后再次尝试，如果发现修改配置后能够成功获取，请在程序运行目录下找到"成功解包域名缓存.txt"文件，在里面找到新的域名并添加到 `hostNameFilter`中，然后重新修改`filterHostName`为`true`。除此之外，你可以提交 Issues 或者 Pull Request 到仓库，帮助提高程序健壮性。

### 推送数据格式

弹幕数据由WebSocket服务进行分发，使用Json格式进行推送，见项目  [BarrageMessages.cs](./BarrageGrab/JsonEntity/BarrageMessages.cs)，如需调整请克隆项目后参照 [message.proto](./BarrageGrab/proto/message.proto) 进行源码修改调整，文件包含所有弹幕相关数据结构，可前往[ws在线测试](http://wstool.jackxiang.com/)网站，连接 ws://127.0.0.1:8888 进行测试

### 使用方法
1. 配置要监听的进程名称，例如有些朋友可能用QQ浏览器或者360浏览器，可以在快捷方式上右键打开文件位置，一般exe文件的名称就是进程名
2. 管理员身份启动本程序，第一次启动会提示安装自签名证书，程序启动后挂在后台不要关，不然再打开会监听不到正在进行中的直播弹幕。
3. 打开浏览器进入任何直播间进行测试，没有问题再启动直播伴侣，<b>浏览器和直播伴侣同时打开时还是要注意进程过滤，不然弹幕会杂交</b>

## 🖼️控制台截图

[![控制台截图](https://s1.ax1x.com/2022/11/10/z9YYPU.png)](https://imgse.com/i/z9YYPU)



## 🐳主要依赖项

+ [Titanium.Web.Proxy](https://www.nuget.org/packages/Titanium.Web.Proxy)
+ [Protobuf-net](https://www.nuget.org/packages/protobuf-net/)



## ⚠️特别注意

1. 程序只能监听到握手之后的ws数据包，例如先进入直播间或开启直播再打开本程序是无法监听到的，所以请保持程序后台运行

2. 由于打开系统代理需要自动检查/生成证书，所以程序需要管理员身份运行

3. 只有到达客户端的弹幕数据才能被接收，被抖音服务器过滤的弹幕是抓不到的

   

## 📢鸣谢

+ 请施舍一个 ⭐Start ，现在工具处于早期版本，及时订阅更新获得更佳的使用体验
