CREATE TABLE IF NOT EXISTS `Training_Timestamps` (
  `uid` int(10) NOT NULL auto_increment,
  `DATE` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `username` varchar(32) NOT NULL,
  `action` varchar(1) NOT NULL default 'U',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1;
