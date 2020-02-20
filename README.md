# Introduction
DataProxy_RES je aplikacija koja sluzi za prikazivanje potrosnje elektricne energije podrucja korisniku po zadatkom vremenskom opsegu, u danima.


# Getting Started, Build and Test
Da bi zapoceli rad sa aplikacijom pokrenite .sln fajl, i kompajlirajte release.
Aplikacija se pokrece tako sto se prvo pokrene server.exe, a nakon njega client.exe


#Components
Aplikacija je zamisljena tako da se moze razdvojiti na vise fizickih masina. Komponente aplikacije su server, client, common.ddl i baza podataka.
Serverska aplikacija pored  sluzi i kao kes memorija upita koji su vec poslati bazi, pa na taj nacin brze vraca korisniku odgovor bez pristupa bazi podataka.
Klijentska aplikacija je veoma intuitivna, sva validacija je uradjena na front end-u tako da korisnik ne moze uneti pogresne podatke.
Baza podataka koriscena u ovom slucaju je MSSQL, koriscen je EF6 i Code-First pristup. 

Aplikacija je testirana manuelno i automatski, pa u kodu mozete pronaci i odredjene UNIT testove, kao i izvestaj trenutne pokrivenosti koda.



# Contribute
Autori: Milan Medic i Nikola Milic