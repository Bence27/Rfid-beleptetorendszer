-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Dec 04. 11:29
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `arduino`
--
CREATE DATABASE IF NOT EXISTS `arduino` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `arduino`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felvett`
--

CREATE TABLE `felvett` (
  `RFID` varchar(20) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Nev` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felvett`
--

INSERT INTO `felvett` (`RFID`, `Nev`) VALUES
('E247778D', 'Bence'),
('BBF2E949', 'Szaki');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felvett`
--
ALTER TABLE `felvett`
  ADD PRIMARY KEY (`Nev`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
