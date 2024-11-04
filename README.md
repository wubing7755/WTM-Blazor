# 项目说明

WTM-Blazor

## 项目结构

- Blazor：主项目（后台API以及Server模式下的_Host页面）
- Blazor.Client：WebAssembly模式的单独项目，包含了Wasm模式的启动代码和配置
- Blazor.Shared：共享项目，所有的Blazor页面都在这个项目中，Server模式和Wasm模式都使用这里的页面
- Blazor.Model：模型项目，所有模型在这个项目中定义
- Blazor.ViewModel：视图模型项目，所有的ViewModel在这个项目下定义
- Blazor.DataAccess：数据库项目，DataContext的定义以及数据迁移生成的代码将会在这个项目中
- Blazor.Test：单元测试项目

