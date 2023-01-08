# ShopsDatabase
A projekt célja egy olyan üzleteket ábrázoló adatbázis, amely által bizonyos szinten vázolom a valós üzleteket. Ez magába foglalja a beszerzőket, alkalmazottakat, termékeket és a vásárlást is. A beszerzők beszerzési helyekről szállítanak terméket a boltoknak, ahol a termékek kategóriákhoz tartoznak. Emellett az üzletben az alkalmazottak egy-egy szakosztályhoz tartoznak, ahol bizonyos pozíciókat töltenek be. A vásárlás a kezdeti tervvel ellentétben csak a boltban történik, de tartozik hozzá egy számla. 

Minden tábla,  ahol ez lehetséges, tartalmaz 10 valós adatot, illetve ~100 generált adatot, amit a [https://www.mockaroo.com/](https://www.mockaroo.com/) oldal segítségével generáltam.

A valós adatoknál a más táblából való külső kulcsokat random generáltam ki, ehhez helyenként WITH vagy JOIN clause-t használtam. 

Így végül 15 tábla készült el, amelyek közül háromról GUI, Windows Form Applicaiton, is készült Visual Studióban C#-ot és .NET Core 3.0-t használva. 

Emellett az Oracle SQL adatbázist átvittem egy MySQL adatbázis kezelő rendszerbe, átírva a CREATE és INSERT utasításokat.
