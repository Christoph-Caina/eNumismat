﻿/*
CREATE TABLE IF NOT EXISTS `CONTACTS`
(
  `id` INTEGER NOT NULL PRIMARY KEY  AUTOINCREMENT,
  `name1` TEXT(45) NOT NULL,
  `name2` TEXT(45),
  `familyname` TEXT(45) NOT NULL,
  `gender` TEXT(45),
  `birthdate` TEXT,
  `addrline1` TEXT(45),
  `addrline2` TEXT(45),
  `postalcode` TEXT(5),
  `city` TEXT(45),
  `state` TEXT(45),
  `country` TEXT(45),
  `phone` TEXT(45),
  `mobile` TEXT(45),
  `email` TEXT(45),
  `notes` TEXT
);
*/

-- needs to be completed
CREATE TABLE [contacts](
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [name] TEXT(99) NOT NULL, 
  [gender] TEXT(15));


CREATE TABLE [gender](
  [gender] TEXT(15) PRIMARY KEY NOT NULL UNIQUE, 
  [symbol] TEXT(1));

CREATE TABLE [labels](
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [labelname] TEXT(99) NOT NULL, 
  [labeltype] INTEGER NOT NULL, 
  [contact_id] INTEGER NOT NULL, 
  [labelcolor] TEXT(15));

CREATE TABLE [labeltypes](
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [type] TEXT(99) NOT NULL);

CREATE TABLE "postalcode"([postalcode] TEXT(10) PRIMARY KEY NOT NULL UNIQUE);

CREATE TABLE "state"(
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [state] TEXT(99) NOT NULL);

CREATE TABLE "city"(
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [city] TEXT(99) NOT NULL);

CREATE TABLE [country](
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
  [name] TEXT(50) NOT NULL, 
  [ISO_2] TEXT(2) NOT NULL, 
  [ISO_3] TEXT(3), 
  [de] TEXT(50), 
  [es] TEXT(50), 
  [fr] TEXT(50),
  [ro] TEXT(50),
  --[hu] TEXT(50), 
  --[el] TEXT(50),
  --[it] TEXT(50), 
  --[jp] TEXT(50), 
  --[lt] TEXT(50), 
  --[nl] TEXT(50), 
  --[no] TEXT(50), 
  --[pl] TEXT(50), 
  --[pt] TEXT(50), 
  [ar] TEXT(50), 
  --[cn] TEXT(50), 
  --[cs] TEXT(50),
  --[ru] TEXT(50), 
  --[sk] TEXT(50), 
  --[th] TEXT(50), 
  --[uk] TEXT(50));

  
CREATE TABLE IF NOT EXISTS `CURRENCIES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL,
  `short` TEXT(5),
  `symbol` TEXT(3)
);

CREATE TABLE IF NOT EXISTS `COINTYPES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL,
  `diameter` TEXT(45),
  `thickness` TEXT(45),
  `weight` TEXT(45),
  `CURRENCIES_id` INTEGER NOT NULL,
  CONSTRAINT `fk_COINTYPES_CURRENCIES1`
    FOREIGN KEY (`CURRENCIES_id`)
    REFERENCES `CURRENCIES` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `COINSTATUS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS `EPOCHS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS `SERIES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS `COINS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL,
  `year` TEXT(4),
  `mintage_amount` INTEGER,
  `mintage_sign` TEXT,
  `mintage_sign2` TEXT,
  `COINTYPES_id` INTEGER NOT NULL,
  `COINSTATUS_id` INTEGER,
  `EPOCHS_id` INTEGER,
  `SERIES_id` INTEGER,
  CONSTRAINT `fk_COINS_COINTYPES`
    FOREIGN KEY (`COINTYPES_id`)
    REFERENCES `COINTYPES` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COINS_COINSTATUS1`
    FOREIGN KEY (`COINSTATUS_id`)
    REFERENCES `COINSTATUS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COINS_EPOCHS1`
    FOREIGN KEY (`EPOCHS_id`)
    REFERENCES `EPOCHS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COINS_SERIES1`
    FOREIGN KEY (`SERIES_id`)
    REFERENCES `SERIES` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

/*
CREATE TABLE IF NOT EXISTS `COUNTRIES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);
*/

CREATE TABLE IF NOT EXISTS `SWAPDETAILS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `COINS_id` INTEGER NOT NULL,
  `COINS_id1` INTEGER NOT NULL,
  CONSTRAINT `fk_SWAPDETAILS_COINS1`
    FOREIGN KEY (`COINS_id`)
    REFERENCES `COINS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_SWAPDETAILS_COINS2`
    FOREIGN KEY (`COINS_id1`)
    REFERENCES `COINS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `SWAPLIST`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `CONTACTS_id` INTEGER NOT NULL,
  `SWAPDETAILS_id` INTEGER NOT NULL,
  `swapstatus` TEXT(6),
  `rating` TEXT(5),
  `date` TEXT,
  `trackingcode_in` TEXT(45),
  `trackingcode_out` TEXT(45),
  CONSTRAINT `fk_SWAPLIST_CONTACTS1`
    FOREIGN KEY (`CONTACTS_id`)
    REFERENCES `CONTACTS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_SWAPLIST_SWAPDETAILS1`
    FOREIGN KEY (`SWAPDETAILS_id`)
    REFERENCES `SWAPDETAILS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `EPOCHS_has_COUNTRIES`
(
  `EPOCHS_id` INTEGER NOT NULL,
  `COUNTRIES_id` INTEGER NOT NULL,
  PRIMARY KEY (`EPOCHS_id`, `COUNTRIES_id`),
  CONSTRAINT `fk_EPOCHS_has_COUNTRIES_EPOCHS1`
    FOREIGN KEY (`EPOCHS_id`)
    REFERENCES `EPOCHS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_EPOCHS_has_COUNTRIES_COUNTRIES1`
    FOREIGN KEY (`COUNTRIES_id`)
    REFERENCES `COUNTRIES` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `COLLECTIONS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);

CREATE TABLE IF NOT EXISTS `COINS_has_COLLECTIONS`
(
  `COINS_id` INTEGER NOT NULL,
  `COLLECTIONS_id` INTEGER NOT NULL,
  PRIMARY KEY (`COINS_id`, `COLLECTIONS_id`),
  CONSTRAINT `fk_COINS_has_COLLECTIONS_COINS1`
    FOREIGN KEY (`COINS_id`)
    REFERENCES `COINS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COINS_has_COLLECTIONS_COLLECTIONS1`
    FOREIGN KEY (`COLLECTIONS_id`)
    REFERENCES `COLLECTIONS` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);