CREATE TABLE IF NOT EXISTS `contacts`
(
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`name` TEXT NOT NULL,
	`surename` TEXT NOT NULL,
    `gender` TEXT,
    `birthdate` TEXT,
    `street` TEXT,
    `zip_code` INTEGER,
    `city` TEXT,
    `country` TEXT,
    `phone` TEXT,
    `mobile` TEXT,
    `email` TEXT,
	`notes` TEXT
);

CREATE TABLE IF NOT EXISTS `swaplist`
(
	`id`INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`contacts_id` INTEGER NOT NULL,
	`date` TEXT NOT NULL,
	`swapdetails_id` INTEGER NOT NULL,
	`tracking_code_in` TEXT,
	`tracking_code_out` TEXT,
	`rating` NUMERIC,
	`swapstatus` TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS `swapdetails`
(
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`coin_id_out` INTEGER NOT NULL,
	`coin_id_in` INTEGER NOT NULL
);

CREATE TABLE IF NOT EXISTS `coins`
(
	`id`INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`name` TEXT NOT NULL,
	`country_id`INTEGER NOT NULL,
	`collection_id` INTEGER NOT NULL,
	`currency_id` INTEGER NOT NULL,
	`coin_status_id` INTEGER NOT NULL,
	`coin_details_id` INTEGER NOT NULL, /* ??? */
);

CREATE TABLE IF NOT EXISTS `currencies`
(
	`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`name` TEXT NOT NULL,
	`short` TEXT,
	`symbol`TEXT
);

INSERT INTO `currencies`
	(`name`, `short`, `symbol`)
VALUES
	('EURO', 'EUR', '€'),
	('Deutsche Mark', 'DM', null),
	('Reichsmark', 'RM', 'ℛℳ'),
	('Mark', null,'ℳ'),
	('Dollar', null, '$'),
	('Pfund', null,'£'),
	('Lira', null,'₤'),
	('Yen', null,'¥'),
	('Cruzeiro', null,'₢'),
	('Colón', null,'₡'),
	('Franc', null,'₣'),
	('Rubel', null,'₽'),
	('Drachme', null, '₯')
	('Indische Rupie', null, '₹'),
	('Türkische Lira', null, '₺');


	