# 🧍‍♂️ Inventory_Personal 

Unity로 개발한 **간단한 방치형 게임(Idle Game)** 프로젝트입니다.  
캐릭터가 자율적으로 맵을 돌아다니며 아이템을 수집하고, 인벤토리를 자동으로 채워가는 구조로 설계되어 있습니다.

---

## 🕹️ 게임 설명

- 캐릭터는 **NavMesh** 위를 자율적으로 배회하며, 아이템이 감지되면 그쪽으로 이동합니다.
- 아이템에 닿으면 **획득**되며, 아이템은 랜덤한 위치에 리젠됩니다.
- 획득한 아이템은 **인벤토리에 자동 저장**되며, 인벤토리에서 아이템을 **장착**할 수 있습니다.
- 클리어 조건이 3가지입니다. (50,000 Gold 모으기, Level.10 달성하기, 인벤토리 가득 채우기)

---

## 🎮 주요 기능

| 기능 | 설명 |
|------|------|
| 🔄 방치형 캐릭터 | `NavMeshAgent`를 통해 캐릭터가 스스로 랜덤한 목적지로 이동 |
| 📦 아이템 획득, 장착 | 아이템 획득 시 인벤토리에 저장, 장착 시 외모 변경 |
| 🧺 인벤토리 시스템 | 슬롯 기반의 간단한 인벤토리 UI 구현 |
| 🧠 상태머신 FSM | 캐릭터는 배회하다가 주변에 아이템이 존재하면 다가갑니다. `Searching`, `Move` 상태로 구성된 간단한 FSM을 따릅니다 |

---  

## 🧠FSM 구조
![image](https://github.com/user-attachments/assets/0ba4fa10-1850-4772-8a47-50cba30a4555)

---

## 🔧 설치 및 실행
#### 방법 1
https://play.unity.com/en/games/679402af-f06b-4ee7-8afd-e518a0b5a7ef/webgl-builds

#### 방법 2
1. Unity Hub에서 이 프로젝트를 열기
2. 메인 씬(`MainScene`)을 실행
3. 캐릭터가 자동으로 배회하며 아이템을 수집하는 것을 관찰

---

## 📷 스크린샷
| Play1 |
|---|
| ![01](https://github.com/user-attachments/assets/ec29a977-58c4-4bce-8a45-ef8f57c18954) |

| Play2 |
|---|
| ![02](https://github.com/user-attachments/assets/18212657-721d-4d15-b2f0-3c368674cc76) |

| Clear |
|---|
| ![03](https://github.com/user-attachments/assets/154287dc-f3a4-4c14-b09e-601855fa6a73) |
---
