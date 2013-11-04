CREATE TABLE IF NOT EXISTS `ECPN_table` (
    `uid` int(10) NOT NULL AUTO_INCREMENT,
    `unityID` varchar(100) COLLATE latin1_spanish_ci NOT
  NULL,
    `deviceID` text COLLATE latin1_spanish_ci NOT NULL,
    `os` varchar(10) COLLATE latin1_spanish_ci NOT NULL,
    PRIMARY KEY (`uid`)
  ) ENGINE=MyISAM  DEFAULT CHARSET=latin1
  COLLATE=latin1_spanish_ci AUTO_INCREMENT=1;