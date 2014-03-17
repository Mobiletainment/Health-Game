INSERT INTO `aspace`.`ECPN_table` (
`uid` ,
`unityID` ,
`deviceID` ,
`os` ,
`username` ,
`isChild`
)
VALUES (
NULL , 'Isabelle-test', 'Isabelle-test', 'test', 'Isabelle', '1'
);

INSERT INTO `aspace`.`Child_Parent` (
`child` ,
`parent`
)
VALUES (
'Isabelle', 'Isabelle'
);