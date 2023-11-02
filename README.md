# Sync ARKit face tracking 
using [extOSC](https://github.com/iam1337/extOSC.git#upm)
 to learn OSC

Sync Apple ARKit Face Tracking

- Unity Version: Unity2022.3.8f1
- Model :[千駄ヶ谷 渋（iPhone用BlendShapeあり](https://hub.vroid.com/characters/7307666808713466197/models/1090122510476995853)

------

# 練習使用 [extOSC](https://github.com/iam1337/extOSC.git#upm) 串流臉部表情
- 特別要注意的是臉部 BlendShape 與 Unity ARFoundation sample 的 ARKitBlend key不太一樣，有針對這個ＶＲＭ 模型 BlendShape key 做調整
- `ARKitBlendShape` 腳本中本不該與`OSC Transform sender`腳本做關聯，但因為只是想快速測試，就不多加設計了
