BEGIN;

-- new table layout



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

/*
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
*/

/*
INSERT INTO `CONTACTS`
	(`name1`, `name2`, `familyname`, `gender`, `birthdate`, `addrline1`, `addrline2`, `postalcode`, `city`, `state`, `country`, `phone`, `mobile`, `email`, `notes`)
VALUES
	('Max', null, 'Mustermann', 'male', null, 'Musterstraße 23', null, '12345', 'Musterdorf', null, 'Deutschland', null, null, null, null),
	('Marta', null, 'Mustermann', 'female', null, 'Musterstraße 23', null, '12345', 'Musterdorf', null, 'Deutschland', null, null, null, null),
	('Christoph', 'Daniel', 'Caina', 'male', '1986-03-25', 'Quellenstraße 21', null,  '71272', 'Renningen', 'Baden-Württemberg', 'Deutschland', null, null, 'christoph@caina.de', 'Developer of eNumismat');
*/

INSERT INTO `COINSTATUS`
    (`name`)
VALUES
    ('missing'),
	('ordered'),
	('swap_in'),
	('swap_out'),
	('available');


COMMIT;