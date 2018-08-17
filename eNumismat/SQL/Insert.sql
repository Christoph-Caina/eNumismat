BEGIN;

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

INSERT INTO `CONTACTS`
	(`name`, `surename`, `gender`, `birthdate`, `street`, `zipcode`, `city`, `country`, `phone`, `mobile`, `email`, `notes`)
VALUES
	('Mustermann', 'Max', 'male', null, 'Musterstraße 23', '12345', 'Musterdorf', 'Deutschland', null, null, null, null),
	('Mustermann', 'Marta', 'female', null, 'Musterstraße 23', '12345', 'Musterdorf', 'Deutschland', null, null, null, null),
	('Caina', 'Christoph', 'male', '25.03.1986', 'Quellenstraße 21', '71272', 'Renningen', 'Deutschland', null, null, 'christoph@caina.de', 'Developer of eNumismat');

COMMIT;