# SUDOKU by Karel Vlk

## Téma
Aplikace je založena na populární logické hře Sudoku, kterou byla vymyšlena v 
roce 1979 Howardem Garnsem a je hraná do dnes. Cílem hry je do každého volného 
políčka hrajího pole o rozměrech 9x9 zvolit vhodnou číslici 1-9 tak, aby byla 
splněna následující pravidla:
```
*   v žádném řádku se nesmí vyskytovat jedna číslice více než jednou, tedy všechny 
    číslice na řádku se vyskytují právě jednou. 
*   v žádném sloupci se nesmí vyskytovat jedna číslice více než jednou, tedy všechny 
    číslice ve sloupci se vyskytují právě jednou.
*   v každém z devíci podpolí o rozměrech 3x3, pro které platí, že každé dvě pole 
    jsou disjunktní, platí stejné pravidlo jako pro řádky a sloupce. Tedy v každém
    jednom podpoli se může vyskytovat cifra 1-9 pouze jednou. 
```

## O aplikaci
SUDOKU by Karel Vlk je aplikace operující s hrou Sudoku. Funguje ve dvou režimech, ze
kterých si uživatel může vybrat právě ten, který bude chtít využívat. Samozřejmě z
jakéhokoli stavu aplikace se dá dostat zpět do menu a zvolit jiný režim fungování.

### Game (režim hry)
Režim `Game (hry)` je režimem interaktivním, v němž má uživatel možnost výběru úrovně 
obtížnosti ze čtyř dostupných. Následně se uživateli vygeneruje polovyplněné hrací
pole. Do nevyplněných polí má hráč (uživatel) za úkol napsat cifry 1-9 podle pravidel 
hry a tím Sudoku vyřešit. Je zde možnost v jakém koli herním stavu kliknout na tlačítko
`Check (kontrola)`, které zbarví jednotlivá políčka hracího pole zelenou respektive červenou
barvou v závislosti na korektnosti řešení. Tedy zelená barva značí políčka, která jsou 
vyplněna správnou číslici a červená barva značí políčko se špatně zvolenou číslicí.
Je zde také tlačítko `Hint (nápověda)`, které po kliknutí vyplní náhodně jedno políčko
správnou číslicí, jako pomoc hráči, který si neví rady jak dál postupovat. 

### Solver (režim řešitele)
Režim `Solver (řešitel)` umožňuje uživateli řešení zadané Sudoku. Jinými slovy hráč vyplní 
určitá políčka hracího pole ciframi 1-9 a program se mu pokusí najít řešení. Pokud řešení 
najde, tak ho zobrazí a vypíše hlášku `"Successfully solved" (úspěšně vyřešeno)`. V opačném
případě zůstane na obrazovce zadané červeně zbarvené polovyplněné pole s vypsanou hláškou
`"Cannot be solved!" (nelze vyřešit)`.

## Využití aplikace
Aplikace lze být využívána pro zkrácení dlouhých chvil společně s procvičováním mozku 
uživatele u hraní této logické hry v interaktivním režimu. Velkou výhodou této verze hry
Sudoku je to, že lze v každém herním stavu zjistit, zda-li je aktuální částečné řešení správné.
Druhou výhodou je možnost nápovědy, která může být velmi užitečná pokud už uživatel neví jak 
pokračovat.

## Ovládání (průvodce aplikací)
### Úvodní obrazovka
Na úvodní obrazovce jsou dvě tlačitka:
```
* Game
* Solver
```
Po kliknutí na zvolené tlačítko se spustí příslušný režim popsaný výše.

### Game menu obrazovka
Po stisknutí tlačítka `Game` se zobrazí možnosti obtížnosti, která značí kolik políček herního
pole bude muset uživatel vyřešit. Po zvolení obtížnosti je zapotřebí stisknout tlačítko 
`Continue` pro přechod do hry. 

### Game obrazovka
Zde se nachází přes celou obrazovku hrací pole, do kterého se vypisují cifry 1-9 pomocí klávesnice.
Je potřeba však označit políčko, do kterého chce uživatel psát kliknutím myší. Pro mazání cifry je 
možno použít klávesu `backspace` nebo zmáčknutí jakéholi nenumerické klávesy. Je možné přepisovat 
pouze políčka, která nebyla součástí zadání. Dále se na obrazovce nachází tlačítka `Check` a `Hint`, 
která po kliknutí fungují tak, jak je popsáno výše.

### Solver 
V tomto režimu je také přes celou obrazovku hrací pole, které funguje stejně jako v `Game` režimu 
pouze s tím rozdílem, že jsou editovatelná všechna políčka. Je zde také tlačítko `Reset`, které vymaže
všechna políčka hracího pole pro zadání nových hodnot.

### Ostatní
V levém dolním rohu se ve všech stavech aplikace, kromě úvodní obrazovky, nachází tlačítko `Back to menu`,
jenž umožňuje přesun na úvodní obrazovku. Tato akce však znamená ztrátu veškerého stavu hracího pole v obou
 režimech 

## Technická dokumentace
Uživatelské rozhraní této aplikace je vytvořené ve Windows Form, a tudíž aplikace reaguje na události 
vyvolané uživatelem v objektu `Form.cs`. Zde se po zachycení události přístušným elementem vyvolá událost
dám do objektu příslušného režimu, ve kterém aplikace aktuálně operuje. Object `Form` se tedy stará pouze 
o vizualizaci a input uživatele, tudíž obsahuje pouze metody k tomu určené.

Po stuštění aplikace se inicializují objekty, které jsou nezbytně nutné pro fungování aplikace, jsou to:
```
* Board
* Solver
* GameMode
* SolverMode
``` 
### Board 
Tato třída zajištuje uchovávání aktuálního stavu herního pole, které je závislé na akcích uživatele. Hrací pole je 
reprezentováno jako 2D pole integerů znázorňující aktuální stav políčka. Pokud je políčko prázdné, tak je hodnota 
nastavena na 0. Je zde také další 2D pole indexované stejně jako pole reprezentující stav hracího pole. Toto
pole obsahuje reference na objekty jednotlivých políček, aby bylo možné s nimi manipulovat. Tyto instance jsou také 
generované touto třídou.

#### Entity (políčko)
Toto je třída políčka. Políčko je reprezentované jako `TextBox`. V této třídě jsou metody operující se stavem políčka. 
Tedy metoda na změnu barvy. Je zde metoda, která kontroluje korektnost vstupu od uživatele tak, že pokud uživatel 
zadá do políčka hracího pole něco jiného než cifru 1-9, tak se obsah políčka automaticky vymaže a nastaví na nevyplněný.
Následně po vyhodnocení vstupu od uživatele instance tohoto objektu pošle `Board-u` aktuální stav. Třída také obsahuje 
proměnnou která o políčku říká zda-li bylo vygenerováno s hodnotou pro interaktivní hru. Pokud je tato proměnná `true` 
tak je nastavená vlastost `Text` na `disabled` a tudíž ho nelze přepsat.

### SolverMode
Tato třída zajištuje řešení zadaného hracího pole reprezentované 2D polem integerů. Hlavní algoritmus této třídy, který 
řeší Sudoku je založený principu `backtrackingu`. Tedy algoritmus vyzkouší na prázdné políčko vybrat jednu z cifer 1-9 a
následně se rekurzivně pokusí dořešit Sudoku. Pokud se mu to nepodaří vrátí se a zkusí další možnou cifru. Pokud žádná 
další neexistuje, tak algoritmus skončí s návratovou hodnotou `false`, v opačném případě s hodnotou `true`. V jednotlivých
průchodech se předané 2D pole hracího púole dynamicky mění, a proto si příslušná řešící metoda nejdříve zkopíruje původní
předané pole do nového, s kterým následně pracuje. Metoda vrátí `Tuple<bool, int[,]>`, kde první hodnota je informace, zda-li
bylo Sudoku vyřešeno a druhá hodnota je reference na 2D s finálním řešením. 

Tento algoritmus jsem si vybral z toho důvodu, že vyřeší jakékoli Sudoku a je relativně jednoduchý na napsání narozdíl od jiných,
které nemají takovou účinost

Algoritmus má exponenciální časovou složitost, avšak na pole 9x9 není nijak omezující.

#### Validator
Součástí třídy je také třída `Validator`, která obsahuje metody, které kontrolují zdali je hrací pole vyplněno podle pravidel.

### GameMode
Tato třída se stará o logiku hry a propojení `Solver-u` a `Form-u`. Zajišťuje:
```
* Hint
* Check
* Generator
``` 
#### Hint
Hint funguje na tak, že se nejdříve zkusí z aktuálního stavu dopočítat řešení. Pokud pro lze tak se bude s tímto řešením pracovat,
pokud ne, tak se vezme už vyplněné hrací pole, který vytvořil generátor hracího pole. Následně se porovnávají aktuální a vybraná
vyřešená hrací pole a pozice rozdílných políček se ukládají do dynamického `List-u`, ze které random generator vybere jednu a ta se
následně doplní do řešení.

#### Check 
Check funguje na stejném principu jako `Hint` jen s rozdílem, že rozdílná políčka barví červeně a ostatní neprázdné zeleně.

#### Generator
Generator je třída obsahující metody na generování hracího pole pro interaktivní hru. Vytvoří se zde nejdříve diagonálně
3 disjunktní 3x3 podpole. Jejikož tyto podpole jsou na hlavní diagonále, tak se neovcliňují navzájem. Proto je tedy možné 
opět pomocí random generátoru doplnit hodnoty tak aby v každém podpoli nebyla 2 stejná čísla. To nám zaručí, že budeme mít 9!*3
různých řešení. Zbylé hodnoty dopočítáme pomocí `Solver-u`. N8sledně opět pomocí random generátoru vymažeme počet políček, který 
závisí na zvolené obtížnosti. 


