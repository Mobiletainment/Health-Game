CREATE TABLE IF NOT EXISTS `SelfControl_Feedback` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) character set utf8 collate utf8_unicode_ci NOT NULL,
  `near` int(2) NOT NULL,
  `imaterial` int(2) NOT NULL,
  `material` int(2) NOT NULL,
  `ignoring` int(2) NOT NULL,
  `timeout` int(2) NOT NULL,
  PRIMARY KEY  (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8;
