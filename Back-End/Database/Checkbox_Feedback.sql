-- phpMyAdmin SQL Dump
-- version 3.5.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 03, 2013 at 03:07 PM
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
-- Table structure for table `Checkbox_Feedback`
--

CREATE TABLE IF NOT EXISTS `Checkbox_Feedback` (
  `uid` int(10) NOT NULL AUTO_INCREMENT,
  `DATE` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deviceID` text CHARACTER SET latin1 COLLATE latin1_spanish_ci NOT NULL,
  `username` varchar(32) CHARACTER SET latin1 COLLATE latin1_spanish_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  `screenName` varchar(32) CHARACTER SET latin1 COLLATE latin1_spanish_ci NOT NULL,
  `customFeedback` text CHARACTER SET latin1 COLLATE latin1_spanish_ci,
  `cb1` enum('TRUE','FALSE') DEFAULT NULL,
  `cb2` enum('TRUE','FALSE') DEFAULT NULL,
  `cb3` enum('TRUE','FALSE') DEFAULT NULL,
  `cb4` enum('TRUE','FALSE') DEFAULT NULL,
  `cb5` enum('TRUE','FALSE') DEFAULT NULL,
  `cb6` enum('TRUE','FALSE') DEFAULT NULL,
  `cb7` enum('TRUE','FALSE') DEFAULT NULL,
  `cb8` enum('TRUE','FALSE') DEFAULT NULL,
  `cb9` enum('TRUE','FALSE') DEFAULT NULL,
  `cb10` enum('TRUE','FALSE') DEFAULT NULL,
  `cb11` enum('TRUE','FALSE') DEFAULT NULL,
  `cb12` enum('TRUE','FALSE') DEFAULT NULL,
  `cb13` enum('TRUE','FALSE') DEFAULT NULL,
  `cb14` enum('TRUE','FALSE') DEFAULT NULL,
  `cb15` enum('TRUE','FALSE') DEFAULT NULL,
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
