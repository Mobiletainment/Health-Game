--
-- Table structure for table `ECPN_table`
CREATE TABLE IF NOT EXISTS `ECPN_table` (
  `uid` int(10) NOT NULL auto_increment,
  `unityID` varchar(100) character set utf8 collate utf8_unicode_ci NOT NULL,
  `deviceID` text character set utf8 collate utf8_unicode_ci NOT NULL,
  `os` varchar(10) character set utf8 collate utf8_unicode_ci NOT NULL,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `isChild` tinyint(1) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=106 ;
