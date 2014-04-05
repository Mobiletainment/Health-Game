-- phpMyAdmin SQL Dump
-- version 2.11.8.1deb5+lenny9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 05, 2014 at 02:55 AM
-- Server version: 5.0.51
-- PHP Version: 5.2.6-1+lenny16

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `aspace`
--

-- --------------------------------------------------------

--
-- Table structure for table `Behavior_Feedback`
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=47 ;

--
-- Dumping data for table `Behavior_Feedback`
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
(46, '2014-04-04 20:43:40', 'Diana ', 'Schlägt andere Kinder', 5, 'Zerstört mutwillig Dinge', 5, 'Ahmt Sie nach oder wiederholt was Sie sagen', 5);

-- --------------------------------------------------------

--
-- Table structure for table `Benchmark_Feedback`
--

CREATE TABLE IF NOT EXISTS `Benchmark_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `rating` int(2) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `Benchmark_Feedback`
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
(24, '2014-04-04 23:31:17', 'Test', 5);

-- --------------------------------------------------------

--
-- Table structure for table `Checkbox_Feedback`
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
-- Dumping data for table `Checkbox_Feedback`
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
-- Table structure for table `Child_Parent`
--

CREATE TABLE IF NOT EXISTS `Child_Parent` (
  `child` varchar(32) collate utf8_unicode_ci NOT NULL,
  `parent` varchar(32) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`child`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `Child_Parent`
--

INSERT INTO `Child_Parent` (`child`, `parent`) VALUES
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
('David', 'David');

-- --------------------------------------------------------

--
-- Table structure for table `DailyInputs_Check`
--

CREATE TABLE IF NOT EXISTS `DailyInputs_Check` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` date default NULL,
  `username` varchar(32) NOT NULL,
  `dailyDuties` tinyint(1) default '0',
  `benchmark` tinyint(1) default '0',
  `selfControl` tinyint(1) default '0',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=108 ;

--
-- Dumping data for table `DailyInputs_Check`
--

INSERT INTO `DailyInputs_Check` (`uid`, `DATE`, `username`, `dailyDuties`, `benchmark`, `selfControl`) VALUES
(106, '2014-04-04', 'David', 1, 1, 1),
(107, '2014-04-04', 'Test', 0, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `dataface__modules`
--

CREATE TABLE IF NOT EXISTS `dataface__modules` (
  `module_name` varchar(255) NOT NULL,
  `module_version` int(11) default NULL,
  PRIMARY KEY  (`module_name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dataface__modules`
--


-- --------------------------------------------------------

--
-- Table structure for table `dataface__mtimes`
--

CREATE TABLE IF NOT EXISTS `dataface__mtimes` (
  `name` varchar(255) NOT NULL,
  `mtime` int(11) default NULL,
  PRIMARY KEY  (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dataface__mtimes`
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
('Tasks_Feedback', 1395069979);

-- --------------------------------------------------------

--
-- Table structure for table `dataface__preferences`
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
-- Dumping data for table `dataface__preferences`
--


-- --------------------------------------------------------

--
-- Table structure for table `dataface__version`
--

CREATE TABLE IF NOT EXISTS `dataface__version` (
  `version` int(5) NOT NULL default '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dataface__version`
--

INSERT INTO `dataface__version` (`version`) VALUES
(4798);

-- --------------------------------------------------------

--
-- Table structure for table `ECPN_table`
--

CREATE TABLE IF NOT EXISTS `ECPN_table` (
  `uid` int(10) NOT NULL auto_increment,
  `unityID` varchar(100) collate utf8_unicode_ci NOT NULL,
  `deviceID` text collate utf8_unicode_ci NOT NULL,
  `os` varchar(10) collate utf8_unicode_ci NOT NULL,
  `username` varchar(32) collate utf8_unicode_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=535 ;

--
-- Dumping data for table `ECPN_table`
--

INSERT INTO `ECPN_table` (`uid`, `unityID`, `deviceID`, `os`, `username`, `isChild`) VALUES
(458, 'Isabelle-test', 'Isabelle-test', 'test', 'Isabelle', 1),
(456, 'Manuel-test', 'Manuel-test', 'test', 'Manuel', 1),
(457, 'Clemens-test', 'Clemens-test', 'test', 'Clemens', 1),
(363, '9E665F35-FC7E-415F-A078-99A24E2ABAB5', '02E63DBE963F47F451A5147866708D195DF7EB30A7F2C3C45006EFEE08C73EB8', 'ios', 'manuel', 0),
(452, 'asdf-test', 'asdf-test', 'test', 'asdf', 1),
(455, 'Diana-test', 'Diana-test', 'test', 'Diana', 1),
(407, '', '$test-child', 'ios', 'test', 1),
(533, 'CAAAF1E6-7569-4203-8134-7A809CF6BF3F', 'EBAAC99BF96A2CB0D85C0C5A6370C64E70B0E47E4F859444038DAB9DFD33E7F9', 'ios', 'David', 1),
(534, '', 'e5043b8ec1d9924e72856a9e596db71f0c0f29c911a1411d12e9b4f7d62c6e77', 'ios', 'David', 0),
(231, '4d2f90a87f59e97db4f19350ae7b10e484436886', '4d2f90a87f59e97db4f19350ae7b10e484436886', 'editor', '666', 0),
(404, '5058BD3C-FC66-402E-8982-A6BC51C773CB', '02E63DBE963F47F451A5147866708D195DF7EB30A7F2C3C45006EFEE08C73EB8', 'ios', 'manuel', 1),
(496, '', 'e59dd19d65ef7a454c20b2683c54466c65a501376d12c5c7b945b3eae225b277', 'ios', 'Clemens', 0),
(512, '', 'fa01a9b132332bfd503b677ba97a676382bf7132b88284ef8f9b0a966eac55ed', 'ios', 'Diana ', 0),
(513, '', 'browser', 'browser', 'test', 0);

-- --------------------------------------------------------

--
-- Stand-in structure for view `Feedback_TaeglicheAufgaben`
--
CREATE TABLE IF NOT EXISTS `Feedback_TaeglicheAufgaben` (
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `Feedback_Verhaltensweisen`
--
CREATE TABLE IF NOT EXISTS `Feedback_Verhaltensweisen` (
);
-- --------------------------------------------------------

--
-- Table structure for table `Items`
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `Items`
--


-- --------------------------------------------------------

--
-- Table structure for table `PushNotificationsToChild`
--

CREATE TABLE IF NOT EXISTS `PushNotificationsToChild` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(32) NOT NULL,
  `message` text NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `PushNotificationsToChild`
--

INSERT INTO `PushNotificationsToChild` (`uid`, `DATE`, `username`, `action`, `message`) VALUES
(8, '2014-04-04 02:49:27', 'David', '', 'Lob erhalten: Super, das hast du toll gemacht! '),
(9, '2014-04-05 02:54:24', 'David', '', 'Lob erhalten: Sehr gut! Ich bin stolz auf dich! ');

-- --------------------------------------------------------

--
-- Table structure for table `SelfControl_Feedback`
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `SelfControl_Feedback`
--

INSERT INTO `SelfControl_Feedback` (`uid`, `DATE`, `username`, `near`, `immaterial`, `material`, `ignoring`, `timeout`) VALUES
(1, '2014-04-04 20:15:32', 'David', 3, 0, 0, 0, 1),
(2, '2014-04-04 20:20:02', 'David', 0, 0, 0, 0, 0),
(3, '2014-04-04 20:20:24', 'David', 3, 0, 0, 0, 3),
(4, '2014-04-04 20:21:15', 'David', 1, 2, 3, 2, 1),
(5, '2014-04-04 22:22:49', 'David', 0, 0, 0, 0, 0),
(6, '2014-04-04 22:23:08', 'David', 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `Tasks_Data`
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=66 ;

--
-- Dumping data for table `Tasks_Data`
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
(65, '2014-04-05 02:21:34', 'David', 'Bett machen', 'Geschirr abwaschen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Tasks_Feedback`
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=75 ;

--
-- Dumping data for table `Tasks_Feedback`
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
(74, '2014-04-04 22:22:44', 'David', 'Geschirr abräumen', 0, 'Müll rausbringen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Training`
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
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=43 ;

--
-- Dumping data for table `Training`
--

INSERT INTO `Training` (`uid`, `DATE`, `username`, `t1`, `t2`, `t3`, `t4`, `t5`, `t6`, `timeout`) VALUES
(42, '2014-04-03 18:25:02', 'null', 0, 0, 0, 0, 0, 0, NULL),
(41, '2014-03-18 12:59:33', 'Diana', 1, 1, 1, 1, 1, 1, NULL),
(40, '2014-03-18 00:26:08', 'Clemens', 1, 1, 1, 1, 1, 1, 'Wohnzimmer'),
(39, '2014-03-17 22:10:25', 'Asdf', 0, 0, 0, 0, 0, 1, 'Efg'),
(38, '2014-03-17 21:52:52', 'Asd', 1, 0, 0, 0, 0, 0, NULL),
(37, '2014-03-17 20:57:36', 'david', 1, 1, 1, 1, 1, 0, 'Kindergarten'),
(31, '0000-00-00 00:00:00', 'test0.1_414cd6a93a58dd60', 0, 0, 0, 1, 0, 0, NULL),
(32, '0000-00-00 00:00:00', '', 0, 1, 0, 0, 0, 1, '2iej'),
(33, '0000-00-00 00:00:00', 'test0.1_db76509ec24138e3', 1, 0, 0, 0, 0, 0, NULL),
(34, '0000-00-00 00:00:00', 'test', 1, 1, 1, 0, 0, 0, 'Bett'),
(36, '2014-03-17 20:47:56', 'Hero', 1, 0, 0, 0, 0, 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Training_Timestamps`
--

CREATE TABLE IF NOT EXISTS `Training_Timestamps` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(1) NOT NULL default 'U',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=97 ;

--
-- Dumping data for table `Training_Timestamps`
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
(96, '2014-04-05 00:29:43', 'David', 'U');

-- --------------------------------------------------------

--
-- Table structure for table `User_Info`
--

CREATE TABLE IF NOT EXISTS `User_Info` (
  `uid` int(10) NOT NULL auto_increment,
  `username` varchar(32) NOT NULL,
  `gender` varchar(8) NOT NULL,
  `mail` varchar(96) NOT NULL,
  `birthdate` date NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=92 ;

--
-- Dumping data for table `User_Info`
--

INSERT INTO `User_Info` (`uid`, `username`, `gender`, `mail`, `birthdate`) VALUES
(1, 'test', 'female', 'sd@23.at', '2014-03-30'),
(3, 'test', 'male', 'franz@al.at', '2222-02-22'),
(4, 'test', 'male', 'david@as.com', '0004-04-06'),
(5, 'Test', 'female', 'dav@gd.at', '2014-03-08'),
(6, 'Test', 'male', 'qw@gh.at', '2014-03-08'),
(7, 'test', 'female', 'skdfj@xxy.zz', '2014-04-03'),
(8, 'test', 'female', 'ddf@gmail.com', '2014-12-31'),
(9, 'Test', 'male', 'oasch@brunze.penis', '2014-03-08'),
(10, 'test', 'female', 'sdf@ds.atr', '2233-03-23'),
(11, 'test', 'female', 'sd@ff.com', '2222-02-02'),
(12, 'test', 'female', 'te@er.at', '0000-00-00'),
(13, 'test', 'male', 'ff@fm.at', '0200-04-05'),
(14, 'test', 'male', 'oi@oi.oi', '1000-12-04'),
(15, 'Test', 'female', 'ghh@fg.at', '2014-03-16'),
(16, 'test', 'female', 'dsf@df.at', '3333-03-03'),
(17, 'Test', 'female', 'dv@fg.gh', '2014-03-16'),
(18, 'Test', 'female', 'egg@gh.gh', '2014-01-16'),
(19, 'Test', 'female', 'fhhp@gb.bhh', '2014-03-16'),
(20, 'Test', 'female', 'fh@gn.fu', '2014-03-17'),
(21, 'Test', 'female', 'rhb@fg.g', '2014-03-17'),
(22, 'Test', 'female', 'fg@fg.fb', '2014-03-17'),
(23, 'Hero', 'female', 'sdf@sdf.at', '3000-03-03'),
(24, 'Test', 'female', 'fg@fh.gh', '2014-03-17'),
(25, 'Test', 'female', 'fgg@gh.gj', '2014-03-17'),
(26, 'Test', 'female', 'tt@gg.gn', '2014-03-17'),
(27, 'Test', 'female', 'fgg@fh.fh', '2014-03-17'),
(28, 'test', 'female', 'sdf@sdl.at', '2012-10-30'),
(29, 'Hero', 'female', 'fg@fg.at', '2014-03-05'),
(30, 'david', 'male', 'david@gmail.com', '2005-03-17'),
(31, 'Asd', 'male', 'dfg@gh.fh', '2014-03-17'),
(32, 'Asd', 'female', 'dg@gg.g', '2014-03-17'),
(33, 'Asdf', 'female', 'dfg@vb.gh', '2014-03-17'),
(34, 'asdf', 'male', 'dsf@sdf.at', '2014-03-15'),
(35, 'Clemens', 'male', 'gs12m015@technikum-wien.at', '2014-03-18'),
(36, 'Diana', 'female', 'dcm1706@gmail.com', '2004-03-18'),
(37, 'Test', 'male', 'bbb@hhj.nn', '2014-03-18'),
(38, 'Test', 'male', 'fg@vb.fh', '2014-03-18'),
(39, 'Test', 'female', 'fg@fg.dh', '2014-03-18'),
(40, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-18'),
(41, 'Test', 'female', 'fgg@vh.fh', '2014-03-18'),
(42, 'Test', 'female', 'df@fg.g', '2014-01-18'),
(43, 'Test', 'female', 'rf@fv.g', '2014-03-18'),
(44, 'test', 'female', 'ddf@fdf.at', '2012-10-30'),
(45, 'test', 'female', 'sd@df.at', '2011-10-31'),
(46, 'test', 'female', 'sd@df.at', '2011-10-31'),
(47, 'Test', 'female', 'fg@fg.dg', '2014-03-18'),
(48, 'Test', 'female', 'gg@fg.fg', '2014-03-18'),
(49, 'test', 'female', 'df@sdf.at', '0000-00-00'),
(50, 'test', 'female', 'df@df.at', '2012-10-30'),
(51, 'Asd', 'female', 'fgg@fg.gg', '2014-03-19'),
(52, 'Test', 'female', 'fg@gg.gh', '2014-02-19'),
(53, 'Test', 'female', 'hh@gg.g', '2014-03-19'),
(54, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-20'),
(55, 'Diana', 'female', 'dcm1607@gmail.com', '2014-03-22'),
(56, 'test', 'male', 'da@gf.at', '2014-03-24'),
(57, 'test', 'female', 'test@test.com', '2014-03-26'),
(58, 'test', 'female', 'test@test.com', '2014-03-26'),
(59, 'test', 'female', 'test@test.com', '2014-03-26'),
(60, 'test', 'female', 'test@test.com', '2014-03-21'),
(61, 'test', 'female', 'test@test.com', '2014-03-21'),
(62, 'test', 'female', 'ds@sd.at', '2014-03-26'),
(63, 'test', 'female', 'ds@sd.at', '2014-03-26'),
(64, 'test', 'female', 'ds@sd.at', '2014-03-26'),
(65, 'test', 'female', 'd@test.at', '2014-05-01'),
(66, 'Test', 'female', 'dg@gg.gh', '2014-04-01'),
(67, 'Test', 'female', 'fg@g.g', '2014-04-01'),
(68, 'test', 'female', 'df@dfdd.d', '2014-04-02'),
(69, 'test', 'female', 'sd@ts.at', '2013-11-30'),
(70, 'test', 'female', 'david@pertiller.net', '2014-04-30'),
(71, 'Test', 'female', 'dg@fg.fgz', '2014-04-02'),
(72, 'Clemens', 'male', 'lol@lol.lol', '2014-04-03'),
(73, 'test', 'female', 'sd@ds.at', '2013-12-31'),
(74, 'Test', 'female', 'df@fv.g', '2014-04-03'),
(75, 'Test', 'female', 'df@fg.fgp', '2014-03-03'),
(76, 'Test', 'female', 'dv@fg.gn', '2014-04-03'),
(77, 'test', 'male', 'sd@sd.t', '2013-12-30'),
(78, 'Test', 'female', 'df@fh.gh', '2014-04-03'),
(79, 'David', 'female', 'fh@fv.fg', '2014-04-03'),
(80, '', 'female', 'df@g.gh', '2014-04-03'),
(81, 'David', 'female', 'fg@gg.fg', '2014-04-03'),
(82, 'David', 'female', 'df@g.v', '2014-04-03'),
(83, 'Test', 'female', 'df@f.f', '2014-04-03'),
(84, 'test', 'female', 'dg@g.f', '2014-04-03'),
(85, 'Test', 'female', 'df@fg.g', '2014-04-04'),
(86, 'David', 'male', 'davi@pertil.net', '2014-12-31'),
(87, 'Diana ', 'female', 'dcm@gmail.vom', '2014-04-04'),
(88, 'David', 'male', 'fg@gg.gh', '2014-04-04'),
(89, 'David', 'male', 'sd@sd.at', '2014-04-03'),
(90, 'David', 'male', 'david@pertiller.net', '2014-04-18'),
(91, 'David', 'male', 'fg@fb.fh', '2014-04-05');

-- --------------------------------------------------------

--
-- Structure for view `Feedback_TaeglicheAufgaben`
--
DROP TABLE IF EXISTS `Feedback_TaeglicheAufgaben`;

CREATE ALGORITHM=UNDEFINED DEFINER=`aspace`@`localhost` SQL SECURITY DEFINER VIEW `aspace`.`Feedback_TaeglicheAufgaben` AS select `aspace`.`Checkbox_Feedback`.`uid` AS `uid`,`aspace`.`Checkbox_Feedback`.`DATE` AS `Datum`,`aspace`.`Checkbox_Feedback`.`username` AS `Username`,`aspace`.`Checkbox_Feedback`.`cb1` AS `Bett machen`,`aspace`.`Checkbox_Feedback`.`cb2` AS `Geschirr abräumen`,`aspace`.`Checkbox_Feedback`.`cb3` AS `Geschirr abwaschen`,`aspace`.`Checkbox_Feedback`.`cb4` AS `Tisch decken`,`aspace`.`Checkbox_Feedback`.`cb5` AS `Zimmer aufräumen`,`aspace`.`Checkbox_Feedback`.`cb6` AS `Schultasche packen`,`aspace`.`Checkbox_Feedback`.`cb7` AS `Hausaufgaben machen`,`aspace`.`Checkbox_Feedback`.`cb8` AS `Müll rausbringen`,`aspace`.`Checkbox_Feedback`.`cb9` AS `Schmutzwäsche in den Wäschekorb geben`,`aspace`.`Checkbox_Feedback`.`cb10` AS `Zähne putzen`,`aspace`.`Checkbox_Feedback`.`cb11` AS `Kleider zusammenlegen`,`aspace`.`Checkbox_Feedback`.`cb12` AS `Rechtzeitig schlafen gehen`,`aspace`.`Checkbox_Feedback`.`customFeedback` AS `Eigene Angabe` from `aspace`.`Checkbox_Feedback` where (`aspace`.`Checkbox_Feedback`.`screenName` = _utf8'Tägliche Aufgaben');

-- --------------------------------------------------------

--
-- Structure for view `Feedback_Verhaltensweisen`
--
DROP TABLE IF EXISTS `Feedback_Verhaltensweisen`;

CREATE ALGORITHM=UNDEFINED DEFINER=`aspace`@`localhost` SQL SECURITY DEFINER VIEW `aspace`.`Feedback_Verhaltensweisen` AS select `aspace`.`Checkbox_Feedback`.`uid` AS `uid`,`aspace`.`Checkbox_Feedback`.`DATE` AS `Datum`,`aspace`.`Checkbox_Feedback`.`username` AS `Username`,`aspace`.`Checkbox_Feedback`.`cb1` AS `Schlägt andere Kinder`,`aspace`.`Checkbox_Feedback`.`cb2` AS `Zerstört mutwillig Dinge`,`aspace`.`Checkbox_Feedback`.`cb3` AS `Aggressionsgeladene Wutausbrüche`,`aspace`.`Checkbox_Feedback`.`cb4` AS `Amt Sie nach`,`aspace`.`Checkbox_Feedback`.`cb5` AS `Missachtet Anweisungen`,`aspace`.`Checkbox_Feedback`.`cb6` AS `Droht Ihnen/Anderen`,`aspace`.`Checkbox_Feedback`.`customFeedback` AS `Eigene Angabe` from `aspace`.`Checkbox_Feedback` where (`aspace`.`Checkbox_Feedback`.`screenName` = _utf8'Unerwünschte Verhaltensweisen');
