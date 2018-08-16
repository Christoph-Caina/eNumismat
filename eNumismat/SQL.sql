CREATE TABLE IF NOT EXISTS `CURRENCIES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL,
  `short` TEXT(5),
  `symbol` TEXT(3)
);

INSERT INTO `CURRENCIES`
	(`name`, `short`, `symbol`)
  VALUES
	('EURO', 'EUR', '€'),
	('Deutsche Mark', 'DM', null),
	('Reichsmark', 'RM', 'ℛℳ'),
	('Mark', null,'ℳ'),
	('Dollar', null, '$'),
	('Dollar (US)', 'USD', 'US$'),
	('Dollar (CAN)', 'CAD', 'CA$'),
	('Dollar (AUS)', 'AUD', 'AU$'),
	('Pfund', null,'£'),
	('Lira', null,'₤'),
	('Yen', null,'¥'),
	('Cruzeiro', null,'₢'),
	('Colón', null,'₡'),
	('Franc', null,'₣'),
	('Rubel', null,'₽'),
	('Drachme', null, '₯'),
	('Rupie (Indien)', null, '₹'),
	('Lira (Türkei)', null, '₺'),
	('Rupie (Bengalisch)', null, '৳'),
	('Bath (Thailand)', null, '฿'),
	('Cruzeiro (Brasilien)', null, '₢'),
	('Peso (Spanien)', null, '₱');

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

INSERT INTO `COINTYPES`
	(`name`, `diameter`, `thickness`, `weight`, `CURRENCIES_id`)
  VALUES
	('5 DM Gedenkmünze', null, null, null, 2),
	('5 DM Umlaufmünze "Silberadler"', null, null, null, 2),
	('5 DM Umlaufmünze', null, null, '15,5 g', 2),
	('10 DM Gedenkmünze "925er Silber"', '32,5 mm', null, null, 2),
	('10 DM Gedenkmünze "625er Silber"', '32,5 mm', null, null, 2),
	('10 € Gedenkmünze "925er Silber"', '32,5 mm', null, null, 1), 
	('10 € Gedenkmünze "625er Silber"', '32,5 mm', null, null, 1),
	('10 € Gedenkmünze', '32,5 mm', null, null, 1),
	('20 € Gedenkmünze "925er Silber"', '32,5 mm', null, null, 1),
	('25 € Gedenkmünze "925er Silber"', '32,5 mm', null, null, 1),
	('2 € Gedenkmünze', null, null, null, 1),
	('5 € Sammlermünze', null, null, null, 1);


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

CREATE TABLE IF NOT EXISTS `COUNTRIES`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `name` TEXT(45) NOT NULL
);

INSERT INTO `COUNTRIES`
	(`name`)
VALUES
	('Deutschland'),
	('Österreich'),
	('Schweiz'),
	('Frankreich'),
	('Norwegen'),
	('Italien'),
	('Türkei'),
	('Russland'),
	('Kanada'),
	('Australien');

CREATE TABLE IF NOT EXISTS `CONTACTS`
(
  `id` INTEGER NOT NULL PRIMARY KEY  AUTOINCREMENT,
  `name` TEXT(45) NOT NULL,
  `surename` TEXT(45) NOT NULL,
  `gender` TEXT(45),
  `birthdate` TEXT,
  `street` TEXT(45),
  `zipcode` TEXT(5),
  `city` TEXT(45),
  `country` TEXT(45),
  `phone` TEXT(45),
  `mobile` TEXT(45),
  `email` TEXT(45),
  `notes` TEXT
);

INSERT INTO `CONTACTS`
	(`name`, `surename`, `gender`, `birthdate`, `street`, `zipcode`, `city`, `country`, `phone`, `mobile`, `email`, `notes`)
VALUES
	('Mustermann', 'Max', 'male', null, 'Musterstraße 23', '12345', 'Musterdorf', 'Deutschland', null, null, null, null),
	('Mustermann', 'Marta', 'female', null, 'Musterstraße 23', '12345', 'Musterdorf', 'Deutschland', null, null, null, null),
	('Caina', 'Christoph', 'male', '25.03.1986', 'Quellenstraße 21', '71272', 'Renningen', 'Deutschland', null, null, 'christoph@caina.de', 'Developer of eNumismat');

CREATE TABLE IF NOT EXISTS `SWAPDETAILS`
(
  `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
  `COINS_id` INTEGER NOT NULL,
  `COINS_id1` INTEGER NOT NULL,
  `date` TEXT,
  `rating` TEXT(5),
  `trackingcode_in` TEXT(45),
  `trackingcode_out` TEXT(45),
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