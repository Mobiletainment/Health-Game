-- phpMyAdmin SQL Dump
-- version 3.5.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 03, 2013 at 03:17 PM
-- Server version: 5.5.32-31.0-log
-- PHP Version: 5.3.17

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `pertille_aquaSpace`
--

-- --------------------------------------------------------

--
-- Structure for view `Feedback_Verhaltensweisen`
--

CREATE ALGORITHM=UNDEFINED DEFINER=`pertille`@`localhost` SQL SECURITY DEFINER VIEW `Feedback_Verhaltensweisen` AS select `Checkbox_Feedback`.`uid` AS `uid`,`Checkbox_Feedback`.`DATE` AS `Datum`,`Checkbox_Feedback`.`username` AS `Username`,`Checkbox_Feedback`.`cb1` AS `Schlägt andere Kinder`,`Checkbox_Feedback`.`cb2` AS `Zerstört mutwillig Dinge`,`Checkbox_Feedback`.`cb3` AS `Aggressionsgeladene Wutausbrüche`,`Checkbox_Feedback`.`cb4` AS `Amt Sie nach`,`Checkbox_Feedback`.`cb5` AS `Missachtet Anweisungen`,`Checkbox_Feedback`.`cb6` AS `Droht Ihnen/Anderen`,`Checkbox_Feedback`.`customFeedback` AS `Eigene Angabe` from `Checkbox_Feedback`;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
