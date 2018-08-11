CREATE TABLE `contacts`
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