--
-- Table structure for table `ECPN_table`
--

CREATE TABLE IF NOT EXISTS `ECPN_table` (
  `uid` int(10) NOT NULL AUTO_INCREMENT,
  `unityID` varchar(100) COLLATE latin1_spanish_ci NOT NULL,
  `deviceID` text COLLATE latin1_spanish_ci NOT NULL,
  `os` varchar(10) COLLATE latin1_spanish_ci NOT NULL,
  `username` varchar(32) COLLATE latin1_spanish_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  PRIMARY KEY (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci AUTO_INCREMENT=68 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
