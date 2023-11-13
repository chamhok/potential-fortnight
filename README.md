# TextRPG

난 유니티로 만드는게 좋아요...

## 기본 구조

- `Program` 클래스는 게임의 진입점이며, `Main` 메서드에서 게임 데이터 설정 및 게임 소개를 표시합니다.
- `GameDataSetting` 메서드는 캐릭터 및 아이템 정보를 초기화하고 정렬합니다.
- `DisplayGameIntro` 메서드는 게임 소개 화면을 표시하고 플레이어의 선택에 따라 다양한 화면으로 이동합니다.

## 캐릭터 및 아이템 관리

- `Character` 클래스는 캐릭터 정보를 저장하고 관리합니다.
- `Item` 클래스는 아이템 정보를 저장하며, 인벤토리와 상점에서 관리됩니다.

## 게임 화면 구성

- `DisplayMyInfo` 메서드는 캐릭터 정보를 표시하고 나가기 옵션을 제공합니다.
- `DisplayInventory` 메서드는 인벤토리를 표시하고 장착 관리 및 나가기 옵션을 제공합니다.
- `Displaystore` 메서드는 상점을 표시하고 구매하기, 판매하기, 나가기 옵션을 제공합니다.

## 구매 및 판매 관리

- `DisplaystoreBuyManagement` 및 `DisplaystoreSaleManagement` 메서드는 각각 상점에서 아이템을 구매하거나 판매하는 화면을 표시합니다.
- `DisplaystorefailedBuy` 및 `DisplaystorefailedSale` 메서드는 구매 또는 판매가 불가능한 경우에 메시지를 표시하고 해당 화면으로 다시 이동합니다.

## 기타

- `CheckValidInput` 메서드는 사용자 입력이 유효한지 확인하고 범위 내에 있는지 확인합니다.
- `MyClass` 클래스는 화면에 라인 및 박스를 그리는 메서드를 제공합니다.


