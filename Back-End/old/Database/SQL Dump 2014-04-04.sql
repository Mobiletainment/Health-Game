-- phpMyAdmin SQL Dump
-- version 2.11.8.1deb5+lenny9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Apr 04, 2014 at 08:23 PM
-- Server version: 5.0.51
-- PHP Version: 5.2.6-1+lenny16

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
-- Database: `aspace`
--

-- --------------------------------------------------------

--
-- Table structure for table `Behavior_Feedback`
--

DROP TABLE IF EXISTS `Behavior_Feedback`;
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=46 ;

-- --------------------------------------------------------

--
-- Table structure for table `Benchmark_Feedback`
--

DROP TABLE IF EXISTS `Benchmark_Feedback`;
CREATE TABLE IF NOT EXISTS `Benchmark_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `rating` int(2) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=21 ;

-- --------------------------------------------------------

--
-- Table structure for table `Checkbox_Feedback`
--

DROP TABLE IF EXISTS `Checkbox_Feedback`;
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

-- --------------------------------------------------------

--
-- Table structure for table `Child_Parent`
--

DROP TABLE IF EXISTS `Child_Parent`;
CREATE TABLE IF NOT EXISTS `Child_Parent` (
  `child` varchar(32) collate utf8_unicode_ci NOT NULL,
  `parent` varchar(32) collate utf8_unicode_ci default NULL,
  PRIMARY KEY  (`child`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `DailyInputs_Check`
--

DROP TABLE IF EXISTS `DailyInputs_Check`;
CREATE TABLE IF NOT EXISTS `DailyInputs_Check` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` date default NULL,
  `username` varchar(32) NOT NULL,
  `dailyDuties` tinyint(1) default '0',
  `benchmark` tinyint(1) default '0',
  `selfControl` tinyint(1) default '0',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=107 ;

-- --------------------------------------------------------

--
-- Table structure for table `dataface__modules`
--

DROP TABLE IF EXISTS `dataface__modules`;
CREATE TABLE IF NOT EXISTS `dataface__modules` (
  `module_name` varchar(255) NOT NULL,
  `module_version` int(11) default NULL,
  PRIMARY KEY  (`module_name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dataface__mtimes`
--

DROP TABLE IF EXISTS `dataface__mtimes`;
CREATE TABLE IF NOT EXISTS `dataface__mtimes` (
  `name` varchar(255) NOT NULL,
  `mtime` int(11) default NULL,
  PRIMARY KEY  (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dataface__preferences`
--

DROP TABLE IF EXISTS `dataface__preferences`;
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

-- --------------------------------------------------------

--
-- Table structure for table `dataface__version`
--

DROP TABLE IF EXISTS `dataface__version`;
CREATE TABLE IF NOT EXISTS `dataface__version` (
  `version` int(5) NOT NULL default '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ECPN_table`
--

DROP TABLE IF EXISTS `ECPN_table`;
CREATE TABLE IF NOT EXISTS `ECPN_table` (
  `uid` int(10) NOT NULL auto_increment,
  `unityID` varchar(100) collate utf8_unicode_ci NOT NULL,
  `deviceID` text collate utf8_unicode_ci NOT NULL,
  `os` varchar(10) collate utf8_unicode_ci NOT NULL,
  `username` varchar(32) collate utf8_unicode_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=512 ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `Feedback_TaeglicheAufgaben`
--
DROP VIEW IF EXISTS `Feedback_TaeglicheAufgaben`;
CREATE TABLE IF NOT EXISTS `Feedback_TaeglicheAufgaben` (
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `Feedback_Verhaltensweisen`
--
DROP VIEW IF EXISTS `Feedback_Verhaltensweisen`;
CREATE TABLE IF NOT EXISTS `Feedback_Verhaltensweisen` (
);
-- --------------------------------------------------------

--
-- Table structure for table `SelfControl_Feedback`
--

DROP TABLE IF EXISTS `SelfControl_Feedback`;
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

-- --------------------------------------------------------

--
-- Table structure for table `Tasks_Data`
--

DROP TABLE IF EXISTS `Tasks_Data`;
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=61 ;

-- --------------------------------------------------------

--
-- Table structure for table `Tasks_Feedback`
--

DROP TABLE IF EXISTS `Tasks_Feedback`;
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
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=70 ;

-- --------------------------------------------------------

--
-- Table structure for table `Training`
--

DROP TABLE IF EXISTS `Training`;
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

-- --------------------------------------------------------

--
-- Table structure for table `Training_Timestamps`
--

DROP TABLE IF EXISTS `Training_Timestamps`;
CREATE TABLE IF NOT EXISTS `Training_Timestamps` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(1) NOT NULL default 'U',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=90 ;

-- --------------------------------------------------------

--
-- Table structure for table `User_Info`
--

DROP TABLE IF EXISTS `User_Info`;
CREATE TABLE IF NOT EXISTS `User_Info` (
  `uid` int(10) NOT NULL auto_increment,
  `username` varchar(32) NOT NULL,
  `gender` varchar(8) NOT NULL,
  `mail` varchar(96) NOT NULL,
  `birthdate` date NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=87 ;

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
