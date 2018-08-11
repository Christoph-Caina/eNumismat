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
    `email` TEXT
);

CREATE TABLE IF NOT EXISTS `swaplist`
(
	`id`INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`contacts_id` INTEGER NOT NULL,
	`date` NUMERIC NOT NULL,
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