# Arduino fejlesztői dokumentáció készítette Szita Bence és Szakonyi Ádám
### Bevezetés
A projekt egy rfid beléptető rendszer tervezése, aminél tudunk regisztrálni különböző felhasználókat vagy már meglévőket is tudjunk vele törölni. A rendszer képes felismerni a már regisztrált felhasználókat majd üdvözli őket az ismeretlenekről pedig képet készít.
### Kódok
#### Arduino kód
Includoljuk a szükséges header yyyyyyyyyyyyyyyy SPI.h és MFRC522.h majd definiáljuk az általunk használt pin eket.
Változók
- int readsuccess
-	byte readcard[4]
-	char str[32];
-	String StrUID;
-	String appUID[10];
-	char ch=' ';
setup függvény: ez a loop elött fut le egyszer itt beállítjuk a kommunikációs portot és a pineket.

loop függvény: Először megnézi, hogy hogy érkezett e adat a Serial porton Ezt a Serial.avaiable függvény nézi, ha igen akkor beolvassa majd végrehajtja a megfelelő utasításokat. Ezután megvizsgálja, hogy az rfid olvasónál történt e input ha igen akkor azt továbbítja a Serial-on.

![setup](https://user-images.githubusercontent.com/91843369/205723240-6e4c44eb-f71c-444c-aca8-f9773171dbcf.png)

![loop](https://user-images.githubusercontent.com/91843369/205723336-1915e100-5ca1-4421-94f6-59b7e89170ed.png)

getid függvény: Ez vizsgálja, hogy érkezett e input az olvasóra ha igen akkor kiolvassa majd átadja az array_to_String függvénynek ami megfelelő formára alakítja.

![getid_ats](https://user-images.githubusercontent.com/91843369/205723441-01772d9d-9c0c-45c6-b59f-280790cdcc53.png)

#### Windows Form Application

**Form 1 Design** tartalma:tb_log, lv, cbname, pic, but_felvitel, but_torles, but_belep, but_kilep
![kezdolap](https://user-images.githubusercontent.com/91843369/205723783-d9ce4749-aa60-41ba-8e57-aa7d29f318e2.png)

**Form1.cs**
![globalisForm1](https://user-images.githubusercontent.com/91843369/205723861-6dace039-1e65-4f7e-86a1-2237f094de52.png)

but_kilep_Click: kilépés gombra kattintva bezárja az ablakot
but_belep_Click: A belépésre kattintva a Form megnyitja a Serialport-ot 10 másodpercig várja az adat érkezését, ha nem jön rajta semmi akkor zárja a kapcsolatot, ha pedig jött adat akkor annak a beolvasása után szünteti meg. Az érkezett adatot az rfid változóban tárolja majd megvizsgálja, hogy szerepelt e az rfid az adatok tömbben és eredménytől függően elvégzi a feladatot.

![belep1](https://user-images.githubusercontent.com/91843369/205723964-75f0e723-9848-4643-9a0a-abd1ae1e5309.png)
![belep2](https://user-images.githubusercontent.com/91843369/205723973-bd00aaea-7145-420f-83a9-63880be83036.png)
![belep3](https://user-images.githubusercontent.com/91843369/205723991-7ac2bec3-938e-45e8-a1ff-4684ae253329.png)

Form1_Load: A form betöltésekor fut le csatlakozik a Mysql adatbázishoz lekéri az adatokat majd feltölti a list viewet és az adatok tömböt.
![load](https://user-images.githubusercontent.com/91843369/205724116-4429b8b5-e0ce-47c2-95e3-e8b991b81556.png)

but_torles_Click & TorlesMentes: A törlés gombra kattintva a kiválasztott elemet kitörli a listview elemből majd meghívja a Törlésmentés függvényt, ami kitörli az adatbázisból és az adatok tömbből.
![torles](https://user-images.githubusercontent.com/91843369/205724222-111bd154-c81c-4912-b6df-96ba188642d2.png)
![torlesmentes](https://user-images.githubusercontent.com/91843369/205724232-a01269db-f304-484a-b68c-033aad43c316.png)

Form1_Activated: Amikor visszakerül a focus a form-ra újra lekéri az adatbázisból az elemeket a régiket törli a list view-ból és feltölti az újakkal.
![Activated](https://user-images.githubusercontent.com/91843369/205724347-6bacd11e-a28e-45e3-8feb-0a5da6073d35.png)

VideoCaptureDevice_NewFrame: Ez felel a képek készítéséért majd menti azokat a megfelelő mappába
![Kepkeszites](https://user-images.githubusercontent.com/91843369/205724428-42784db0-0819-49d0-8000-f4adfc88906e.png)

but_felvitel_Click: Megnyitja a felviteli ablakot
**Felvitel.cs Design**

![felvitel (1)](https://user-images.githubusercontent.com/91843369/205724489-85d91de5-5014-487b-ba15-2afad6ff8bc1.png)

but_rfidolv_Click & AdatbazisMentes: A but_rfidolv_CLick megvizsgálja, hogy név mező ki van e töltve, ha igen beolvassa az rfid-t majd meghívja az AdatbazisMentes függvényt, ami frissíti az adatbázist és az adatok tömböt
![rfidolv1](https://user-images.githubusercontent.com/91843369/205724581-2526a799-83d7-4083-9f7e-bc6cf5f717c6.png)
![rfidolv2](https://user-images.githubusercontent.com/91843369/205724591-1fdf5253-a26a-4203-9b82-9207c59bd8fa.png)
![Adatbazismentes](https://user-images.githubusercontent.com/91843369/205724662-e3308af9-b653-4106-b13b-a3d301532196.png)

but_kilep_Click: Bezárja a felvitel ablakot

### Áramköri rajz
![aramkor](https://user-images.githubusercontent.com/91843369/205724712-705b829b-44a0-4216-9796-6cd84af575fb.jpg)

### Adatbázis
Egy táblás adatbázis ami kettő oszlopot tartalmaz egy a névnek egy pedig az rfid-nek

**Hardver specifikációk:** Arduino Uno, RC522 – RFID Kártya író és olvasó modul, LED-ek

**Szoftver specifikáció:** Microsoft Visual Studio, MySQL, Xampp, ArduinoIDE

**Rendszerkövetelmény:** .Net Framework 4.7.2 vagy újabb

**Fejlesztés közbeni nehézségek:** Arduino megértése 

