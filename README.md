<!--
 * @Author: Zhangqilei
 * @Date: 2022-03-04 21:22:32
 * @LastEditors: Zhangqilei
 * @LastEditTime: 2022-03-07 16:59:22
 * @Description: 
 * 
-->
# WebAPIR
这是实现Net core 链接mysql数据库的Demo

## 这里介绍一下该项目的一些经验.
1. 启动
进入目录后执行 `dotnet run`
编辑器我用的是VS Code.很奇怪我在VS上没办法run起来.但是在VS Code 却可以打断点调试

2. 启动后浏览器打开 `https://localhost:7109/swagger/index.html`
就可以看到API文档,安装数据库后然后你可以用Postman测试啦

3. 项目结构
 - **Program.cs**
 项目的入口.在里面我配置了连接数据库的方法和增加了跨域支持

 - **appsettings.json**
这里配置了一个字符串 叫ConnectionStrings.这里字符串包含了本地mysql数据库的信息.包括连接地址,用户,数据库名称,密码.请根据自己的数据库进行配置

- Models
这里需要关注**User**和**UserContext**


**User**:对应我表中数据的一个class.我表里有什么数据这里就有什么数据,我提供一下我本地的数据库截图,可以参考一下
![](https://s2.loli.net/2022/03/07/J4RgEuDzHoc2keO.jpg)

**UserContext**: 你需要为你的表的数据创建上下文.可以理解为NET Core 获取数据的中间件.具体的内容需要再研究.按照网上的写法.它让我得到了数据库的表的主体.当你有了这个,你就可以对数据库的表进行增删改查啦.

> 微软提供的连接数据库的库叫做EntityFrameworkCore,当你新建项目的时候它不在你的项目里.需要你手动添加
EntityFrameworkCore提供了对SQL serve的原生支持,亲儿子就是不一样.

然而当你用MySql 或者PostgreSQL之类的,你需要安装EntityFrameworkCore提供了对SQL,还得安装对应数据库的插件比如说

Mysql:Pomelo.EntityFrameworkCore.MySql

PostgreSQL: Npgsql.EntityFrameworkCore.PostgreSQL 

下面提供一下安装EntityFrameworkCore的方法
`Install-Package Microsoft.EntityFrameworkCore`
`Install-Package Microsoft.EntityFrameworkCore.Design`
`Install-Package Microsoft.EntityFrameworkCore.Tools`
把这三个安装以后你就有了操作数据库的基础.然后在安装根据对应的数据库插件就行了.
安装的插件在WebAPIR.cspro有目录可以自行参考

4. 单独讲一下**Controller**

看了教程,微软的想法是Model里创建你需要的Model,Controller里面创建你需要的API.
这就是MVC呀,这样就好理解了.每一个服务创建一个controller.

本Demo的用到的控制器是PersonController.cs,里面有4个API分别对应CRUD.这几个接口写的比较简单,验证什么的也没加.,写法也是安装微软官方的教程来的.

但是.net core 创建API的方法真是简单明了,看代码
`[HttpPost("create")]`就能读出来这是一个post的创建方法.
而且它控制器继承了它自己封装的BaseController.里面提供了大量的方法和属性,方便你告诉前端接口受否成功,还是失败.反正我觉得很规范.
这里只是简单的使用了一下Net core创建了web api的服务.这个框架很强大.又是跨平台,写起来也舒服.还是很推荐大家试试的.可以快速的为你的前端创建基础的服务.



 
