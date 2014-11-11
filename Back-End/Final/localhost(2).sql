-- phpMyAdmin SQL Dump
-- version 2.11.8.1deb5+lenny9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 09. November 2014 um 15:00
-- Server Version: 5.0.51
-- PHP-Version: 5.2.6-1+lenny16

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `aspace`
--
CREATE DATABASE `aspace` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `aspace`;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Behavior_Feedback`
--

CREATE TABLE IF NOT EXISTS `Behavior_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `behavior1` text character set utf8 collate utf8_unicode_ci,
  `rating1` int(2) default NULL,
  `behavior2` text character set utf8 collate utf8_unicode_ci,
  `rating2` int(2) default NULL,
  `behavior3` text character set utf8 collate utf8_unicode_ci,
  `rating3` int(2) default NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=52 ;

--
-- Daten für Tabelle `Behavior_Feedback`
--

INSERT INTO `Behavior_Feedback` (`uid`, `DATE`, `username`, `behavior1`, `rating1`, `behavior2`, `rating2`, `behavior3`, `rating3`) VALUES
(1, '2014-03-13 21:36:34', 'test', 'Ahmt Sie nach oder wiederholt was Sie sagen', 7, 'Missachtet Anweisungen', 5, 'Droht Ihnen oder anderen', 5),
(2, '2014-03-13 21:37:39', 'test', 'Schlägt andere Kinder', 10, 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 1),
(3, '2014-03-13 21:37:46', 'test', 'Schlägt andere Kinder', 10, 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 1),
(4, '2014-03-13 21:53:17', 'test', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 9),
(5, '2014-03-13 22:07:36', 'test', 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Missachtet Anweisungen', 5, 'sdf', 5),
(6, '2014-03-13 22:14:32', 'test', 'Schlägt andere Kinder', 1, 'David', 5, 'Bananen', 5),
(7, '2014-03-13 22:14:32', 'test', 'Mein Sohn', 1, 'schlägt andere', 5, 'ÖÜÄÜ?ß', 5),
(8, '2014-03-13 23:20:34', 'test', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Missachtet Anweisungen', 5),
(9, '2014-03-13 23:33:24', 'test', 'undefined', 3, 'David', 5, 'Bananen', 6),
(10, '2014-03-17 00:49:35', 'Hero', 'Schoko', 8, 'lade', 3, 'undefined', 3),
(11, '2014-03-17 00:50:27', 'Hero', 'Ahmt Sie nach oder wiederholt was Sie sagen', 6, 'Schoko', 10, 'lade', 9),
(12, '2014-03-17 01:05:12', 'Hero', 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 3, 'Ahmt Sie nach oder wiederholt was Sie sagen', 1),
(13, '2014-03-17 01:07:14', 'Test', 'Schlägt andere Kinder', 2, 'Fg', 2, 'Gh', 10),
(14, '2014-03-17 01:43:54', 'Test', 'Schlägt andere Kinder', 1, 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 10),
(15, '2014-03-17 15:43:06', 'test', 'Zerstört mutwillig Dinge', 7, 'Ahmt Sie nach oder wiederholt was Sie sagen', 6, 'Droht Ihnen oder anderen', 1),
(16, '2014-03-17 20:44:25', 'Hero', 'Zerstört mutwillig Dinge', 2, 'Dav', 8, 'id', 8),
(17, '2014-03-17 20:57:12', 'david', 'Zerstört mutwillig Dinge', 8, 'spielen', 1, 'Am Computer', 3),
(18, '2014-03-17 21:52:29', 'Asd', 'Schlägt andere Kinder', 10, 'Rgv', 1, 'Fg', 2),
(19, '2014-03-17 22:01:02', 'Asd', 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(20, '2014-03-17 22:10:14', 'Asdf', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 1),
(21, '2014-03-18 00:22:13', 'Clemens', 'Missachtet Anweisungen', 2, 'Raucht', 7, 'Trinkt Alkohol', 5),
(22, '2014-03-18 12:56:59', 'Diana', 'Schlägt andere Kinder', 3, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Missachtet Anweisungen', 2),
(23, '2014-03-18 15:03:36', 'Test', 'Schlägt andere Kinder', 1, 'Zerstört mutwillig Dinge', 9, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(24, '2014-03-18 15:06:47', 'Test', 'Schlägt andere Kinder', 1, 'Zerstört mutwillig Dinge', 10, 'Ahmt Sie nach oder wiederholt was Sie sagen', 1),
(25, '2014-03-18 15:06:50', 'Test', 'Schlägt andere Kinder', 1, 'Zerstört mutwillig Dinge', 10, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(26, '2014-03-18 15:22:45', 'Diana', 'Schlägt andere Kinder', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(27, '2014-03-18 18:47:37', 'Test', 'Schlägt andere Kinder', 1, 'Zerstört mutwillig Dinge', 10, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 1),
(28, '2014-03-18 19:33:10', 'Test', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(29, '2014-03-18 20:22:48', 'Test', 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Missachtet Anweisungen', 5),
(30, '2014-03-18 20:56:34', 'test', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Missachtet Anweisungen', 5),
(31, '2014-03-18 20:57:28', 'test', 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(32, '2014-03-18 21:39:54', 'Test', 'Zerstört mutwillig Dinge', 7, 'Missachtet Anweisungen', 4, 'Lügt ständig', 4),
(33, '2014-03-19 12:51:39', 'test', 'Zerstört mutwillig Dinge', 3, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'undefined', 5),
(34, '2014-03-19 16:39:22', 'Asd', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(35, '2014-03-19 18:38:59', 'Test', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(36, '2014-03-20 13:38:14', 'Diana', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Missachtet Anweisungen', 8),
(37, '2014-03-22 11:55:20', 'Diana', 'Zerstört mutwillig Dinge', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Droht Ihnen oder anderen', 5),
(38, '2014-03-24 20:27:44', 'test', 'Zerstört mutwillig Dinge', 9, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 7, 'undefined', 7),
(39, '2014-03-26 21:07:51', 'test', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(40, '2014-04-02 21:27:10', 'test', 'Schlägt andere Kinder', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'df', 5),
(41, '2014-04-02 21:51:04', 'test', 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(42, '2014-04-03 15:29:59', 'Clemens', 'Ahmt Sie nach oder wiederholt was Sie sagen', 2, 'Missachtet Anweisungen', 5, 'Fugg', 8),
(43, '2014-04-03 15:39:57', 'test', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5, 'Missachtet Anweisungen', 5),
(44, '2014-04-03 18:33:39', 'Test', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5),
(45, '2014-04-03 20:33:51', '', 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(46, '2014-04-04 20:43:40', 'Diana ', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5),
(47, '2014-04-06 12:31:05', 'David', 'Schlägt andere Kinder', 2, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 8),
(48, '2014-05-25 12:33:14', 'David', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 2, 'Ahmt Sie nach oder wiederholt was Sie sagen', 7, 'Missachtet Anweisungen', 5),
(49, '2014-05-25 23:50:00', 'David', 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 2, 'Ahmt Sie nach oder wiederholt was Sie sagen', 6, 'Spielt nicht gerne', 1),
(50, '2014-05-26 13:08:11', 'David', 'Schlägt andere Kinder', 8, 'Ahmt Sie nach oder wiederholt was Sie sagen', 3, 'Spielt nicht gerne', 1),
(51, '2014-07-17 23:10:30', 'David', 'Schlägt andere Kinder', 6, 'Zerstört mutwillig Dinge', 5, 'Hat aggressionsgeladene Wutausbrüche, flucht oder schimpft', 5);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Benchmark_Feedback`
--

CREATE TABLE IF NOT EXISTS `Benchmark_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `rating` int(2) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=43 ;

--
-- Daten für Tabelle `Benchmark_Feedback`
--

INSERT INTO `Benchmark_Feedback` (`uid`, `DATE`, `username`, `rating`) VALUES
(1, '2014-03-17 18:25:27', 'test', 3),
(2, '2014-03-17 18:25:41', 'test', 8),
(3, '2014-03-17 18:26:27', 'test', 10),
(4, '2014-03-17 21:06:06', 'david', 1),
(5, '2014-03-17 21:52:59', 'Asd', 9),
(6, '2014-03-17 22:10:40', 'Asdf', 1),
(7, '2014-03-17 22:10:40', 'Asdf', 1),
(8, '2014-03-18 00:44:43', 'Clemens', 4),
(9, '2014-03-18 13:01:17', 'Diana', 7),
(10, '2014-03-26 21:24:58', 'test', 5),
(11, '2014-04-02 22:03:25', 'Test', 5),
(12, '2014-04-04 19:38:31', 'David', 6),
(13, '2014-04-04 19:38:39', 'David', 6),
(14, '2014-04-04 19:38:49', 'David', 8),
(15, '2014-04-04 19:39:01', 'David', 8),
(16, '2014-04-04 19:40:18', 'David', 8),
(17, '2014-04-04 19:40:24', 'David', 8),
(18, '2014-04-04 19:41:19', 'David', 8),
(19, '2014-04-04 19:42:57', 'David', 8),
(20, '2014-04-04 19:43:11', 'David', 3),
(21, '2014-04-04 22:17:58', 'David', 5),
(22, '2014-04-04 22:21:53', 'David', 3),
(23, '2014-04-04 22:23:15', 'David', 3),
(24, '2014-04-04 23:31:17', 'Test', 5),
(25, '2014-04-06 12:32:30', 'David', 5),
(26, '2014-04-06 22:13:00', 'Diana ', 7),
(27, '2014-04-28 02:36:40', 'test', 5),
(28, '2014-05-01 02:41:52', 'David', 7),
(29, '2014-05-01 02:42:49', 'test', 5),
(30, '2014-05-01 02:43:36', 'David', 5),
(31, '2014-05-01 03:00:21', 'David', 7),
(32, '2014-05-07 12:49:04', 'diana', 5),
(33, '2014-05-07 15:43:01', 'diana', 5),
(34, '2014-05-18 13:52:59', 'Diana ', 10),
(35, '2014-05-22 16:44:58', 'Diana ', 1),
(36, '2014-05-26 01:20:50', 'David', 4),
(37, '2014-05-26 13:26:14', 'David', 10),
(38, '2014-05-30 22:38:57', 'Diana ', 7),
(39, '2014-06-10 00:47:43', 'David', 5),
(40, '2014-07-21 20:48:01', 'David', 5),
(41, '2014-07-27 02:20:21', 'Clemens_iOS', 9),
(42, '2014-08-27 16:09:55', 'Manny', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Checkbox_Feedback`
--

CREATE TABLE IF NOT EXISTS `Checkbox_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `deviceID` text character set latin1 collate latin1_spanish_ci NOT NULL,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  `screenName` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `customFeedback1` text character set utf8 collate utf8_unicode_ci,
  `customFeedback2` text,
  `customFeedback3` text,
  `cb1` enum('TRUE','FALSE') default NULL,
  `cb2` enum('TRUE','FALSE') default NULL,
  `cb3` enum('TRUE','FALSE') default NULL,
  `cb4` enum('TRUE','FALSE') default NULL,
  `cb5` enum('TRUE','FALSE') default NULL,
  `cb6` enum('TRUE','FALSE') default NULL,
  `cb7` enum('TRUE','FALSE') default NULL,
  `cb8` enum('TRUE','FALSE') default NULL,
  `cb9` enum('TRUE','FALSE') default NULL,
  `cb10` enum('TRUE','FALSE') default NULL,
  `cb11` enum('TRUE','FALSE') default NULL,
  `cb12` enum('TRUE','FALSE') default NULL,
  `cb13` enum('TRUE','FALSE') default NULL,
  `cb14` enum('TRUE','FALSE') default NULL,
  `cb15` enum('TRUE','FALSE') default NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=176 ;

--
-- Daten für Tabelle `Checkbox_Feedback`
--

INSERT INTO `Checkbox_Feedback` (`uid`, `DATE`, `deviceID`, `username`, `isChild`, `screenName`, `customFeedback1`, `customFeedback2`, `customFeedback3`, `cb1`, `cb2`, `cb3`, `cb4`, `cb5`, `cb6`, `cb7`, `cb8`, `cb9`, `cb10`, `cb11`, `cb12`, `cb13`, `cb14`, `cb15`) VALUES
(21, '2013-12-04 18:06:27', '', 'David', 0, 'Unerwünschte Verhaltensweisen', 'über alles', NULL, NULL, 'TRUE', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(22, '2013-12-04 18:06:57', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', 'TRUE', '', '', NULL, NULL),
(23, '2013-12-04 18:10:13', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(24, '2013-12-04 18:14:55', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(25, '2013-12-04 18:15:10', '', 'David', 0, 'Tägliche Aufgaben', 'Spiel spielen', NULL, NULL, 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', NULL, NULL),
(26, '2013-12-04 18:19:56', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(27, '2013-12-04 18:20:24', '', 'David', 0, 'Tägliche Aufgaben', 'Lernen', NULL, NULL, 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', NULL, NULL),
(29, '2013-12-04 18:21:59', '', 'David', 0, 'Tägliche Aufgaben', 'nein', NULL, NULL, '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', '', '', 'TRUE', '', 'TRUE', '', NULL, NULL),
(32, '2013-12-04 18:26:29', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', '', '', '', '', 'TRUE', '', NULL, NULL),
(34, '2013-12-04 18:28:09', '', 'David', 0, 'Tägliche Aufgaben', 'geht', NULL, NULL, 'TRUE', 'TRUE', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', NULL, NULL),
(35, '2013-12-04 18:33:29', '', 'David', 0, 'Tägliche Aufgaben', 'er', NULL, NULL, 'TRUE', '', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', NULL, NULL),
(36, '2013-12-04 18:35:39', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', '', NULL, NULL),
(37, '2013-12-04 18:36:43', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', '', NULL, NULL),
(38, '2013-12-04 18:38:27', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, 'TRUE', '', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', 'TRUE', '', 'TRUE', NULL, NULL),
(39, '2013-12-04 18:39:08', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(40, '2013-12-04 18:39:29', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, 'TRUE', '', '', 'TRUE', '', '', '', '', '', '', '', '', '', NULL, NULL),
(41, '2013-12-04 18:39:47', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(42, '2013-12-04 18:40:55', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, 'TRUE', '', '', 'TRUE', '', 'TRUE', '', '', '', '', '', '', '', NULL, NULL),
(43, '2013-12-04 18:42:30', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', '', '', '', '', '', '', '', NULL, NULL),
(44, '2013-12-04 18:43:13', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', '', '', '', '', '', NULL, NULL),
(45, '2013-12-04 18:48:04', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(46, '2013-12-04 18:48:36', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(47, '2013-12-04 18:49:24', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', '', NULL, NULL),
(48, '2013-12-04 20:19:11', '', 'MegaMan', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(51, '2013-12-04 20:35:29', '', 'test', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(53, '2013-12-04 20:40:55', '', 'test', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(55, '2013-12-04 21:53:38', '', 'Zebra', 0, 'Tägliche Aufgaben', 'Aufhören zu programmieren', NULL, NULL, 'TRUE', '', '', 'TRUE', '', '', '', 'TRUE', '', '', '', '', 'TRUE', NULL, NULL),
(56, '2013-12-04 21:56:43', '', 'Zebra', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(57, '2013-12-04 21:56:51', '', 'Zebra', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', 'TRUE', '', NULL, NULL),
(58, '2013-12-04 22:09:13', '', 'Zebra', 0, 'Unerwünschte Verhaltensweisen', 'isst zuviel Süßes', NULL, NULL, 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(59, '2013-12-04 22:09:23', '', 'Zebra', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', 'TRUE', '', '', 'TRUE', '', '', '', NULL, NULL),
(60, '2013-12-04 22:25:35', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', 'TRUE', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(61, '2013-12-04 22:30:06', '', 'Mäggi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', 'TRUE', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(62, '2013-12-04 22:32:04', '', 'Mäggi', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(63, '2013-12-04 22:46:31', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(64, '2013-12-04 22:47:01', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(65, '2013-12-04 22:47:05', '', 'Evilgirl', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', '', '', '', '', '', '', NULL, NULL),
(66, '2013-12-04 22:51:50', '', 'Zebra', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(67, '2013-12-04 22:52:12', '', 'Zebra', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', '', '', '', '', '', '', NULL, NULL),
(68, '2013-12-04 23:12:32', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(69, '2013-12-04 23:28:08', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', 'TRUE', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(70, '2013-12-04 23:48:46', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', 'TRUE', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(71, '2013-12-04 23:49:18', '', 'Evilgirl', 0, 'Tägliche Aufgaben', '', NULL, NULL, 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', '', NULL, NULL),
(72, '2013-12-04 23:56:05', '', 'Lokalmatador', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(73, '2013-12-04 23:56:55', '', 'Lokalmatador', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(74, '2013-12-04 23:57:33', '', 'Lokalmatador', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(75, '2013-12-04 23:59:54', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(76, '2013-12-05 00:01:09', '', 'Evilgirl', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(77, '2013-12-05 02:11:25', '', 'yxasdas', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(78, '2013-12-05 02:11:41', '', 'yxasdas', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(79, '2013-12-05 02:11:54', '', 'yxasdas', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(80, '2013-12-05 02:12:02', '', 'yxasdas', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(81, '2013-12-05 09:49:38', '', 'AliBaba', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(82, '2013-12-05 09:50:07', '', 'AliBaba', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', 'TRUE', '', 'TRUE', '', '', '', '', '', '', '', NULL, NULL),
(83, '2013-12-05 10:55:49', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', 'TRUE', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(84, '2013-12-05 11:17:03', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', 'TRUE', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(85, '2013-12-05 11:17:31', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(86, '2013-12-05 11:49:11', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(87, '2013-12-05 11:51:46', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(88, '2013-12-05 11:52:25', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(89, '2013-12-05 11:54:44', '', 'Madi', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(90, '2013-12-05 11:56:39', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(91, '2013-12-05 12:04:11', '', 'Conny', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(92, '2013-12-05 12:04:48', '', 'Conny', 0, 'Tägliche Aufgaben', 'lernen', NULL, NULL, 'TRUE', '', '', 'TRUE', '', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(93, '2013-12-05 16:48:19', '', '666', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(94, '2013-12-05 16:48:26', '', '666', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', '', '', '', 'TRUE', '', '', NULL, NULL),
(95, '2013-12-05 18:45:33', '', '666', 0, 'Unerwünschte Verhaltensweisen', 'sSADADADA', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(96, '2013-12-06 20:14:39', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(97, '2013-12-06 20:14:41', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(98, '2013-12-06 20:32:49', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(99, '2013-12-06 20:32:55', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(101, '2013-12-08 22:04:26', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(104, '2013-12-08 23:04:52', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(105, '2013-12-09 14:14:55', '', 'Olaf', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(106, '2013-12-09 14:29:17', '', 'Olaf', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(107, '2013-12-09 14:29:23', '', 'Olaf', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(108, '2013-12-09 20:45:13', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(109, '2013-12-09 20:45:21', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(110, '2013-12-09 20:45:46', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', 'TRUE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(111, '2013-12-09 20:45:51', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', 'TRUE', '', '', NULL, NULL),
(112, '2013-12-09 20:49:07', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(113, '2013-12-09 20:49:12', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', 'TRUE', '', NULL, NULL),
(114, '2013-12-09 20:50:11', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(115, '2013-12-09 20:50:14', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', 'TRUE', '', '', NULL, NULL),
(116, '2013-12-09 21:59:26', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(117, '2013-12-09 22:00:01', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(118, '2013-12-09 22:48:33', '', 'DAVID', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(119, '2013-12-09 22:48:36', '', 'DAVID', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', 'TRUE', '', '', NULL, NULL),
(120, '2013-12-10 10:22:35', '', '', 0, 'Unerwünschte Verhaltensweisen', 'schläft dauernd', NULL, NULL, 'TRUE', 'TRUE', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(121, '2013-12-10 10:25:08', '', '', 0, 'Unerwünschte Verhaltensweisen', 'schläft dauernd', NULL, NULL, 'TRUE', 'TRUE', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(122, '2013-12-10 10:25:46', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(123, '2013-12-10 10:25:53', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(124, '2013-12-10 10:32:20', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(125, '2013-12-10 10:32:29', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', '', '', '', '', NULL, NULL),
(126, '2013-12-10 10:41:21', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', 'TRUE', 'TRUE', 'TRUE', 'TRUE', 'TRUE', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(127, '2013-12-10 10:41:30', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', 'TRUE', '', 'TRUE', '', 'TRUE', 'TRUE', 'TRUE', 'TRUE', '', '', '', '', NULL, NULL),
(128, '2013-12-10 18:44:57', '', 'saswe', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(129, '2013-12-10 18:45:00', '', 'saswe', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', 'TRUE', '', '', '', '', '', '', NULL, NULL),
(130, '2013-12-10 19:26:39', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(131, '2013-12-10 19:43:27', '', 'Detlev', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(132, '2013-12-10 19:43:31', '', 'Detlev', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', 'TRUE', '', '', '', '', '', '', NULL, NULL),
(133, '2013-12-12 21:57:57', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(134, '2013-12-12 21:58:01', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(135, '2013-12-12 23:26:36', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(136, '2013-12-12 23:26:40', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(137, '2013-12-13 11:02:10', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(138, '2013-12-13 11:03:43', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(139, '2013-12-13 11:03:49', '', 'David', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', '', 'TRUE', '', '', '', NULL, NULL),
(140, '2013-12-13 13:33:47', '', 'gusti', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(141, '2013-12-13 13:33:56', '', 'gusti', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', 'TRUE', '', 'TRUE', '', '', '', '', '', '', NULL, NULL),
(142, '2013-12-13 13:42:21', '', 'gusti', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(143, '2013-12-13 13:42:24', '', 'gusti', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', 'TRUE', '', '', '', '', NULL, NULL),
(144, '2013-12-30 21:03:42', '', '666', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(145, '2013-12-30 21:03:46', '', '666', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', '', '', 'TRUE', '', '', '', '', NULL, NULL),
(146, '2013-12-30 21:17:16', '', '666', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(147, '2013-12-30 21:17:21', '', '666', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', 'TRUE', '', '', '', '', '', '', '', NULL, NULL),
(148, '2014-01-06 20:31:18', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, 'TRUE', '', '', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(149, '2014-01-06 20:31:49', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', 'TRUE', 'TRUE', '', '', 'TRUE', '', '', '', '', '', NULL, NULL),
(150, '2014-01-13 12:35:29', '', '', 0, 'Unerwünschte Verhaltensweisen', 'Wirft Objekte', NULL, NULL, '', 'TRUE', '', 'TRUE', '', '', 'TRUE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(151, '2014-01-13 12:41:45', '', '', 0, 'Unerwünschte Verhaltensweisen', 'Wirft Objekte', NULL, NULL, '', 'TRUE', '', 'TRUE', '', '', 'TRUE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(152, '2014-01-13 12:44:16', '', '', 0, 'Unerwünschte Verhaltensweisen', 'Wirft Objekte', NULL, NULL, '', 'TRUE', '', 'TRUE', '', '', 'TRUE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(153, '2014-01-13 12:48:09', '', '', 0, 'Tägliche Aufgaben', 'Katzen klo sauber machen\n\n\n\n\n.', NULL, NULL, '', '', 'TRUE', '', '', '', '', '', '', 'TRUE', '', '', 'TRUE', NULL, NULL),
(154, '2014-01-13 14:58:10', '', '', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', 'TRUE', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(155, '2014-01-13 14:58:19', '', '', 0, 'Tägliche Aufgaben', '', NULL, NULL, '', '', '', '', '', '', 'TRUE', '', '', '', '', '', '', NULL, NULL),
(156, '2014-01-17 17:38:17', '', 'David', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', 'TRUE', '', '', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(157, '2014-01-17 17:59:57', '', 'David', 0, 'Verhaltensmassstab', '0.8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(158, '2014-01-17 18:01:06', '', 'David', 0, 'Verhaltensmassstab', '0.8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(159, '2014-01-17 18:04:43', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'David', 0, 'Verhaltensmassstab', '0.5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(160, '2014-01-17 18:05:51', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'David', 0, 'Verhaltensmassstab', '0.5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(161, '2014-01-17 18:07:50', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'David', 0, 'Verhaltensmassstab', '0.8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(162, '2014-01-17 18:09:55', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'David', 0, 'Verhaltensmassstab', '0.6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(163, '2014-01-17 18:11:18', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'David', 0, 'Verhaltensmassstab', '0.3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(164, '2014-02-19 23:59:11', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(165, '2014-02-20 00:02:14', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(166, '2014-02-20 00:02:48', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(167, '2014-02-20 00:03:04', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(168, '2014-02-20 00:03:04', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(169, '2014-02-20 00:04:59', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(170, '2014-02-20 00:05:05', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(171, '2014-02-20 00:05:34', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(172, '2014-02-20 00:06:38', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(173, '2014-02-20 00:07:19', '3FAA69C5-F440-45DC-B3CA-8171576B90CD', 'David', 1, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(174, '2014-02-23 23:26:29', 'CAAAF1E6-7569-4203-8134-7A809CF6BF3F', 'Tes', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(175, '2014-02-23 23:26:31', 'CAAAF1E6-7569-4203-8134-7A809CF6BF3F', 'Tes', 0, 'Unerwünschte Verhaltensweisen', '', NULL, NULL, '', '', '', '', 'TRUE', '', '', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Child_Parent`
--

CREATE TABLE IF NOT EXISTS `Child_Parent` (
  `child` varchar(32) collate utf8_unicode_ci NOT NULL,
  `parent` varchar(32) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`child`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Daten für Tabelle `Child_Parent`
--

INSERT INTO `Child_Parent` (`child`, `parent`) VALUES
('Davidp', 'Davidp'),
('MainMenu', 'MainMenu'),
('MS', 'MS'),
('manny', 'manny'),
('132', '132'),
('Da is', 'Da is'),
('Isabelle', 'Isabelle'),
('Clemens', 'Clemens'),
('Diana', 'Diana'),
('asdf', 'asdf'),
('Qwe', 'Qwe'),
('Asd', 'Asd'),
('Higo', 'Higo'),
('Dgg54', 'Dgg54'),
('Tett', 'Tett'),
('Dav', 'Dav'),
('Fall', 'Fall'),
('Davi65', 'Davi65'),
('Davidfgh', 'Davidfgh'),
('Hallo', 'Hallo'),
('Hero', 'Hero'),
('Da3', 'Da3'),
('Da2', 'Da2'),
('Da', 'Da'),
('David2', 'David2'),
('Viktor', 'Viktor'),
('Manuel', 'Manuel'),
('666', '666'),
('test', 'test'),
('gusti', 'gusti'),
('David', 'David'),
('Dav2', 'Dav2'),
('Dav3', 'Dav3'),
('Dav4', 'Dav4'),
('msprung', 'msprung'),
('Clemens_iOS', 'Clemens_iOS'),
('Clemens_Android', 'Clemens_Android'),
('windschuetze', 'windschuetze');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `DailyInputs_Check`
--

CREATE TABLE IF NOT EXISTS `DailyInputs_Check` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` date default NULL,
  `username` varchar(32) NOT NULL,
  `dailyDuties` tinyint(1) default '0',
  `benchmark` tinyint(1) default '0',
  `selfControl` tinyint(1) default '0',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=127 ;

--
-- Daten für Tabelle `DailyInputs_Check`
--

INSERT INTO `DailyInputs_Check` (`uid`, `DATE`, `username`, `dailyDuties`, `benchmark`, `selfControl`) VALUES
(106, '2014-04-04', 'David', 1, 1, 1),
(107, '2014-04-04', 'Test', 0, 1, 0),
(108, '2014-04-06', 'David', 0, 1, 0),
(109, '2014-04-06', 'Diana ', 1, 1, 1),
(110, '2014-04-23', 'David', 1, 0, 1),
(111, '2014-04-28', 'test', 1, 1, 0),
(112, '2014-05-01', 'David', 1, 1, 0),
(113, '2014-05-01', 'test', 1, 1, 0),
(114, '2014-05-07', 'diana', 1, 1, 1),
(115, '2014-05-18', 'Diana ', 1, 1, 1),
(116, '2014-05-22', 'Diana ', 0, 1, 0),
(117, '2014-05-25', 'test', 1, 0, 0),
(118, '2014-05-25', 'David', 1, 0, 0),
(119, '2014-05-26', 'null', 1, 0, 0),
(120, '2014-05-26', 'David', 1, 1, 1),
(121, '2014-05-30', 'Diana ', 1, 1, 0),
(122, '2014-06-09', 'David', 1, 0, 0),
(123, '2014-06-10', 'David', 1, 0, 0),
(124, '2014-07-21', 'David', 1, 1, 1),
(125, '2014-07-27', 'Clemens_iOS', 1, 1, 1),
(126, '2014-08-27', 'Manny', 1, 1, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ECPN_table`
--

CREATE TABLE IF NOT EXISTS `ECPN_table` (
  `uid` int(10) NOT NULL auto_increment,
  `unityID` varchar(100) collate utf8_unicode_ci NOT NULL,
  `deviceID` text collate utf8_unicode_ci NOT NULL,
  `os` varchar(10) collate utf8_unicode_ci NOT NULL,
  `username` varchar(32) collate utf8_unicode_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=661 ;

--
-- Daten für Tabelle `ECPN_table`
--

INSERT INTO `ECPN_table` (`uid`, `unityID`, `deviceID`, `os`, `username`, `isChild`) VALUES
(458, 'Isabelle-test', 'Isabelle-test', 'test', 'Isabelle', 1),
(456, 'Manuel-test', 'Manuel-test', 'test', 'Manuel', 1),
(457, 'Clemens-test', 'Clemens-test', 'test', 'Clemens', 1),
(363, '9E665F35-FC7E-415F-A078-99A24E2ABAB5', '02E63DBE963F47F451A5147866708D195DF7EB30A7F2C3C45006EFEE08C73EB8', 'ios', 'manuel', 0),
(597, 'A3F0C28F-4205-4829-8CD9-C9B26D1010BD', '02E63DBE963F47F451A5147866708D195DF7EB30A7F2C3C45006EFEE08C73EB8', 'ios', 'manny', 1),
(452, 'asdf-test', 'asdf-test', 'test', 'asdf', 1),
(455, 'Diana-test', 'Diana-test', 'test', 'Diana', 1),
(650, '', 'APA91bE6oHMP1Btk0tmvYADVkWSNdb6XN2H4O4wgWFy4sK_feGuf_m7j7PK3RRlGKddl5t4Wk1dQBCUWcmZ0sDcC7zb5N4gBJh3DxqU1wXtOhNBKPOcsMJMQdBUTOwnC96CibIKZjc6Lyy_BWYUVDwqNOJsEBw1xlA', 'android', 'test', 0),
(407, '', '$test-child', 'ios', 'test', 1),
(584, 'E6441F31-F4FD-43EE-BE5A-E1265C7866A8', 'EBAAC99BF96A2CB0D85C0C5A6370C64E70B0E47E4F859444038DAB9DFD33E7F9', 'ios', 'David', 1),
(231, '4d2f90a87f59e97db4f19350ae7b10e484436886', '4d2f90a87f59e97db4f19350ae7b10e484436886', 'editor', '666', 0),
(581, 'e5043b8ec1d9924e72856a9e596db71f0c0f29c911a1411d12e9b4f7d62c6e77', 'e5043b8ec1d9924e72856a9e596db71f0c0f29c911a1411d12e9b4f7d62c6e77', 'ios', 'David_Old', 1),
(404, '5058BD3C-FC66-402E-8982-A6BC51C773CB', '02E63DBE963F47F451A5147866708D195DF7EB30A7F2C3C45006EFEE08C73EB8', 'ios', 'manuel', 1),
(496, '', 'e59dd19d65ef7a454c20b2683c54466c65a501376d12c5c7b945b3eae225b277', 'ios', 'Clemens', 0),
(594, '', 'fa01a9b132332bfd503b677ba97a676382bf7132b88284ef8f9b0a966eac55ed', 'ios', 'Diana ', 0),
(646, '', 'browser', 'browser', 'David', 0),
(660, '', '72f43b34f1db3e892ef7dcc022b7649c36f2d836bf4b557455dba8d9ff6a4843', 'ios', 'Manny', 0),
(623, '369EE4E4-1FD4-4BA3-9388-2012EA41D8CA', 'EBAAC99BF96A2CB0D85C0C5A6370C64E70B0E47E4F859444038DAB9DFD33E7F9', 'ios', 'Davidp', 1),
(611, '2C68F4D3-A14C-485D-A7EC-4B7BBD51406E', '82DA3D642B2DA73DFB0A493E73835D7E3175C32876DAD09D01B9612D0E099379', 'ios', 'MS', 1),
(612, '', '39ab2602375b6880b3412011578deb7029e8509b835509dc1f41af1768176ca6', 'ios', 'MS', 0),
(613, '', '', 'ios', 'David_Old', 0),
(621, '22bc6600ed9aa244b14be41c3a14092847026c86', '22bc6600ed9aa244b14be41c3a14092847026c86', 'editor', 'MainMenu', 1),
(620, '', 'edd820763305ce954bd0cc24198676d843c7e5140034e6f9a8adff4ee815cd6d', 'ios', 'MainMenu', 0),
(631, '', 'APA91bEiBRbwwa0wAGMsxpOXlmra7fdw4NuORIo20fuXKIWgA1wXV_ajnCry8wvuck7Gl__MWcC0E10CXMkX_Oj-ZqcWwQi-SC5t1GZ5fJ-AOZS951AWhZC5NQa43P1hMsvFLaiUoUl8NsehnpKyRBfKs8viS4s-Eg', 'android', 'Davidp', 0),
(632, 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'D515338D-61C4-50AD-83B2-A2A60781A88D', 'editor', 'Dav2', 1),
(636, '', 'APA91bEiBRbwwa0wAGMsxpOXlmra7fdw4NuORIo20fuXKIWgA1wXV_ajnCry8wvuck7Gl__MWcC0E10CXMkX_Oj-ZqcWwQi-SC5t1GZ5fJ-AOZS951AWhZC5NQa43P1hMsvFLaiUoUl8NsehnpKyRBfKs8viS4s-Eg', 'android', 'Dav2', 0),
(637, '04795311-62D3-4397-B0C7-7C280A41DA6F', 'EBAAC99BF96A2CB0D85C0C5A6370C64E70B0E47E4F859444038DAB9DFD33E7F9', 'ios', 'Dav3', 1),
(654, '89B11002-A987-452B-9966-315BCF12D54D', 'EE1C872BE2546055F25148B786A285E5DF1BB8E5D775BE817B380EDCFC51242C', 'ios', 'Clemens_iOS', 1),
(640, '', 'APA91bG5RlWI-EHukUsko3L0vny0-uu_T9A88gHK1KT4dU04V2_RMycF80Ag1FHQYZfSdceik1lcMj9ltPUov1Ir8Jwwl9BL1DMq7e_gW_lQNB_k0tob43AizNYexffeEajeazaVVKnDsa_ZUlU524Y8GrALmowOsA', 'android', 'Dav3_', 0),
(641, '501E6F2E-D99C-463B-907C-048F3CFFB5DD', 'EBAAC99BF96A2CB0D85C0C5A6370C64E70B0E47E4F859444038DAB9DFD33E7F9', 'ios', 'Dav4', 1),
(642, '', 'e16d1fa62d90b867063752c50bb41654198131989e7a2662eb5fb99fcf3fc46b', 'ios', 'Dav4', 0),
(643, 'DEA4E703-45D8-415F-ABE2-DB4768CE8174', '82DA3D642B2DA73DFB0A493E73835D7E3175C32876DAD09D01B9612D0E099379', 'ios', 'msprung', 1),
(652, '', '07e42ea5a0c08c55a27a823b5119ffe91aba50dc31679339d4c04ba4115eda57', 'ios', 'msprung', 0),
(651, '', 'e5043b8ec1d9924e72856a9e596db71f0c0f29c911a1411d12e9b4f7d62c6e77', 'ios', 'Dav3', 0),
(655, '', 'e59dd19d65ef7a454c20b2683c54466c65a501376d12c5c7b945b3eae225b277', 'ios', 'Clemens_iOS', 0),
(658, '2ae93a49a9d066faf3c1c9b6117ff8f6', 'APA91bHNkVcEYslycuvGBRaDGc0Kx6gekE1OpnFkrsTOQaiTNaQe32NRHdaIktfgOulghozSCcE4XS3vewUjBOJ4Jwp8Fa5eDJtHte_LjgINmo-DGixIVyZuIPEQfhJGO3vhOGP7JO65D1nyWuJ--0iL6KM_u0gptYcglZ4Hdh4h5ShG5_IDTCU', 'android', 'Clemens_Android', 1),
(657, '', 'APA91bGERNzqXcVmFY4v1FOPAq-jbDxdvWV2d9x80JzEffoUCfTfB8d7__gzL9pZ_dNnrzrHLDKvaMGmVm9KX0XB4umVlTsdvqK0uHz8hZd-1B00DKTlTqm7Bikmp8GX1-FdoK2kCxmFrXP-pjFqWkYZ2ZETGEVBuRDgoNFxTCAhiMcupgTUG98', 'android', 'Clemens_Android', 0),
(659, 'df2cc9911a8d0df641639262a5bebff5', 'APA91bHG_QymfCtipyJMVbgTfPDeTnksLc-qC8nL7AZg5AmLDPPYZf34j77v5LML_B5o_cqy-2gPovUklfe6bs8meZHZQBl7X-1mONSyUwdqnd10U3H51A66oztWS8yH0oTJiCrGq37oIR8hV6OOBSXWVJq048AQwERN4qwiePvceqe5rX92zW4', 'android', 'windschuetze', 1);

-- --------------------------------------------------------

--
-- Stellvertreter-Struktur des Views `Feedback_TaeglicheAufgaben`
--
CREATE TABLE IF NOT EXISTS `Feedback_TaeglicheAufgaben` (
);
-- --------------------------------------------------------

--
-- Stellvertreter-Struktur des Views `Feedback_Verhaltensweisen`
--
CREATE TABLE IF NOT EXISTS `Feedback_Verhaltensweisen` (
);
-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Items`
--

CREATE TABLE IF NOT EXISTS `Items` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE_CREATED` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `life` tinyint(3) default '0',
  `salad` tinyint(3) default '0',
  `snail` tinyint(3) default '0',
  `sight` tinyint(3) default '0',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=61 ;

--
-- Daten für Tabelle `Items`
--

INSERT INTO `Items` (`uid`, `DATE_CREATED`, `username`, `life`, `salad`, `snail`, `sight`) VALUES
(60, '2014-07-27 23:52:33', 'windschuetze', 0, 0, 0, 0),
(59, '2014-07-24 13:00:18', 'Clemens_Android', 0, 0, 0, 0),
(58, '2014-07-24 12:57:24', 'Clemens_Android', 0, 0, 0, 0),
(57, '2014-07-24 11:36:22', 'Clemens_iOS', 0, 0, 0, 0),
(56, '2014-07-21 11:32:06', 'msprung', 0, 0, 0, 0),
(32, '2014-04-06 00:40:00', 'David', 0, 1, 0, 0),
(33, '2014-04-06 00:40:08', 'David', 0, 1, 0, 0),
(34, '2014-04-06 00:48:53', 'David', 0, 1, 0, 0),
(35, '2014-04-06 01:38:40', 'David', 0, 1, 0, 0),
(36, '2014-04-06 02:22:24', 'Da is', 0, 0, 0, 0),
(37, '2014-04-06 02:28:14', 'David', 0, 1, 0, 0),
(38, '2014-04-06 02:30:38', 'David', 0, 1, 0, 0),
(39, '2014-04-06 02:32:25', '132', 0, 0, 0, 0),
(40, '2014-04-06 02:53:55', 'David', 0, 1, 0, 0),
(41, '2014-04-22 17:18:27', 'David', 0, 1, 0, 0),
(42, '2014-04-22 18:23:13', 'David', 0, 1, 0, 0),
(55, '2014-07-21 00:36:26', 'Dav4', 0, 0, 0, 0),
(53, '2014-07-19 14:16:13', 'Dav2', 0, 0, 0, 0),
(54, '2014-07-20 22:15:01', 'Dav3', 0, 0, 1, 0),
(52, '2014-07-17 23:09:55', 'Davidp', 0, 0, 0, 0),
(51, '2014-07-11 01:31:38', 'MainMenu', 0, 2, 1, 1),
(50, '2014-07-07 18:14:12', 'MainMenu', 0, 2, 1, 1),
(49, '2014-07-07 18:12:58', 'MainMenu', 0, 2, 1, 1),
(48, '2014-07-07 18:10:39', 'MainMenu', 0, 2, 1, 1),
(47, '2014-07-07 18:09:52', 'MainMenu', 0, 2, 1, 1),
(46, '2014-07-07 18:06:10', 'MainMenu', 0, 2, 1, 1),
(43, '2014-05-10 14:03:49', 'manny', 0, 0, 0, 1),
(44, '2014-05-23 14:18:57', 'manny', 0, 0, 0, 1),
(45, '2014-05-26 14:00:12', 'MS', 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `PushNotificationsToChild`
--

CREATE TABLE IF NOT EXISTS `PushNotificationsToChild` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(32) NOT NULL,
  `message` text NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=158 ;

--
-- Daten für Tabelle `PushNotificationsToChild`
--

INSERT INTO `PushNotificationsToChild` (`uid`, `DATE`, `username`, `action`, `message`) VALUES
(15, '2014-04-22 18:13:20', 'David', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil du so gut bist!'),
(13, '2014-04-22 18:12:42', 'David', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(14, '2014-04-22 18:12:48', 'David', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(12, '2014-04-22 18:10:28', 'David', '', 'Lob erhalten: Bravo!!! Gut gemacht! '),
(11, '2014-04-22 18:07:52', 'David', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(10, '2014-04-06 01:39:48', 'David', '', 'Lob erhalten: Super, das hast du toll gemacht! '),
(8, '2014-04-04 02:49:27', 'David', '', 'Lob erhalten: Super, das hast du toll gemacht! '),
(9, '2014-04-05 02:54:24', 'David', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(16, '2014-04-22 18:13:28', 'David', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil du so gut bist!'),
(17, '2014-04-22 18:15:04', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(18, '2014-04-22 18:15:19', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(19, '2014-04-22 18:18:08', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(20, '2014-04-22 18:18:14', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(21, '2014-04-22 18:19:22', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(22, '2014-04-22 18:23:41', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(23, '2014-04-22 18:28:08', 'David', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(24, '2014-04-24 02:09:49', 'David', 'compliment', 'Lob erhalten: Wahnsinn! Eine Gold Medaille! Nur so weiter!'),
(25, '2014-04-24 02:10:14', 'David', 'compliment', 'Lob erhalten: Wahnsinn! Eine Gold Medaille! Nur so weiter!'),
(26, '2014-04-24 02:10:49', 'David', 'compliment', 'Lob erhalten: Wahnsinn! Eine Gold Medaille! Nur so weiter!'),
(27, '2014-04-24 02:12:59', 'David', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil du sie verdient hast!'),
(28, '2014-04-24 02:15:53', 'David', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es verdient hast!'),
(29, '2014-04-24 02:17:19', 'David', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du sie wirklich verdient hast! Super!'),
(30, '2014-04-30 20:33:55', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(31, '2014-04-30 20:33:56', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(32, '2014-04-30 20:33:58', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(33, '2014-04-30 20:34:06', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(34, '2014-04-30 20:34:07', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(35, '2014-04-30 20:34:10', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(36, '2014-04-30 20:34:13', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(37, '2014-04-30 20:34:14', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(38, '2014-04-30 20:34:15', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(39, '2014-04-30 20:34:22', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(40, '2014-04-30 20:36:48', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(41, '2014-04-30 20:37:00', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sdfsdf'),
(42, '2014-04-30 20:37:11', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(43, '2014-04-30 20:37:26', 'test', 'reward_reallife', 'Belohnung erhalten: sdfsdf'),
(44, '2014-04-30 20:37:44', 'test', 'reward_reallife', 'Belohnung erhalten: sdfsdf'),
(45, '2014-04-30 20:38:17', 'test', 'reward_reallife', 'Belohnung erhalten: sdfsdf'),
(46, '2014-04-30 20:48:35', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(47, '2014-04-30 20:48:41', 'test', 'reward_reallife', 'Belohnung erhalten: df'),
(48, '2014-04-30 20:48:46', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(49, '2014-04-30 20:48:51', 'test', 'reward_reallife', 'Belohnung erhalten: sdf'),
(50, '2014-04-30 21:01:12', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil dadas'),
(51, '2014-04-30 21:02:19', 'test', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil sdfsdf'),
(52, '2014-04-30 21:02:58', 'test', 'reward_reallife', 'Belohnung erhalten: sdfdfs'),
(53, '2014-04-30 21:04:31', 'test', 'reward_reallife', 'Belohnung erhalten: df'),
(54, '2014-04-30 21:05:22', 'test', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil sdf'),
(55, '2014-04-30 21:06:45', 'test', 'reward_reallife', 'Belohnung erhalten: sdf'),
(56, '2014-04-30 21:08:58', 'test', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Ich will'),
(57, '2014-04-30 21:22:01', 'test', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil gdff'),
(58, '2014-04-30 22:43:19', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ich will, dass wir das schaffen!'),
(59, '2014-04-30 22:44:26', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ich will, dass wir das schaffen!'),
(60, '2014-04-30 22:44:35', 'test', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ich will, dass wir das schaffen!'),
(61, '2014-04-30 22:44:40', 'David', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ich will, dass wir das schaffen!'),
(62, '2014-04-30 22:45:19', 'David', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ich will, dass wir das schaffen!'),
(63, '2014-04-30 22:46:28', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast!'),
(64, '2014-04-30 22:47:05', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast mein Schatz!'),
(65, '2014-04-30 22:47:10', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast mein Schatz!'),
(66, '2014-04-30 22:47:30', 'David', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast mein Schatz!'),
(67, '2014-04-30 22:53:57', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil Du es dir verdient hast mein Schatz!'),
(68, '2014-04-30 23:18:25', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(69, '2014-04-30 23:22:25', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(70, '2014-04-30 23:22:28', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(71, '2014-04-30 23:22:36', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(72, '2014-04-30 23:33:51', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil dffdg'),
(73, '2014-04-30 23:36:29', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdf'),
(74, '2014-04-30 23:39:58', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(75, '2014-04-30 23:40:07', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(76, '2014-04-30 23:40:09', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil sdff'),
(77, '2014-04-30 23:40:48', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast mein Schatz!'),
(78, '2014-04-30 23:43:03', 'test', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil du es dir verdient hast mein Schatz!'),
(79, '2014-05-18 13:54:33', 'Diana', 'compliment', 'Lob erhalten: Super, das hast du toll gemacht! '),
(80, '2014-05-18 13:54:37', 'Diana', 'compliment', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(81, '2014-05-23 14:20:43', 'manny', '', 'Lob erhalten: Super, das hast du toll gemacht! '),
(82, '2014-05-25 23:52:13', 'David', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Woohooo'),
(83, '2014-05-26 01:54:31', 'David', '', 'Lob erhalten: Fgg'),
(84, '2014-05-26 13:15:59', 'David', '', 'Lob erhalten: Bravo!!! Gut gemacht! '),
(85, '2014-05-26 13:20:45', 'David', 'reward_ingame', 'Ein extra Leben erhalten! Ich schenke dir die Belohnung, weil Ich will dass du es schaffst'),
(86, '2014-05-26 13:24:30', 'David', 'reward_reallife', 'Belohnung erhalten: Super gemacht! Hol dir ein Eis ab!'),
(87, '2014-06-10 12:10:56', 'David', '', 'Lob erhalten: Wow! Einfach toll! '),
(88, '2014-06-10 12:12:51', 'David', '', 'Lob erhalten: Bravo!!! Gut gemacht! '),
(89, '2014-07-05 22:33:41', 'manny', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(90, '2014-07-11 03:16:53', 'MainMenu', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Du heute so brav gearbeitet hast ;)'),
(91, '2014-07-17 16:05:06', 'MainMenu', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil Test :)'),
(92, '2014-07-17 16:06:19', 'MainMenu', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Gut gemacht :D'),
(93, '2014-07-17 16:06:57', 'MainMenu', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil ...'),
(94, '2014-07-17 22:16:06', 'David', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Ddddddddddd'),
(95, '2014-07-17 23:11:55', 'Davidp', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil olkj'),
(96, '2014-07-17 23:15:27', 'Davidp', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil sdsd'),
(97, '2014-07-17 23:15:36', 'Davidp', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(98, '2014-07-17 23:27:21', 'Davidp', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil xc'),
(99, '2014-07-19 13:39:25', 'Davidp', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil hhhh'),
(100, '2014-07-19 13:40:02', 'Davidp', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil ich dich Liebe!'),
(101, '2014-07-20 02:24:38', 'Dav2', 'reward_reallife', 'Belohnung erhalten: Ff'),
(102, '2014-07-20 02:24:51', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(103, '2014-07-20 02:24:54', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(104, '2014-07-20 02:24:56', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(105, '2014-07-20 02:24:58', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(106, '2014-07-20 02:25:01', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(107, '2014-07-20 02:25:25', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Dfg'),
(108, '2014-07-20 19:34:54', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(109, '2014-07-20 19:34:58', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(110, '2014-07-20 19:34:59', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(111, '2014-07-20 19:35:01', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(112, '2014-07-20 19:35:03', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(113, '2014-07-20 19:35:05', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(114, '2014-07-20 19:35:07', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(115, '2014-07-20 19:35:15', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(116, '2014-07-20 19:35:16', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(117, '2014-07-20 19:35:49', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(118, '2014-07-20 19:37:45', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(119, '2014-07-20 19:38:19', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(120, '2014-07-20 19:38:21', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(121, '2014-07-20 19:38:23', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(122, '2014-07-20 19:38:49', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(123, '2014-07-20 19:38:53', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(124, '2014-07-20 19:39:12', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil Dgg'),
(125, '2014-07-20 19:40:13', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(126, '2014-07-20 19:40:16', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(127, '2014-07-20 19:40:27', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(128, '2014-07-20 19:40:59', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(129, '2014-07-20 19:41:01', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(130, '2014-07-20 19:41:03', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(131, '2014-07-20 19:42:06', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sdds'),
(132, '2014-07-20 19:42:11', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sdds'),
(133, '2014-07-20 19:42:14', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sdds'),
(134, '2014-07-20 19:44:47', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sd'),
(135, '2014-07-20 19:44:52', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sd'),
(136, '2014-07-20 19:45:25', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sd'),
(137, '2014-07-20 19:49:52', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sd'),
(138, '2014-07-20 19:50:01', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil sd'),
(139, '2014-07-20 19:52:37', 'Dav2', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil blabla'),
(140, '2014-07-20 19:55:34', 'Dav2', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil ßß00'),
(141, '2014-07-20 20:16:34', 'Dav2', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil sdf'),
(142, '2014-07-20 20:19:02', 'Dav2', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil sdf'),
(143, '2014-07-20 20:28:09', 'Dav2', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil sdf'),
(144, '2014-07-20 20:33:05', 'Dav2', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Ggh'),
(145, '2014-07-20 20:43:48', 'Dav2', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil sdf'),
(146, '2014-07-21 00:39:46', 'Dav4', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil Dr'),
(147, '2014-07-21 22:21:34', 'Dav3', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! '),
(148, '2014-07-21 22:25:37', 'Dav3', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Hh'),
(149, '2014-07-24 11:40:05', 'Clemens_iOS', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil Ich dich lieb habe ;)'),
(150, '2014-07-24 13:01:15', 'Clemens_Android', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil ich dich teste'),
(151, '2014-07-25 09:53:04', 'Clemens_iOS', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil Weil du es sichtlich brauchst :P'),
(152, '2014-08-03 21:59:03', 'Clemens_iOS', 'reward_ingame', 'Ein Salatblatt erhalten! Ich schenke dir die Belohnung, weil du knuddlig bist :)'),
(153, '2014-08-03 21:59:42', 'Clemens_iOS', 'reward_ingame', 'Eine Wiederbelebung erhalten! Ich schenke dir die Belohnung, weil Du sicher wiederbelebt werden musst...'),
(154, '2014-08-03 22:00:16', 'Clemens_iOS', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil Du eine brauchst...'),
(155, '2014-08-03 22:01:01', 'Clemens_iOS', 'reward_ingame', 'Eine Schnecke erhalten! Ich schenke dir die Belohnung, weil Du immer viel zu schnell unterwegs bist...'),
(156, '2014-08-27 16:10:55', 'manny', '', 'Lob erhalten: Super, das hast du toll gemacht! '),
(157, '2014-08-27 16:12:04', 'manny', 'reward_ingame', 'Eine Brille erhalten! Ich schenke dir die Belohnung, weil du gerade so lieb mit deiner schwester das buch geteilt hat');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `SelfControl_Feedback`
--

CREATE TABLE IF NOT EXISTS `SelfControl_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `near` int(2) NOT NULL,
  `immaterial` int(2) NOT NULL,
  `material` int(2) NOT NULL,
  `ignoring` int(2) NOT NULL,
  `timeout` int(2) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=19 ;

--
-- Daten für Tabelle `SelfControl_Feedback`
--

INSERT INTO `SelfControl_Feedback` (`uid`, `DATE`, `username`, `near`, `immaterial`, `material`, `ignoring`, `timeout`) VALUES
(1, '2014-04-04 20:15:32', 'David', 3, 0, 0, 0, 1),
(2, '2014-04-04 20:20:02', 'David', 0, 0, 0, 0, 0),
(3, '2014-04-04 20:20:24', 'David', 3, 0, 0, 0, 3),
(4, '2014-04-04 20:21:15', 'David', 1, 2, 3, 2, 1),
(5, '2014-04-04 22:22:49', 'David', 0, 0, 0, 0, 0),
(6, '2014-04-04 22:23:08', 'David', 0, 0, 0, 0, 0),
(7, '2014-04-06 22:13:28', 'Diana ', 3, 3, 3, 1, 1),
(8, '2014-04-23 01:50:09', 'David', 3, 1, 0, 0, 0),
(9, '2014-05-07 12:49:22', 'diana', 0, 0, 0, 0, 0),
(10, '2014-05-18 13:53:10', 'Diana ', 3, 3, 3, 3, 3),
(11, '2014-05-26 01:50:59', 'David', 0, 0, 0, 0, 0),
(12, '2014-05-26 01:51:07', 'David', 0, 0, 0, 0, 0),
(13, '2014-05-26 01:51:19', 'David', 0, 0, 0, 0, 0),
(14, '2014-05-26 13:26:38', 'David', 3, 1, 0, 1, 0),
(15, '2014-06-10 00:47:48', 'David', 0, 0, 0, 0, 0),
(16, '2014-07-21 20:48:07', 'David', 0, 0, 0, 0, 0),
(17, '2014-07-27 02:20:44', 'Clemens_iOS', 0, 3, 0, 0, 0),
(18, '2014-08-27 16:10:26', 'Manny', 3, 3, 2, 3, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Tasks_Data`
--

CREATE TABLE IF NOT EXISTS `Tasks_Data` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `item1` text character set utf8 collate utf8_unicode_ci,
  `item2` text character set utf8 collate utf8_unicode_ci,
  `item3` text character set utf8 collate utf8_unicode_ci,
  `item4` text character set utf8 collate utf8_unicode_ci,
  `item5` text character set utf8 collate utf8_unicode_ci,
  `item6` text character set utf8 collate utf8_unicode_ci,
  `item7` text character set utf8 collate utf8_unicode_ci,
  `item8` text character set utf8 collate utf8_unicode_ci,
  `item9` text character set utf8 collate utf8_unicode_ci,
  `item10` text character set utf8 collate utf8_unicode_ci,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=107 ;

--
-- Daten für Tabelle `Tasks_Data`
--

INSERT INTO `Tasks_Data` (`uid`, `DATE`, `username`, `item1`, `item2`, `item3`, `item4`, `item5`, `item6`, `item7`, `item8`, `item9`, `item10`) VALUES
(11, '2014-03-16 21:35:31', 'aspace', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(12, '2014-03-16 21:36:28', 'test', 'Geschirr abwaschen', 'Zimmer aufräumen', 'Schultrasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, '2014-03-16 21:37:38', 'test', 'David lieb haben', 'PS4 spielen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(14, '2014-03-16 21:39:25', 'test', 'Hallo sagen', 'Zimmer aufräumen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, '2014-03-17 00:49:02', 'Hero', 'Essen', 'Schultrasche packen', 'Hausaufgaben machen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(16, '2014-03-17 01:07:46', 'Test', 'Mag', 'Auto', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL),
(17, '2014-03-17 01:12:58', 'Hero', 'Tisch decken', 'Schultrasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(18, '2014-03-17 01:44:00', 'Test', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(19, '2014-03-17 15:43:11', 'test', 'Tisch decken', 'Schultasche packen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, '2014-03-17 20:44:56', 'Hero', 'Geschirr abwaschen', 'Schultasche packen', 'Müll rausbringen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL),
(21, '2014-03-17 20:57:29', 'david', 'Bett machen', 'Zimmer aufräumen', 'Schultasche packen', 'Schmutzwäsche in den Wäschekorb geben', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL),
(22, '2014-03-17 21:52:42', 'Asd', 'Bett machen', 'Geschirr abwaschen', 'Tisch decken', 'Zimmer aufräumen', 'Schultasche packen', 'Hausaufgaben machen', NULL, NULL, NULL, NULL),
(23, '2014-03-17 22:01:07', 'Asd', 'Geschirr abräumen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(24, '2014-03-17 22:10:23', 'Asdf', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(25, '2014-03-17 22:24:21', 'asdf', 'Davd', 'Bett machen', 'Geschirr abwaschen', 'Zimmer aufräumen', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL),
(26, '2014-03-18 00:25:10', 'Clemens', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(27, '2014-03-18 12:59:21', 'Diana', 'Katzenklo saubern', 'Geschirr abwaschen', 'Tisch decken', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL),
(28, '2014-03-18 15:03:48', 'Test', 'Tisch decken', 'Müll rausbringen', 'Schmutzwäsche in den Wäschekorb geben', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL, NULL, NULL),
(29, '2014-03-18 15:08:12', 'Test', 'Geschirr abwaschen', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(30, '2014-03-18 15:24:48', 'Diana', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(31, '2014-03-18 18:47:56', 'Test', 'Zimmer aufräumen', 'Schultasche packen', 'Hausaufgaben machen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(32, '2014-03-18 19:33:14', 'Test', 'Geschirr abräumen', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(33, '2014-03-18 20:57:38', 'test', 'Geschirr abräumen', 'Zimmer aufräumen', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(34, '2014-03-19 12:51:44', 'test', 'Bett machen', 'Tisch decken', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(35, '2014-03-19 16:39:26', 'Asd', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(36, '2014-03-19 18:39:06', 'Test', 'Geschirr abräumen', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(37, '2014-03-19 19:01:18', 'Test', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(38, '2014-03-19 19:01:18', 'Test', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(39, '2014-03-20 13:38:42', 'Diana', 'Schultasche packen', 'Hausaufgaben machen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(40, '2014-03-22 11:55:29', 'Diana', 'Tisch decken', 'Zimmer aufräumen', 'Schmutzwäsche in den Wäschekorb geben', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL, NULL),
(41, '2014-03-24 20:27:48', 'test', 'Bett machen', 'Geschirr abräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(42, '2014-03-26 21:19:42', 'test', 'Kleider zusammenlegen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(43, '2014-03-26 21:24:39', 'test', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(44, '2014-04-02 12:21:50', 'test', 'Kleider zusammenlegen', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(45, '2014-04-02 21:27:15', 'test', 'Geschirr abräumen', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(46, '2014-04-02 21:51:10', 'test', 'Geschirr abräumen', 'Geschirr abwaschen', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(47, '2014-04-02 22:02:44', 'Test', 'Geschirr abräumen', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(48, '2014-04-03 15:31:46', 'Clemens', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Zimmer aufräumen', 'Schultasche packen', 'Schmutzwäsche in den Wäschekorb geben', 'Zähne putzen', 'Kleider zusammenlegen', 'Rechtzeitig schlafen gehen', NULL),
(49, '2014-04-03 15:47:44', 'Test', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Tisch decken', 'Zimmer aufräumen', 'Müll rausbringen', 'Schmutzwäsche in den Wäschekorb geben', 'Zähne putzen', 'Kleider zusammenlegen', 'Rechtzeitig schlafen gehen'),
(50, '2014-04-03 18:33:44', 'Test', 'Geschirr abräumen', 'Geschirr abwaschen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(51, '2014-04-03 19:14:56', 'test', 'Geschirr abwaschen', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(52, '2014-04-03 19:26:45', 'Test', 'Geschirr abwaschen', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(53, '2014-04-03 19:45:06', 'David', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(54, '2014-04-03 20:33:54', '', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(55, '2014-04-03 20:56:39', 'David', 'Geschirr abwaschen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(56, '2014-04-03 21:36:35', 'David', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(57, '2014-04-03 21:55:34', 'Test', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(58, '2014-04-03 23:47:28', 'test', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(59, '2014-04-04 13:15:10', 'Test', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(60, '2014-04-04 14:49:54', 'David', 'Geschirr abräumen', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(61, '2014-04-04 20:43:46', 'Diana ', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(62, '2014-04-04 23:56:48', 'David', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Tisch decken', 'Zimmer aufräumen', 'Schultasche packen', 'Hausaufgaben machen', 'Müll rausbringen', 'Schmutzwäsche in den Wäschekorb geben', 'Zähne putzen'),
(63, '2014-04-05 00:22:35', 'David', 'Bett machen', 'Geschirr abräumen', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL),
(64, '2014-04-05 01:45:08', 'David', 'Zimmer aufräumen', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(65, '2014-04-05 02:21:34', 'David', 'Bett machen', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(66, '2014-04-06 12:31:10', 'David', 'Geschirr abräumen', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(67, '2014-04-06 13:18:23', 'Test', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(68, '2014-04-06 22:04:05', 'Diana ', 'Tisch decken', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(69, '2014-04-06 22:04:06', 'Diana ', 'Tisch decken', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(70, '2014-04-10 10:51:22', 'test', 'Schultasche packen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(71, '2014-04-22 18:12:07', 'David', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(72, '2014-04-23 01:47:59', 'David', 'Bett machen', 'Geschirr abräumen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(73, '2014-04-27 17:24:51', 'test', 'Mit anderen Kindern spielen', 'Bett machen', 'Zimmer aufräumen', 'Schultasche packen', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL),
(74, '2014-04-27 18:32:50', 'test', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(75, '2014-04-27 18:34:39', 'test', 'Geschirr abräumen', 'Geschirr abwaschen', 'Tisch decken', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL),
(76, '2014-04-27 22:23:01', 'test', 'Kleider zusammenlegen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(77, '2014-04-27 22:36:48', 'test', 'Geschirr abräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(78, '2014-04-27 22:38:18', 'test', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(79, '2014-04-28 01:30:04', 'test', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL),
(80, '2014-04-28 01:40:35', 'test', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(81, '2014-05-01 01:47:35', 'David', 'Mit anderen Kindern spielen', 'Schultasche packen', 'Hausaufgaben machen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL),
(82, '2014-05-07 12:31:47', 'diana', 'Schmutzwäsche in den Wäschekorb geben', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(83, '2014-05-08 14:27:40', 'test', 'Nicht fernsehen', 'Bett machen', 'Schultasche packen', 'Hausaufgaben machen', 'Zähne putzen', NULL, NULL, NULL, NULL, NULL),
(84, '2014-05-09 13:25:27', 'Diana ', 'Zimmer aufräumen', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(85, '2014-05-25 12:18:37', 'David', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(86, '2014-05-25 12:33:25', 'David', 'Geschirr abwaschen', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(87, '2014-05-25 13:12:37', 'david', 'Hausaufgaben machen', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(88, '2014-05-25 14:06:25', 'david', 'Geschirr abräumen', 'Zimmer aufräumen', 'Hausaufgaben machen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL),
(89, '2014-05-25 22:49:43', 'david', 'Schmutzwäsche in den Wäschekorb geben', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(90, '2014-05-25 23:50:12', 'David', 'Mehr spielen', 'Bett machen', 'Tisch decken', 'Schultasche packen', 'Schmutzwäsche in den Wäschekorb geben', 'Kleider zusammenlegen', NULL, NULL, NULL, NULL),
(91, '2014-05-26 01:35:41', 'David', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(92, '2014-05-26 01:48:13', 'David', 'Geschirr abwaschen', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(93, '2014-05-26 13:11:27', 'David', 'Bett machen', 'Geschirr abräumen', 'Geschirr abwaschen', 'Schultasche packen', NULL, NULL, NULL, NULL, NULL, NULL),
(94, '2014-06-07 00:36:01', 'David_Old', 'Geschirr abräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(95, '2014-07-05 22:33:04', 'Manny', 'Tisch decken', 'Zimmer aufräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(96, '2014-07-17 23:11:03', 'David', 'Bett machen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(97, '2014-07-19 12:05:13', 'Davidp', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(98, '2014-07-19 13:39:03', 'DavidP', 'Müll rausbringen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(99, '2014-07-19 14:00:55', 'Davidp', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(100, '2014-07-21 20:49:29', 'test', 'Geschirr abräumen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(101, '2014-07-21 22:21:07', 'Dav3', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(102, '2014-07-21 22:25:23', 'Dav3', 'Tisch decken', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(103, '2014-07-22 16:55:33', 'Manny', 'Bett machen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(104, '2014-07-24 11:38:45', 'Clemens_iOS', 'Zimmer aufräumen', 'Zähne putzen', 'Rechtzeitig schlafen gehen', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(105, '2014-07-24 12:59:40', 'Clemens_Android', 'Geschirr abräumen', 'Zimmer aufräumen', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(106, '2014-08-27 16:09:16', 'Manny', 'Tisch decken', 'Schmutzwäsche in den Wäschekorb geben', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Tasks_Feedback`
--

CREATE TABLE IF NOT EXISTS `Tasks_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `item1` text character set utf8 collate utf8_unicode_ci,
  `rating1` int(2) default NULL,
  `item2` text character set utf8 collate utf8_unicode_ci,
  `rating2` int(2) default NULL,
  `item3` text character set utf8 collate utf8_unicode_ci,
  `rating3` int(2) default NULL,
  `item4` text character set utf8 collate utf8_unicode_ci,
  `rating4` int(2) default NULL,
  `item5` text character set utf8 collate utf8_unicode_ci,
  `rating5` int(2) default NULL,
  `item6` text character set utf8 collate utf8_unicode_ci,
  `rating6` int(2) default NULL,
  `item7` text character set utf8 collate utf8_unicode_ci,
  `rating7` int(2) default NULL,
  `item8` text character set utf8 collate utf8_unicode_ci,
  `rating8` int(2) default NULL,
  `item9` text character set utf8 collate utf8_unicode_ci,
  `rating9` int(2) default NULL,
  `item10` text character set utf8 collate utf8_unicode_ci,
  `rating10` int(2) default NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=149 ;

--
-- Daten für Tabelle `Tasks_Feedback`
--

INSERT INTO `Tasks_Feedback` (`uid`, `DATE`, `username`, `item1`, `rating1`, `item2`, `rating2`, `item3`, `rating3`, `item4`, `rating4`, `item5`, `rating5`, `item6`, `rating6`, `item7`, `rating7`, `item8`, `rating8`, `item9`, `rating9`, `item10`, `rating10`) VALUES
(10, '2014-03-17 03:27:46', 'Hero', 'Tisch decken', 0, 'Schultrasche packen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(11, '2014-03-17 03:28:02', 'Hero', 'Tisch decken', 1, 'Schultrasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(12, '2014-03-17 21:02:44', 'david', 'Bett machen', 0, 'Zimmer aufräumen', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(13, '2014-03-17 21:04:44', 'david', 'Bett machen', 0, 'Zimmer aufräumen', 0, 'Schultasche packen', 1, 'Schmutzwäsche in den Wäschekorb geben', 1, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(14, '2014-03-17 22:10:31', 'Asdf', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, '2014-03-17 22:11:11', 'Asdf', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(16, '2014-03-17 22:11:11', 'Asdf', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(17, '2014-03-18 00:40:00', 'Clemens', 'Zähne putzen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(18, '2014-03-18 00:41:19', 'Clemens', 'Zähne putzen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(19, '2014-03-18 00:41:46', 'Clemens', 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(20, '2014-03-18 13:01:04', 'Diana', 'Katzenklo saubern', 1, 'Geschirr abwaschen', 0, 'Tisch decken', 1, 'Hausaufgaben machen', 1, 'Zähne putzen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(21, '2014-03-20 13:39:15', 'Diana', 'Schultasche packen', 0, 'Hausaufgaben machen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(22, '2014-03-20 13:39:35', 'Diana', 'Schultasche packen', 1, 'Hausaufgaben machen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(23, '2014-04-02 15:00:58', 'test', 'Kleider zusammenlegen', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(24, '2014-04-02 15:00:59', 'test', 'Kleider zusammenlegen', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(25, '2014-04-02 22:03:35', 'Test', 'Geschirr abräumen', 1, 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(26, '2014-04-03 15:50:16', 'Test', 'Bett machen', 0, 'Geschirr abräumen', 0, 'Geschirr abwaschen', 1, 'Tisch decken', 1, 'Zimmer aufräumen', 1, 'Müll rausbringen', 1, 'Schmutzwäsche in den Wäschekorb geben', 1, 'Zähne putzen', 0, 'Kleider zusammenlegen', 0, 'Rechtzeitig schlafen gehen', 0),
(27, '2014-04-04 13:18:02', 'Test', 'Zimmer aufräumen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(28, '2014-04-04 18:24:46', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(29, '2014-04-04 18:54:43', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(30, '2014-04-04 18:54:49', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(31, '2014-04-04 18:56:27', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(32, '2014-04-04 18:56:31', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(33, '2014-04-04 18:57:40', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(34, '2014-04-04 19:00:13', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(35, '2014-04-04 19:00:22', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(36, '2014-04-04 19:00:36', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(37, '2014-04-04 19:05:31', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(38, '2014-04-04 19:07:27', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(39, '2014-04-04 19:07:42', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(40, '2014-04-04 19:09:13', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(41, '2014-04-04 19:10:52', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(42, '2014-04-04 19:15:51', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(43, '2014-04-04 19:16:01', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(44, '2014-04-04 19:16:34', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(45, '2014-04-04 19:17:12', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(46, '2014-04-04 19:18:01', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(47, '2014-04-04 19:18:33', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(48, '2014-04-04 19:18:37', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(49, '2014-04-04 19:19:03', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(50, '2014-04-04 19:20:00', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(51, '2014-04-04 19:20:41', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(52, '2014-04-04 19:20:55', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(53, '2014-04-04 19:21:21', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(54, '2014-04-04 19:22:03', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(55, '2014-04-04 19:22:49', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(56, '2014-04-04 19:22:58', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(57, '2014-04-04 19:26:47', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(58, '2014-04-04 19:27:21', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(59, '2014-04-04 19:27:34', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(60, '2014-04-04 19:27:47', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(61, '2014-04-04 19:28:02', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(62, '2014-04-04 19:29:57', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(63, '2014-04-04 19:30:51', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(64, '2014-04-04 19:35:28', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(65, '2014-04-04 19:35:34', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(66, '2014-04-04 19:36:20', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(67, '2014-04-04 19:36:51', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(68, '2014-04-04 19:37:09', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(69, '2014-04-04 19:43:19', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(70, '2014-04-04 22:14:32', 'David', 'Geschirr abräumen', 1, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(71, '2014-04-04 22:16:30', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(72, '2014-04-04 22:17:44', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(73, '2014-04-04 22:18:42', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(74, '2014-04-04 22:22:44', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(75, '2014-04-06 22:11:35', 'Diana ', 'Tisch decken', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(76, '2014-04-06 22:11:45', 'Diana ', 'Tisch decken', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(77, '2014-04-06 22:11:53', 'Diana ', 'Tisch decken', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(78, '2014-04-23 01:48:50', 'David', 'Bett machen', 1, 'Geschirr abräumen', 0, 'Zimmer aufräumen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(79, '2014-04-23 01:49:44', 'David', 'Bett machen', 0, 'Geschirr abräumen', 1, 'Zimmer aufräumen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(80, '2014-04-28 01:38:39', 'test', 'Bett machen', 0, 'Geschirr abräumen', 0, 'Geschirr abwaschen', 0, 'Tisch decken', 0, 'Zimmer aufräumen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(81, '2014-05-01 01:48:49', 'David', 'Mit anderen Kindern spielen', 1, 'Schultasche packen', 1, 'Hausaufgaben machen', 1, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(82, '2014-05-01 01:50:03', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(83, '2014-05-01 01:51:03', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(84, '2014-05-01 01:51:10', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(85, '2014-05-01 01:51:16', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(86, '2014-05-01 01:51:34', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(87, '2014-05-01 01:55:02', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(88, '2014-05-01 01:56:09', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(89, '2014-05-01 01:58:51', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(90, '2014-05-01 01:59:45', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(91, '2014-05-01 02:00:09', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(92, '2014-05-01 02:00:14', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(93, '2014-05-01 02:01:50', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(94, '2014-05-01 02:02:07', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(95, '2014-05-01 02:02:19', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(96, '2014-05-01 02:02:28', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(97, '2014-05-01 02:02:50', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(98, '2014-05-01 02:04:52', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(99, '2014-05-01 02:05:03', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(100, '2014-05-01 02:05:54', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(101, '2014-05-01 02:08:08', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(102, '2014-05-01 02:08:19', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(103, '2014-05-01 02:08:30', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(104, '2014-05-01 02:10:12', 'test', 'Tisch decken', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(105, '2014-05-01 02:10:17', 'test', 'Tisch decken', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(106, '2014-05-01 02:10:45', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(107, '2014-05-01 02:11:06', 'David', 'Mit anderen Kindern spielen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(108, '2014-05-07 12:48:56', 'diana', 'Schmutzwäsche in den Wäschekorb geben', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(109, '2014-05-07 15:42:20', 'diana', 'Schmutzwäsche in den Wäschekorb geben', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(110, '2014-05-07 15:42:57', 'diana', 'Schmutzwäsche in den Wäschekorb geben', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(111, '2014-05-07 15:43:37', 'diana', 'Schmutzwäsche in den Wäschekorb geben', 0, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(112, '2014-05-18 13:52:39', 'Diana ', 'Zimmer aufräumen', 1, 'Schultasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(113, '2014-05-25 11:48:59', 'test', 'Nicht fernsehen', 1, 'Bett machen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(114, '2014-05-25 11:49:23', 'test', 'Nicht fernsehen', 0, 'Bett machen', 1, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(115, '2014-05-25 13:05:17', 'test', 'Nicht fernsehen', 1, 'Bett machen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(116, '2014-05-25 13:06:15', 'test', 'Nicht fernsehen', 0, 'Bett machen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(117, '2014-05-25 13:07:54', 'test', 'Nicht fernsehen', 0, 'Bett machen', 0, 'Schultasche packen', 0, 'Hausaufgaben machen', 0, 'Zähne putzen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(118, '2014-05-25 23:51:31', 'David', 'Mehr spielen', 0, 'Bett machen', 1, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(119, '2014-05-25 23:51:43', 'David', 'Mehr spielen', 1, 'Bett machen', 1, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(120, '2014-05-26 01:10:01', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(121, '2014-05-26 01:11:30', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(122, '2014-05-26 01:12:16', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(123, '2014-05-26 01:12:23', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(124, '2014-05-26 01:16:01', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(125, '2014-05-26 01:16:05', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(126, '2014-05-26 01:16:28', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(127, '2014-05-26 01:16:31', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(128, '2014-05-26 01:17:07', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(129, '2014-05-26 01:19:22', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(130, '2014-05-26 01:19:27', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(131, '2014-05-26 01:19:45', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(132, '2014-05-26 01:19:47', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(133, '2014-05-26 01:19:59', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(134, '2014-05-26 01:20:23', 'David', 'Mehr spielen', 0, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 1, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(135, '2014-05-26 01:26:37', 'David', 'Mehr spielen', 0, 'Bett machen', 0, 'Tisch decken', 1, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(136, '2014-05-26 01:27:31', 'David', 'Mehr spielen', 0, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 1, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(137, '2014-05-26 01:29:27', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(138, '2014-05-26 01:30:40', 'David', 'Mehr spielen', 1, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 0, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(139, '2014-05-26 01:32:10', 'David', 'Mehr spielen', 0, 'Bett machen', 0, 'Tisch decken', 0, 'Schultasche packen', 0, 'Schmutzwäsche in den Wäschekorb geben', 1, 'Kleider zusammenlegen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(140, '2014-05-26 01:35:48', 'David', 'Tisch decken', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(141, '2014-05-26 01:51:13', 'David', 'Geschirr abwaschen', 1, 'Zimmer aufräumen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(142, '2014-05-26 13:25:51', 'David', 'Bett machen', 1, 'Geschirr abräumen', 1, 'Geschirr abwaschen', 1, 'Schultasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(143, '2014-05-26 13:48:48', 'David', 'Bett machen', 1, 'Geschirr abräumen', 1, 'Geschirr abwaschen', 1, 'Schultasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(144, '2014-06-09 20:40:09', 'David', 'Bett machen', 1, 'Geschirr abräumen', 0, 'Geschirr abwaschen', 1, 'Schultasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(145, '2014-06-10 00:47:40', 'David', 'Bett machen', 0, 'Geschirr abräumen', 1, 'Geschirr abwaschen', 0, 'Schultasche packen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(146, '2014-07-21 20:47:58', 'David', 'Bett machen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(147, '2014-07-27 02:20:04', 'Clemens_iOS', 'Zimmer aufräumen', 0, 'Zähne putzen', 1, 'Rechtzeitig schlafen gehen', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(148, '2014-08-27 16:10:36', 'Manny', 'Tisch decken', 1, 'Schmutzwäsche in den Wäschekorb geben', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Training`
--

CREATE TABLE IF NOT EXISTS `Training` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `t1` tinyint(1) NOT NULL default '0',
  `t2` tinyint(1) NOT NULL default '0',
  `t3` tinyint(1) NOT NULL default '0',
  `t4` tinyint(1) NOT NULL default '0',
  `t5` tinyint(1) NOT NULL default '0',
  `t6` tinyint(1) NOT NULL default '0',
  `timeout` varchar(300) default NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=53 ;

--
-- Daten für Tabelle `Training`
--

INSERT INTO `Training` (`uid`, `DATE`, `username`, `t1`, `t2`, `t3`, `t4`, `t5`, `t6`, `timeout`) VALUES
(52, '2014-07-24 12:59:43', 'Clemens_Android', 0, 0, 0, 0, 0, 0, NULL),
(51, '2014-07-24 11:38:52', 'Clemens_iOS', 1, 0, 0, 0, 0, 0, NULL),
(50, '2014-07-21 17:52:30', 'msprung', 1, 0, 0, 0, 0, 0, NULL),
(49, '2014-07-21 00:39:33', 'Dav4', 0, 0, 0, 0, 0, 0, NULL),
(48, '2014-07-20 22:59:34', 'Dav3', 0, 0, 0, 0, 0, 0, NULL),
(47, '2014-07-20 02:24:27', 'Dav2', 0, 0, 0, 0, 0, 0, NULL),
(46, '2014-07-19 12:05:15', 'Davidp', 0, 0, 0, 0, 0, 0, NULL),
(45, '2014-07-11 03:16:05', 'MainMenu', 0, 0, 0, 0, 0, 0, NULL),
(44, '2014-06-07 00:36:02', 'David_Old', 0, 0, 0, 0, 0, 0, NULL),
(43, '2014-05-11 15:34:27', 'manny', 1, 1, 0, 0, 0, 0, NULL),
(42, '2014-04-03 18:25:02', 'null', 1, 0, 0, 0, 0, 0, NULL),
(41, '2014-03-18 12:59:33', 'Diana', 1, 1, 1, 1, 1, 1, 'Bathroom'),
(40, '2014-03-18 00:26:08', 'Clemens', 1, 1, 1, 1, 1, 1, 'Wohnzimmer'),
(39, '2014-03-17 22:10:25', 'Asdf', 0, 0, 0, 0, 0, 1, 'Efg'),
(38, '2014-03-17 21:52:52', 'Asd', 1, 0, 0, 0, 0, 0, NULL),
(37, '2014-03-17 20:57:36', 'david', 1, 1, 0, 0, 0, 0, 'Kindergarten'),
(31, '0000-00-00 00:00:00', 'test0.1_414cd6a93a58dd60', 0, 0, 0, 1, 0, 0, NULL),
(32, '0000-00-00 00:00:00', '', 1, 1, 0, 1, 1, 1, 'schule'),
(33, '0000-00-00 00:00:00', 'test0.1_db76509ec24138e3', 1, 0, 0, 0, 0, 0, NULL),
(34, '0000-00-00 00:00:00', 'test', 1, 1, 1, 1, 0, 0, 'Bett'),
(36, '2014-03-17 20:47:56', 'Hero', 1, 0, 0, 0, 0, 0, NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Training_Timestamps`
--

CREATE TABLE IF NOT EXISTS `Training_Timestamps` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(1) NOT NULL default 'U',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=142 ;

--
-- Daten für Tabelle `Training_Timestamps`
--

INSERT INTO `Training_Timestamps` (`uid`, `DATE`, `username`, `action`) VALUES
(1, '2014-04-03 12:20:50', 'test', 'C'),
(2, '2014-04-03 12:22:10', 'test', 'U'),
(3, '2014-04-02 00:00:59', 'test', 'C'),
(4, '2014-04-03 12:43:12', 'test', 'U'),
(5, '2014-04-03 12:46:38', 'test', 'U'),
(6, '2014-04-03 12:57:08', 'test', 'U'),
(7, '2014-04-03 12:57:11', 'test', 'U'),
(8, '2014-04-03 12:57:17', 'test', 'U'),
(9, '2014-04-03 12:57:20', 'test', 'U'),
(10, '2014-04-03 12:57:42', 'test', 'U'),
(11, '2014-04-03 12:58:25', 'test', 'U'),
(12, '2014-04-03 12:58:26', 'test', 'U'),
(13, '2014-04-03 12:58:30', 'test', 'U'),
(14, '2014-04-03 12:58:50', 'test', 'U'),
(15, '2014-04-03 12:59:00', 'test', 'U'),
(16, '2014-04-03 13:01:25', 'test', 'U'),
(17, '2014-04-03 13:01:29', 'test', 'U'),
(18, '2014-04-03 13:01:45', 'test', 'U'),
(19, '2014-04-03 13:02:01', 'test', 'U'),
(20, '2014-04-03 13:05:11', 'test', 'U'),
(21, '2014-04-03 13:08:38', 'test', 'U'),
(22, '2014-04-03 13:08:40', 'test', 'U'),
(23, '2014-04-03 13:10:11', 'test', 'U'),
(24, '2014-04-03 13:10:13', 'test', 'U'),
(25, '2014-04-03 13:11:30', 'test', 'U'),
(26, '2014-04-03 13:11:57', 'test', 'U'),
(27, '2014-04-03 13:15:56', 'test', 'U'),
(28, '2014-04-03 13:17:07', 'test', 'U'),
(29, '2014-04-03 13:27:48', 'test', 'U'),
(30, '2014-04-03 13:29:17', 'test', 'U'),
(31, '2014-04-03 13:33:07', 'test', 'U'),
(32, '2014-04-03 13:34:07', 'test', 'U'),
(33, '2014-04-03 13:34:08', 'test', 'U'),
(34, '2014-04-03 13:34:37', 'test', 'U'),
(35, '2014-04-03 13:37:03', 'test', 'U'),
(36, '2014-04-03 13:37:33', 'test', 'U'),
(37, '2014-04-03 13:38:55', 'test', 'U'),
(38, '2014-04-03 13:38:58', 'test', 'U'),
(39, '2014-04-03 13:39:35', 'test', 'U'),
(40, '2014-04-03 13:41:09', 'test', 'U'),
(41, '2014-04-03 13:41:32', 'test', 'U'),
(42, '2014-04-03 13:41:41', 'test', 'U'),
(43, '2014-04-03 13:41:54', 'test', 'U'),
(44, '2014-04-03 13:42:39', 'test', 'U'),
(45, '2014-04-03 13:42:40', 'test', 'U'),
(46, '2014-04-03 13:42:51', 'test', 'U'),
(47, '2014-04-03 13:42:56', 'test', 'U'),
(48, '2014-04-03 13:42:57', 'test', 'U'),
(49, '2014-04-03 13:46:03', 'test', 'U'),
(50, '2014-04-03 13:47:00', 'test', 'U'),
(51, '2014-04-03 13:48:07', 'test', 'U'),
(52, '2014-04-03 13:49:07', 'test', 'U'),
(53, '2014-04-03 13:49:35', 'test', 'U'),
(54, '2014-04-03 13:49:38', 'test', 'U'),
(55, '2014-04-03 13:50:09', 'test', 'U'),
(56, '2014-04-03 13:50:16', 'test', 'U'),
(57, '2014-04-03 13:50:16', 'test', 'U'),
(58, '2014-04-03 13:50:17', 'test', 'U'),
(59, '2014-04-03 13:52:37', 'test', 'U'),
(60, '2014-04-03 13:52:56', 'test', 'U'),
(61, '2014-04-03 13:52:59', 'test', 'U'),
(62, '2014-04-03 13:53:12', 'test', 'U'),
(63, '2014-04-03 13:53:20', 'test', 'U'),
(64, '2014-04-03 13:56:38', 'test', 'U'),
(65, '2014-04-03 13:56:49', 'test', 'U'),
(66, '2014-04-03 13:56:51', 'test', 'U'),
(67, '2014-04-03 14:02:04', 'test', 'U'),
(68, '2014-04-03 14:02:21', 'test', 'U'),
(69, '2014-04-03 14:03:09', 'test', 'U'),
(70, '2014-04-03 14:03:23', 'test', 'U'),
(71, '2014-04-03 14:05:16', 'test', 'U'),
(72, '2014-04-03 14:06:59', 'test', 'U'),
(73, '2014-04-03 14:07:47', 'test', 'U'),
(74, '2014-04-03 14:07:49', 'test', 'U'),
(75, '2014-04-03 14:08:12', 'test', 'U'),
(76, '2014-04-03 14:08:15', 'test', 'U'),
(77, '2014-04-03 14:08:17', 'test', 'U'),
(78, '2014-04-03 14:08:19', 'test', 'U'),
(79, '2014-04-03 14:08:36', 'test', 'U'),
(80, '2014-04-03 14:08:38', 'test', 'U'),
(81, '2014-04-03 14:08:42', 'test', 'U'),
(82, '2014-04-03 14:23:27', 'test', 'C'),
(83, '2014-04-02 14:44:51', 'test', 'C'),
(84, '2014-04-03 15:00:44', 'test', 'U'),
(85, '2014-04-03 15:01:02', 'test', 'U'),
(86, '2014-04-03 15:01:02', 'test', 'U'),
(87, '2014-04-03 15:27:39', 'test', 'C'),
(88, '2014-04-03 15:50:58', 'Clemens', 'U'),
(89, '2014-04-03 15:51:06', 'Clemens', 'U'),
(90, '2014-04-04 21:55:41', 'David', 'C'),
(91, '2014-04-04 21:55:44', 'David', 'U'),
(92, '2014-04-04 21:56:02', 'David', 'U'),
(93, '2014-04-04 21:56:10', 'David', 'U'),
(94, '2014-04-04 21:57:23', 'David', 'U'),
(95, '2014-04-04 22:10:34', 'David', 'U'),
(96, '2014-04-05 00:29:43', 'David', 'U'),
(97, '2014-04-06 12:32:04', 'David', 'C'),
(98, '2014-04-06 12:45:46', 'null', 'C'),
(99, '2014-04-06 22:16:13', 'Diana ', 'U'),
(100, '2014-04-06 22:16:20', 'Diana ', 'U'),
(101, '2014-04-06 22:17:13', 'Diana ', 'U'),
(102, '2014-04-06 22:17:23', 'Diana ', 'U'),
(103, '2014-04-06 22:17:29', 'Diana ', 'U'),
(104, '2014-04-06 22:17:47', 'Diana ', 'U'),
(105, '2014-04-06 22:18:26', 'Diana ', 'U'),
(106, '2014-04-14 12:24:15', 'Test', 'C'),
(107, '2014-04-14 12:27:52', '', 'C'),
(108, '2014-04-14 12:34:49', '', 'C'),
(109, '2014-04-26 12:31:45', 'David', 'U'),
(110, '2014-04-26 12:31:51', 'David', 'U'),
(111, '2014-04-28 02:04:40', 'test', 'U'),
(112, '2014-04-28 02:04:48', 'test', 'U'),
(113, '2014-05-01 03:45:32', 'David', 'U'),
(114, '2014-05-01 03:45:46', 'David', 'U'),
(115, '2014-05-01 14:00:04', 'David', 'U'),
(116, '2014-05-07 12:49:49', 'diana', 'U'),
(117, '2014-05-07 12:50:08', 'diana', 'U'),
(118, '2014-05-07 12:51:52', 'diana', 'U'),
(119, '2014-05-07 12:52:19', 'diana', 'U'),
(120, '2014-05-07 12:52:31', 'diana', 'U'),
(121, '2014-05-07 12:52:53', 'diana', 'U'),
(122, '2014-05-07 15:41:52', 'diana', 'U'),
(123, '2014-05-18 13:52:17', 'Diana ', 'U'),
(124, '2014-05-18 13:52:28', 'Diana ', 'U'),
(125, '2014-05-22 16:41:18', 'Diana ', 'U'),
(126, '2014-05-22 16:43:13', 'Diana ', 'U'),
(127, '2014-05-22 23:27:05', 'Diana ', 'U'),
(128, '2014-05-23 14:18:13', 'manny', 'C'),
(129, '2014-05-26 13:15:05', 'David', 'C'),
(130, '2014-05-26 13:23:54', 'David', 'U'),
(131, '2014-05-26 13:59:35', '', 'U'),
(132, '2014-05-30 22:40:32', 'Diana ', 'U'),
(133, '2014-06-03 13:30:27', 'David', 'C'),
(134, '2014-06-07 00:36:37', 'David_Old', 'C'),
(135, '2014-06-08 12:02:20', 'David', 'C'),
(136, '2014-07-19 11:56:15', '', 'U'),
(137, '2014-07-19 11:56:25', '', 'C'),
(138, '2014-07-21 18:17:06', 'msprung', 'C'),
(139, '2014-07-27 02:19:31', 'Clemens_iOS', 'C'),
(140, '2014-08-27 16:13:54', 'Manny', 'U'),
(141, '2014-08-27 16:14:15', 'Manny', 'C');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `User_Info`
--

CREATE TABLE IF NOT EXISTS `User_Info` (
  `uid` int(10) NOT NULL auto_increment,
  `username` varchar(32) NOT NULL,
  `gender` varchar(8) NOT NULL,
  `mail` varchar(96) NOT NULL,
  `birthdate` date NOT NULL,
  `badges` int(11) default '2',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=139 ;

--
-- Daten für Tabelle `User_Info`
--

INSERT INTO `User_Info` (`uid`, `username`, `gender`, `mail`, `birthdate`, `badges`) VALUES
(1, 'test', 'female', 'sd@23.at', '2014-03-30', 2),
(3, 'test', 'male', 'franz@al.at', '2222-02-22', 2),
(4, 'test', 'male', 'david@as.com', '0004-04-06', 2),
(5, 'Test', 'female', 'dav@gd.at', '2014-03-08', 2),
(6, 'Test', 'male', 'qw@gh.at', '2014-03-08', 2),
(7, 'test', 'female', 'skdfj@xxy.zz', '2014-04-03', 2),
(8, 'test', 'female', 'ddf@gmail.com', '2014-12-31', 2),
(9, 'Test', 'male', 'oasch@brunze.penis', '2014-03-08', 2),
(10, 'test', 'female', 'sdf@ds.atr', '2233-03-23', 2),
(11, 'test', 'female', 'sd@ff.com', '2222-02-02', 2),
(12, 'test', 'female', 'te@er.at', '0000-00-00', 2),
(13, 'test', 'male', 'ff@fm.at', '0200-04-05', 2),
(14, 'test', 'male', 'oi@oi.oi', '1000-12-04', 2),
(15, 'Test', 'female', 'ghh@fg.at', '2014-03-16', 2),
(16, 'test', 'female', 'dsf@df.at', '3333-03-03', 2),
(17, 'Test', 'female', 'dv@fg.gh', '2014-03-16', 2),
(18, 'Test', 'female', 'egg@gh.gh', '2014-01-16', 2),
(19, 'Test', 'female', 'fhhp@gb.bhh', '2014-03-16', 2),
(20, 'Test', 'female', 'fh@gn.fu', '2014-03-17', 2),
(21, 'Test', 'female', 'rhb@fg.g', '2014-03-17', 2),
(22, 'Test', 'female', 'fg@fg.fb', '2014-03-17', 2),
(23, 'Hero', 'female', 'sdf@sdf.at', '3000-03-03', 2),
(24, 'Test', 'female', 'fg@fh.gh', '2014-03-17', 2),
(25, 'Test', 'female', 'fgg@gh.gj', '2014-03-17', 2),
(26, 'Test', 'female', 'tt@gg.gn', '2014-03-17', 2),
(27, 'Test', 'female', 'fgg@fh.fh', '2014-03-17', 2),
(28, 'test', 'female', 'sdf@sdl.at', '2012-10-30', 2),
(29, 'Hero', 'female', 'fg@fg.at', '2014-03-05', 2),
(30, 'david', 'male', 'david@gmail.com', '2005-03-17', 14),
(31, 'Asd', 'male', 'dfg@gh.fh', '2014-03-17', 2),
(32, 'Asd', 'female', 'dg@gg.g', '2014-03-17', 2),
(33, 'Asdf', 'female', 'dfg@vb.gh', '2014-03-17', 2),
(34, 'asdf', 'male', 'dsf@sdf.at', '2014-03-15', 2),
(35, 'Clemens', 'male', 'gs12m015@technikum-wien.at', '2014-03-18', 2),
(36, 'Diana', 'female', 'dcm1706@gmail.com', '2004-03-18', 5),
(37, 'Test', 'male', 'bbb@hhj.nn', '2014-03-18', 2),
(38, 'Test', 'male', 'fg@vb.fh', '2014-03-18', 2),
(39, 'Test', 'female', 'fg@fg.dh', '2014-03-18', 2),
(40, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-18', 5),
(41, 'Test', 'female', 'fgg@vh.fh', '2014-03-18', 2),
(42, 'Test', 'female', 'df@fg.g', '2014-01-18', 2),
(43, 'Test', 'female', 'rf@fv.g', '2014-03-18', 2),
(44, 'test', 'female', 'ddf@fdf.at', '2012-10-30', 2),
(45, 'test', 'female', 'sd@df.at', '2011-10-31', 2),
(46, 'test', 'female', 'sd@df.at', '2011-10-31', 2),
(47, 'Test', 'female', 'fg@fg.dg', '2014-03-18', 2),
(48, 'Test', 'female', 'gg@fg.fg', '2014-03-18', 2),
(49, 'test', 'female', 'df@sdf.at', '0000-00-00', 2),
(50, 'test', 'female', 'df@df.at', '2012-10-30', 2),
(51, 'Asd', 'female', 'fgg@fg.gg', '2014-03-19', 2),
(52, 'Test', 'female', 'fg@gg.gh', '2014-02-19', 2),
(53, 'Test', 'female', 'hh@gg.g', '2014-03-19', 2),
(54, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-20', 5),
(55, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-22', 5),
(56, 'test', 'male', 'da@gf.at', '2014-03-24', 2),
(57, 'test', 'female', 'test@test.com', '2014-03-26', 2),
(58, 'test', 'female', 'test@test.com', '2014-03-26', 2),
(59, 'test', 'female', 'test@test.com', '2014-03-26', 2),
(60, 'test', 'female', 'test@test.com', '2014-03-21', 2),
(61, 'test', 'female', 'test@test.com', '2014-03-21', 2),
(62, 'test', 'female', 'ds@sd.at', '2014-03-26', 2),
(63, 'test', 'female', 'ds@sd.at', '2014-03-26', 2),
(64, 'test', 'female', 'ds@sd.at', '2014-03-26', 2),
(65, 'test', 'female', 'd@test.at', '2014-05-01', 2),
(66, 'Test', 'female', 'dg@gg.gh', '2014-04-01', 2),
(67, 'Test', 'female', 'fg@g.g', '2014-04-01', 2),
(68, 'test', 'female', 'df@dfdd.d', '2014-04-02', 2),
(69, 'test', 'female', 'sd@ts.at', '2013-11-30', 2),
(70, 'test', 'female', 'david@pertiller.net', '2014-04-30', 2),
(71, 'Test', 'female', 'dg@fg.fgz', '2014-04-02', 2),
(72, 'Clemens', 'male', 'lol@lol.lol', '2014-04-03', 2),
(73, 'test', 'female', 'sd@ds.at', '2013-12-31', 2),
(74, 'Test', 'female', 'df@fv.g', '2014-04-03', 2),
(75, 'Test', 'female', 'df@fg.fgp', '2014-03-03', 2),
(76, 'Test', 'female', 'dv@fg.gn', '2014-04-03', 2),
(77, 'test', 'male', 'sd@sd.t', '2013-12-30', 2),
(78, 'Test', 'female', 'df@fh.gh', '2014-04-03', 2),
(79, 'David', 'female', 'fh@fv.fg', '2014-04-03', 37),
(80, '', 'female', 'df@g.gh', '2014-04-03', 2),
(81, 'David', 'female', 'fg@gg.fg', '2014-04-03', 37),
(82, 'David', 'female', 'df@g.v', '2014-04-03', 37),
(83, 'Test', 'female', 'df@f.f', '2014-04-03', 2),
(84, 'test', 'female', 'dg@g.f', '2014-04-03', 2),
(85, 'Test', 'female', 'df@fg.g', '2014-04-04', 2),
(86, 'David', 'male', 'davi@pertil.net', '2014-12-31', 37),
(87, 'Diana ', 'female', 'dcm@gmail.vom', '2014-04-04', 5),
(88, 'David', 'male', 'fg@gg.gh', '2014-04-04', 37),
(89, 'David', 'male', 'sd@sd.at', '2014-04-03', 37),
(90, 'David', 'male', 'david@pertiller.net', '2014-04-18', 37),
(91, 'David', 'male', 'fg@fb.fh', '2014-04-05', 37),
(92, 'David', 'male', 'df@fg.fh', '2014-04-06', 37),
(93, 'Test', 'female', 'df@f.g', '2014-04-06', 2),
(94, 'Diana ', 'female', 'dvm@gmail.com', '2014-04-06', 5),
(95, 'test', 'female', 'test@sd.st', '2013-11-30', 2),
(96, 'David', 'female', 'sdf@df.at', '2013-11-29', 37),
(97, 'David', 'female', 'sdf@df.at', '2014-12-31', 37),
(98, 'David', 'male', 'david@pertiller.net', '2004-04-23', 37),
(99, 'test', 'female', 'dd.dd.at@d.at', '2014-04-08', 2),
(100, 'test', 'female', 'df@sdf.at', '2014-04-26', 2),
(101, 'test', 'male', 'sd@sd.at', '2012-11-30', 2),
(102, 'David', 'male', 'da@ll.b', '2014-05-01', 37),
(103, 'David', 'male', 'da@ll.b', '2014-05-01', 37),
(104, 'diana', 'female', 'gh@zjk.com', '2014-05-07', 5),
(105, 'test', 'female', 'sd@sd.at', '2014-10-30', 2),
(106, 'Diana ', 'female', 'g@l.com', '2014-05-09', 5),
(107, 'manny', 'male', 'manuel.sprung@gmail.com', '1974-04-12', 5),
(108, 'David', 'female', 'dp@mail.com', '2012-11-30', 37),
(109, 'David', 'female', 'df@df.com', '2014-05-25', 37),
(110, 'david', 'female', 'df@dfc.com', '2014-05-25', 37),
(111, 'david', 'female', 'hj@v.com', '2014-05-25', 37),
(112, 'david', 'female', 'fg@cc.gg', '2014-05-26', 37),
(113, 'David', 'male', 'fg@gg.fh', '2014-05-25', 37),
(114, 'David', 'female', 'df@fg.fh', '2014-05-26', 16),
(115, 'David', 'female', 'fg@fg.f', '2014-05-26', 17),
(116, 'David', 'male', 'dp@fg.at', '2005-11-19', 13),
(117, 'MS', 'male', 'manuel.sprung@gmail.com', '2009-01-14', 2),
(118, 'David_Old', 'female', 'df@bb.k', '2014-06-07', 2),
(119, 'Manny', 'male', 'manuel.sprung@gmail.com', '1973-07-09', 5),
(120, 'David', 'female', 'dfdf@d.at', '0000-00-00', 5),
(121, 'Davidp', 'female', 'dfdf@d.at', '0000-00-00', 2),
(122, 'Davidp', 'female', 'dfdf@d.at', '0000-00-00', 2),
(123, 'Davidp', 'male', 'fg@dff.at', '2014-07-19', 2),
(124, 'DavidP', 'male', 'tz@cv.kk', '2014-07-19', 2),
(125, 'Davidp', 'female', 'dff@fgg.fgh', '2014-07-19', 2),
(126, 'Dav2', 'female', 'fg@gg.gh', '2014-07-20', 2),
(127, 'msprung', 'female', 'manuel.sprung@gmail.com', '2009-01-01', 2),
(128, 'test', 'male', 'sdf@sdf.at', '2014-11-28', 2),
(129, 'Dav3', 'female', 'gg@df.zz', '2014-07-21', 2),
(130, 'Dav3', 'female', 'gg@df.zz', '2014-07-21', 2),
(131, 'test', 'female', 'gg@df.zz', '2014-07-21', 2),
(132, 'test', 'female', 'gg@df.zz', '2014-07-21', 2),
(133, 'Dav3', 'female', 'eff@fg.fg', '2014-07-21', 2),
(134, 'msprung', 'male', 'manuel.sprung@gmail.com', '2009-01-01', 2),
(135, 'Manny', 'male', 'manuel.sprung@gmail.com', '2014-04-21', 5),
(136, 'Clemens_iOS', 'male', 'clemens-test@test.test', '2014-07-24', 5),
(137, 'Clemens_Android', 'male', 'clemens_android@test.test', '0000-00-00', 2),
(138, 'Manny', 'female', 'manuel.sprung@gmail.com', '2009-01-14', 5);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dataface__modules`
--

CREATE TABLE IF NOT EXISTS `dataface__modules` (
  `module_name` varchar(255) NOT NULL,
  `module_version` int(11) default NULL,
  PRIMARY KEY  (`module_name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `dataface__modules`
--


-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dataface__mtimes`
--

CREATE TABLE IF NOT EXISTS `dataface__mtimes` (
  `name` varchar(255) NOT NULL,
  `mtime` int(11) default NULL,
  PRIMARY KEY  (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `dataface__mtimes`
--

INSERT INTO `dataface__mtimes` (`name`, `mtime`) VALUES
('ECPN_table', 1386111673),
('dataface__modules', 1386111673),
('dataface__version', 1386111673),
('dataface__mtimes', 1386111679),
('Checkbox_Feedback', 1386111855),
('Child_Parent', 1386111855),
('Feedback_Verhaltensweisen', 1386539985),
('Feedback_TäglicheAufgaben', 1386178045),
('dataface__preferences', 1386178139),
('Feedback_TaeglicheAufgaben', 1386178198),
('Training', 1394578334),
('User_Info', 1394578334),
('Behavior_Feedback', 1395069979),
('Tasks_Data', 1395069979),
('Tasks_Feedback', 1395069979),
('Benchmark_Feedback', 1396895716),
('DailyInputs_Check', 1396895716),
('Items', 1396895716),
('PushNotificationsToChild', 1396895716),
('SelfControl_Feedback', 1396895716),
('Training_Timestamps', 1396895716);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dataface__preferences`
--

CREATE TABLE IF NOT EXISTS `dataface__preferences` (
  `pref_id` int(11) unsigned NOT NULL auto_increment,
  `username` varchar(64) NOT NULL,
  `table` varchar(128) NOT NULL,
  `record_id` varchar(255) NOT NULL,
  `key` varchar(128) NOT NULL,
  `value` varchar(255) NOT NULL,
  PRIMARY KEY  (`pref_id`),
  KEY `username` (`username`),
  KEY `table` (`table`),
  KEY `record_id` (`record_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Daten für Tabelle `dataface__preferences`
--


-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `dataface__version`
--

CREATE TABLE IF NOT EXISTS `dataface__version` (
  `version` int(5) NOT NULL default '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `dataface__version`
--

INSERT INTO `dataface__version` (`version`) VALUES
(4798);

-- --------------------------------------------------------

--
-- Struktur des Views `Feedback_TaeglicheAufgaben`
--
DROP TABLE IF EXISTS `Feedback_TaeglicheAufgaben`;

CREATE ALGORITHM=UNDEFINED DEFINER=`aspace`@`localhost` SQL SECURITY DEFINER VIEW `aspace`.`Feedback_TaeglicheAufgaben` AS select `aspace`.`Checkbox_Feedback`.`uid` AS `uid`,`aspace`.`Checkbox_Feedback`.`DATE` AS `Datum`,`aspace`.`Checkbox_Feedback`.`username` AS `Username`,`aspace`.`Checkbox_Feedback`.`cb1` AS `Bett machen`,`aspace`.`Checkbox_Feedback`.`cb2` AS `Geschirr abräumen`,`aspace`.`Checkbox_Feedback`.`cb3` AS `Geschirr abwaschen`,`aspace`.`Checkbox_Feedback`.`cb4` AS `Tisch decken`,`aspace`.`Checkbox_Feedback`.`cb5` AS `Zimmer aufräumen`,`aspace`.`Checkbox_Feedback`.`cb6` AS `Schultasche packen`,`aspace`.`Checkbox_Feedback`.`cb7` AS `Hausaufgaben machen`,`aspace`.`Checkbox_Feedback`.`cb8` AS `Müll rausbringen`,`aspace`.`Checkbox_Feedback`.`cb9` AS `Schmutzwäsche in den Wäschekorb geben`,`aspace`.`Checkbox_Feedback`.`cb10` AS `Zähne putzen`,`aspace`.`Checkbox_Feedback`.`cb11` AS `Kleider zusammenlegen`,`aspace`.`Checkbox_Feedback`.`cb12` AS `Rechtzeitig schlafen gehen`,`aspace`.`Checkbox_Feedback`.`customFeedback` AS `Eigene Angabe` from `aspace`.`Checkbox_Feedback` where (`aspace`.`Checkbox_Feedback`.`screenName` = _utf8'Tägliche Aufgaben');

-- --------------------------------------------------------

--
-- Struktur des Views `Feedback_Verhaltensweisen`
--
DROP TABLE IF EXISTS `Feedback_Verhaltensweisen`;

CREATE ALGORITHM=UNDEFINED DEFINER=`aspace`@`localhost` SQL SECURITY DEFINER VIEW `aspace`.`Feedback_Verhaltensweisen` AS select `aspace`.`Checkbox_Feedback`.`uid` AS `uid`,`aspace`.`Checkbox_Feedback`.`DATE` AS `Datum`,`aspace`.`Checkbox_Feedback`.`username` AS `Username`,`aspace`.`Checkbox_Feedback`.`cb1` AS `Schlägt andere Kinder`,`aspace`.`Checkbox_Feedback`.`cb2` AS `Zerstört mutwillig Dinge`,`aspace`.`Checkbox_Feedback`.`cb3` AS `Aggressionsgeladene Wutausbrüche`,`aspace`.`Checkbox_Feedback`.`cb4` AS `Amt Sie nach`,`aspace`.`Checkbox_Feedback`.`cb5` AS `Missachtet Anweisungen`,`aspace`.`Checkbox_Feedback`.`cb6` AS `Droht Ihnen/Anderen`,`aspace`.`Checkbox_Feedback`.`customFeedback` AS `Eigene Angabe` from `aspace`.`Checkbox_Feedback` where (`aspace`.`Checkbox_Feedback`.`screenName` = _utf8'Unerwünschte Verhaltensweisen');
